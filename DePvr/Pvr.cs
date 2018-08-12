using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace DePvr
{
    /// <summary>
    /// A PVR texture manager.
    /// </summary>
    public class Pvr : IDisposable
    {
        /// <summary>
        /// The pointer to the texture.
        /// </summary>
        private readonly IntPtr _pointer;

        /// <summary>
        /// Gets the width of the texture.
        /// </summary>
        public uint Width => UnmanagedProxy.GetWidth(_pointer);

        /// <summary>
        /// Gets the height of the texture.
        /// </summary>
        public uint Height => UnmanagedProxy.GetHeight(_pointer);

        /// <summary>
        /// Gets the size of the texture binary.
        /// </summary>
        public uint DataSize => UnmanagedProxy.GetDataSize(_pointer);

        /// <summary>
        /// Gets the texture binary.
        /// </summary>
        public byte[] Data
        {
            get
            {
                var length = (int) DataSize;
                var bytes = new byte[length];
                var pointer = UnmanagedProxy.GetDataPointer(_pointer);

                Marshal.Copy(pointer, bytes, 0, length);
                return bytes;
            }
        }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="pointer">A pointer to the unmanaged texture.</param>
        private Pvr(IntPtr pointer)
        {
            _pointer = pointer;
        }

        /// <summary>
        /// Loads a texture from a file.
        /// </summary>
        /// <param name="path">The path of a file to load from.</param>
        /// <returns>The loaded texture.</returns>
        public static Pvr LoadFromFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found", path);
            }

            var fullPath = Path.GetFullPath(path);
            var pointer = UnmanagedProxy.LoadFromFile(path);
            var pvr = new Pvr(pointer);

            return pvr;
        }

        /// <summary>
        /// Loads a texture from a byte array.
        /// </summary>
        /// <param name="bytes">The byte array to load from.</param>
        /// <returns>The loaded texture.</returns>
        public static Pvr LoadFromBytes(byte[] bytes)
        {
            var length = bytes.Length;
            var srcPointer = Marshal.AllocHGlobal(length);
            Marshal.Copy(bytes, 0, srcPointer, length);

            var pointer = UnmanagedProxy.LoadFromMemory(srcPointer);
            var pvr = new Pvr(pointer);

            return pvr;
        }

        /// <summary>
        /// Loads a texture from a stream.
        /// </summary>
        /// <param name="stream">The stream to load from.</param>
        /// <returns>The loaded texture.</returns>
        public static Pvr LoadFromStream(Stream stream)
        {
            using (var memory = new MemoryStream())
            {
                memory.CopyTo(stream);
                return LoadFromBytes(memory.ToArray());
            }
        }

        /// <summary>
        /// Flips the texture vertically.
        /// </summary>
        /// <returns>Whether it was flipped successfully.</returns>
        public bool FlipVertical()
        {
            return UnmanagedProxy.FlipVertical(_pointer);
        }

        /// <summary>
        /// Flips the texture horizontally.
        /// </summary>
        /// <returns>Whether it was flipped successfully.</returns>
        public bool FlipHorizontal()
        {
            return UnmanagedProxy.FlipHorizontal(_pointer);
        }

        /// <summary>
        /// Converts the texture to a Bitmap object.
        /// </summary>
        /// <returns>The converted object.</returns>
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

        /// <summary>
        /// Exports the texture to a file.
        /// </summary>
        /// <param name="path">The path of a file to export to.</param>
        public void Export(string path)
        {
            Export(path, ImageFormat.Png);
        }

        /// <summary>
        /// Exports the texture to a file with the specified format.
        /// </summary>
        /// <param name="path">The path of a file to export to.</param>
        /// <param name="format">The image format to export with.</param>
        public void Export(string path, ImageFormat format)
        {
            using (var bitmap = ToBitmap())
            {
                bitmap.Save(path, format);
            }
        }

        /// <summary>
        /// Frees the memory space used by the texture.
        /// </summary>
        public void Dispose()
        {
            UnmanagedProxy.Dispose(_pointer);
        }
    }
}
