﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using McFly.Core;
using Microsoft.Extensions.Logging;

namespace McFly.Server.Data
{
    public class ProjectsAccess : DataAccess, IProjectsAccess
    {
        private ILogger<ProjectsAccess> Logger { get; set; }

        public ProjectsAccess(ILogger<ProjectsAccess> logger)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<string> GetDatabases()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT NAME FROM sys.databases WHERE NAME NOT IN('master', 'tempdb', 'model', 'msdb')";
                List<string> databases = new List<string>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    databases.Add(reader.GetFieldValue<string>(0));
                }
                return databases;
            }
        }
                                                                                   
        public void CreateProject(string projectName, Position start, Position end)
        {
            using (var conn = new SqlConnection(ConnectionString))
            using (var createDbCommand = conn.CreateCommand())
            {
                conn.Open();
                createDbCommand.CommandText = $"CREATE DATABASE {projectName}";
                try
                {
                    createDbCommand.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Logger.LogError($"Unable to create Database {projectName}: {e.Message}");
                    throw;
                }   
            }

            var sqlBuilder = new SqlConnectionStringBuilder(ConnectionString) {InitialCatalog = projectName};
            using (var conn = new SqlConnection(sqlBuilder.ToString()))
            {                                       
                try
                { 
                    conn.Open();
                    var initScript = File.ReadAllText("Scripts/create_database.sql");
                    IEnumerable<string> commandStrings = Regex.Split(initScript, @"^\s*GO\s*$",
                        RegexOptions.Multiline | RegexOptions.IgnoreCase);
                    foreach (var commandString in commandStrings)
                    {
                        if (string.IsNullOrWhiteSpace(commandString))
                            continue;
                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = commandString;
                            command.ExecuteNonQuery();
                        }
                    }

                    using (var infoCommand = conn.CreateCommand())
                    {
                        infoCommand.CommandText =
                            $"INSERT INTO trace_info (start_pos_hi, start_pos_lo, end_pos_hi, end_pos_lo) VALUES ({start.High}, {start.Low}, {start.High}, {start.Low})";
                        infoCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    using (var deleteCommand = conn.CreateCommand())
                    {
                        deleteCommand.CommandText = $"DROP DATABASE {projectName}";
                        deleteCommand.ExecuteNonQuery();
                        throw;
                    }
                }
            }
        }
    }
}
