﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace McFly.Server.Data.SqlServer
{
    [Table("frame")]
    internal class FrameEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("frame_id")]
        public long FrameId { get; set; }

        [Column("pos_hi")]
        public int PosHi { get; set; }

        [Column("pos_lo")]
        public int PosLo { get; set; }

        [Column("thread_id")]
        public int ThreadId { get; set; }

        [Column("rax")]
        public long Rax { get; set; }

        [Column("rbx")]
        public long Rbx { get; set; }

        [Column("rcx")]
        public long Rcx { get; set; }

        [Column("rdx")]
        public long Rdx { get; set; }

        [Column("opcode")]
        public byte[] OpCode { get; set; }

        [Column("opcode_mnemonic")]
        public string OpCodeMnemonic { get; set; }

        [Column("disassembly_note")]
        public string DisassemblyNote { get; set; }

        public virtual List<NoteEntity> Notes { get; set; }

        public virtual List<StackFrameEntity> StackFrames { get; set; }
    }

    [Table("note")]
    internal class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("note_id")]
        public long NoteId { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("text")]
        public string Text { get; set; }
    }

    [Table("stack_frame")]
    internal class StackFrameEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StackFrameId { get; set; }
                                            
        [Column("stack_pointer")]
        public long StackPointer { get; set; }

        [Column("return_address")]
        public long ReturnAddress { get; set; }

        [Column("module_name")]
        public string ModuleName { get; set; }

        [Column("function")]
        public string Function { get; set; }

        [Column("offset")]
        public long Offset { get; set; }

        [Column("frame_id")]
        public long FrameId { get; set; }

        [ForeignKey("FrameId")]
        public FrameEntity Frame { get; set; }
    }

    internal class McFlyContext : DbContext
    {
        public McFlyContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<FrameEntity> FrameEntities { get; set; }
        public DbSet<NoteEntity> NoteEntities { get; set; }
        public DbSet<StackFrameEntity> StackFrameEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FrameEntity>()
                .HasIndex(entity => new
                {
                    entity.PosHi,
                    entity.PosLo,
                    entity.ThreadId
                }).IsUnique(true);
        }
    }
}