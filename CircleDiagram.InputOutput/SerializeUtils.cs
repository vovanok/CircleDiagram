using System;
using System.ComponentModel;
using System.Drawing;

namespace CircleDiagram.InputOutput
{
    public class SerializeUtils
    {
        public static int BrushToInt(Brush value)
        {
            if (value == null) return 0;
            if (!(value is SolidBrush)) return 0;
            return ColorToInt((value as SolidBrush).Color);
        }

        public static Brush IntToBrush(int value)
        {
            return new SolidBrush(IntToColor(value));
        }

        public static int ColorToInt(Color value)
        {
            return value.ToArgb();
        }

        public static Color IntToColor(int value)
        {
            return Color.FromArgb(value);
        }

        public static int FontToInt(Font value)
        {
            if (value == null) return 0;
            return value.ToHfont().ToInt32();
        }

        public static Font IntToFont(int value)
        {
            return Font.FromHfont(new IntPtr(value));
        }

        public static string FontToString(Font value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(Font));
            return converter.ConvertToString(value);
        }

        public static Font StringToFont(string value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(Font));
            return (Font)converter.ConvertFromString(value);
        }

        public static Color BrushToColor(Brush value)
        {
            return IntToColor(BrushToInt(value));
        }
    }
}