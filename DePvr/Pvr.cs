using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace DePvr
{
    public class Pvr
    {
        private IntPtr _pointer;

        public uint Width => DeEtc.GetWidth(_pointer);
        public uint Height => DeEtc.GetHeight(_pointer);
        public uint DataSize => DeEtc.GetDataSize(_pointer);

        public byte[] Data
        {
            get
            {
                var length = (int) DataSize;
                var bytes = new byte[length];
                var pointer = DeEtc.GetDataPointer(_pointer);

                Marshal.Copy(pointer, bytes, 0, length);
                return bytes;
            }
        }

        private Pvr(IntPtr pointer)
        {
            _pointer = pointer;
        }

        public static Pvr Load(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found", path);
            }

            var fullPath = Path.GetFullPath(path);
            var pointer = DeEtc.LoadPvr(path);
            var pvr = new Pvr(pointer);

            return pvr;
        }

        public bool FlipVertical()
        {
            return DeEtc.FlipPvrVertical(_pointer);
        }

        public bool FlipHorizontal()
        {
            return DeEtc.FlipPvrHorizontal(_pointer);
        }

        public Bitmap ToBitmap()
        {
            var width = (int) Width;
            var height = (int) Height;
            var bytes = Data;

            var bitmap = new Bitmap(width, height);
            var i = 0;
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var r = bytes[i++];
                    var g = bytes[i++];
                    var b = bytes[i++];
                    var a = bytes[i++];

                    bitmap.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }

            return bitmap;
        }

        public void Export(string path)
        {
            Export(path, ImageFormat.Png);
        }

        public void Export(string path, ImageFormat format)
        {
            using (var bitmap = ToBitmap())
            {
                bitmap.Save(path, format);
            }
        }
    }
}
