using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CircleDiagram.Main
{
    public class CircleDiagramModel
    {
        public int CountLevels { get; private set; }

        public Brush MainBackground { get; private set; }

        public Brush RingBackground { get; private set; }

        public Brush IntervalBackground { get; private set; }

        public Pen NodeBorder { get; private set; }

        public Pen RingBorder { get; private set; }

        public Pen RelationshipPen { get; private set; }

        public Brush NumerationBrush { get; private set; }

        public Font NumerationFont { get; private set; }

        public int NumerationBeginNumber { get; private set; }

        public bool NumerationIsInverted { get; private set; }

        public List<CircleDiagramNode> Nodes { get; private set; }

        public List<CircleDiagramRelationship> Relationships { get; private set; }

        public CircleDiagramModel()
        {
            CountLevels = 0;
            MainBackground = new SolidBrush(Color.Empty);
            RingBackground = new SolidBrush(Color.Empty);
            IntervalBackground = new SolidBrush(Color.Empty);
            NodeBorder = new Pen(Color.Empty, 0);
            RingBorder = new Pen(Color.Empty, 0);
            RelationshipPen = new Pen(Color.Empty, 0);
            Nodes = new List<CircleDiagramNode>();
            Relationships = new List<CircleDiagramRelationship>();
            NumerationBrush = new SolidBrush(Color.Empty);
            NumerationFont = new Font("Verdana", 10);
            NumerationBeginNumber = 0;
            NumerationIsInverted = false;
        }

        public CircleDiagramModel(int countLevels, Brush mainBackground, 
            Brush ringBackground, Brush intervalBackground, Pen nodeBorder, 
            Pen ringBorder, Pen relationshipPen, Brush numerationBrush,
            Font numerationFont, int numerationBeginNumber, 
            bool numerationIsInverted, List<CircleDiagramNode> nodes, 
            List<CircleDiagramRelationship> relationships)
        {
            CountLevels = countLevels >= 0 ? countLevels : 0;
            MainBackground = mainBackground ?? new SolidBrush(Color.White);
            RingBackground = ringBackground ?? new SolidBrush(Color.LightGray);
            IntervalBackground = intervalBackground ?? new SolidBrush(Color.White);
            NodeBorder = nodeBorder ?? new Pen(Color.Black, 3);
            RingBorder = ringBorder ?? new Pen(Color.Black, 1);
            RelationshipPen = relationshipPen ?? new Pen(Color.Black, 1);
            NumerationBrush = numerationBrush ?? new SolidBrush(Color.Black);
            NumerationFont = numerationFont ?? new Font("Verdana", 10);
            NumerationBeginNumber = numerationBeginNumber;
            NumerationIsInverted = numerationIsInverted;
            Nodes = nodes ?? new List<CircleDiagramNode>();
            Relationships = relationships ?? new List<CircleDiagramRelationship>();
        }

        public bool IsCorrect()
        {
            return CountLevels >= 0
                   && MainBackground != null
                   && RingBackground != null
                   && IntervalBackground != null
                   && NodeBorder != null
                   && RingBorder != null
                   && RelationshipPen != null
                   && NumerationBrush != null
                   && NumerationFont != null
                   && Nodes != null
                   && Relationships != null;
        }

        public void ChangeParametersValues(int countLevels, Brush mainBackground,
            Brush ringBackground, Brush intervalBackground, Pen nodeBorder,
            Pen ringBorder, Pen relationshipPen, Brush numerationBrush, 
            Font numerationFont, int numerationBeginNumber, bool numerationIsInverted)
        {
            CountLevels = countLevels >= 0 ? countLevels : CountLevels;
            MainBackground = mainBackground ?? MainBackground;
            RingBackground = ringBackground ?? RingBackground;
            IntervalBackground = intervalBackground ?? IntervalBackground;
            NodeBorder = nodeBorder ?? NodeBorder;
            RingBorder = ringBorder ?? RingBorder;
            RelationshipPen = relationshipPen ?? RelationshipPen;
            NumerationBrush = numerationBrush ?? NumerationBrush;
            NumerationFont = numerationFont ?? NumerationFont;
            NumerationBeginNumber = numerationBeginNumber;
            NumerationIsInverted = numerationIsInverted;
        }

        public void ChangeParametersValues(int countLevels, Brush mainBackground, 
            Brush ringBackground, Brush intervalBackground, Pen nodeBorder,
            Pen ringBorder, Pen relationshipPen, Brush numerationBrush, 
            Font numerationFont, int numerationBeginNumber, bool numerationIsInverted,
            List<CircleDiagramNode> nodes, List<CircleDiagramRelationship> relationships)
        {
            ChangeParametersValues(countLevels, mainBackground,
                ringBackground, intervalBackground, nodeBorder,
                ringBorder, relationshipPen, numerationBrush, 
                numerationFont, numerationBeginNumber, numerationIsInverted);
            Nodes = nodes ?? Nodes;
            Relationships = relationships ?? Relationships;
        }

        public CircleDiagramNode FindNodeByName(string name)
        {
            if (string.IsNullOrEmpty(name) || !IsCorrect()) return null;
            try
            {
                return Nodes.SingleOrDefault(g => g.Name == name);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public CircleDiagramRelationship FindRelationshipByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            try
            {
                return Relationships.SingleOrDefault(g => g.Name == name);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddNode(CircleDiagramNode node)
        {
            if (node == null || !IsCorrect()) return false;
            Nodes.Add(node);
            return true;
        }

        public bool DeleteNode(CircleDiagramNode node)
        {
            if (node == null || !IsCorrect()) return false;
            return Nodes.Remove(node);
        }

        public bool AddRelationship(CircleDiagramRelationship relationship)
        {
            if (relationship == null || !IsCorrect()) return false;
            Relationships.Add(relationship);
            return true;
        }

        public bool DeleteRelationship(CircleDiagramRelationship relationship)
        {
            if (relationship == null || !IsCorrect()) return false;
            return Relationships.Remove(relationship);
        }
    }
}
