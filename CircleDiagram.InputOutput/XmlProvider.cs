using System;
using System.IO;
using System.Xml.Serialization;

namespace CircleDiagram.InputOutput
{
    public class XmlProvider
    {
        public static void WriteXmlToStream(XmlModel xmlModel, Stream stream)
        {
            try
            {
                if (xmlModel == null || stream == null) return;
                var xmlSerializer = new XmlSerializer(typeof (XmlModel));
                xmlSerializer.Serialize(stream, xmlModel);
            }
            catch (Exception)
            {
                return;
            }
        }

        public static XmlModel ReadXmlFromStream(Stream stream)
        {
            try
            {
                if (stream == null) return null;
                var xmlSerializer = new XmlSerializer(typeof(XmlModel));
                var obj = xmlSerializer.Deserialize(stream);
                if (obj != null && obj is XmlModel)
                    return (XmlModel) obj;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}