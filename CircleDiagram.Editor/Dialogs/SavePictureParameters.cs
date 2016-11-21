using System;
using System.Windows.Forms;

namespace CircleDiagram.Editor.Dialogs
{
    public partial class SavePictureParameters : Form
    {
        public SavePictureParameters()
        {
            InitializeComponent();
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            nudHeight.Value = nudWidth.Value;
        }

        public int PictureWidth
        {
            get
            {
                return (int)nudWidth.Value;
            }
        }

        public int PictureHeigth
        {
            get
            {
                return (int)nudHeight.Value;
            }
        }
    }
}
