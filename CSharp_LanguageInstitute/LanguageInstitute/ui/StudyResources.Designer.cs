
namespace LanguageInstitute.ui
{
    partial class StudyResources
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiSymbolLabel9 = new Sunny.UI.UISymbolLabel();
            this.btnSearch = new Sunny.UI.UISymbolButton();
            this.txtSearch = new CxFlatUI.CxFlatTextBox();
            this.dataGridView = new Sunny.UI.UIDataGridView();
            this.videoSearchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.videoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.thumbnailDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urlDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoSearchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uiSymbolLabel9
            // 
            this.uiSymbolLabel9.BackColor = System.Drawing.Color.Transparent;
            this.uiSymbolLabel9.Font = new System.Drawing.Font("Kristen ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiSymbolLabel9.ForeColor = System.Drawing.Color.Plum;
            this.uiSymbolLabel9.Location = new System.Drawing.Point(12, 12);
            this.uiSymbolLabel9.MinimumSize = new System.Drawing.Size(1, 2);
            this.uiSymbolLabel9.Name = "uiSymbolLabel9";
            this.uiSymbolLabel9.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.uiSymbolLabel9.Size = new System.Drawing.Size(619, 40);
            this.uiSymbolLabel9.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolLabel9.Symbol = 57553;
            this.uiSymbolLabel9.SymbolColor = System.Drawing.Color.PaleTurquoise;
            this.uiSymbolLabel9.SymbolSize = 35;
            this.uiSymbolLabel9.TabIndex = 73;
            this.uiSymbolLabel9.Text = "Study Resources (YouTube)";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.btnSearch.Location = new System.Drawing.Point(725, 87);
            this.btnSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(147, 58);
            this.btnSearch.TabIndex = 75;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Hint = "검색어를 입력하세요";
            this.txtSearch.Location = new System.Drawing.Point(29, 97);
            this.txtSearch.MaxLength = 32767;
            this.txtSearch.Multiline = false;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSearch.SelectedText = "";
            this.txtSearch.SelectionLength = 0;
            this.txtSearch.SelectionStart = 0;
            this.txtSearch.Size = new System.Drawing.Size(679, 48);
            this.txtSearch.TabIndex = 76;
            this.txtSearch.TabStop = false;
            this.txtSearch.UseSystemPasswordChar = false;
            // 
            // dataGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeight = 32;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.thumbnailDataGridViewImageColumn,
            this.titleDataGridViewTextBoxColumn,
            this.authorDataGridViewTextBoxColumn,
            this.urlDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.videoBindingSource;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.dataGridView.Location = new System.Drawing.Point(18, 182);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowHeadersWidth = 62;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.SelectedIndex = -1;
            this.dataGridView.ShowGridLine = true;
            this.dataGridView.Size = new System.Drawing.Size(862, 446);
            this.dataGridView.TabIndex = 77;
            // 
            // videoSearchBindingSource
            // 
            this.videoSearchBindingSource.DataSource = typeof(YoutubeSearch.VideoSearch);
            // 
            // videoBindingSource
            // 
            this.videoBindingSource.DataSource = typeof(LanguageInstitute.ui.Video);
            // 
            // thumbnailDataGridViewImageColumn
            // 
            this.thumbnailDataGridViewImageColumn.DataPropertyName = "Thumbnail";
            this.thumbnailDataGridViewImageColumn.HeaderText = "Thumbnail";
            this.thumbnailDataGridViewImageColumn.MinimumWidth = 8;
            this.thumbnailDataGridViewImageColumn.Name = "thumbnailDataGridViewImageColumn";
            this.thumbnailDataGridViewImageColumn.Width = 150;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Width = 150;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            this.authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
            this.authorDataGridViewTextBoxColumn.HeaderText = "Author";
            this.authorDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            this.authorDataGridViewTextBoxColumn.Width = 150;
            // 
            // urlDataGridViewTextBoxColumn
            // 
            this.urlDataGridViewTextBoxColumn.DataPropertyName = "Url";
            this.urlDataGridViewTextBoxColumn.HeaderText = "Url";
            this.urlDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.urlDataGridViewTextBoxColumn.Name = "urlDataGridViewTextBoxColumn";
            this.urlDataGridViewTextBoxColumn.Width = 150;
            // 
            // StudyResources
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 691);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.uiSymbolLabel9);
            this.Name = "StudyResources";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoSearchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UISymbolLabel uiSymbolLabel9;
        private Sunny.UI.UISymbolButton btnSearch;
        private CxFlatUI.CxFlatTextBox txtSearch;
        private Sunny.UI.UIDataGridView dataGridView;
        private System.Windows.Forms.BindingSource videoSearchBindingSource;
        private System.Windows.Forms.DataGridViewImageColumn thumbnailDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource videoBindingSource;
    }
}