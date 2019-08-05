using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Parsley;

namespace AgcApp
{
    public class FunctionCompiler
    {
        void method()
        {
          
        }
    }

    public class FunctionLexer : Parsley.Lexer
    {
        public static TokenKind FloatingPointNumber = new Pattern("number",@"[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)");
        public static TokenKind Identifier = new Pattern("identifier", @"[_a-zA-Z][_a-zA-Z0-9]{0,30}");
        public static TokenKind Space = new Pattern("Space", @"\s", skippable: true);
        public static readonly TokenKind Digit = new Pattern("Digit", @"[0-9]");
        public static readonly TokenKind Name = new Pattern("Name", @"[a-z]+");
        public static readonly TokenKind Increment = new Operator("++");
        public static readonly TokenKind Decrement = new Operator("--");
        public static readonly TokenKind GreaterThanEqual = new Operator(">=");
        public static readonly TokenKind LessThanEqual = new Operator("<=");

        public static readonly TokenKind Comments = new Pattern("Comments",
            @"(/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/)|(//.*)", skippable: true);

        public static readonly TokenKind Add = new Operator("+");
        public static readonly TokenKind Subtract = new Operator("-");
        public static readonly TokenKind Multiply = new Operator("*");
        public static readonly TokenKind Divide = new Operator("/");
        public static readonly TokenKind Exponent = new Operator("^");
        public static readonly TokenKind LeftParen = new Operator("(");
        public static readonly TokenKind RightParen = new Operator(")");
          public static readonly TokenKind LeftCurlyBrace = new Operator("{");
          public static readonly TokenKind RightCurlyBrace = new Operator("}");
          public static readonly TokenKind LeftBrace = new Operator("[");
          public static readonly TokenKind RightBrace = new Operator("]");

      public static readonly TokenKind Comma = new Operator(",");

      public FunctionLexer():
        base(FloatingPointNumber, Identifier, Space,Digit, Name, Increment, Decrement, GreaterThanEqual, LessThanEqual,Add ,
              Comments, Subtract, Multiply, Divide, Exponent,
              LeftParen, RightParen,LeftCurlyBrace, RightCurlyBrace, LeftBrace,RightBrace, Comma)
        { }
      }
    }

