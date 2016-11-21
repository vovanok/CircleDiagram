using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CircleDiagram.Main;

namespace CircleDiagram.Editor.Dialogs
{
    public partial class RelationshipParameters : Form
    {
        private class ComboBoxItem
        {
            public CircleDiagramNode CircleDiagramNode { get; set; }

            public ComboBoxItem(CircleDiagramNode circleDiagramNode)
            {
                CircleDiagramNode = circleDiagramNode;
            }

            public override string ToString()
            {
                if (CircleDiagramNode == null) return string.Empty;
                return string.Format("{0} - {1}",
                    CircleDiagramNode.StartCircleNumber, CircleDiagramNode.Text);
            }
        }

        public RelationshipParameters()
        {
            InitializeComponent();
        }

        public List<CircleDiagramNode> Nodes
        {
            set
            {
                if (value == null) return;

                var items = value.Where(g => g != null)
                    .Select(g => new ComboBoxItem(g)).ToArray();

                cbBeginNode.Items.Clear();
                cbBeginNode.Items.AddRange(items);

                cbEndNode.Items.Clear();
                cbEndNode.Items.AddRange(items);
            }
        }

        public List<CircleDiagramRelationship> Relationships { private get; set; }

        public CircleDiagramNode BeginNode { get; private set; }

        public CircleDiagramNode EndNode { get; private set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var selBeginItem = cbBeginNode.SelectedItem;
            var selEndItem = cbEndNode.SelectedItem;

            if (selBeginItem == null
                || !(selBeginItem is ComboBoxItem)
                || selEndItem == null
                || !(selEndItem is ComboBoxItem))
            {
                BeginNode = null;
                EndNode = null;
                MessageBox.Show(@"Необходимо выбрать начальную и конечную вершины");
                DialogResult = DialogResult.None;
                return;
            }

            BeginNode = (selBeginItem as ComboBoxItem).CircleDiagramNode;
            EndNode = (selEndItem as ComboBoxItem).CircleDiagramNode;

            if (Relationships
                .SingleOrDefault(g => g.BeginNode.Name == BeginNode.Name 
                    && g.EndNode.Name == EndNode.Name) != null)
            {
                BeginNode = null;
                EndNode = null;
                MessageBox.Show(@"Такая связь уже существует");
                DialogResult = DialogResult.None;
                return;
            }

            if (BeginNode.StartCircleNumber <= EndNode.StartCircleNumber)
            {
                MessageBox.Show(@"Уровень начальной вершины должен быть больше уровня конечной вершины");
                DialogResult = DialogResult.None;
            }
        }
    }
}
