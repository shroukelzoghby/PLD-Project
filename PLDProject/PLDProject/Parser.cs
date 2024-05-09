
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;


namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF           =  0, // (EOF)
        SYMBOL_ERROR         =  1, // (Error)
        SYMBOL_WHITESPACE    =  2, // Whitespace
        SYMBOL_APOST         =  3, // ''
        SYMBOL_MINUS         =  4, // '-'
        SYMBOL_MINUSMINUS    =  5, // '--'
        SYMBOL_EXCLAMEQ      =  6, // '!='
        SYMBOL_PERCENT       =  7, // '%'
        SYMBOL_LPAREN        =  8, // '('
        SYMBOL_RPAREN        =  9, // ')'
        SYMBOL_TIMES         = 10, // '*'
        SYMBOL_DOT           = 11, // '.'
        SYMBOL_DIV           = 12, // '/'
        SYMBOL_COLON         = 13, // ':'
        SYMBOL_SEMI          = 14, // ';'
        SYMBOL_LBRACE        = 15, // '{'
        SYMBOL_RBRACE        = 16, // '}'
        SYMBOL_PLUS          = 17, // '+'
        SYMBOL_PLUSPLUS      = 18, // '++'
        SYMBOL_LT            = 19, // '<'
        SYMBOL_LTEQ          = 20, // '<='
        SYMBOL_EQ            = 21, // '='
        SYMBOL_EQEQ          = 22, // '=='
        SYMBOL_GT            = 23, // '>'
        SYMBOL_GTEQ          = 24, // '>='
        SYMBOL_BREAK         = 25, // break
        SYMBOL_CASE          = 26, // case
        SYMBOL_DIGIT         = 27, // Digit
        SYMBOL_DO            = 28, // do
        SYMBOL_DOUBLE        = 29, // double
        SYMBOL_ELSE          = 30, // else
        SYMBOL_END           = 31, // end
        SYMBOL_FLOAT         = 32, // float
        SYMBOL_FOR           = 33, // for
        SYMBOL_ID            = 34, // Id
        SYMBOL_IF            = 35, // if
        SYMBOL_INT           = 36, // int
        SYMBOL_START         = 37, // start
        SYMBOL_STRING        = 38, // string
        SYMBOL_SWITCH        = 39, // switch
        SYMBOL_WHILE         = 40, // while
        SYMBOL_ASSIGN        = 41, // <assign>
        SYMBOL_CASE_LIST     = 42, // <case_list>
        SYMBOL_CASE_STAT     = 43, // <case_stat>
        SYMBOL_CONCEPT       = 44, // <concept>
        SYMBOL_COND          = 45, // <cond>
        SYMBOL_D_TYPE        = 46, // <D_type>
        SYMBOL_DIGIT2        = 47, // <digit>
        SYMBOL_DO_WHILE_STAT = 48, // <do_while_stat>
        SYMBOL_EXP           = 49, // <exp>
        SYMBOL_EXPR          = 50, // <expr>
        SYMBOL_FACTOR        = 51, // <factor>
        SYMBOL_FOR_STAT      = 52, // <for_stat>
        SYMBOL_ID2           = 53, // <id>
        SYMBOL_IF_STAT       = 54, // <if_stat>
        SYMBOL_OP            = 55, // <op>
        SYMBOL_PROG          = 56, // <Prog>
        SYMBOL_STAT_LIST     = 57, // <stat_list>
        SYMBOL_STEP          = 58, // <step>
        SYMBOL_SWITCH_STAT   = 59, // <switch_stat>
        SYMBOL_TERM          = 60  // <term>
    };

    enum RuleConstants : int
    {
        RULE_PROG_START_END                                          =  0, // <Prog> ::= start <stat_list> end
        RULE_STAT_LIST                                               =  1, // <stat_list> ::= <concept>
        RULE_STAT_LIST2                                              =  2, // <stat_list> ::= <concept> <stat_list>
        RULE_CONCEPT                                                 =  3, // <concept> ::= <assign>
        RULE_CONCEPT2                                                =  4, // <concept> ::= <for_stat>
        RULE_CONCEPT3                                                =  5, // <concept> ::= <if_stat>
        RULE_CONCEPT4                                                =  6, // <concept> ::= <switch_stat>
        RULE_CONCEPT5                                                =  7, // <concept> ::= <do_while_stat>
        RULE_ASSIGN_EQ_DOT                                           =  8, // <assign> ::= <D_type> <id> '=' <expr> '.'
        RULE_ID_ID                                                   =  9, // <id> ::= Id
        RULE_EXPR_PLUS                                               = 10, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                              = 11, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                    = 12, // <expr> ::= <term>
        RULE_TERM_TIMES                                              = 13, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                                = 14, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                            = 15, // <term> ::= <term> '%' <factor>
        RULE_TERM                                                    = 16, // <term> ::= <factor>
        RULE_FACTOR_APOST                                            = 17, // <factor> ::= <factor> '' <exp>
        RULE_FACTOR                                                  = 18, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                       = 19, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                                     = 20, // <exp> ::= <id>
        RULE_EXP2                                                    = 21, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                             = 22, // <digit> ::= Digit
        RULE_D_TYPE_INT                                              = 23, // <D_type> ::= int
        RULE_D_TYPE_FLOAT                                            = 24, // <D_type> ::= float
        RULE_D_TYPE_DOUBLE                                           = 25, // <D_type> ::= double
        RULE_D_TYPE_STRING                                           = 26, // <D_type> ::= string
        RULE_IF_STAT_IF_LPAREN_RPAREN_START_END                      = 27, // <if_stat> ::= if '(' <cond> ')' start <stat_list> end
        RULE_IF_STAT_IF_LPAREN_RPAREN_START_END_ELSE                 = 28, // <if_stat> ::= if '(' <cond> ')' start <stat_list> end else <stat_list>
        RULE_COND                                                    = 29, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LPAREN_LT                                            = 30, // <op> ::= '(' '<'
        RULE_OP_GT                                                   = 31, // <op> ::= '>'
        RULE_OP_EQ                                                   = 32, // <op> ::= '='
        RULE_OP_LTEQ                                                 = 33, // <op> ::= '<='
        RULE_OP_GTEQ                                                 = 34, // <op> ::= '>='
        RULE_OP_EXCLAMEQ_EQEQ_RPAREN                                 = 35, // <op> ::= '!=' '==' ')'
        RULE_FOR_STAT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE      = 36, // <for_stat> ::= for '(' <D_type> <assign> ';' <cond> ';' <step> ')' '{' <stat_list> '}'
        RULE_STEP_PLUSPLUS                                           = 37, // <step> ::= <id> '++'
        RULE_STEP_MINUSMINUS                                         = 38, // <step> ::= <id> '--'
        RULE_STEP_PLUSPLUS2                                          = 39, // <step> ::= '++' <id>
        RULE_STEP_MINUSMINUS2                                        = 40, // <step> ::= '--' <id>
        RULE_SWITCH_STAT_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE          = 41, // <switch_stat> ::= switch '(' <id> ')' '{' <case_list> '}'
        RULE_CASE_LIST                                               = 42, // <case_list> ::= <case_stat>
        RULE_CASE_LIST2                                              = 43, // <case_list> ::= <case_stat> <case_list>
        RULE_CASE_STAT_CASE_COLON_BREAK_SEMI                         = 44, // <case_stat> ::= case <expr> ':' <stat_list> break ';'
        RULE_DO_WHILE_STAT_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN_SEMI = 45  // <do_while_stat> ::= do '{' <stat_list> '}' while '(' <cond> ')' ';'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox ls;

        public MyParser(string filename,ListBox lst,ListBox ls)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.ls = ls;
            this.lst= lst;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_APOST :
                //''
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_LIST :
                //<case_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_STAT :
                //<case_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_D_TYPE :
                //<D_type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO_WHILE_STAT :
                //<do_while_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STAT :
                //<for_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STAT :
                //<if_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROG :
                //<Prog>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STAT_LIST :
                //<stat_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STAT :
                //<switch_stat>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROG_START_END :
                //<Prog> ::= start <stat_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT_LIST :
                //<stat_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STAT_LIST2 :
                //<stat_list> ::= <concept> <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <for_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <if_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <switch_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <do_while_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_DOT :
                //<assign> ::= <D_type> <id> '=' <expr> '.'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_APOST :
                //<factor> ::= <factor> '' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_D_TYPE_INT :
                //<D_type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_D_TYPE_FLOAT :
                //<D_type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_D_TYPE_DOUBLE :
                //<D_type> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_D_TYPE_STRING :
                //<D_type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STAT_IF_LPAREN_RPAREN_START_END :
                //<if_stat> ::= if '(' <cond> ')' start <stat_list> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STAT_IF_LPAREN_RPAREN_START_END_ELSE :
                //<if_stat> ::= if '(' <cond> ')' start <stat_list> end else <stat_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LPAREN_LT :
                //<op> ::= '(' '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQ :
                //<op> ::= '='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTEQ :
                //<op> ::= '<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GTEQ :
                //<op> ::= '>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ_EQEQ_RPAREN :
                //<op> ::= '!=' '==' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STAT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<for_stat> ::= for '(' <D_type> <assign> ';' <cond> ';' <step> ')' '{' <stat_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STAT_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE :
                //<switch_stat> ::= switch '(' <id> ')' '{' <case_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_LIST :
                //<case_list> ::= <case_stat>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_LIST2 :
                //<case_list> ::= <case_stat> <case_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_STAT_CASE_COLON_BREAK_SEMI :
                //<case_stat> ::= case <expr> ':' <stat_list> break ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DO_WHILE_STAT_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN_SEMI :
                //<do_while_stat> ::= do '{' <stat_list> '}' while '(' <cond> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"' in line: "+args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string msg2= "Expected Token: "+args.ExpectedTokens.ToString();
            lst.Items.Add(msg2);
            //todo: Report message to UI?
        }

        private void TokenReadEvent(LALRParser pr, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "   \t \t" +(SymbolConstants) args.Token.Symbol.Id;
            ls.Items.Add(info);
        }

    }
}
