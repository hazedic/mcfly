﻿// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-18-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-18-2018
// ***********************************************************************
// <copyright file="IDisassemblyFacade.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace McFly
{
    /// <summary>
    ///     Interface IDisassemblyFacade
    /// </summary>
    public interface IDisassemblyFacade
    {
        /// <summary>
        ///     Gets the disassembly lines.
        /// </summary>
        /// <param name="numInstructions">The number instructions.</param>
        /// <returns>IEnumerable&lt;DisassemblyLine&gt;.</returns>
        IEnumerable<DisassemblyLine> GetDisassemblyLines(int numInstructions);

        /// <summary>
        ///     Gets the disassembly lines.
        /// </summary>
        /// <param name="threadId">The thread identifier.</param>
        /// <param name="numInstructions">The number instructions.</param>
        /// <returns>IEnumerable&lt;DisassemblyLine&gt;.</returns>
        IEnumerable<DisassemblyLine> GetDisassemblyLines(int threadId, int numInstructions);
    }
}