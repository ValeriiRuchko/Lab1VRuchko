using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab1
{
    abstract class Node
    {
        public abstract int visit();
    }

    class IntegerNode : Node
    {
        int value;
        Token token;

        public IntegerNode(Token token)
        {
            this.token = token;
            value = Int32.Parse(token.value);
        }
        public override int visit()
        {
            return value;
        }
    };
    class BinOpNode : Node  //binary operations
    {
        Node left;
        Node right;
        Token token;

        public BinOpNode(Node left, Token token, Node right)
        {
            this.left = left;
            this.token = token;
            this.right = right;
        }

        public override int visit()
        {
            if(token.type == TokenType.PLUS)
            {
                return left.visit() + right.visit();
            }
            if (token.type == TokenType.MINUS)
            {
                return left.visit() - right.visit();
            }
            if (token.type == TokenType.MUL)
            {
                return left.visit() * right.visit();
            }
            if (token.type == TokenType.DIV)
            {
                int right_value = right.visit();
                if(right_value == 0)
                {
                    //throw DivisionByZeroException
                }
                return left.visit() / right.visit();
            }
            if (token.type == TokenType.MOD)
            {
                int right_value = right.visit();
                if (right_value == 0)
                {
                    //throw DivisionByZeroException
                }
                return left.visit() % right.visit();
            }
            if (token.type == TokenType.EXP)
            {
                return (int)(Math.Pow(left.visit(), right.visit()));
            }

            return -1;
        }
    };

    class VarNode : Node    //  getting value of another box
    {
        string name;
        int row, col;
        Token token;

        public VarNode(Token token)
        {
            this.token = token;
            this.name = token.value;
            var regex = new Regex(@"^R(?<row>\d+)C(?<col>\d+)$");
            var matches = regex.Matches(name);
            row = Int32.Parse(matches[0].Groups["row"].Value) - 1;
            col = Int32.Parse(matches[0].Groups["col"].Value) - 1;
        }
        public override int visit()
        {
            CellManager.Instance.VarEnter(name);
            bool exists = CellManager.Instance.CellExists(row, col);
            int value;
            if (exists)
            {
                value = CellManager.Instance.GetValue(row, col);
            }
            else
            {
                value = 0;
            }

            CellManager.Instance.VarLeave(name);
            
            return value;
        }
    };
}
