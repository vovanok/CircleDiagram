using System.Collections.Generic;
using CircleDiagram.Main;

namespace CircleDiagram.Graphic
{
    public class BuldingRelationshipsNode
    {
        public CircleDiagramNode Node { get; set; }

        public List<CircleDiagramRelationship> InRelationships { get; set; }

        public List<CircleDiagramRelationship> OutRelationships { get; set; }

        public BuldingRelationshipsNode(CircleDiagramNode node)
        {
            Node = node;
            InRelationships = new List<CircleDiagramRelationship>();
            OutRelationships = new List<CircleDiagramRelationship>();
        }
    }
}
