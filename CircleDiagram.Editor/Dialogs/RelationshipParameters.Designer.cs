namespace CircleDiagram.Editor.Dialogs
{
    partial class RelationshipParameters
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
            this.lblBeginNode = new System.Windows.Forms.Label();
            this.cbBeginNode = new System.Windows.Forms.ComboBox();
            this.lblEndNode = new System.Windows.Forms.Label();
            this.cbEndNode = new System.Windows.Forms.ComboBox();
            this.lblArrow = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBeginNode
            // 
            this.lblBeginNode.AutoSize = true;
            this.lblBeginNode.Location = new System.Drawing.Point(9, 9);
            this.lblBeginNode.Name = "lblBeginNode";
            this.lblBeginNode.Size = new System.Drawing.Size(109, 13);
            this.lblBeginNode.TabIndex = 0;
            this.lblBeginNode.Text = "Начальная вершина";
            // 
            // cbBeginNode
            // 
            this.cbBeginNode.FormattingEnabled = true;
            this.cbBeginNode.Location = new System.Drawing.Point(12, 25);
            this.cbBeginNode.Name = "cbBeginNode";
            this.cbBeginNode.Size = new System.Drawing.Size(224, 21);
            this.cbBeginNode.TabIndex = 1;
            // 
            // lblEndNode
            // 
            this.lblEndNode.AutoSize = true;
            this.lblEndNode.Location = new System.Drawing.Point(261, 9);
            this.lblEndNode.Name = "lblEndNode";
            this.lblEndNode.Size = new System.Drawing.Size(102, 13);
            this.lblEndNode.TabIndex = 2;
            this.lblEndNode.Text = "Конечная вершина";
            // 
            // cbEndNode
            // 
            this.cbEndNode.FormattingEnabled = true;
            this.cbEndNode.Location = new System.Drawing.Point(264, 25);
            this.cbEndNode.Name = "cbEndNode";
            this.cbEndNode.Size = new System.Drawing.Size(224, 21);
            this.cbEndNode.TabIndex = 3;
            // 
            // lblArrow
            // 
            this.lblArrow.AutoSize = true;
            this.lblArrow.Location = new System.Drawing.Point(242, 28);
            this.lblArrow.Name = "lblArrow";
            this.lblArrow.Size = new System.Drawing.Size(16, 13);
            this.lblArrow.TabIndex = 4;
            this.lblArrow.Text = "->";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(333, 52);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(414, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // RelationshipParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 83);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblArrow);
            this.Controls.Add(this.cbEndNode);
            this.Controls.Add(this.lblEndNode);
            this.Controls.Add(this.cbBeginNode);
            this.Controls.Add(this.lblBeginNode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RelationshipParameters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры связи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBeginNode;
        private System.Windows.Forms.ComboBox cbBeginNode;
        private System.Windows.Forms.Label lblEndNode;
        private System.Windows.Forms.ComboBox cbEndNode;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}