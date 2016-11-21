using System;
using System.Drawing;

namespace CircleDiagram.Main
{
    public class CircleDiagramNode
    {
        public string Name { get; private set; }

        public string Text { get; private set; }

        public float StartAngle { get; private set; }

        public float SweepAngle { get; private set; }

        public int StartCircleNumber { get; private set; }

        public int CountCircles { get; private set; }

        public Brush Background { get; private set; }

        public Brush TextBrush { get; private set; }

        public Font TextFont { get; private set; }

        public CircleDiagramNode()
        {
            Name = string.Format("Node_{0}", Guid.NewGuid());
            Text = string.Empty;
            StartAngle = 0;
            SweepAngle = 0;
            StartCircleNumber = 0;
            CountCircles = 0;
            Background = new SolidBrush(Color.Red);
            TextBrush = new SolidBrush(Color.Black);
            TextFont = new Font("Verdana", 10);
        }

        public CircleDiagramNode(string text, float startAngle, float sweepAngle,
            int startCircleNumber, int countCircles, Brush background, Brush textBrush,
            Font textFont) : this()
        {
            Text = text ?? string.Empty;
            StartAngle = startAngle >= 0 ? startAngle : 0;
            SweepAngle = sweepAngle >= 0 ? sweepAngle : 0;
            StartCircleNumber = startCircleNumber >=0 ? startCircleNumber : 0;
            CountCircles = countCircles >= 0 ? countCircles : 0;
            Background = background ?? new SolidBrush(Color.Red);
            TextBrush = textBrush ?? new SolidBrush(Color.Black);
            TextFont = textFont ?? new Font("Verdana", 10);
        }

        public CircleDiagramNode(string name, string text, float startAngle, float sweepAngle,
            int startCircleNumber, int countCircles, Brush background, Brush textBrush, Font textFont)
        {
            Name = name ?? string.Empty;
            Text = text ?? string.Empty;
            StartAngle = startAngle >= 0 ? startAngle : 0;
            SweepAngle = sweepAngle >= 0 ? sweepAngle : 0;
            StartCircleNumber = startCircleNumber >= 0 ? startCircleNumber : 0;
            CountCircles = countCircles >= 0 ? countCircles : 0;
            Background = background ?? new SolidBrush(Color.Red);
            TextBrush = textBrush ?? new SolidBrush(Color.Black);
            TextFont = textFont ?? new Font("Verdana", 10);
        }

        public void ChangeParametersValues(string text, float startAngle, float sweepAngle,
            int startCircleNumber, int countCircles, Brush background, Brush textBrush, Font textFont)
        {
            Text = text ?? Text;
            StartAngle = startAngle >= 0 ? startAngle : StartAngle;
            SweepAngle = sweepAngle >= 0 ? sweepAngle : SweepAngle;
            StartCircleNumber = startCircleNumber >= 0 ? startCircleNumber : StartCircleNumber;
            CountCircles = countCircles >= 0 ? countCircles : CountCircles;
            Background = background ?? Background;
            TextBrush = textBrush ?? TextBrush;
            TextFont = textFont ?? TextFont;
        }
    }
}
