using System.Windows.Forms;
using CircleDiagram.Main;

namespace CircleDiagram.Editor.CustomControls
{
    public class CircleDiagramNodesListView : ListView
    {
        private CircleDiagramModel CircleDiagramModel;

        public void SetCircleDiagramModel(CircleDiagramModel circleDiagramModel)
        {
            CircleDiagramModel = circleDiagramModel;
        }

        public void UpdateGroups()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            Groups.Clear();
            Groups.Add(Consts.NoneGroup, Consts.NoneGroupText);
            for (var groupKey = 0; groupKey < CircleDiagramModel.CountLevels; groupKey++)
                Groups.Add(groupKey.ToString(), string.Format(Consts.GroupTextFormat, groupKey));
            foreach (ListViewItem curItem in Items)
            {
                var curModelNode = CircleDiagramModel.FindNodeByName(curItem.Name);
                if (curModelNode == null) continue;
                curItem.Group = Groups[curModelNode.StartCircleNumber.ToString()] 
                    ?? Groups[Consts.NoneGroup];
            }
        }

        public CircleDiagramNode GetSelectedCircleDiagramNode()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return null;
            var lvSelItem = SelectedItems.Count > 0
                                ? SelectedItems[0]
                                : null;
            return lvSelItem != null
                ? CircleDiagramModel.FindNodeByName(lvSelItem.Name)
                : null;
        }

        public void UpdateContent()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            Items.Clear();
            UpdateGroups();
            CircleDiagramModel.Nodes.ForEach(AddCircleDiagramNode);
        }

        public void AddCircleDiagramNode(CircleDiagramNode node)
        {
            var lvItem = new ListViewItem { Text = node.Text.Trim().Replace("\r\n", " "), Name = node.Name };
            var targetGroup = Groups[node.StartCircleNumber.ToString()]
                ?? Groups[Consts.NoneGroup];
            if (targetGroup != null)
                lvItem.Group = targetGroup;
            var newListItem = Items.Add(lvItem);
            SelectedIndices.Clear();
            SelectedIndices.Add(newListItem.Index);
        }

        public void SelectItemByDefault()
        {
            if (Items.Count <= 0) return;
            SelectedIndices.Clear();
            SelectedIndices.Add(0);
        }
    }
}
