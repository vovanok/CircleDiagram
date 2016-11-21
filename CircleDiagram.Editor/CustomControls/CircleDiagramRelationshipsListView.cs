using System.Windows.Forms;
using CircleDiagram.Main;

namespace CircleDiagram.Editor.CustomControls
{
    public class CircleDiagramRelationshipsListView : ListView
    {
        private CircleDiagramModel CircleDiagramModel;

        public void SetCircleDiagramModel(CircleDiagramModel circleDiagramModel)
        {
            CircleDiagramModel = circleDiagramModel;
        }

        public CircleDiagramRelationship GetSelectedCircleDiagramRelationship()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return null;
            var lvSelItem = SelectedItems.Count > 0
                                ? SelectedItems[0]
                                : null;
            return lvSelItem != null
                ? CircleDiagramModel.FindRelationshipByName(lvSelItem.Name)
                : null;
        }

        public void UpdateContent()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            Items.Clear();
            CircleDiagramModel.Relationships.ForEach(AddCircleDiagramRelationship);
        }

        public void AddCircleDiagramRelationship(CircleDiagramRelationship relationship)
        {
            if (relationship == null) return;
            var relationshipText = string.Format("{0} -> {1}",
                relationship.BeginNode != null 
                    ? string.Format("{0} - {1}", 
                        relationship.BeginNode.StartCircleNumber, 
                        relationship.BeginNode.Text.Trim().Replace("\r\n", " ")) 
                    : string.Empty,
                relationship.EndNode != null 
                    ? string.Format("{0} - {1}", 
                        relationship.EndNode.StartCircleNumber, 
                        relationship.EndNode.Text.Trim().Replace("\r\n", " ")) 
                    : string.Empty);

            var lvItem = new ListViewItem { Text = relationshipText, Name = relationship.Name };
            Items.Add(lvItem);
        }
    }
}
