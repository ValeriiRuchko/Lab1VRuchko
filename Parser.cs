using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class SyntaxException : Exception { }
    class Parser
    {
        Lexer lexer;
        Token current_token;

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
            this.current_token = lexer.Get_Next_Token();
        }

        private void error()
        {
            throw new SyntaxException();
        }

        private void readLex(TokenType token_type) //read next lex
        {
            if (current_token.type == token_type)
            {
                current_token = lexer.Get_Next_Token();
            }
            else
            {
                error();
            }
        }


        public Node expression()
        {
            Node node = term();

            while(current_token.type == TokenType.PLUS || current_token.type == TokenType.MINUS)
            {
                Token token = current_token;
                if(token.type == TokenType.PLUS)
                {
                    readLex(TokenType.PLUS);
                }
                else if(token.type == TokenType.MINUS)
                {
                    readLex(TokenType.MINUS);
                }
                node = new BinOpNode(node, token, term());
            }

            return node;
        }

        public Node term()
        {
            Node node = factor();

            while (current_token.type == TokenType.MUL || current_token.type == TokenType.DIV || current_token.type == TokenType.MOD)
            {
                Token token = current_token;
                if(token.type == TokenType.MUL)
                {
                    readLex(TokenType.MUL);
                }
                else if (token.type == TokenType.DIV)
                {
                    readLex(TokenType.DIV);
                }
                else if (token.type == TokenType.MOD)
                {
                    readLex(TokenType.MOD);
                }

                node = new BinOpNode(node, token, factor());
            }

            return node;
        }

        public Node factor()
        {
            Token token = current_token;
            Node node = exponent();

            if(current_token.type == TokenType.EXP)
            {
                token = current_token;
                readLex(TokenType.EXP);
                node = new BinOpNode(node, token, factor());
            }

            return node;
        }
       
        public Node exponent()
        {
            Token token = current_token;

            if(token.type == TokenType.INTEGER)
            {
                readLex(TokenType.INTEGER);
                return new IntegerNode(token);
            }

            if(token.type == TokenType.ID)
            {
                Node node = variable();
                return node;
            }

            if (token.type == TokenType.LPAREN)
            {
                readLex(TokenType.LPAREN);
                Node node = expression();
                readLex(TokenType.RPAREN);
                return node;
            }

            error();
            return null;
        }

        public Node variable()
        {
            Node node = new VarNode(current_token);
            readLex(TokenType.ID);
            return node;
        }
    }
}
