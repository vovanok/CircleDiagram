using System.Drawing;
using CircleDiagram.Editor.PropertiesAggregators;
using CircleDiagram.InputOutput;
using CircleDiagram.Main;

namespace CircleDiagram.Editor.Utils
{
    public static class ConvertingUtils
    {
        public static void GetNodePropertiesFromCircleDiagramNode(this CircleDiagramNodeProperies nodePropeties, 
            CircleDiagramNode node)
        {
            if (node == null || nodePropeties == null) return;
            nodePropeties.Name = node.Name;
            nodePropeties.BackgroundColor = SerializeUtils.BrushToColor(node.Background);
            nodePropeties.StartAngle = node.StartAngle;
            nodePropeties.SweepAngle = node.SweepAngle;
            nodePropeties.StartCircleNumber = node.StartCircleNumber;
            nodePropeties.CountCircles = node.CountCircles;
            nodePropeties.Text = node.Text;
            nodePropeties.TextColor = SerializeUtils.BrushToColor(node.TextBrush);
            nodePropeties.TextFont = node.TextFont;
        }

        public static void SetNodePropertiesToCircleDiagramNode(
            this CircleDiagramNodeProperies nodePropeties, CircleDiagramNode node)
        {
            if (node == null || nodePropeties == null) return;
            node.ChangeParametersValues(nodePropeties.Text, nodePropeties.StartAngle,
                nodePropeties.SweepAngle, nodePropeties.StartCircleNumber,
                nodePropeties.CountCircles, new SolidBrush(nodePropeties.BackgroundColor),
                new SolidBrush(nodePropeties.TextColor), nodePropeties.TextFont);
        }

        public static void GetMainPropertiesFromCircleDiagramModel(
            this CircleDiagramMainProperies mainProperties, CircleDiagramModel model)
        {
            if (model == null || !model.IsCorrect() || mainProperties == null) return;
            mainProperties.CountLevels = model.CountLevels;
            mainProperties.MainBackgroundColor = SerializeUtils.BrushToColor(model.MainBackground);
            mainProperties.RingBackgroundColor = SerializeUtils.BrushToColor(model.RingBackground);
            mainProperties.IntervalBackgroundColor = SerializeUtils.BrushToColor(model.IntervalBackground);
            mainProperties.NodeBorderColor = model.NodeBorder.Color;
            mainProperties.NodeBorderThickness = model.NodeBorder.Width;
            mainProperties.RingBorderColor = model.RingBorder.Color;
            mainProperties.RingBorderThickness = model.RingBorder.Width;
            mainProperties.RelationshipPenColor = model.RelationshipPen.Color;
            mainProperties.RelationshipPenThickness = model.RelationshipPen.Width;
            mainProperties.NumerationColor = SerializeUtils.BrushToColor(model.NumerationBrush);
            mainProperties.NumerationFont = model.NumerationFont;
            mainProperties.NumerationBeginNumber = model.NumerationBeginNumber;
            mainProperties.NumerationIsInverted = model.NumerationIsInverted;
        }

        public static void SetMainPropertiesToCircleDiagramModel(
            this CircleDiagramMainProperies mainPropeties, CircleDiagramModel model)
        {
            if (model == null || !model.IsCorrect() || mainPropeties == null) return;
            model.ChangeParametersValues(mainPropeties.CountLevels,
                new SolidBrush(mainPropeties.MainBackgroundColor),
                new SolidBrush(mainPropeties.RingBackgroundColor),
                new SolidBrush(mainPropeties.IntervalBackgroundColor),
                new Pen(mainPropeties.NodeBorderColor, mainPropeties.NodeBorderThickness),
                new Pen(mainPropeties.RingBorderColor, mainPropeties.RingBorderThickness),
                new Pen(mainPropeties.RelationshipPenColor, mainPropeties.RelationshipPenThickness),
                new SolidBrush(mainPropeties.NumerationColor), mainPropeties.NumerationFont,
                mainPropeties.NumerationBeginNumber, mainPropeties.NumerationIsInverted);
        }
    }
}
