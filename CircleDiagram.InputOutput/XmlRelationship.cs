using System.Xml.Serialization;

namespace CircleDiagram.InputOutput
{
    public class XmlRelationship
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("beginNodeName")]
        public string BeginNodeName { get; set; }

        [XmlAttribute("endNodeName")]
        public string EndNodeName { get; set; }

        public XmlRelationship()
        {
            Name = string.Empty;
            BeginNodeName = string.Empty;
            EndNodeName = string.Empty;
        }

        public XmlRelationship(string name, string beginNodeName, string endNodeName)
        {
            Name = name;
            BeginNodeName = beginNodeName;
            EndNodeName = endNodeName;
        }
    }
}
