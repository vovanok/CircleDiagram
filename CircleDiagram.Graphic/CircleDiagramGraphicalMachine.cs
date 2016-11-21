using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using CircleDiagram.Main;

namespace CircleDiagram.Graphic
{
    public class CircleDiagramGraphicalMachine
    {
        #region Rod parameters

        private readonly CircleDiagramModel CircleDiagramModel;

        #endregion

        #region Private parameters

        private float SquareCanvasLength;

        private float DiagramAreaLength;

        private float PercentageScale;

        private Bitmap MainLayer;

        private Bitmap MapLayer;

        private Bitmap NodesLayer;

        private Bitmap RelationshipsLayer;

        #endregion

        #region Ctors

        public CircleDiagramGraphicalMachine(CircleDiagramModel circleDiagramModel)
        {
            CircleDiagramModel = circleDiagramModel;
        }

        #endregion

        #region Consts

        private const float DefaultSquareCanvasLength = 500;

        private const float SquareIndent = 10;

        #endregion

        #region API

        public void RedrawDiagram(Graphics graphics, Color emptyAreasColor)
        {
            if (graphics == null 
                || CircleDiagramModel == null
                || !CircleDiagramModel.IsCorrect()) return;

            var width = graphics.VisibleClipBounds.Width;
            var height = graphics.VisibleClipBounds.Height;

            if (width == 0 || height == 0) return;

            SquareCanvasLength = width <= height ? width : height;

            DiagramAreaLength = SquareCanvasLength - SquareIndent;

            PercentageScale = DiagramAreaLength/DefaultSquareCanvasLength;
            if (PercentageScale <= 0) PercentageScale = 1;

            MapLayer = new Bitmap(
                (int)(DiagramAreaLength + SquareIndent), 
                (int)(DiagramAreaLength + SquareIndent));
            UpdateMap();
            NodesLayer = new Bitmap(
                (int)(DiagramAreaLength + SquareIndent),
                (int)(DiagramAreaLength + SquareIndent));
            UpdateNodes();
            RelationshipsLayer = new Bitmap(
                (int)(DiagramAreaLength + SquareIndent),
                (int)(DiagramAreaLength + SquareIndent));
            UpdateRelationships();

            MainLayer = new Bitmap((int)SquareCanvasLength, (int)SquareCanvasLength);
            var mainGraphics = Graphics.FromImage(MainLayer);
            mainGraphics.DrawImage(MapLayer, new PointF(0, 0));
            mainGraphics.DrawImage(NodesLayer, new PointF(0, 0));
            mainGraphics.DrawImage(RelationshipsLayer, new PointF(0, 0));
            
            graphics.Clear(emptyAreasColor);

            var dX = width / 2;
            var dY = height / 2;
            graphics.TranslateTransform(dX, dY);

            graphics.DrawImage(MainLayer, 
                new PointF(-SquareCanvasLength / 2, -SquareCanvasLength / 2));

            //var grPath = new GraphicsPath();
            //grPath.AddLine(new PointF(-250, -250), new PointF(-250, -50));
            //grPath.AddLine(new PointF(-250, -50), new PointF(-50, -50));
            //grPath.AddLine(new PointF(-50, -50), new PointF(-250, -250));
            //var grBrush = new PathGradientBrush(grPath);
            //grBrush.CenterColor = Color.Black;
            //grBrush.SurroundColors = new [] { Color.Empty };
            //graphics.FillPath(grBrush, grPath);
        }

        public void QuickRedrawDiagram(Graphics graphics, Color emptyAreasColor)
        {
            if (graphics == null || MainLayer == null) return;
            graphics.Clear(emptyAreasColor);
            var dX = graphics.VisibleClipBounds.Width / 2;
            var dY = graphics.VisibleClipBounds.Height / 2;
            graphics.TranslateTransform(dX, dY);
            graphics.DrawImage(MainLayer,
                new PointF(-SquareCanvasLength / 2, -SquareCanvasLength / 2));
        }
        
        #endregion

        #region Main

        private void UpdateMap()
        {
            if (MapLayer == null) return;
            try
            {
                var mapGraphics = Graphics.FromImage(MapLayer);
                mapGraphics.Clear(((SolidBrush)(CircleDiagramModel.MainBackground)).Color);
                mapGraphics.TranslateTransform(
                    DiagramAreaLength / 2 + SquareIndent / 2,
                    DiagramAreaLength / 2 + SquareIndent / 2);

                var circleThickness = GetRingThickness();

                var actualPen = (Pen)CircleDiagramModel.RingBorder.Clone();
                actualPen.Width = actualPen.Width * PercentageScale;

                var curLevelNumber =
                    CircleDiagramModel.NumerationIsInverted
                        ? CircleDiagramModel.NumerationBeginNumber
                        : CircleDiagramModel.NumerationBeginNumber
                            + CircleDiagramModel.CountLevels - 1;


                for (var i = CircleDiagramModel.CountLevels - 1; i >= 0; i--)
                {
                    var radiusMain = circleThickness * (i * 2 + 1);
                    var radiusAlt = circleThickness * i * 2;

                    if (radiusMain != 0)
                    {
                        mapGraphics.FillEllipse(CircleDiagramModel.RingBackground,
                            -radiusMain, -radiusMain, radiusMain * 2, radiusMain * 2);
                        mapGraphics.DrawEllipse(actualPen,
                            -radiusMain, -radiusMain, radiusMain * 2, radiusMain * 2);
                    }
                    if (radiusAlt != 0)
                    {
                        mapGraphics.FillEllipse(CircleDiagramModel.IntervalBackground,
                            -radiusAlt, -radiusAlt, radiusAlt * 2, radiusAlt * 2);
                        mapGraphics.DrawEllipse(actualPen,
                            -radiusAlt, -radiusAlt, radiusAlt * 2, radiusAlt * 2);
                    }

                    var actualNumerationFont = GetModifiedFont(CircleDiagramModel.NumerationFont);

                    mapGraphics.DrawStringInBox(curLevelNumber.ToString(),
                        -radiusMain, -circleThickness / 2, circleThickness,
                        circleThickness, CircleDiagramModel.NumerationBrush,
                        actualNumerationFont);

                    mapGraphics.DrawStringInBox(curLevelNumber.ToString(),
                        -circleThickness / 2, -radiusMain, circleThickness,
                        circleThickness, CircleDiagramModel.NumerationBrush,
                        actualNumerationFont);

                    mapGraphics.DrawStringInBox(curLevelNumber.ToString(),
                        radiusMain - circleThickness, -circleThickness / 2,
                        circleThickness, circleThickness, CircleDiagramModel.NumerationBrush,
                        actualNumerationFont);

                    mapGraphics.DrawStringInBox(curLevelNumber.ToString(),
                        -circleThickness / 2, radiusMain - circleThickness,
                        circleThickness, circleThickness, CircleDiagramModel.NumerationBrush,
                        actualNumerationFont);

                    if (!CircleDiagramModel.NumerationIsInverted)
                        curLevelNumber--;
                    else
                        curLevelNumber++;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void UpdateNodes()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            if (NodesLayer == null) return;
            try
            {
                var nodesGraphics = Graphics.FromImage(NodesLayer);
                nodesGraphics.Clear(Color.Empty);
                nodesGraphics.TranslateTransform(
                    DiagramAreaLength / 2 + SquareIndent / 2,
                    DiagramAreaLength / 2 + SquareIndent / 2);
                CircleDiagramModel.Nodes.ForEach(g => DrawNode(g, nodesGraphics));
            }
            catch (Exception)
            {
                return;
            }
        }

        private void UpdateRelationships()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            if (RelationshipsLayer == null) return;
            try
            {
                var relationshipsGraphics = Graphics.FromImage(RelationshipsLayer);
                relationshipsGraphics.Clear(Color.Empty);
                relationshipsGraphics.TranslateTransform(
                    DiagramAreaLength / 2 + SquareIndent / 2,
                    DiagramAreaLength / 2 + SquareIndent / 2);
                CircleDiagramModel.Relationships.ForEach(g => DrawRelationship(g, relationshipsGraphics));
            }
            catch (Exception)
            {
                return;
            }
        }

        #endregion

        #region Draw utils

        private void DrawNode(CircleDiagramNode circleDiagramNode, Graphics graphics)
        {
            if (circleDiagramNode == null) return;
            if (graphics == null) return;
            if (circleDiagramNode.StartCircleNumber >= CircleDiagramModel.CountLevels) return;
            if (circleDiagramNode.CountCircles <= 0) return;
            if (circleDiagramNode.StartCircleNumber != 0 
             && circleDiagramNode.StartCircleNumber + 1 - circleDiagramNode.CountCircles < 0) return;

            float radius1, radius2;
            GetRadiusesOfNode(circleDiagramNode, out radius1, out radius2);

            var actualPen = (Pen)CircleDiagramModel.NodeBorder.Clone();
            actualPen.Width = actualPen.Width*PercentageScale;

            if (circleDiagramNode.StartCircleNumber == 0)
            {
                var radius = radius1 >= radius2 ? radius1 : radius2;
                graphics.FillEllipse(circleDiagramNode.Background, -radius, -radius, radius * 2, radius * 2);
                graphics.DrawEllipse(actualPen, -radius, -radius, radius * 2, radius * 2);
                graphics.DrawStringInBox(circleDiagramNode.Text, -radius, -radius, radius * 2, radius * 2, 
                    circleDiagramNode.TextBrush, GetModifiedFont(circleDiagramNode.TextFont));
                return;
            }

            graphics.FillTruncSector(new PointF(0, 0), radius2 - 1, radius1 + 1,
                circleDiagramNode.StartAngle, circleDiagramNode.SweepAngle, circleDiagramNode.Background);

            graphics.DrawTruncSector(new PointF(0, 0), radius1, radius2,
                circleDiagramNode.StartAngle, circleDiagramNode.SweepAngle, actualPen);

            graphics.DrawStringAround(circleDiagramNode.Text, new PointF(0, 0), radius1, radius2,
                circleDiagramNode.StartAngle, circleDiagramNode.SweepAngle, circleDiagramNode.TextBrush, 
                GetModifiedFont(circleDiagramNode.TextFont), true);
        }

        private void DrawRelationship(CircleDiagramRelationship relationship, Graphics graphics)
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            if (relationship == null) return;
            if (graphics == null) return;

            //Связи с такой же стартовой вершиной
            var relationshipsWithSameBeginNode =
                GetOrderedOutRelationshipsForNode(relationship.BeginNode);
            if (relationshipsWithSameBeginNode == null) return;

            var beginNodeIndex = relationshipsWithSameBeginNode.IndexOf(relationship);
            if (beginNodeIndex < 0) return;

            //Связи с такой же конечной вершиной
            var relationshipsWithSameEndNode =
                GetOrderedInRelationshipsForNode(relationship.EndNode);
            if (relationshipsWithSameEndNode == null) return;

            var endNodeIndex = relationshipsWithSameEndNode.IndexOf(relationship);
            if (endNodeIndex < 0) return;

            var angleForBeginVertex = relationship.BeginNode.StartAngle
                + (relationship.BeginNode.SweepAngle / (relationshipsWithSameBeginNode.Count + 1))
                    * (beginNodeIndex + 1);

            var angleForEndVertex = relationship.EndNode.StartCircleNumber != 0
                ? relationship.EndNode.StartAngle
                    + (relationship.EndNode.SweepAngle / (relationshipsWithSameEndNode.Count + 1))
                        * (endNodeIndex + 1)
                : angleForBeginVertex;

            float beginNodeRadius1, beginNodeRadius2, endNodeRadius1, endNodeRadius2;
            GetRadiusesOfNode(relationship.BeginNode, out beginNodeRadius1, out beginNodeRadius2);
            GetRadiusesOfNode(relationship.EndNode, out endNodeRadius1, out endNodeRadius2);

            var ringThickness = GetRingThickness();

            var beginFunctionalRadius =
                beginNodeRadius1 <= beginNodeRadius2
                    ? beginNodeRadius1
                    : beginNodeRadius2;

            var endFunctionalRadius =
                endNodeRadius1 >= endNodeRadius2
                    ? endNodeRadius1
                    : endNodeRadius2;

            float beginAngle, endAngle;
            if (angleForBeginVertex <= angleForEndVertex)
            {
                beginAngle = angleForBeginVertex;
                endAngle = angleForEndVertex;
            }
            else
            {
                beginAngle = angleForEndVertex;
                endAngle = angleForBeginVertex;
            }

            var actualPen = (Pen)CircleDiagramModel.RelationshipPen.Clone();
            actualPen.Width = actualPen.Width*PercentageScale;

            var deltaAngle = (float)(Math.Abs(beginAngle - endAngle) * 0.15);

            var vertexes = new List<PointF>();
            vertexes.Add(GraphicsUtils.GetPointOnCircle(beginFunctionalRadius,
                new PointF(0, 0), angleForBeginVertex));
            vertexes.Add(GraphicsUtils.GetPointOnCircle(endFunctionalRadius + 0.75f * ringThickness,
                new PointF(0, 0), angleForBeginVertex));
            vertexes.Add(GraphicsUtils.GetPointOnCircle(endFunctionalRadius + 0.5f * ringThickness,
                new PointF(0, 0), angleForBeginVertex));
            vertexes.Add(GraphicsUtils.GetPointOnCircle(endFunctionalRadius + 0.5f * ringThickness,
                new PointF(0, 0), angleForBeginVertex + deltaAngle));

            for (var curAngle = angleForBeginVertex + deltaAngle + 1;
                 curAngle < angleForEndVertex - deltaAngle; curAngle++)
            {
                vertexes.Add(GraphicsUtils.GetPointOnCircle(endFunctionalRadius + 0.5f * ringThickness,
                    new PointF(0, 0), curAngle));
            }

            vertexes.Add(GraphicsUtils.GetPointOnCircle(endFunctionalRadius + 0.5f * ringThickness,
                new PointF(0, 0), angleForEndVertex - deltaAngle));
            vertexes.Add(GraphicsUtils.GetPointOnCircle(endFunctionalRadius + 0.5f * ringThickness,
                new PointF(0, 0), angleForEndVertex));
            vertexes.Add(GraphicsUtils.GetPointOnCircle(endFunctionalRadius + 0.25f * ringThickness,
                new PointF(0, 0), angleForEndVertex));
            vertexes.Add(GraphicsUtils.GetPointOnCircle(endFunctionalRadius,
                new PointF(0, 0), angleForEndVertex));

            if (vertexes.Count < 8) return;

            graphics.DrawLine(actualPen, vertexes[0], vertexes[1]);
            graphics.DrawBezier(actualPen, vertexes[1], vertexes[2], vertexes[2], vertexes[3]);
            graphics.DrawCurve(actualPen, vertexes.GetRange(3, vertexes.Count - 6).ToArray());
            graphics.DrawBezier(actualPen, vertexes[vertexes.Count - 4], 
                vertexes[vertexes.Count - 3], vertexes[vertexes.Count - 3],
                vertexes[vertexes.Count - 2]);
            graphics.DrawLine(actualPen, vertexes[vertexes.Count - 2], vertexes[vertexes.Count - 1]);

            graphics.DrawArrow(vertexes[vertexes.Count - 1], 50,
                360 - angleForEndVertex, 0.30f * ringThickness, new SolidBrush(actualPen.Color));
        }

        #endregion

        #region Relationships utils

        private List<CircleDiagramRelationship> GetOrderedInRelationshipsForNode(
            CircleDiagramNode node)
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect() || node == null)
                return new List<CircleDiagramRelationship>();
            return CircleDiagramModel.Relationships
                .Where(g => g.EndNode == node)
                .OrderBy(g => g.BeginNode.StartCircleNumber + g.BeginNode.SweepAngle / 2)
                .ToList();
        }

        private List<CircleDiagramRelationship> GetOrderedOutRelationshipsForNode(
            CircleDiagramNode node)
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect() || node == null)
                return new List<CircleDiagramRelationship>();
            return CircleDiagramModel.Relationships
                .Where(g => g.BeginNode == node)
                .OrderBy(g => g.EndNode.StartCircleNumber + g.EndNode.SweepAngle / 2)
                .ToList();
        }

        #endregion

        #region Utils

        private float GetRingThickness()
        {
            return Math.Abs(DiagramAreaLength / (CircleDiagramModel.CountLevels * 4 - 2));
        }

        private void GetRadiusesOfNode(CircleDiagramNode node,
            out float firstRadius, out float secondRadius)
        {
            try
            {
                if (node == null)
                {
                    firstRadius = 0;
                    secondRadius = 0;
                    return;
                }
                
                var ringThickness = GetRingThickness();

                if (node.StartCircleNumber == 0)
                {
                    firstRadius = ringThickness * (node.CountCircles * 2 - 1);
                    secondRadius = 0;
                }else
                {
                    firstRadius = ringThickness * (node.StartCircleNumber * 2 + 1);
                    secondRadius = ringThickness * (node.StartCircleNumber * 2 - (node.CountCircles - 1) * 2);    
                }
            }
            catch (Exception)
            {
                firstRadius = 0;
                secondRadius = 0;
            }
        }

        private Font GetModifiedFont(Font sourceFont)
        {
            if (sourceFont == null) return null;
            return new Font(sourceFont.Name, sourceFont.Size * PercentageScale,
                sourceFont.Style, sourceFont.Unit,
                sourceFont.GdiCharSet, sourceFont.GdiVerticalFont );
        }

        #endregion
    }
}
