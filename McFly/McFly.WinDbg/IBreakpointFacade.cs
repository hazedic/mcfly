﻿// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 04-03-2018
// ***********************************************************************
// <copyright file="IBreakpointFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace McFly.WinDbg
{
    /// <summary>
    ///     Facade over managing breakpoints
    /// </summary>
    /// <seealso cref="IInjectable" />
    public interface IBreakpointFacade : IInjectable
    {
        /// <summary>
        ///     Clears the breakpoints.
        /// </summary>
        void ClearBreakpoints();

        /// <summary>
        ///     Sets the breakpoint by mask.
        /// </summary>
        /// <param name="moduleMask">The module mask.</param>
        /// <param name="functionMask">The function mask.</param>
        void SetBreakpointByMask(string moduleMask, string functionMask);

        /// <summary>
        ///     Sets the read access breakpoint.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="address">The address.</param>
        void SetReadAccessBreakpoint(int length, ulong address);

        /// <summary>
        ///     Sets the write access breakpoint.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="address">The address.</param>
        void SetWriteAccessBreakpoint(int length, ulong address);
    }
}