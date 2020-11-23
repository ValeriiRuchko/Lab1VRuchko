
namespace Lab1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.AddColumnB = new System.Windows.Forms.ToolStripButton();
            this.DeleteColumnB = new System.Windows.Forms.ToolStripButton();
            this.AddRowB = new System.Windows.Forms.ToolStripButton();
            this.DeleteRowB = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(740, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(158, 34);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(158, 34);
            this.saveToolStripMenuItem.Text = "Save ";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(65, 29);
            this.aboutToolStripMenuItem.Text = "Help";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeight = 34;
            this.dgv.Location = new System.Drawing.Point(0, 79);
            this.dgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 62;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.Size = new System.Drawing.Size(740, 294);
            this.dgv.TabIndex = 3;
            this.dgv.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgv_CellBeginEdit);
            this.dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellDoubleClick);
            this.dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCellEndEdit);
            // 
            // AddColumnB
            // 
            this.AddColumnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddColumnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddColumnB.Name = "AddColumnB";
            this.AddColumnB.Size = new System.Drawing.Size(117, 29);
            this.AddColumnB.Text = "Add Column";
            this.AddColumnB.Click += new System.EventHandler(this.AddColumnB_Click);
            // 
            // DeleteColumnB
            // 
            this.DeleteColumnB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteColumnB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteColumnB.Name = "DeleteColumnB";
            this.DeleteColumnB.Size = new System.Drawing.Size(133, 29);
            this.DeleteColumnB.Text = "Delete Column";
            this.DeleteColumnB.Click += new System.EventHandler(this.DeleteColumnB_Click);
            // 
            // AddRowB
            // 
            this.AddRowB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddRowB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddRowB.Name = "AddRowB";
            this.AddRowB.Size = new System.Drawing.Size(89, 29);
            this.AddRowB.Text = "Add Row";
            this.AddRowB.Click += new System.EventHandler(this.AddRowB_Click);
            // 
            // DeleteRowB
            // 
            this.DeleteRowB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DeleteRowB.Image = ((System.Drawing.Image)(resources.GetObject("DeleteRowB.Image")));
            this.DeleteRowB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteRowB.Name = "DeleteRowB";
            this.DeleteRowB.Size = new System.Drawing.Size(105, 29);
            this.DeleteRowB.Text = "Delete Row";
            this.DeleteRowB.Click += new System.EventHandler(this.DeleteRowB_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddColumnB,
            this.DeleteColumnB,
            this.AddRowB,
            this.DeleteRowB});
            this.toolStrip2.Location = new System.Drawing.Point(0, 33);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(740, 34);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 376);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "MyExcel";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStripButton AddColumnB;
        private System.Windows.Forms.ToolStripButton DeleteColumnB;
        private System.Windows.Forms.ToolStripButton AddRowB;
        private System.Windows.Forms.ToolStripButton DeleteRowB;
        private System.Windows.Forms.ToolStrip toolStrip2;
    }
}

