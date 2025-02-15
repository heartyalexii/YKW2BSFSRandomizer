﻿using System;
using System.Linq;

namespace YKWrandomizer.Level5.Compression.ETC1
{
    // RGB Class From https://github.com/FanTranslatorsInternational/Kuriimu

    public struct RGB
    {
        public byte R, G, B, padding; // padding for speed reasons

        public RGB(int r, int g, int b)
        {
            R = (byte)r;
            G = (byte)g;
            B = (byte)b;
            padding = 0;
        }

        public static RGB operator +(RGB c, int mod) => new RGB(Clamp(c.R + mod), Clamp(c.G + mod), Clamp(c.B + mod));
        public static int operator -(RGB c1, RGB c2) => ErrorRGB(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B);
        public static RGB Average(RGB[] src) => new RGB((int)src.Average(c => c.R), (int)src.Average(c => c.G), (int)src.Average(c => c.B));
        public RGB Scale(int limit) => limit == 16 ? new RGB(R * 17, G * 17, B * 17) : new RGB((R << 3) | (R >> 2), (G << 3) | (G >> 2), (B << 3) | (B >> 2));
        public RGB Unscale(int limit) => new RGB(R * limit / 256, G * limit / 256, B * limit / 256);

        public override int GetHashCode() => R | (G << 8) | (B << 16);
        public override bool Equals(object obj) => obj != null && GetHashCode() == obj.GetHashCode();
        public static bool operator ==(RGB c1, RGB c2) => c1.Equals(c2);
        public static bool operator !=(RGB c1, RGB c2) => !c1.Equals(c2);

        public static int Clamp(int n) => Math.Max(0, Math.Min(n, 255));
        public static int Sign3(int n) => (n + 4) % 8 - 4;
        public static int ErrorRGB(int r, int g, int b) => 2 * r * r + 4 * g * g + 3 * b * b; // human perception
    }
}

