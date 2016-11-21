using System.Collections.Generic;
using System.Xml.Serialization;

namespace CircleDiagram.InputOutput
{
    [XmlRoot("CircleDiagramModel")]
    public class XmlModel
    {
        [XmlAttribute("countLevels")]
        public int CountLevels { get; set; }

        [XmlAttribute("mainBackgroundColor")]
        public int MainBackgroundColor { get; set; }

        [XmlAttribute("ringBackgroundColor")]
        public int RingBackgroundColor { get; set; }

        [XmlAttribute("intervalBackgroundColor")]
        public int IntervalBackgroundColor { get; set; }

        [XmlAttribute("nodeBorderColor")]
        public int NodeBorderColor { get; set; }

        [XmlAttribute("nodeBorderThickness")]
        public float NodeBorderThickness { get; set; }

        [XmlAttribute("ringBorderColor")]
        public int RingBorderColor { get; set; }

        [XmlAttribute("ringBorderThickness")]
        public float RingBorderThickness { get; set; }

        [XmlAttribute("relationshipPenColor")]
        public int RelationshipPenColor { get; set; }

        [XmlAttribute("relationshipPenThickness")]
        public float RelationshipPenThickness { get; set; }

        [XmlAttribute("numerationColor")]
        public int NumerationColor { get; set; }

        [XmlAttribute("numerationFont")]
        public string NumerationFont { get; set; }

        [XmlAttribute("numerationBeginNumber")]
        public int NumerationBeginNumber { get; set; }

        [XmlAttribute("numerationIsInverted")]
        public bool NumerationIsInverted { get; set; }

        [XmlArray("Nodes")]
        [XmlArrayItem("Node")]
        public List<XmlNode> Nodes { get; set; }

        [XmlArray("Relationships")]
        [XmlArrayItem("Relationship")]
        public List<XmlRelationship> Relationships { get; set; }

        public XmlModel()
        {
            CountLevels = 0;
            MainBackgroundColor = 0;
            RingBackgroundColor = 0;
            IntervalBackgroundColor = 0;
            NodeBorderColor = 0;
            NodeBorderThickness = 0;
            RingBorderColor = 0;
            RingBorderThickness = 0;
            RelationshipPenColor = 0;
            RelationshipPenThickness = 0;
            NumerationColor = 0;
            NumerationFont = string.Empty;
            NumerationBeginNumber = 0;
            NumerationIsInverted = false;
            Nodes = new List<XmlNode>();
            Relationships = new List<XmlRelationship>();
        }

        public XmlModel(int countLevels, int mainBackgroundColor, int ringBackgroundColor,
            int intervalBackgroundColor, int nodeBorderColor, float nodeBorderThickness,
            int ringBorderColor, float ringBorderThickness, int relationshipPenColor, 
            float relationshipPenThickness, int numerationColor, string numerationFont,
            int numerationBeginNumber, bool numerationIsInverted,
            List<XmlNode> nodes, List<XmlRelationship> relationships)
        {
            CountLevels = countLevels;
            MainBackgroundColor = mainBackgroundColor;
            RingBackgroundColor = ringBackgroundColor;
            IntervalBackgroundColor = intervalBackgroundColor;
            NodeBorderColor = nodeBorderColor;
            NodeBorderThickness = nodeBorderThickness;
            RingBorderColor = ringBorderColor;
            RingBorderThickness = ringBorderThickness;
            RelationshipPenColor = relationshipPenColor;
            RelationshipPenThickness = relationshipPenThickness;
            NumerationColor = numerationColor;
            NumerationFont = numerationFont;
            NumerationBeginNumber = numerationBeginNumber;
            NumerationIsInverted = numerationIsInverted;
            Nodes = nodes ?? new List<XmlNode>();
            Relationships = relationships ?? new List<XmlRelationship>();
        }
    }
}
