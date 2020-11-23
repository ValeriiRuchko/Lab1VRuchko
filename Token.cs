using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    enum TokenType
    {
        INTEGER,    //123
        ID,         //RC
        PLUS,       //+
        MINUS,      //-
        MUL,        //*
        DIV,        // /
        MOD,        // %
        EXP,        // ^
        LPAREN,     // (
        RPAREN,     // )
        END,
    }
    class Token
    {
        public TokenType type;  //тип лексеми
        public string value;    //value in a box

        public Token(TokenType type, string value)
        {
            this.type = type;
            this.value = value;
        }
    }
}
