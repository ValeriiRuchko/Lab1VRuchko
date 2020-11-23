using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        bool formulaView;
        string currenPath = "";
        public Form1(string[] args)
        {
            InitializeComponent();
            CellManager.Instance.ProvideDataGridView(dgv);
            SetupDataGridView(5, 5);    //table size at the start
            formulaView = false;
            if(args.Length == 1)
            {
                LoadDGV(args[0]);
            }
        }

        private void SetupDataGridView(int columns, int rows)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance |
                BindingFlags.SetProperty, null, dgv, new object[] { true });
            dgv.AllowUserToAddRows = false;
            dgv.ColumnCount = columns;
            dgv.RowCount = rows;
            UpdateDGV();
        }

        private void AddRow()
        {
            dgv.RowCount += 1;
            UpdateDGV();
        }

        private void DeleteRow()
        {
            DialogResult result = MessageBox.Show("Ви дійсно хочете видалити цей рядок?", "Delete Row", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                if(dgv.RowCount > 1)
                {
                    DataGridViewCell dgvCell = dgv.SelectedCells[0];
                    dgv.Rows.RemoveAt(dgvCell.RowIndex);
                }

                UpdateDGV();
                UpdateCellValues();
            }
            else { }  
        }


        private void AddColumn()
        {
            dgv.ColumnCount += 1;
            UpdateDGV();
        }

        private void DeleteColumn()
        {
            DialogResult result = MessageBox.Show("Ви дійсно хочете видалити цей рядок?", "Delete Column", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (dgv.ColumnCount > 1)
                {
                    DataGridViewCell dgvCell = dgv.SelectedCells[0];
                    dgv.Columns.RemoveAt(dgvCell.ColumnIndex);
                }

                UpdateDGV();
                UpdateCellValues();
            }
            else { }
        }

        private void UpdateDGV()
        {
            foreach(DataGridViewColumn column in dgv.Columns)
            {
                column.HeaderText = "C" + (column.Index + 1);
                column.MinimumWidth = 100;
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = "R" + (row.Index + 1);
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell dgvCell in row.Cells)
                {
                    if (dgvCell.Tag == null)
                    {
                        dgvCell.Tag = new Cell(dgvCell, "");
                    }
                }
                    
            }
        }

        public void UpdateCellValues()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell dgvCell in row.Cells)
                {
                    Cell cell = (Cell)dgvCell.Tag;
                    cell.Calculate();
                    if (!formulaView)
                    {
                        if (cell.Formula == "")
                        {
                            dgvCell.Value = cell.Formula;
                        }
                        else
                        {
                            dgvCell.Value = cell.Value.ToString();
                        }
                    }
                }
            }
        }
        
        private void SaveDGV(string path)       //saving file
        {
            currenPath = path;
            dgv.EndEdit();
            DataTable table = new DataTable("data");
            foreach(DataGridViewColumn col in dgv.Columns)
            {
                table.Columns.Add(col.Index.ToString());
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow drNewRow = table.NewRow();
                foreach (DataColumn col in table.Columns)
                {
                    drNewRow[col.ColumnName] = CellManager.Instance.GetCell(row.Cells[Int32.Parse(col.ColumnName)]).Formula;
                }
                table.Rows.Add(drNewRow);
            }
            table.WriteXml(path);
        }

        private void LoadDGV(string path)   //loading file
        {
            currenPath = path;
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(path);
            DataTable table = dataSet.Tables[0];
            dgv.ColumnCount = table.Columns.Count;
            dgv.RowCount = table.Rows.Count;
            foreach(DataGridViewRow row in dgv.Rows)
            {
                foreach(DataGridViewCell dgvCell in row.Cells)
                {
                    dgvCell.Tag = new Cell(dgvCell, table.Rows[dgvCell.RowIndex][dgvCell.ColumnIndex].ToString());
                }
            }
            UpdateDGV();
            UpdateCellValues();

        }

        private void dgvCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;
            Cell cell = CellManager.Instance.GetCell(e.RowIndex, e.ColumnIndex);
            DataGridViewCell dgvCell = cell.Parent;
            string oldFormula = cell.Formula;
            if(dgvCell.Value != null)
            {
                cell.Formula = dgvCell.Value.ToString();
                try
                {
                    UpdateCellValues();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.GetType().ToString());
                    CellManager.Instance.Reset();
                    cell.Formula = oldFormula;
                    UpdateCellValues();
                }

            }
            else
            {
                cell.Formula = "";
            }
        }

        private void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Cell cell = CellManager.Instance.GetCell(e.RowIndex, e.ColumnIndex);
            DataGridViewCell dgvCell = cell.Parent;
            dgvCell.Value = cell.Formula;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv.BeginEdit(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

     
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save changes", "Save File", MessageBoxButtons.YesNoCancel);
            if(result == DialogResult.Yes)
            {
                if(currenPath != "")
                {
                    SaveDGV(currenPath);
                }
                else
                {
                    if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        SaveDGV(saveFileDialog1.FileName);
                    }
                }
            }
            else if(result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void AddColumnB_Click(object sender, EventArgs e)
        {
            AddColumn();
        }

        private void DeleteColumnB_Click(object sender, EventArgs e)
        {
            DeleteColumn();
        }

        private void AddRowB_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void DeleteRowB_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        private void CalculateB_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadDGV(openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currenPath != "")
            {
                SaveDGV(currenPath);
            }
            else
            {
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveDGV(saveFileDialog1.FileName);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I'm trying", "About");
        }
    }
}
