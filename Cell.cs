using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    class Cell
    {
        public DataGridViewCell Parent { get; set; }
        public int Value { get; set; }
        public string Formula { get; set; }

        public Cell(DataGridViewCell parent, string formula)
        {
            this.Parent = parent;
            Value = 0;
            this.Formula = formula;
        }

        public int Calculate()
        {
            if (Formula != "")
            {
                Value = Interpreter.interpret(Formula);
            }
            return Value;
        }
    }

    class ReccursionException : Exception { }

    class CellManager
    {
        private static CellManager instance;

        public static CellManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CellManager();
                }
                return instance;
            }
        }

        public List<string> varStack = new List<string>(); //here we store values from the boxes

        private DataGridView dgv;

        public void ProvideDataGridView(DataGridView dgv)
        {
            this.dgv = dgv;
        }

        public Cell GetCell(int row, int column) //get cell by row & column
        {
            Cell cell = (Cell)dgv[column, row].Tag;
            return cell;
        }

        public Cell GetCell(DataGridViewCell dgvCell)
        {
            Cell cell = (Cell)dgvCell.Tag;
            return cell;
        }

        public bool CellExists(int row, int column) //checking if cell exists
        {
            try
            {
                GetCell(row, column);
                return true;
            }
            catch(ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        public int GetValue(int row, int column)    //get value of the box
        {
            Cell cell = GetCell(row, column);
            if(cell.Formula != "")
            {
                return cell.Calculate();
            }
            else
            {
                return cell.Value;
            }
        }
        public void VarEnter(string name)   //recurrsion check
        {
            if(varStack.Contains(name))
            {
                Reset();
                throw new ReccursionException();
            }
            varStack.Add(name);
        }

        public void VarLeave(string name)
        {
            varStack.Remove(name);
        }

        public void Reset()
        {
            varStack.Clear();
        }
    }
}
