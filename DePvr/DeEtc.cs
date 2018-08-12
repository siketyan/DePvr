using System;
using System.Runtime.InteropServices;

namespace DePvr
{
    public static class DeEtc
    {
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadFromFile(string path);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadFromMemory(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Decode(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FlipVertical(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FlipHorizontal(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetWidth(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetHeight(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint GetDataSize(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetDataPointer(IntPtr pointer);
    }
}
