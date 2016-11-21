using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using CircleDiagram.Editor.Dialogs;
using CircleDiagram.Editor.PropertiesAggregators;
using CircleDiagram.Editor.Utils;
using CircleDiagram.Graphic;
using CircleDiagram.InputOutput;
using CircleDiagram.Main;

namespace CircleDiagram.Editor
{
    public sealed partial class MainForm : Form
    {
        #region Rod parameters

        private readonly CircleDiagramModel CircleDiagramModel = new CircleDiagramModel();

        #endregion

        #region Machines

        private readonly CircleDiagramGraphicalMachine GraphicalMachine;
        private readonly CircleDiagramInputOutputMachine InputOutputMachine;

        #endregion

        #region Propeties editors

        private readonly CircleDiagramNodeProperies NodePropeties = new CircleDiagramNodeProperies();
        private readonly CircleDiagramMainProperies MainPropeties = new CircleDiagramMainProperies();
        
        #endregion
        
        #region Saving parameters

        private string CurrentModelFileName;

        #endregion

        #region State parameters

        private Graphics WorkGraphics;

        #endregion

        #region Ctor

        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            lvNodes.SetCircleDiagramModel(CircleDiagramModel);
            lvRelationships.SetCircleDiagramModel(CircleDiagramModel);

            pgNodeProperties.SelectedObject = NodePropeties;
            pgMainProperties.SelectedObject = MainPropeties;

            GraphicalMachine = new CircleDiagramGraphicalMachine(CircleDiagramModel);
            InputOutputMachine = new CircleDiagramInputOutputMachine(CircleDiagramModel);

            CreateNew();
        }

        #endregion

        #region Properties editing

        private void UpdateNodeAfterEditing()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            var targetNode = CircleDiagramModel.FindNodeByName(NodePropeties.Name);
            if (targetNode == null) return;
            NodePropeties.SetNodePropertiesToCircleDiagramNode(targetNode);
            var targetItem = lvNodes.Items[targetNode.Name];
            if (targetItem == null) return;
            targetItem.Text = targetNode.Text.Replace("\r\n", " ");
            var group = lvNodes.Groups[targetNode.StartCircleNumber.ToString()];
            if (group != null)
                targetItem.Group = group;
            else
            {
                var noneGroup = lvNodes.Groups[Consts.NoneGroup];
                if (noneGroup != null)
                    targetItem.Group = noneGroup;
            }
            RedrawDiagramOnControl();
        }

        private void UpdateMainSettingsAfterEditing()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            var oldLevelsCount = CircleDiagramModel.CountLevels;
            MainPropeties.SetMainPropertiesToCircleDiagramModel(CircleDiagramModel);
            var newLevelsCount = CircleDiagramModel.CountLevels;
            if (oldLevelsCount != newLevelsCount)
                lvNodes.UpdateGroups();
            RedrawDiagramOnControl();
        }

        #endregion

        #region Nodes list box operations

        private void AddNode()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;

            var newNode = new CircleDiagramNode("Новая вершина",
                0, 0, 0, 1, new SolidBrush(Color.Red), new SolidBrush(Color.Black), new Font("Verdana", 10));
            if (CircleDiagramModel.AddNode(newNode))
                lvNodes.AddCircleDiagramNode(newNode);
            RedrawDiagramOnControl();
        }

        private void DeleteSelectedNode()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            var targetNode = lvNodes.GetSelectedCircleDiagramNode();
            if (targetNode == null) return;
            if (CircleDiagramModel.DeleteNode(targetNode))
                lvNodes.Items.RemoveByKey(targetNode.Name);
            RedrawDiagramOnControl();
        }

        private void SelectNode()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect() || NodePropeties == null) return;

            var targetNode = lvNodes.GetSelectedCircleDiagramNode();
            if (targetNode == null) return;

            NodePropeties.GetNodePropertiesFromCircleDiagramNode(targetNode);
            pgNodeProperties.Refresh();
        }

        #endregion

        #region Relationships list box operations

        private void AddRelationship()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;

            var relationshipParameters = new RelationshipParameters
                {
                    Nodes = CircleDiagramModel.Nodes,
                    Relationships = CircleDiagramModel.Relationships
                };
            if (relationshipParameters.ShowDialog() != DialogResult.OK) return;

            var newRelationship = new CircleDiagramRelationship(
                relationshipParameters.BeginNode,
                relationshipParameters.EndNode);

            if (CircleDiagramModel.AddRelationship(newRelationship))
                lvRelationships.AddCircleDiagramRelationship(newRelationship);

            RedrawDiagramOnControl();
        }

        private void DeleteSelectedRelationship()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            var targetRelationship = lvRelationships.GetSelectedCircleDiagramRelationship();
            if (targetRelationship == null) return;
            if (CircleDiagramModel.DeleteRelationship(targetRelationship))
                lvRelationships.Items.RemoveByKey(targetRelationship.Name);
            RedrawDiagramOnControl();
        }

        #endregion

        #region Save load new operations

        private void CreateNew()
        {
            if (CircleDiagramModel == null || !CircleDiagramModel.IsCorrect()) return;
            var whiteBrush = new SolidBrush(Color.White);
            var blackBlush = new SolidBrush(Color.Black);
            var nodes = new List<CircleDiagramNode> 
            { 
                new CircleDiagramNode("Центр", 0, 0, 0, 1,
                    new SolidBrush(Color.Red), blackBlush, new Font("Verdana", 10))
            };
            var relationship = new List<CircleDiagramRelationship>();
            CircleDiagramModel.ChangeParametersValues(
                1, whiteBrush, new SolidBrush(Color.LightGray), whiteBrush, 
                new Pen(blackBlush, 3), new Pen(blackBlush, 1), new Pen(blackBlush, 1),
                new SolidBrush(Color.Black), new Font("Verdana", 10), 1, false,
                nodes, relationship);

            lvNodes.UpdateContent();
            lvRelationships.UpdateContent();
            MainPropeties.GetMainPropertiesFromCircleDiagramModel(CircleDiagramModel);
            lvNodes.SelectItemByDefault();
            CurrentModelFileName = null;
            RedrawDiagramOnControl();
        }

        private void SaveFile()
        {
            if (!string.IsNullOrEmpty(CurrentModelFileName)
                && File.Exists(CurrentModelFileName))
            {
                SaveWithFilename(CurrentModelFileName);
            }
            else
            {
                SaveFileAs();
            }
        }

        private void SaveFileAs()
        {
            try
            {
                var sfDlg = new SaveFileDialog
                {
                    Title = @"Open Image Files",
                    Filter = @"XML файл|*.xml"
                };
                if (sfDlg.ShowDialog() == DialogResult.OK)
                {
                    var fileName = sfDlg.FileName;
                    SaveWithFilename(fileName);
                }
            }
            catch (Exception)
            {
                SaveFileError();
            }
        }

        private void SaveWithFilename(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                SaveFileError();
                return;
            }
            Cursor = Cursors.WaitCursor;
            try
            {
                if (InputOutputMachine.Save(fileName))
                    CurrentModelFileName = fileName;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private static void SaveFileError()
        {
            MessageBox.Show(@"Ошибка сохранения файла");
        }

        private void LoadFile()
        {
            var lfDlg = new OpenFileDialog
                            {
                                Filter = @"XML файл|*.xml"
                            };

            if (lfDlg.ShowDialog() != DialogResult.OK) return;

            var fileName = lfDlg.FileName;
            if (string.IsNullOrEmpty(fileName))
            {
                LoadFileError();
                return;
            }
            Cursor = Cursors.WaitCursor;
            bool loadResult;
            try
            {
                loadResult = InputOutputMachine.Load(fileName);
            }
            catch(Exception)
            {
                LoadFileError();
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
                    
            if (!loadResult)
            {
                LoadFileError();
                return;
            }

            lvNodes.UpdateContent();
            lvRelationships.UpdateContent();
            MainPropeties.GetMainPropertiesFromCircleDiagramModel(CircleDiagramModel);
            lvNodes.SelectItemByDefault();
            pgMainProperties.Refresh();
            CurrentModelFileName = fileName;
            RedrawDiagramOnControl();
        }

        private static void LoadFileError()
        {
            MessageBox.Show(@"Ошибка загрузки файла");
        }

        #endregion

        #region Drawing operations

        private void SaveImageFile()
        {
            if (GraphicalMachine == null) return;
            var paramsDlg = new SavePictureParameters();
            if (paramsDlg.ShowDialog() != DialogResult.OK) return;
            var width = paramsDlg.PictureWidth;
            var height = paramsDlg.PictureHeigth;

            var sfdlg = new SaveFileDialog
                            {
                                Title = @"Выберете путь к файлу",
                                Filter = @"BMP файл|*.bmp|JPG файл|*.jpg|JPEG файл|*.jpeg|PNG файл|*.png"
                            };
            if (sfdlg.ShowDialog() != DialogResult.OK) return;

            var fileName = sfdlg.FileName;
            ImageFormat imageFormat;
            switch (Path.GetExtension(fileName))
            {
                case ".bmp":
                    imageFormat = ImageFormat.Bmp;
                    break;
                case ".jpg":
                case ".jpeg":
                    imageFormat = ImageFormat.Jpeg;
                    break;
                case ".png":
                    imageFormat = ImageFormat.Png;
                    break;
                default:
                    MessageBox.Show(
                        @"Некорректный тип файла. Допускается сохранение в следующих форматах: bmp, jpeg, png");
                    return;
            }

            var bitmap = new Bitmap(width, height);
            var graphics = Graphics.FromImage(bitmap);
            GraphicalMachine.RedrawDiagram(graphics, Color.Empty);
            try
            {
                Cursor = Cursors.WaitCursor;
                bitmap.Save(fileName, imageFormat);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void RedrawDiagramOnControl()
        {
            if (GraphicalMachine == null) return;
            GraphicalMachine.RedrawDiagram(
                pnlDiagramView.CreateGraphics(), 
                pnlDiagramView.BackColor);
        }

        private void QuickRedrawDiagramOnControl()
        {
            if (GraphicalMachine == null || WorkGraphics == null) return;
            GraphicalMachine.QuickRedrawDiagram(
                WorkGraphics,
                pnlDiagramView.BackColor);
        }

        #endregion

        #region Events handlers

        private void pgNodeProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdateNodeAfterEditing();
        }

        private void pgMainProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            UpdateMainSettingsAfterEditing();
        }

        private void tsmiCreate_Click(object sender, EventArgs e)
        {
            CreateNew();
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void tsmiSaveModel_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void tsmiSaveModelAs_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void tsmiSavePicture_Click(object sender, EventArgs e)
        {
            SaveImageFile();
        }

        private void tsbAddNode_Click(object sender, EventArgs e)
        {
            AddNode();
        }

        private void tsbDeleteNode_Click(object sender, EventArgs e)
        {
            DeleteSelectedNode();
        }

        private void btnRedraw_Click(object sender, EventArgs e)
        {
            RedrawDiagramOnControl();
        }

        private void lvNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectNode();
        }

        private void tsbAddRelationship_Click(object sender, EventArgs e)
        {
            AddRelationship();
        }

        private void tsbDeleteRelationship_Click(object sender, EventArgs e)
        {
            DeleteSelectedRelationship();
        }

        private void pnlDiagramView_Paint(object sender, PaintEventArgs e)
        {
            WorkGraphics = e.Graphics;
            QuickRedrawDiagramOnControl();
        }

        private void pnlDiagramView_SizeChanged(object sender, EventArgs e)
        {
            RedrawDiagramOnControl();
        }

        #endregion
    }
}
