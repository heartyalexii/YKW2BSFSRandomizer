﻿using System.Drawing;

namespace YKWrandomizer.Level5.Image.Color_Formats
{
    public interface IColorFormat
    {
        string Name { get; }

        int Size { get; }

        byte[] Encode(Color color);

        Color Decode(byte[] data);
    }
}
