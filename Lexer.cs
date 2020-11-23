using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab1
{
    class TokenException : Exception
    {
    }
    class Lexer
    {
        string text;    //value in a box
        int position;   //char position
        char current_char;
        const char NONE = '\0'; //порожній символ

        public Lexer(string text) //constructor
        {
            this.text = text;
            position = 0;
            current_char = text[0];
        }

        public void Error() //exception throw on error
        {
            throw new TokenException();
        }

        public void advance()   //move onto the next position (1+)
        {
            ++position;
            if(position > text.Length - 1)
            {
                current_char = NONE;
            }
            else
            {
                current_char = text[position];
            }
        }
        public void skip_whitespace()   // пропускаємо пробіли
        {
            while (current_char != NONE && Char.IsWhiteSpace(current_char))
            {
                advance();
            }
        }

        public string id()  //we use it, when there's name of other box in the box
        {
            string result = "";
            
            while(current_char != NONE && Char.IsLetterOrDigit(current_char))
            {
                result += current_char;
                advance();
            }

            var regex = new Regex(@"^R(?<row>\d+)C(?<col>\d+)$");
            var matches = regex.Matches(result);

            if(matches.Count != 1)
            {
                throw new TokenException();
            }

            string name = matches[0].Groups[0].Value;
            return name;
        }

        public string integer() //there are numbers in the box
        {
            string result = "";

            while (current_char != NONE && Char.IsDigit(current_char))
            {
                result += current_char;
                advance();
            }

            if(Char.IsLetter(current_char)) //if there is a letter, throw an exception
            {
                throw new TokenException();
            }

            return result;
        }

        public Token Get_Next_Token()   //read next token
        {
            while(current_char != NONE)
            {
                if(Char.IsWhiteSpace(current_char))
                {
                    skip_whitespace();
                    continue;
                }
                if(Char.IsLetter(current_char))
                {
                    return new Token(TokenType.ID, id());
                }
                if(Char.IsDigit(current_char))
                {
                    return new Token(TokenType.INTEGER, integer());
                }
                if (current_char == '+')
                {
                    advance();
                    return new Token(TokenType.PLUS, "+");
                }
                if (current_char == '-')
                {
                    advance();
                    return new Token(TokenType.MINUS, "-");
                }
                if (current_char == '*')
                {
                    advance();
                    return new Token(TokenType.MUL, "*");
                }
                if (current_char == '/')
                {
                    advance();
                    return new Token(TokenType.DIV, "/");
                }
                if (current_char == '%')
                {
                    advance();
                    return new Token(TokenType.MOD, "%");
                }
                if (current_char == '^')
                {
                    advance();
                    return new Token(TokenType.EXP, "^");
                }
                if (current_char == '(')
                {
                    advance();
                    return new Token(TokenType.LPAREN, "(");
                }
                if (current_char == ')')
                {
                    advance();
                    return new Token(TokenType.RPAREN, ")");
                }

                Error();
            }

            return new Token(TokenType.END, "END");
        }
    }
}
