﻿// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tysmithnet
// Created          : 03-26-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-24-2018
// ***********************************************************************
// <copyright file="MemoryRange.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace McFly.Core
{
    /// <summary>
    ///     Represents a memory range in virtual address space of a debugged target
    /// </summary>
    /// <seealso cref="System.IEquatable{McFly.Core.MemoryRange}" />
    /// <seealso cref="System.IComparable{McFly.Core.MemoryRange}" />
    /// <seealso cref="System.IComparable" />
    [DebuggerDisplay("{DebuggerDisplay}")]
    public class MemoryRange : IEquatable<MemoryRange>, IComparable<MemoryRange>, IComparable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MemoryRange" /> class.
        /// </summary>
        /// <param name="lowAddress">The low.</param>
        /// <param name="highAddress">The high.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public MemoryRange(ulong lowAddress, ulong highAddress)
        {
            if (lowAddress > highAddress)
                throw new ArgumentOutOfRangeException(
                    $"Low memory address cannot be greater than the high memory address");

            LowAddress = lowAddress;
            HighAddress = highAddress;
        }

        /// <summary>
        ///     Compares to.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="System.ArgumentException">MemoryRange</exception>
        /// <exception cref="ArgumentException">MemoryRange</exception>
        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            if (!(obj is MemoryRange)) throw new ArgumentException($"Object must be of type {nameof(MemoryRange)}");
            return CompareTo((MemoryRange) obj);
        }

        /// <summary>
        ///     Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>System.Int32.</returns>
        public int CompareTo(MemoryRange other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var lowComparison = LowAddress.CompareTo(other.LowAddress);
            if (lowComparison != 0) return lowComparison;
            return HighAddress.CompareTo(other.HighAddress);
        }

        /// <summary>
        ///     Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if both MemoryRange are logically equivalent, <c>false</c> otherwise.</returns>
        public bool Equals(MemoryRange other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return LowAddress == other.LowAddress && HighAddress == other.HighAddress;
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((MemoryRange) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (LowAddress.GetHashCode() * 397) ^ HighAddress.GetHashCode();
            }
        }

        /// <summary>
        ///     Parses the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>MemoryRange.</returns>
        /// <exception cref="System.FormatException">
        ///     Input did not match either a range+length range nor a start:end range, e.g. abcL123,
        ///     abc:def
        /// </exception>
        /// <exception cref="FormatException">
        ///     Input did not match either a range+length range nor a start:end range, e.g. abcL123,
        ///     abc:def
        /// </exception>
        public static MemoryRange Parse(string input)
        {
            var lengthMatch = Regex.Match(input, "^(?<s>[a-f0-9]+)l(?<l>[a-f0-9]+)$", RegexOptions.IgnoreCase);
            if (lengthMatch.Success)
            {
                var start = lengthMatch.Groups["s"].Value;
                var length = lengthMatch.Groups["l"].Value;
                var startULong = Convert.ToUInt64(start, 16);
                var lengthULong = Convert.ToUInt64(length, 16);
                return new MemoryRange(startULong, startULong + lengthULong);
            }

            var startEndMatch = Regex.Match(input, "(?<s>[a-f0-9]+):(?<e>[a-f0-9]+)", RegexOptions.IgnoreCase);
            if (startEndMatch.Success)
            {
                var start = startEndMatch.Groups["s"].Value;
                var end = startEndMatch.Groups["e"].Value;
                var startULong = Convert.ToUInt64(start, 16);
                var endULong = Convert.ToUInt64(end, 16);
                return new MemoryRange(startULong, endULong);
            }

            throw new FormatException(
                "Input did not match either a range+length range nor a start:end range, e.g. abcL123, abc:def");
        }

        /// <summary>
        ///     Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return $"{LowAddress:X}:{HighAddress:X}";
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(MemoryRange left, MemoryRange right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
            return Equals(left, right);
        }

        /// <summary>
        ///     Implements the &gt; operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >(MemoryRange left, MemoryRange right)
        {
            return Comparer<MemoryRange>.Default.Compare(left, right) > 0;
        }

        /// <summary>
        ///     Implements the &gt;= operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator >=(MemoryRange left, MemoryRange right)
        {
            return Comparer<MemoryRange>.Default.Compare(left, right) >= 0;
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(MemoryRange left, MemoryRange right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///     Implements the &lt; operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <(MemoryRange left, MemoryRange right)
        {
            return Comparer<MemoryRange>.Default.Compare(left, right) < 0;
        }

        /// <summary>
        ///     Implements the &lt;= operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator <=(MemoryRange left, MemoryRange right)
        {
            return Comparer<MemoryRange>.Default.Compare(left, right) <= 0;
        }

        /// <summary>
        ///     Gets the high address.
        /// </summary>
        /// <value>The high.</value>
        public ulong HighAddress { get; internal set; }

        /// <summary>
        ///     Gets the length.
        /// </summary>
        /// <value>The length.</value>
        [JsonIgnore]
        [XmlIgnore]
        [SoapIgnore]
        public ulong Length => HighAddress - LowAddress;

        /// <summary>
        ///     Gets the low address.
        /// </summary>
        /// <value>The low.</value>
        public ulong LowAddress { get; internal set; }

        /// <summary>
        ///     Gets the debugger display.
        /// </summary>
        /// <value>The debugger display.</value>
        internal string DebuggerDisplay => ToString();
    }
}