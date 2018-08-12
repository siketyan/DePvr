using System;
using System.Runtime.InteropServices;

namespace DePvr
{
    public static class DeEtc
    {
        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadPvrFromFile(string path);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr LoadPvrFromMemory(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FlipPvrVertical(IntPtr pointer);

        [DllImport("DeEtc.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool FlipPvrHorizontal(IntPtr pointer);

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
