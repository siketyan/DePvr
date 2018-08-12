using System;
using System.Runtime.InteropServices;

namespace DePvr
{
    /// <summary>
    /// Unmanaged-to-Managed proxy class for DeEtc.dll
    /// </summary>
    internal static class UnmanagedProxy
    {
        /// <summary>
        /// Loads a PVR texture from a file.
        /// </summary>
        /// <param name="path">A file to load from.</param>
        /// <returns>A pointer of the loaded texture.</returns>
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr LoadFromFile(string path);

        /// <summary>
        /// Loads a PVR texture from a byte array.
        /// </summary>
        /// <param name="pointer">A pointer of the byte array to load from.</param>
        /// <returns>A pointer of the loaded texture.</returns>
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr LoadFromMemory(IntPtr pointer);

        /// <summary>
        /// Decodes the texture to RGBA8888.
        /// Load methods also call decoding, so this will not be needed.
        /// </summary>
        /// <param name="pointer">A pointer of the texture to decode.</param>
        /// <returns>Whether it was decoded successfully.</returns>
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool Decode(IntPtr pointer);

        /// <summary>
        /// Flips the texture vertically.
        /// </summary>
        /// <param name="pointer">A pointer of the texture to flip.</param>
        /// <returns>Whether it was flipped successfully.</returns>
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool FlipVertical(IntPtr pointer);

        /// <summary>
        /// Flips the texture horizontally.
        /// </summary>
        /// <param name="pointer">A pointer of the texture to flip.</param>
        /// <returns>Whether it was flipped successfully.</returns>
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool FlipHorizontal(IntPtr pointer);

        /// <summary>
        /// Gets the width of the texture.
        /// </summary>
        /// <param name="pointer">A pointer of the texture.</param>
        /// <returns>The width of the texture.</returns>
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint GetWidth(IntPtr pointer);

        /// <summary>
        /// Gets the height of the texture.
        /// </summary>
        /// <param name="pointer">A pointer of the texture.</param>
        /// <returns>The height of the texture.</returns>
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint GetHeight(IntPtr pointer);

        /// <summary>
        /// Gets the size of the texture binary.
        /// </summary>
        /// <param name="pointer">A pointer of the texture.</param>
        /// <returns>The size of the texture binary.</returns>
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint GetDataSize(IntPtr pointer);

        /// <summary>
        /// Gets the pointer of the texture binary.
        /// </summary>
        /// <param name="pointer">A pointer of the texture.</param>
        /// <returns>The pointer of the texture binary.</returns>
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetDataPointer(IntPtr pointer);

        /// <summary>
        /// Free the memory space used by the texture.
        /// </summary>
        /// <param name="pointer">A pointer of the texture.</param>
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Dispose(IntPtr pointer);
    }
}
