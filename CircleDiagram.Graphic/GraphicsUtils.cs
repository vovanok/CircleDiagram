using System;
using System.Collections.Generic;
using System.Drawing;

namespace CircleDiagram.Graphic
{
    public static class GraphicsUtils
    {
        /// <summary>
        /// Draw truncate sector
        /// </summary>
        /// <param name="graphics">Graphics for draw</param>
        /// <param name="center">Coordinates of center</param>
        /// <param name="firstRadius">First radius for truncate</param>
        /// <param name="secondRadius">Second radius for truncate</param>
        /// <param name="startAngle">Start angle of sector</param>
        /// <param name="sweepAngle">Sweet angle of sector</param>
        /// <param name="pen">Pen</param>
        public static void DrawTruncSector(this Graphics graphics, 
            PointF center, float firstRadius, float secondRadius, 
            float startAngle, float sweepAngle, Pen pen)
        {
            if (graphics == null || pen == null)
                throw new ArgumentNullException();
            
            if (firstRadius != 0)
                graphics.DrawArc(pen, center.X - firstRadius, center.Y - firstRadius, 
                    firstRadius * 2, firstRadius * 2, startAngle, sweepAngle);

            if (secondRadius != 0)
                graphics.DrawArc(pen, center.X - secondRadius, center.Y - secondRadius,
                    secondRadius * 2, secondRadius * 2, startAngle, sweepAngle);

            var line1Point1 = GetPointOnCircle(firstRadius, center, startAngle);
            var line1Point2 = GetPointOnCircle(secondRadius, center, startAngle);

            var line2Point1 = GetPointOnCircle(firstRadius, center, startAngle + sweepAngle);
            var line2Point2 = GetPointOnCircle(secondRadius, center, startAngle + sweepAngle);

            graphics.DrawLine(pen, line1Point1, line1Point2);
            graphics.DrawLine(pen, line2Point1, line2Point2);
        }

        /// <summary>
        /// Draw fill truncate sector
        /// </summary>
        /// <param name="graphics">Graphics for draw</param>
        /// <param name="center">Сoordinates of center</param>
        /// <param name="firstRadius">First radius for truncate</param>
        /// <param name="secondRadius">Second radius for truncate</param>
        /// <param name="startAngle">Start angle of sector</param>
        /// <param name="sweepAngle">Sweet angle of sector</param>
        /// <param name="brush">Brush</param>
        public static void FillTruncSector(this Graphics graphics, 
            PointF center, float firstRadius, float secondRadius, 
            float startAngle, float sweepAngle, Brush brush)
        {
            if (graphics == null || brush == null)
                throw new ArgumentNullException();

            var points = new List<PointF>();
            for (var angle = startAngle; angle <= startAngle + sweepAngle; angle++)
                points.Add(GetPointOnCircle(firstRadius, center, angle));

            for (var angle = startAngle + sweepAngle; angle >= startAngle; angle--)
                points.Add(GetPointOnCircle(secondRadius, center, angle));

            graphics.FillPolygon(brush, points.ToArray());
        }

        /// <summary>
        /// Draw string around
        /// </summary>
        /// <param name="graphics">Graphics for draw</param>
        /// <param name="value">String value</param>
        /// <param name="center">Center of circle</param>
        /// <param name="firstRadius">First radius of area</param>
        /// <param name="secondRadius">Second radius of area</param>
        /// <param name="startAngle">Start angle of area</param>
        /// <param name="sweepAngle">Sweep angle of area</param>
        /// <param name="brush">Brush of text</param>
        /// <param name="font">Font of text</param>
        /// <param name="optimizeForReading">Optimization taext for reading</param>
        public static void DrawStringAround(this Graphics graphics, string value, 
            PointF center, float firstRadius, float secondRadius, float startAngle, 
            float sweepAngle, Brush brush, Font font, bool optimizeForReading)
        {
            if (graphics == null || value == null || brush == null || font == null)
                throw new ArgumentNullException();

            if (value == string.Empty) return;

            var lines = value.Split(new [] {"\r\n"}, 0);
            if (lines.Length == 0) return;

            var centralAngle = startAngle + sweepAngle/2;
            var isInverse = optimizeForReading && centralAngle > 0 && centralAngle < 180;

            var dRadius = Math.Abs(firstRadius - secondRadius)/(lines.Length + 1);
            if (isInverse)
            {
                var currentRadius = (firstRadius < secondRadius ? firstRadius : secondRadius) + dRadius;
                for (var curLineNum = 0; curLineNum < lines.Length; curLineNum++)
                {
                    var currentString = lines[curLineNum];
                    var dAngle = sweepAngle / (currentString.Length + 1);
                    var currentAngle = startAngle + sweepAngle - dAngle;

                    for (var curSymbolNum = 0; curSymbolNum < currentString.Length; curSymbolNum++)
                    {
                        graphics.RotateTransform(currentAngle - 90);
                        graphics.DrawString(currentString[curSymbolNum].ToString(),
                            font, brush, -(float)font.Height / 2, currentRadius - (float)font.Height / 2);
                        graphics.RotateTransform(-currentAngle + 90);
                        currentAngle -= dAngle;
                    }

                    currentRadius += dRadius;
                }
            }
            else
            {
                var currentRadius = (firstRadius > secondRadius ? firstRadius : secondRadius) - dRadius;
                for (var curLineNum = 0; curLineNum < lines.Length; curLineNum++)
                {
                    var currentString = lines[curLineNum];
                    var dAngle = sweepAngle / (currentString.Length + 1);
                    var currentAngle = startAngle + dAngle;

                    for (var curSymbolNum = 0; curSymbolNum < currentString.Length; curSymbolNum++)
                    {
                        graphics.RotateTransform(currentAngle + 90);
                        graphics.DrawString(currentString[curSymbolNum].ToString(),
                            font, brush, -(float)font.Height / 2, -currentRadius - (float)font.Height / 2);
                        graphics.RotateTransform(-currentAngle - 90);
                        currentAngle += dAngle;
                    }

                    currentRadius -= dRadius;
                }
            }
        }

        /// <summary>
        /// Draw string in box
        /// </summary>
        /// <param name="graphics">Graphics for draw</param>
        /// <param name="value">String value</param>
        /// <param name="x">X coordinate of top left angle of box</param>
        /// <param name="y">Y coordinate of top left angle of box</param>
        /// <param name="width">Width of box</param>
        /// <param name="height">Height of box</param>
        /// <param name="brush">Text brush</param>
        /// <param name="font">Text font</param>
        public static void DrawStringInBox(this Graphics graphics, string value, 
            float x, float y, float width, float height, Brush brush, Font font)
        {
            if (graphics == null || value == null || brush == null || font == null)
                throw new ArgumentNullException();

            if (value == string.Empty) return;

            var lines = value.Split(new [] { "\r\n" }, 0);
            if (lines.Length == 0) return;

            var dY = height / (lines.Length + 1);

            var currentY = y + dY;
            for (var curLineNum = 0; curLineNum < lines.Length; curLineNum++)
            {
                var currentString = lines[curLineNum];
                var dX = width / (currentString.Length + 1);
                var currentX = x + dX;

                for (var curSymbolNum = 0; curSymbolNum < currentString.Length; curSymbolNum++)
                {
                    graphics.DrawString(currentString[curSymbolNum].ToString(),
                        font, brush, currentX - (float)font.Height / 2.5f, currentY - (float)font.Height / 2);
                    currentX += dX;
                }

                currentY += dY;
            }
        }

        public static void DrawStringInBox(this Graphics graphics, string value, 
            PointF topLeftCoordinate, float width, float height, Brush brush, Font font)
        {
            graphics.DrawStringInBox(value, topLeftCoordinate.X,
                                     topLeftCoordinate.Y, width, height, brush, font);
        }

        public static void DrawArrow(this Graphics graphics, PointF destinationPoint, 
            float sweepAngle, float turnAngle, float length, Brush brush)
        {
            if (graphics == null || sweepAngle < 0 || length < 0 || brush == null)
                throw new ArgumentNullException();

            var zeroPoint = new PointF(0, 0);
            var arrowVertexes = new List<PointF>
                {
                    zeroPoint,
                    GetPointOnCircle(length, zeroPoint, 360 - turnAngle + sweepAngle/2),
                    GetPointOnCircle(length, zeroPoint, 360 - turnAngle - sweepAngle/2)
                };

            graphics.TranslateTransform(destinationPoint.X, destinationPoint.Y);
            graphics.FillPolygon(brush, arrowVertexes.ToArray());
            graphics.TranslateTransform(- destinationPoint.X, - destinationPoint.Y);
        }

        /// <summary>
        /// Get point on circle
        /// </summary>
        /// <param name="circleRadius">Circle radius</param>
        /// <param name="circleCenter">Coordinate of circle center</param>
        /// <param name="angle">Angle on the circle</param>
        /// <returns></returns>
        public static PointF GetPointOnCircle(float circleRadius, PointF circleCenter, float angle)
        {
            if (circleRadius <= 0) return new PointF(0, 0);
            
            return new PointF((float)(circleRadius * Math.Cos(angle * Math.PI / 180) + circleCenter.X),
                              (float)(circleRadius * Math.Sin(angle * Math.PI / 180) + circleCenter.Y));
        }

        
    }
}
