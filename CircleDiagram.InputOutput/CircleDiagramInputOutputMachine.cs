using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using CircleDiagram.Main;

namespace CircleDiagram.InputOutput
{
    public class CircleDiagramInputOutputMachine
    {
        #region Main properties

        public CircleDiagramModel CircleDiagramModel;

        #endregion

        #region Ctor

        public CircleDiagramInputOutputMachine(CircleDiagramModel circleDiagramModel)
        {
            CircleDiagramModel = circleDiagramModel != null && circleDiagramModel.IsCorrect() 
                ? circleDiagramModel 
                : null;
        }

        #endregion

        #region API

        public bool Save(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName)) return false;
                if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return false;

                if (Path.GetExtension(fileName) != ".xml")
                    fileName = string.Format("{0}.xml", fileName);

                var xmlModel = GetXmlModel();
                if (xmlModel == null) return false;
                using (var fs = new FileStream(fileName, FileMode.Create))
                {
                    XmlProvider.WriteXmlToStream(xmlModel, fs);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Load(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName)) return false;
                if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return false;

                if (Path.GetExtension(fileName) != ".xml") return false;

                XmlModel xmlModel;
                using (var fs = new FileStream(fileName, FileMode.Open))
                    xmlModel = XmlProvider.ReadXmlFromStream(fs);
                if (xmlModel == null) return false;

                ApplyXmlModel(xmlModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Utils

        private XmlModel GetXmlModel()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return null;
            var countLevels = CircleDiagramModel.CountLevels;
            var mainBackgroundColor = SerializeUtils.BrushToInt(CircleDiagramModel.MainBackground);
            var ringBackgroundColor = SerializeUtils.BrushToInt(CircleDiagramModel.RingBackground);
            var intervalBackgroundColor = SerializeUtils.BrushToInt(CircleDiagramModel.IntervalBackground);
            var nodeBorderColor = SerializeUtils.ColorToInt(CircleDiagramModel.NodeBorder.Color);
            var nodeBorderThickness = CircleDiagramModel.NodeBorder.Width;
            var ringBorderColor = SerializeUtils.ColorToInt(CircleDiagramModel.RingBorder.Color);
            var ringBorderThickness = CircleDiagramModel.RingBorder.Width;
            var relationshipPenColor = SerializeUtils.ColorToInt(CircleDiagramModel.RelationshipPen.Color);
            var relationshipPenThickness = CircleDiagramModel.RelationshipPen.Width;
            var numerationColor = SerializeUtils.BrushToInt(CircleDiagramModel.NumerationBrush);
            var numerationFont = SerializeUtils.FontToString(CircleDiagramModel.NumerationFont);
            var numerationBeginNumber = CircleDiagramModel.NumerationBeginNumber;
            var numerationIsInverted = CircleDiagramModel.NumerationIsInverted;

            return new XmlModel(countLevels, mainBackgroundColor, ringBackgroundColor, 
                intervalBackgroundColor, nodeBorderColor, nodeBorderThickness, ringBorderColor,
                ringBorderThickness, relationshipPenColor, relationshipPenThickness,
                numerationColor, numerationFont, numerationBeginNumber, numerationIsInverted,
                CircleDiagramModel.Nodes.Select(GetXmlNode).ToList(),
                CircleDiagramModel.Relationships.Select(GetXmlRelationship).ToList());
        }

        private static XmlNode GetXmlNode(CircleDiagramNode node)
        {
            if (node == null) return null;

            var name = node.Name;
            var text = node.Text;
            var startAngle = node.StartAngle;
            var sweepAngle = node.SweepAngle;
            var startCircleNumber = node.StartCircleNumber;
            var countCircles = node.CountCircles;
            var backgroundColor = SerializeUtils.BrushToInt(node.Background);
            var textColor = SerializeUtils.BrushToInt(node.TextBrush);
            var textFont = SerializeUtils.FontToString(node.TextFont);

            return new XmlNode(name, text, startAngle, sweepAngle,
                startCircleNumber, countCircles, backgroundColor, textColor, textFont);
        }

        private static XmlRelationship GetXmlRelationship(CircleDiagramRelationship relationship)
        {
            if (relationship == null) return null;
            return new XmlRelationship(relationship.Name, relationship.BeginNode.Name, relationship.EndNode.Name);
        }

        private void ApplyXmlModel(XmlModel xmlModel)
        {
            if (CircleDiagramModel == null 
                || !CircleDiagramModel.IsCorrect()
                || xmlModel == null) return;

            var countLevels = xmlModel.CountLevels;
            var mainBackground = SerializeUtils.IntToBrush(xmlModel.MainBackgroundColor);
            var ringBackground = SerializeUtils.IntToBrush(xmlModel.RingBackgroundColor);
            var intervalBackground = SerializeUtils.IntToBrush(xmlModel.IntervalBackgroundColor);
            var nodeBorder = new Pen(SerializeUtils.IntToColor(xmlModel.NodeBorderColor), 
                xmlModel.NodeBorderThickness);
            var ringBorder = new Pen(SerializeUtils.IntToColor(xmlModel.RingBorderColor),
                                     xmlModel.RingBorderThickness);
            var relationshipPen = new Pen(SerializeUtils.IntToColor(xmlModel.RelationshipPenColor),
                                           xmlModel.RelationshipPenThickness);
            var numerationBrush = SerializeUtils.IntToBrush(xmlModel.NumerationColor);
            var numerationFont = SerializeUtils.StringToFont(xmlModel.NumerationFont);
            var numerationBeginNumber = xmlModel.NumerationBeginNumber;
            var numerationIsInverted = xmlModel.NumerationIsInverted;
            var nodes = xmlModel.Nodes
                .Select(GetCircleDiagramNode)
                .Where(g => g != null).ToList();
            var relationships = xmlModel.Relationships
                .Select(g => GetCircleDiagramRelationship(g, nodes))
                .Where(g => g != null).ToList();
            CircleDiagramModel.ChangeParametersValues(countLevels, mainBackground, ringBackground, 
                intervalBackground, nodeBorder, ringBorder, relationshipPen,
                numerationBrush, numerationFont, numerationBeginNumber, numerationIsInverted,
                nodes, relationships);
        }

        private static CircleDiagramNode GetCircleDiagramNode(XmlNode node)
        {
            if (node == null) return null;

            var name = node.Name;
            var text = node.Text;
            var startAngle = node.StartAngle;
            var sweepAngle = node.SweepAngle;
            var startCircleNumber = node.StartCircleNumber;
            var countCircles = node.CountCircles;
            var background = SerializeUtils.IntToBrush(node.BackgroundColor);
            var textBrush = SerializeUtils.IntToBrush(node.TextColor);
            var textFont = SerializeUtils.StringToFont(node.TextFont);

            return new CircleDiagramNode(name, text, startAngle, sweepAngle,
                startCircleNumber, countCircles, background, textBrush, textFont);
        }

        private static CircleDiagramRelationship GetCircleDiagramRelationship(XmlRelationship relationship, 
            IEnumerable<CircleDiagramNode> nodes)
        {
            if (relationship == null) return null;

            var beginNode = nodes.SingleOrDefault(g => g.Name == relationship.BeginNodeName);
            var endNode = nodes.SingleOrDefault(g => g.Name == relationship.EndNodeName);

            if (beginNode == null || endNode == null) return null;
            return new CircleDiagramRelationship(relationship.Name, beginNode, endNode);
        }

        #endregion
    }
}
