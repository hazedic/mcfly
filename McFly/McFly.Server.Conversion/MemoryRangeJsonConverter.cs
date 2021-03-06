﻿// ***********************************************************************
// Assembly         : McFly.Core.JsonConverters
// Author           : @tysmithnet
// Created          : 04-23-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="MemoryRangeJsonConverter.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using McFly.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace McFly.Server.Conversion
{
    /// <summary>
    ///     Json converter for <see cref="MemoryRange" />
    /// </summary>
    /// <seealso cref="System.Web.Http.ModelBinding.IModelBinder" />
    /// <seealso cref="Newtonsoft.Json.JsonConverter{McFly.Core.MemoryRange}" />
    public sealed class MemoryRangeJsonConverter : JsonConverter<MemoryRange>, IModelBinder
    {
        /// <summary>
        ///     Binds the model to a value by using the specified controller context and binding context.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>true if model binding is successful; otherwise, false.</returns>
        /// <inheritdoc />
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (!typeof(MemoryRange).IsAssignableFrom(bindingContext.ModelType)) return false;
            var val = bindingContext.ValueProvider.GetValue(
                bindingContext.ModelName);
            if (val == null) return false;
            return true;
        }

        /// <summary>
        ///     Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">
        ///     The existing value of object being read. If there is no existing value then <c>null</c>
        ///     will be used.
        /// </param>
        /// <param name="hasExistingValue">The existing value has a value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        /// <exception cref="JsonSerializationException">
        ///     Low must be a valid ulong
        ///     or
        ///     High must be a valid ulong
        /// </exception>
        /// <inheritdoc />
        public override MemoryRange ReadJson(JsonReader reader, Type objectType, MemoryRange existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            var jobj = JObject.Load(reader);
            ulong? low = null;
            ulong? high = null;
            foreach (var prop in jobj)
                switch (prop.Key)
                {
                    case "LowAddress":
                        low = Convert.ToUInt64(prop.Value.ToString());
                        break;
                    case "HighAddress":
                        high = Convert.ToUInt64(prop.Value.ToString());
                        break;
                }

            if (low == null) throw new JsonSerializationException("Low must be a valid ulong");
            if (high == null) throw new JsonSerializationException("High must be a valid ulong");
            return new MemoryRange(high.Value, low.Value);
        }

        /// <summary>
        ///     Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, MemoryRange value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("LowAddress");
            writer.WriteValue(value.LowAddress);
            writer.WritePropertyName("HighAddress");
            writer.WriteValue(value.HighAddress);
            writer.WriteEndObject();
        }
    }
}