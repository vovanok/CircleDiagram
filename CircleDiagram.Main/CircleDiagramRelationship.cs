using System;

namespace CircleDiagram.Main
{
    public class CircleDiagramRelationship
    {
        public string Name { get; private set; }

        public CircleDiagramNode BeginNode { get; private set; }

        public CircleDiagramNode EndNode { get; private set; }

        public CircleDiagramRelationship()
        {
            Name = string.Format("Relationship_{0}", Guid.NewGuid());
        }

        public CircleDiagramRelationship(string name, CircleDiagramNode beginNode, CircleDiagramNode endNode)
        {
            Name = name ?? string.Empty;
            BeginNode = beginNode;
            EndNode = endNode;
        }

        public CircleDiagramRelationship(CircleDiagramNode beginNode, CircleDiagramNode endNode)
        {
            Name = string.Format("Relationship_{0}", Guid.NewGuid());
            BeginNode = beginNode;
            EndNode = endNode;
        }
    }
}
