﻿// ***********************************************************************
// Assembly         : McFly.Core
// Author           : @tsmithnet
// Created          : 03-01-2018
//
// Last Modified By : @tsmithnet
// Last Modified On : 04-26-2018
// ***********************************************************************
// <copyright file="StackFrame.cs" company="McFly.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.Core
{
    /// <summary>
    ///     Represents a single stack frame in a specific threads stack at a single instant in time during the trace
    /// </summary>
    public sealed class StackFrame
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StackFrame" /> class.
        /// </summary>
        /// <param name="stackPointer">The stack pointer.</param>
        /// <param name="returnAddress">The return address.</param>
        /// <param name="module">The module.</param>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="offset">The offset.</param>
        public StackFrame(ulong stackPointer, ulong? returnAddress, string module, string functionName, ulong? offset)
        {
            StackPointer = stackPointer;
            ReturnAddress = returnAddress;
            Module = module;
            FunctionName = functionName;
            Offset = offset;
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
            return Equals((StackFrame) obj);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = StackPointer.GetHashCode();
                hashCode = (hashCode * 397) ^ ReturnAddress.GetHashCode();
                hashCode = (hashCode * 397) ^ (Module != null ? Module.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (FunctionName != null ? FunctionName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int) Offset;
                return hashCode;
            }
        }

        /// <summary>
        ///     Is this instance equal to another stack frame
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><c>true</c> if both are equal, <c>false</c> otherwise.</returns>
        protected bool Equals(StackFrame other)
        {
            var sp = StackPointer == other.StackPointer;
            var ret = ReturnAddress == other.ReturnAddress;
            var mod = string.Equals(Module, other.Module);
            var fun = string.Equals(FunctionName, other.FunctionName);
            var off = Offset == other.Offset;
            return sp && ret && mod && fun && off;
        }

        /// <summary>
        ///     Gets or sets the name of the function.
        /// </summary>
        /// <value>The name of the function.</value>
        public string FunctionName { get; internal set; }

        /// <summary>
        ///     Gets or sets the module.
        /// </summary>
        /// <value>The module.</value>
        public string Module { get; internal set; }

        /// <summary>
        ///     Gets or sets the offset.
        /// </summary>
        /// <value>The offset.</value>
        public ulong? Offset { get; internal set; }

        /// <summary>
        ///     Gets or sets the return address.
        /// </summary>
        /// <value>The return address.</value>
        public ulong? ReturnAddress { get; internal set; }

        /// <summary>
        ///     Gets or sets the stack pointer.
        /// </summary>
        /// <value>The stack pointer.</value>
        public ulong StackPointer { get; internal set; }
    }
}