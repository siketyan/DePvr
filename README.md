# DePvr
Decodes PVR files and exports to Bitmap or image file.

## Features
- Loads a PVR texture from a file, a byte array or a stream.
- Transcodes pixel format of the texture to RGBA8888.
- Flips the texture vertically or horizontally.
- Exports the texture to a Bitmap object or an image file such as PNG.

## Environment
- Windows 10
- .NET Framework 4.7.1

## Example
```cs
var pvr = Pvr.LoadFromFile("texture.pvr"); // Automatically transcoded

pvr.FlipVertical();
pvr.Export("export.png");
// pvr.Export("export.jpg", ImageFormat.Jpeg);
```

## License
This library is released under the MIT license.
For details, please refer `LICENSE.md`.

Please note that **this contains Imagination Technologies' PVRTexLib library in [PVRTexTool](https://community.imgtec.com/developers/powervr/tools/pvrtextool/)**.
The license of the library is in `LICENSE_POWERVR_TOOLS.txt`.
