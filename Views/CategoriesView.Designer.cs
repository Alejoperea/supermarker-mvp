namespace Supermarket_mvp.Views
{
    partial class CategoriesView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriesView));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPageCategoriesList = new TabPage();
            BtnClose = new Button();
            BtnDelete = new Button();
            BtnEdit = new Button();
            BtnNew = new Button();
            DgCategories = new DataGridView();
            BtnSearch = new Button();
            TxtSearch = new TextBox();
            label2 = new Label();
            tabPageCategoriesDetail = new TabPage();
            TxtCategoriesObservation = new TextBox();
            TxtCategoriesName = new TextBox();
            TxtCategoriesId = new TextBox();
            BtnCancel = new Button();
            BtnSave = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabPageCategoriesList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgCategories).BeginInit();
            tabPageCategoriesDetail.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 100);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(28, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(169, 23);
            label1.Name = "label1";
            label1.Size = new Size(207, 50);
            label1.TabIndex = 0;
            label1.Text = "Categories";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageCategoriesList);
            tabControl1.Controls.Add(tabPageCategoriesDetail);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 100);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 350);
            tabControl1.TabIndex = 1;
            // 
            // tabPageCategoriesList
            // 
            tabPageCategoriesList.Controls.Add(BtnClose);
            tabPageCategoriesList.Controls.Add(BtnDelete);
            tabPageCategoriesList.Controls.Add(BtnEdit);
            tabPageCategoriesList.Controls.Add(BtnNew);
            tabPageCategoriesList.Controls.Add(DgCategories);
            tabPageCategoriesList.Controls.Add(BtnSearch);
            tabPageCategoriesList.Controls.Add(TxtSearch);
            tabPageCategoriesList.Controls.Add(label2);
            tabPageCategoriesList.Location = new Point(4, 24);
            tabPageCategoriesList.Name = "tabPageCategoriesList";
            tabPageCategoriesList.Padding = new Padding(3);
            tabPageCategoriesList.Size = new Size(792, 322);
            tabPageCategoriesList.TabIndex = 0;
            tabPageCategoriesList.Text = "Categories List ";
            tabPageCategoriesList.UseVisualStyleBackColor = true;
            // 
            // BtnClose
            // 
            BtnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnClose.Image = Properties.Resources.cerrar;
            BtnClose.Location = new Point(583, 259);
            BtnClose.Name = "BtnClose";
            BtnClose.Size = new Size(125, 39);
            BtnClose.TabIndex = 7;
            BtnClose.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            BtnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnDelete.Image = Properties.Resources.delete;
            BtnDelete.Location = new Point(583, 199);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(125, 42);
            BtnDelete.TabIndex = 6;
            BtnDelete.UseVisualStyleBackColor = true;
            // 
            // BtnEdit
            // 
            BtnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnEdit.Image = Properties.Resources.edit;
            BtnEdit.Location = new Point(583, 137);
            BtnEdit.Name = "BtnEdit";
            BtnEdit.Size = new Size(125, 44);
            BtnEdit.TabIndex = 5;
            BtnEdit.UseVisualStyleBackColor = true;
            // 
            // BtnNew
            // 
            BtnNew.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnNew.Image = Properties.Resources._new;
            BtnNew.Location = new Point(583, 76);
            BtnNew.Name = "BtnNew";
            BtnNew.Size = new Size(125, 42);
            BtnNew.TabIndex = 4;
            BtnNew.UseVisualStyleBackColor = true;
            // 
            // DgCategories
            // 
            DgCategories.AllowUserToAddRows = false;
            DgCategories.AllowUserToDeleteRows = false;
            DgCategories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DgCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DgCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgCategories.Location = new Point(23, 76);
            DgCategories.Name = "DgCategories";
            DgCategories.ReadOnly = true;
            DgCategories.RowTemplate.Height = 25;
            DgCategories.Size = new Size(511, 222);
            DgCategories.TabIndex = 3;
            // 
            // BtnSearch
            // 
            BtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnSearch.Image = Properties.Resources.search_small;
            BtnSearch.Location = new Point(493, 27);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(75, 40);
            BtnSearch.TabIndex = 2;
            BtnSearch.UseVisualStyleBackColor = true;
            // 
            // TxtSearch
            // 
            TxtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TxtSearch.Location = new Point(24, 37);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.PlaceholderText = "Data to search";
            TxtSearch.Size = new Size(451, 23);
            TxtSearch.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 19);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 0;
            label2.Text = "Search Categories";
            // 
            // tabPageCategoriesDetail
            // 
            tabPageCategoriesDetail.Controls.Add(TxtCategoriesObservation);
            tabPageCategoriesDetail.Controls.Add(TxtCategoriesName);
            tabPageCategoriesDetail.Controls.Add(TxtCategoriesId);
            tabPageCategoriesDetail.Controls.Add(BtnCancel);
            tabPageCategoriesDetail.Controls.Add(BtnSave);
            tabPageCategoriesDetail.Controls.Add(label5);
            tabPageCategoriesDetail.Controls.Add(label4);
            tabPageCategoriesDetail.Controls.Add(label3);
            tabPageCategoriesDetail.Location = new Point(4, 24);
            tabPageCategoriesDetail.Name = "tabPageCategoriesDetail";
            tabPageCategoriesDetail.Padding = new Padding(3);
            tabPageCategoriesDetail.Size = new Size(792, 322);
            tabPageCategoriesDetail.TabIndex = 1;
            tabPageCategoriesDetail.Text = "Categories Detail";
            tabPageCategoriesDetail.UseVisualStyleBackColor = true;
            // 
            // TxtCategoriesObservation
            // 
            TxtCategoriesObservation.Location = new Point(24, 175);
            TxtCategoriesObservation.Multiline = true;
            TxtCategoriesObservation.Name = "TxtCategoriesObservation";
            TxtCategoriesObservation.PlaceholderText = "Categories Observation";
            TxtCategoriesObservation.Size = new Size(230, 49);
            TxtCategoriesObservation.TabIndex = 7;
            // 
            // TxtCategoriesName
            // 
            TxtCategoriesName.Location = new Point(24, 101);
            TxtCategoriesName.Name = "TxtCategoriesName";
            TxtCategoriesName.PlaceholderText = "Categories Name";
            TxtCategoriesName.Size = new Size(178, 23);
            TxtCategoriesName.TabIndex = 6;
            // 
            // TxtCategoriesId
            // 
            TxtCategoriesId.Location = new Point(24, 33);
            TxtCategoriesId.Name = "TxtCategoriesId";
            TxtCategoriesId.ReadOnly = true;
            TxtCategoriesId.Size = new Size(100, 23);
            TxtCategoriesId.TabIndex = 5;
            TxtCategoriesId.Text = "0";
            TxtCategoriesId.TextAlign = HorizontalAlignment.Right;
            // 
            // BtnCancel
            // 
            BtnCancel.Image = Properties.Resources.cancel;
            BtnCancel.Location = new Point(144, 244);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(75, 38);
            BtnCancel.TabIndex = 4;
            BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            BtnSave.Image = Properties.Resources.save;
            BtnSave.Location = new Point(38, 244);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(75, 38);
            BtnSave.TabIndex = 3;
            BtnSave.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 157);
            label5.Name = "label5";
            label5.Size = new Size(130, 15);
            label5.TabIndex = 2;
            label5.Text = "Categories Observation";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 83);
            label4.Name = "label4";
            label4.Size = new Size(98, 15);
            label4.TabIndex = 1;
            label4.Text = "Categories Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 15);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 0;
            label3.Text = "Categories Id";
            // 
            // CategoriesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "CategoriesView";
            Text = "Categories Management";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageCategoriesList.ResumeLayout(false);
            tabPageCategoriesList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgCategories).EndInit();
            tabPageCategoriesDetail.ResumeLayout(false);
            tabPageCategoriesDetail.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private TabControl tabControl1;
        private TabPage tabPageCategoriesList;
        private TabPage tabPageCategoriesDetail;
        private Label label2;
        private Button BtnSearch;
        private TextBox TxtSearch;
        private Button BtnClose;
        private Button BtnDelete;
        private Button BtnEdit;
        private Button BtnNew;
        private DataGridView DgCategories;
        private TextBox TxtCategoriesObservation;
        private TextBox TxtCategoriesName;
        private TextBox TxtCategoriesId;
        private Button BtnCancel;
        private Button BtnSave;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}