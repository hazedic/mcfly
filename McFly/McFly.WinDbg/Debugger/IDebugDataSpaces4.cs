﻿// ***********************************************************************
// Assembly         : mcfly
// Author           : @tysmithnet
// Created          : 03-03-2018
//
// Last Modified By : @tysmithnet
// Last Modified On : 03-03-2018
// ***********************************************************************
// <copyright file="IDebugDataSpaces4.cs" company="">
//     Copyright ©  2018
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Runtime.InteropServices;
using System.Text;

#pragma warning disable 1591

namespace McFly.WinDbg.Debugger
{
    /// <summary>
    ///     Interface IDebugDataSpaces4
    /// </summary>
    /// <seealso cref="IDebugDataSpaces3" />
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("d98ada1f-29e9-4ef5-a6c0-e53349883212")]
    public interface IDebugDataSpaces4 : IDebugDataSpaces3
    {
        /* IDebugDataSpaces */

        /// <summary>
        ///     Reads the virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadVirtual(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteVirtual(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Searches the virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Length">The length.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="PatternSize">Size of the pattern.</param>
        /// <param name="PatternGranularity">The pattern granularity.</param>
        /// <param name="MatchOffset">The match offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int SearchVirtual(
            [In] ulong Offset,
            [In] ulong Length,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] pattern,
            [In] uint PatternSize,
            [In] uint PatternGranularity,
            [Out] out ulong MatchOffset);

        /// <summary>
        ///     Reads the virtual uncached.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadVirtualUncached(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the virtual uncached.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteVirtualUncached(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Reads the pointers virtual.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Ptrs">The PTRS.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadPointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
            ulong[] Ptrs);

        /// <summary>
        ///     Writes the pointers virtual.
        /// </summary>
        /// <param name="Count">The count.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="Ptrs">The PTRS.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WritePointersVirtual(
            [In] uint Count,
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray)]
            ulong[] Ptrs);

        /// <summary>
        ///     Reads the physical.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadPhysical(
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the physical.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WritePhysical(
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Reads the control.
        /// </summary>
        /// <param name="Processor">The processor.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadControl(
            [In] uint Processor,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] int BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the control.
        /// </summary>
        /// <param name="Processor">The processor.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteControl(
            [In] uint Processor,
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] int BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Reads the io.
        /// </summary>
        /// <param name="InterfaceType">Type of the interface.</param>
        /// <param name="BusNumber">The bus number.</param>
        /// <param name="AddressSpace">The address space.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the io.
        /// </summary>
        /// <param name="InterfaceType">Type of the interface.</param>
        /// <param name="BusNumber">The bus number.</param>
        /// <param name="AddressSpace">The address space.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteIo(
            [In] INTERFACE_TYPE InterfaceType,
            [In] uint BusNumber,
            [In] uint AddressSpace,
            [In] ulong Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Reads the MSR.
        /// </summary>
        /// <param name="Msr">The MSR.</param>
        /// <param name="MsrValue">The MSR value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadMsr(
            [In] uint Msr,
            [Out] out ulong MsrValue);

        /// <summary>
        ///     Writes the MSR.
        /// </summary>
        /// <param name="Msr">The MSR.</param>
        /// <param name="MsrValue">The MSR value.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteMsr(
            [In] uint Msr,
            [In] ulong MsrValue);

        /// <summary>
        ///     Reads the bus data.
        /// </summary>
        /// <param name="BusDataType">Type of the bus data.</param>
        /// <param name="BusNumber">The bus number.</param>
        /// <param name="SlotNumber">The slot number.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the bus data.
        /// </summary>
        /// <param name="BusDataType">Type of the bus data.</param>
        /// <param name="BusNumber">The bus number.</param>
        /// <param name="SlotNumber">The slot number.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int WriteBusData(
            [In] BUS_DATA_TYPE BusDataType,
            [In] uint BusNumber,
            [In] uint SlotNumber,
            [In] uint Offset,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);

        /// <summary>
        ///     Checks the low memory.
        /// </summary>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int CheckLowMemory();

        /// <summary>
        ///     Reads the debugger data.
        /// </summary>
        /// <param name="Index">The index.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DataSize">Size of the data.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadDebuggerData(
            [In] uint Index,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        /// <summary>
        ///     Reads the processor system data.
        /// </summary>
        /// <param name="Processor">The processor.</param>
        /// <param name="Index">The index.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DataSize">Size of the data.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadProcessorSystemData(
            [In] uint Processor,
            [In] DEBUG_DATA Index,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        /* IDebugDataSpaces2 */

        /// <summary>
        ///     Virtuals to physical.
        /// </summary>
        /// <param name="Virtual">The virtual.</param>
        /// <param name="Physical">The physical.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int VirtualToPhysical(
            [In] ulong Virtual,
            [Out] out ulong Physical);

        /// <summary>
        ///     Gets the virtual translation physical offsets.
        /// </summary>
        /// <param name="Virtual">The virtual.</param>
        /// <param name="Offsets">The offsets.</param>
        /// <param name="OffsetsSize">Size of the offsets.</param>
        /// <param name="Levels">The levels.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetVirtualTranslationPhysicalOffsets(
            [In] ulong Virtual,
            [Out] [MarshalAs(UnmanagedType.LPArray)]
            ulong[] Offsets,
            [In] uint OffsetsSize,
            [Out] out uint Levels);

        /// <summary>
        ///     Reads the handle data.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="DataType">Type of the data.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="DataSize">Size of the data.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadHandleData(
            [In] ulong Handle,
            [In] DEBUG_HANDLE_DATA_TYPE DataType,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint DataSize);

        /// <summary>
        ///     Fills the virtual.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Size">The size.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="PatternSize">Size of the pattern.</param>
        /// <param name="Filled">The filled.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int FillVirtual(
            [In] ulong Start,
            [In] uint Size,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint PatternSize,
            [Out] out uint Filled);

        /// <summary>
        ///     Fills the physical.
        /// </summary>
        /// <param name="Start">The start.</param>
        /// <param name="Size">The size.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="PatternSize">Size of the pattern.</param>
        /// <param name="Filled">The filled.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int FillPhysical(
            [In] ulong Start,
            [In] uint Size,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint PatternSize,
            [Out] out uint Filled);

        /// <summary>
        ///     Queries the virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Info">The information.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int QueryVirtual(
            [In] ulong Offset,
            [Out] out MEMORY_BASIC_INFORMATION64 Info);

        /* IDebugDataSpaces3 */

        /// <summary>
        ///     Reads the image nt headers.
        /// </summary>
        /// <param name="ImageBase">The image base.</param>
        /// <param name="Headers">The headers.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadImageNtHeaders(
            [In] ulong ImageBase,
            [Out] out IMAGE_NT_HEADERS64 Headers);

        /// <summary>
        ///     Reads the tagged.
        /// </summary>
        /// <param name="Tag">The tag.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="TotalSize">The total size.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int ReadTagged(
            [In] [MarshalAs(UnmanagedType.LPStruct)]
            Guid Tag,
            [In] uint Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint TotalSize);

        /// <summary>
        ///     Starts the enum tagged.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int StartEnumTagged(
            [Out] out ulong Handle);

        /// <summary>
        ///     Gets the next tagged.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <param name="Tag">The tag.</param>
        /// <param name="Size">The size.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int GetNextTagged(
            [In] ulong Handle,
            [Out] out Guid Tag,
            [Out] out uint Size);

        /// <summary>
        ///     Ends the enum tagged.
        /// </summary>
        /// <param name="Handle">The handle.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        new int EndEnumTagged(
            [In] ulong Handle);

        /* IDebugDataSpaces4 */

        /// <summary>
        ///     Gets the offset information.
        /// </summary>
        /// <param name="Space">The space.</param>
        /// <param name="Which">The which.</param>
        /// <param name="Offset">The offset.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="InfoSize">Size of the information.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetOffsetInformation(
            [In] DEBUG_DATA_SPACE Space,
            [In] DEBUG_OFFSINFO Which,
            [In] ulong Offset,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint InfoSize);

        /// <summary>
        ///     Gets the next differently valid offset virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="NextOffset">The next offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetNextDifferentlyValidOffsetVirtual(
            [In] ulong Offset,
            [Out] out ulong NextOffset);

        /// <summary>
        ///     Gets the valid region virtual.
        /// </summary>
        /// <param name="Base">The base.</param>
        /// <param name="Size">The size.</param>
        /// <param name="ValidBase">The valid base.</param>
        /// <param name="ValidSize">Size of the valid.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int GetValidRegionVirtual(
            [In] ulong Base,
            [In] uint Size,
            [Out] out ulong ValidBase,
            [Out] out uint ValidSize);

        /// <summary>
        ///     Searches the virtual2.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Length">The length.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="PatternSize">Size of the pattern.</param>
        /// <param name="PatternGranularity">The pattern granularity.</param>
        /// <param name="MatchOffset">The match offset.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int SearchVirtual2(
            [In] ulong Offset,
            [In] ulong Length,
            [In] DEBUG_VSEARCH Flags,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)]
            byte[] buffer,
            [In] uint PatternSize,
            [In] uint PatternGranularity,
            [Out] out ulong MatchOffset);

        /// <summary>
        ///     Reads the multi byte string virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="MaxBytes">The maximum bytes.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringBytes">The string bytes.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadMultiByteStringVirtual(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);

        /// <summary>
        ///     Reads the multi byte string virtual wide.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="MaxBytes">The maximum bytes.</param>
        /// <param name="CodePage">The code page.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringBytes">The string bytes.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadMultiByteStringVirtualWide(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [In] CODE_PAGE CodePage,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);

        /// <summary>
        ///     Reads the unicode string virtual.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="MaxBytes">The maximum bytes.</param>
        /// <param name="CodePage">The code page.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringBytes">The string bytes.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadUnicodeStringVirtual(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [In] CODE_PAGE CodePage,
            [Out] [MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);

        /// <summary>
        ///     Reads the unicode string virtual wide.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="MaxBytes">The maximum bytes.</param>
        /// <param name="Buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="StringBytes">The string bytes.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadUnicodeStringVirtualWide(
            [In] ulong Offset,
            [In] uint MaxBytes,
            [Out] [MarshalAs(UnmanagedType.LPWStr)]
            StringBuilder Buffer,
            [In] uint BufferSize,
            [Out] out uint StringBytes);

        /// <summary>
        ///     Reads the physical2.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesRead">The bytes read.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int ReadPhysical2(
            [In] ulong Offset,
            [In] DEBUG_PHYSICAL Flags,
            [Out] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesRead);

        /// <summary>
        ///     Writes the physical2.
        /// </summary>
        /// <param name="Offset">The offset.</param>
        /// <param name="Flags">The flags.</param>
        /// <param name="buffer">The buffer.</param>
        /// <param name="BufferSize">Size of the buffer.</param>
        /// <param name="BytesWritten">The bytes written.</param>
        /// <returns>System.Int32.</returns>
        [PreserveSig]
        int WritePhysical2(
            [In] ulong Offset,
            [In] DEBUG_PHYSICAL Flags,
            [In] [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
            byte[] buffer,
            [In] uint BufferSize,
            [Out] out uint BytesWritten);
    }
}