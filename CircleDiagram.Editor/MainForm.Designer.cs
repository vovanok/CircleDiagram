using CircleDiagram.Editor.CustomControls;

namespace CircleDiagram.Editor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlDiagramView = new System.Windows.Forms.Panel();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveModel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveModelAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSavePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.tbRelationshipsList = new System.Windows.Forms.TabPage();
            this.lvRelationships = new CircleDiagram.Editor.CustomControls.CircleDiagramRelationshipsListView();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbAddRelationship = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteRelationship = new System.Windows.Forms.ToolStripButton();
            this.tbListNodes = new System.Windows.Forms.TabPage();
            this.tsNodesListOperations = new System.Windows.Forms.ToolStrip();
            this.tsbAddNode = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteNode = new System.Windows.Forms.ToolStripButton();
            this.pgNodeProperties = new System.Windows.Forms.PropertyGrid();
            this.lvNodes = new CircleDiagram.Editor.CustomControls.CircleDiagramNodesListView();
            this.tbMainSettings = new System.Windows.Forms.TabPage();
            this.pgMainProperties = new System.Windows.Forms.PropertyGrid();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tsRelationshipsListOperations = new System.Windows.Forms.ToolStrip();
            this.msMainMenu.SuspendLayout();
            this.tbRelationshipsList.SuspendLayout();
            this.tbListNodes.SuspendLayout();
            this.tsNodesListOperations.SuspendLayout();
            this.tbMainSettings.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tsRelationshipsListOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDiagramView
            // 
            this.pnlDiagramView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDiagramView.Location = new System.Drawing.Point(410, 27);
            this.pnlDiagramView.Name = "pnlDiagramView";
            this.pnlDiagramView.Size = new System.Drawing.Size(720, 590);
            this.pnlDiagramView.TabIndex = 5;
            this.pnlDiagramView.SizeChanged += new System.EventHandler(this.pnlDiagramView_SizeChanged);
            this.pnlDiagramView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlDiagramView_Paint);
            // 
            // btnRedraw
            // 
            this.btnRedraw.Location = new System.Drawing.Point(410, 3);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(77, 21);
            this.btnRedraw.TabIndex = 0;
            this.btnRedraw.Text = "Обновить";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(1130, 24);
            this.msMainMenu.TabIndex = 6;
            this.msMainMenu.Text = "Главное меню";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCreate,
            this.tsmiOpen,
            this.tsmiSaveModel,
            this.tsmiSaveModelAs,
            this.tsmiSavePicture});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiCreate
            // 
            this.tsmiCreate.Name = "tsmiCreate";
            this.tsmiCreate.Size = new System.Drawing.Size(209, 22);
            this.tsmiCreate.Text = "Создать";
            this.tsmiCreate.Click += new System.EventHandler(this.tsmiCreate_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(209, 22);
            this.tsmiOpen.Text = "Открыть";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // tsmiSaveModel
            // 
            this.tsmiSaveModel.Name = "tsmiSaveModel";
            this.tsmiSaveModel.Size = new System.Drawing.Size(209, 22);
            this.tsmiSaveModel.Text = "Сохранить схему";
            this.tsmiSaveModel.Click += new System.EventHandler(this.tsmiSaveModel_Click);
            // 
            // tsmiSaveModelAs
            // 
            this.tsmiSaveModelAs.Name = "tsmiSaveModelAs";
            this.tsmiSaveModelAs.Size = new System.Drawing.Size(209, 22);
            this.tsmiSaveModelAs.Text = "Созранить схему как...";
            this.tsmiSaveModelAs.Click += new System.EventHandler(this.tsmiSaveModelAs_Click);
            // 
            // tsmiSavePicture
            // 
            this.tsmiSavePicture.Name = "tsmiSavePicture";
            this.tsmiSavePicture.Size = new System.Drawing.Size(209, 22);
            this.tsmiSavePicture.Text = "Сохранить изображение";
            this.tsmiSavePicture.Click += new System.EventHandler(this.tsmiSavePicture_Click);
            // 
            // tbRelationshipsList
            // 
            this.tbRelationshipsList.Controls.Add(this.tsRelationshipsListOperations);
            this.tbRelationshipsList.Controls.Add(this.lvRelationships);
            this.tbRelationshipsList.Location = new System.Drawing.Point(4, 22);
            this.tbRelationshipsList.Name = "tbRelationshipsList";
            this.tbRelationshipsList.Padding = new System.Windows.Forms.Padding(3);
            this.tbRelationshipsList.Size = new System.Drawing.Size(400, 567);
            this.tbRelationshipsList.TabIndex = 2;
            this.tbRelationshipsList.Text = "Список связей";
            this.tbRelationshipsList.UseVisualStyleBackColor = true;
            // 
            // lvRelationships
            // 
            this.lvRelationships.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRelationships.Location = new System.Drawing.Point(3, 28);
            this.lvRelationships.MultiSelect = false;
            this.lvRelationships.Name = "lvRelationships";
            this.lvRelationships.ShowGroups = false;
            this.lvRelationships.Size = new System.Drawing.Size(394, 536);
            this.lvRelationships.TabIndex = 0;
            this.lvRelationships.UseCompatibleStateImageBehavior = false;
            this.lvRelationships.View = System.Windows.Forms.View.List;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(55, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(394, 25);
            this.miniToolStrip.TabIndex = 1;
            // 
            // tsbAddRelationship
            // 
            this.tsbAddRelationship.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddRelationship.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddRelationship.Image")));
            this.tsbAddRelationship.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddRelationship.Name = "tsbAddRelationship";
            this.tsbAddRelationship.Size = new System.Drawing.Size(23, 22);
            this.tsbAddRelationship.Text = "Добавить связь";
            this.tsbAddRelationship.Click += new System.EventHandler(this.tsbAddRelationship_Click);
            // 
            // tsbDeleteRelationship
            // 
            this.tsbDeleteRelationship.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteRelationship.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteRelationship.Image")));
            this.tsbDeleteRelationship.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteRelationship.Name = "tsbDeleteRelationship";
            this.tsbDeleteRelationship.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteRelationship.Text = "Удалить связь";
            this.tsbDeleteRelationship.Click += new System.EventHandler(this.tsbDeleteRelationship_Click);
            // 
            // tbListNodes
            // 
            this.tbListNodes.Controls.Add(this.lvNodes);
            this.tbListNodes.Controls.Add(this.pgNodeProperties);
            this.tbListNodes.Controls.Add(this.tsNodesListOperations);
            this.tbListNodes.Location = new System.Drawing.Point(4, 22);
            this.tbListNodes.Name = "tbListNodes";
            this.tbListNodes.Padding = new System.Windows.Forms.Padding(3);
            this.tbListNodes.Size = new System.Drawing.Size(400, 567);
            this.tbListNodes.TabIndex = 1;
            this.tbListNodes.Text = "Список узлов";
            this.tbListNodes.UseVisualStyleBackColor = true;
            // 
            // tsNodesListOperations
            // 
            this.tsNodesListOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddNode,
            this.tsbDeleteNode});
            this.tsNodesListOperations.Location = new System.Drawing.Point(3, 3);
            this.tsNodesListOperations.Name = "tsNodesListOperations";
            this.tsNodesListOperations.Size = new System.Drawing.Size(394, 25);
            this.tsNodesListOperations.TabIndex = 7;
            this.tsNodesListOperations.Text = "Операции над узлами";
            // 
            // tsbAddNode
            // 
            this.tsbAddNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddNode.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddNode.Image")));
            this.tsbAddNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddNode.Name = "tsbAddNode";
            this.tsbAddNode.Size = new System.Drawing.Size(23, 22);
            this.tsbAddNode.Text = "Добавить узел";
            this.tsbAddNode.Click += new System.EventHandler(this.tsbAddNode_Click);
            // 
            // tsbDeleteNode
            // 
            this.tsbDeleteNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteNode.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteNode.Image")));
            this.tsbDeleteNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteNode.Name = "tsbDeleteNode";
            this.tsbDeleteNode.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteNode.Text = "Удалить узел";
            this.tsbDeleteNode.Click += new System.EventHandler(this.tsbDeleteNode_Click);
            // 
            // pgNodeProperties
            // 
            this.pgNodeProperties.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgNodeProperties.HelpVisible = false;
            this.pgNodeProperties.Location = new System.Drawing.Point(3, 262);
            this.pgNodeProperties.Name = "pgNodeProperties";
            this.pgNodeProperties.Size = new System.Drawing.Size(394, 302);
            this.pgNodeProperties.TabIndex = 3;
            this.pgNodeProperties.ToolbarVisible = false;
            this.pgNodeProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgNodeProperties_PropertyValueChanged);
            // 
            // lvNodes
            // 
            this.lvNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvNodes.Location = new System.Drawing.Point(3, 31);
            this.lvNodes.MultiSelect = false;
            this.lvNodes.Name = "lvNodes";
            this.lvNodes.Size = new System.Drawing.Size(394, 225);
            this.lvNodes.TabIndex = 8;
            this.lvNodes.UseCompatibleStateImageBehavior = false;
            this.lvNodes.View = System.Windows.Forms.View.Tile;
            this.lvNodes.SelectedIndexChanged += new System.EventHandler(this.lvNodes_SelectedIndexChanged);
            // 
            // tbMainSettings
            // 
            this.tbMainSettings.Controls.Add(this.pgMainProperties);
            this.tbMainSettings.Location = new System.Drawing.Point(4, 22);
            this.tbMainSettings.Name = "tbMainSettings";
            this.tbMainSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbMainSettings.Size = new System.Drawing.Size(400, 567);
            this.tbMainSettings.TabIndex = 0;
            this.tbMainSettings.Text = "Основные настройки";
            this.tbMainSettings.UseVisualStyleBackColor = true;
            // 
            // pgMainProperties
            // 
            this.pgMainProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgMainProperties.HelpVisible = false;
            this.pgMainProperties.Location = new System.Drawing.Point(3, 3);
            this.pgMainProperties.Name = "pgMainProperties";
            this.pgMainProperties.Size = new System.Drawing.Size(394, 561);
            this.pgMainProperties.TabIndex = 0;
            this.pgMainProperties.ToolbarVisible = false;
            this.pgMainProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgMainProperties_PropertyValueChanged);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tbMainSettings);
            this.tcMain.Controls.Add(this.tbListNodes);
            this.tcMain.Controls.Add(this.tbRelationshipsList);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tcMain.Location = new System.Drawing.Point(0, 24);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(408, 593);
            this.tcMain.TabIndex = 0;
            // 
            // tsRelationshipsListOperations
            // 
            this.tsRelationshipsListOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddRelationship,
            this.tsbDeleteRelationship});
            this.tsRelationshipsListOperations.Location = new System.Drawing.Point(3, 3);
            this.tsRelationshipsListOperations.Name = "tsRelationshipsListOperations";
            this.tsRelationshipsListOperations.Size = new System.Drawing.Size(394, 25);
            this.tsRelationshipsListOperations.TabIndex = 1;
            this.tsRelationshipsListOperations.Text = "Операции над связями";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 617);
            this.Controls.Add(this.btnRedraw);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.pnlDiagramView);
            this.Controls.Add(this.msMainMenu);
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "MainForm";
            this.Text = "Редактор круговых диаграмм-схем";
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.tbRelationshipsList.ResumeLayout(false);
            this.tbRelationshipsList.PerformLayout();
            this.tbListNodes.ResumeLayout(false);
            this.tbListNodes.PerformLayout();
            this.tsNodesListOperations.ResumeLayout(false);
            this.tsNodesListOperations.PerformLayout();
            this.tbMainSettings.ResumeLayout(false);
            this.tcMain.ResumeLayout(false);
            this.tsRelationshipsListOperations.ResumeLayout(false);
            this.tsRelationshipsListOperations.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDiagramView;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveModel;
        private System.Windows.Forms.ToolStripMenuItem tsmiCreate;
        private System.Windows.Forms.ToolStripMenuItem tsmiSavePicture;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveModelAs;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.TabPage tbRelationshipsList;
        private System.Windows.Forms.ToolStrip tsRelationshipsListOperations;
        private System.Windows.Forms.ToolStripButton tsbAddRelationship;
        private System.Windows.Forms.ToolStripButton tsbDeleteRelationship;
        private CircleDiagramRelationshipsListView lvRelationships;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.TabPage tbListNodes;
        private CircleDiagramNodesListView lvNodes;
        private System.Windows.Forms.PropertyGrid pgNodeProperties;
        private System.Windows.Forms.ToolStrip tsNodesListOperations;
        private System.Windows.Forms.ToolStripButton tsbAddNode;
        private System.Windows.Forms.ToolStripButton tsbDeleteNode;
        private System.Windows.Forms.TabPage tbMainSettings;
        private System.Windows.Forms.PropertyGrid pgMainProperties;
        private System.Windows.Forms.TabControl tcMain;
    }
}

