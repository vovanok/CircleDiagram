using System.Drawing;

namespace CircleDiagram.Graphic
{
    public static class Consts
    {
        public static readonly Brush DefaultBackground = new SolidBrush(Color.White);

        public static readonly Brush DefaultBrushRing = new SolidBrush(Color.LightGray);

        public static readonly Brush DefaultBrushInterval = new SolidBrush(Color.White);

        public static readonly Pen DefaultNodePen = new Pen(Color.Black, 3);

        public static readonly Pen DefaultMapPen = new Pen(Color.Black, 1);

        public static readonly Brush DefaultTextBlush = new SolidBrush(Color.Black);

        public static readonly Font DefaultTextFont = new Font("Verdana", 10);
    }
}
