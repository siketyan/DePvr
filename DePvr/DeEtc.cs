using System;
using System.Runtime.InteropServices;

namespace DePvr
{
    internal static class DeEtc
    {
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr LoadFromFile(string path);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr LoadFromMemory(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool Decode(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool FlipVertical(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool FlipHorizontal(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint GetWidth(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint GetHeight(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint GetDataSize(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr GetDataPointer(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void Dispose(IntPtr pointer);
    }
}
