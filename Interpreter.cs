using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Interpreter
    {
        public static Node build_tree(string text)
        {
            if(text == "")
            {
                text = "0";
            }
            Lexer lexer = new Lexer(text);
            Parser parser = new Parser(lexer);
            return parser.expression();
        }
        public static int interpret(string text)
        {
            return interpret(build_tree(text));
        }

        public static int interpret(Node tree)
        {
            return tree.visit();
        }
    }
}
