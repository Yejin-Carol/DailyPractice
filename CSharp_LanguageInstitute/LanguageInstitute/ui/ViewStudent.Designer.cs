
namespace LanguageInstitute.ui
{
    partial class ViewStudent
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
            this.btnLoad = new Sunny.UI.UIButton();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cxFlatPictureBox1 = new CxFlatUI.CxFlatPictureBox();
            this.lbFileName = new Sunny.UI.UILabel();
            this.btnSave = new Sunny.UI.UIButton();
            this.btnOpen = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.cxFlatPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnLoad.Location = new System.Drawing.Point(239, 197);
            this.btnLoad.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 35);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.uiLabel1.Location = new System.Drawing.Point(12, 244);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 1;
            this.uiLabel1.Text = "Filename";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listView1
            // 
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 431);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(542, 243);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // cxFlatPictureBox1
            // 
            this.cxFlatPictureBox1.Location = new System.Drawing.Point(12, 76);
            this.cxFlatPictureBox1.Name = "cxFlatPictureBox1";
            this.cxFlatPictureBox1.Size = new System.Drawing.Size(208, 156);
            this.cxFlatPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cxFlatPictureBox1.TabIndex = 4;
            this.cxFlatPictureBox1.TabStop = false;
            // 
            // lbFileName
            // 
            this.lbFileName.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.lbFileName.Location = new System.Drawing.Point(118, 244);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(100, 23);
            this.lbFileName.TabIndex = 5;
            this.lbFileName.Text = "?";
            this.lbFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnSave.Location = new System.Drawing.Point(239, 156);
            this.btnSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            // 
            // btnOpen
            // 
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnOpen.Location = new System.Drawing.Point(239, 115);
            this.btnOpen.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 35);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "Open";
            // 
            // ViewStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 702);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.cxFlatPictureBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.btnLoad);
            this.Name = "ViewStudent";
            this.Text = "ViewStudent";
            ((System.ComponentModel.ISupportInitialize)(this.cxFlatPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton btnLoad;
        private Sunny.UI.UILabel uiLabel1;
        private System.Windows.Forms.ListView listView1;
        private CxFlatUI.CxFlatPictureBox cxFlatPictureBox1;
        private Sunny.UI.UILabel lbFileName;
        private Sunny.UI.UIButton btnSave;
        private Sunny.UI.UIButton btnOpen;
    }
}