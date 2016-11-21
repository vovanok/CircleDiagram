using System.Xml.Serialization;

namespace CircleDiagram.InputOutput
{
    public class XmlNode
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("text")]
        public string Text { get; set; }

        [XmlAttribute("startAngle")]
        public float StartAngle { get; set; }

        [XmlAttribute("sweepAngle")]
        public float SweepAngle { get; set; }

        [XmlAttribute("startCircleNumber")]
        public int StartCircleNumber { get; set; }

        [XmlAttribute("countCircles")]
        public int CountCircles { get; set; }

        [XmlAttribute("backgroundColor")]
        public int BackgroundColor { get; set; }

        [XmlAttribute("textColor")]
        public int TextColor { get; set; }

        [XmlAttribute("textFont")]
        public string TextFont { get; set; }

        public XmlNode()
        {
            Name = string.Empty;
            Text = string.Empty;
            StartAngle = 0;
            SweepAngle = 0;
            StartCircleNumber = 0;
            CountCircles = 0;
            BackgroundColor = 0;
            TextColor = 0;
            TextFont = string.Empty;
        }

        public XmlNode(string name, string text, float startAngle, 
            float sweepAngle, int startCircleNumber, int countCircles, 
            int backgroundColor, int textColor, string textFont)
        {
            Name = name ?? string.Empty;
            Text = text ?? string.Empty;
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
            StartCircleNumber = startCircleNumber;
            CountCircles = countCircles;
            BackgroundColor = backgroundColor;
            TextColor = textColor;
            TextFont = textFont;
        }
    }
}


