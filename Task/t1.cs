
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

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
        SYMBOL_EOF             =  0, // (EOF)
        SYMBOL_ERROR           =  1, // (Error)
        SYMBOL_WHITESPACE      =  2, // Whitespace
        SYMBOL_PERCENT         =  3, // '%'
        SYMBOL_AMP             =  4, // '&'
        SYMBOL_LPAREN          =  5, // '('
        SYMBOL_RPAREN          =  6, // ')'
        SYMBOL_COMMA           =  7, // ','
        SYMBOL_SEMI            =  8, // ';'
        SYMBOL_LBRACKET        =  9, // '['
        SYMBOL_RBRACKET        = 10, // ']'
        SYMBOL_CARET           = 11, // '^'
        SYMBOL_LBRACE          = 12, // '{'
        SYMBOL_RBRACE          = 13, // '}'
        SYMBOL_TILDE           = 14, // '~'
        SYMBOL_AINT            = 15, // aint
        SYMBOL_BECOMES         = 16, // becomes
        SYMBOL_BIGGER          = 17, // bigger
        SYMBOL_CLOSE           = 18, // close
        SYMBOL_DO              = 19, // do
        SYMBOL_DRIFT           = 20, // drift
        SYMBOL_ECHO            = 21, // echo
        SYMBOL_ELSE            = 22, // else
        SYMBOL_GETS            = 23, // gets
        SYMBOL_IS              = 24, // is
        SYMBOL_MARK            = 25, // mark
        SYMBOL_NOTBIGGER       = 26, // notbigger
        SYMBOL_NOTSMALLER      = 27, // notsmaller
        SYMBOL_OPEN            = 28, // open
        SYMBOL_RUNE            = 29, // rune
        SYMBOL_SEAL            = 30, // seal
        SYMBOL_SHARD           = 31, // shard
        SYMBOL_SMALLER         = 32, // smaller
        SYMBOL_SPARK           = 33, // spark
        SYMBOL_SPIN            = 34, // spin
        SYMBOL_WAVE            = 35, // wave
        SYMBOL_WHEN            = 36, // when
        SYMBOL_CARVE           = 37, // <carve>
        SYMBOL_CHANT           = 38, // <chant>
        SYMBOL_ECHO2           = 39, // <echo>
        SYMBOL_ESSENCE         = 40, // <essence>
        SYMBOL_ETCH            = 41, // <etch>
        SYMBOL_ETCHING         = 42, // <etching>
        SYMBOL_ETCHINGS        = 43, // <etchings>
        SYMBOL_IMBUE           = 44, // <imbue>
        SYMBOL_LENS            = 45, // <lens>
        SYMBOL_LINK            = 46, // <link>
        SYMBOL_LOOP            = 47, // <loop>
        SYMBOL_MIRROR          = 48, // <mirror>
        SYMBOL_MYTHMINUSSCRIPT = 49, // <myth-script>
        SYMBOL_PAGE            = 50, // <page>
        SYMBOL_RIFT            = 51, // <rift>
        SYMBOL_RIPPLES         = 52, // <ripples>
        SYMBOL_THOUGHT         = 53, // <thought>
        SYMBOL_WEAVE           = 54, // <weave>
        SYMBOL_WHISPER         = 55  // <whisper>
    };

    enum RuleConstants : int
    {
        RULE_ESSENCE_SPARK                                                   =  0, // <essence> ::= spark
        RULE_ESSENCE_WAVE                                                    =  1, // <essence> ::= wave
        RULE_ESSENCE_RUNE                                                    =  2, // <essence> ::= rune
        RULE_ESSENCE_ECHO                                                    =  3, // <essence> ::= echo
        RULE_THOUGHT                                                         =  4, // <thought> ::= <thought> <link> <whisper>
        RULE_THOUGHT2                                                        =  5, // <thought> ::= <whisper>
        RULE_WHISPER                                                         =  6, // <whisper> ::= <echo>
        RULE_WHISPER_LBRACKET_RBRACKET                                       =  7, // <whisper> ::= '[' <thought> ']'
        RULE_ECHO_RUNE                                                       =  8, // <echo> ::= rune
        RULE_ECHO_SHARD                                                      =  9, // <echo> ::= shard
        RULE_LINK_TILDE                                                      = 10, // <link> ::= '~'
        RULE_LINK_CARET                                                      = 11, // <link> ::= '^'
        RULE_LINK_AMP                                                        = 12, // <link> ::= '&'
        RULE_LINK_PERCENT                                                    = 13, // <link> ::= '%'
        RULE_MIRROR                                                          = 14, // <mirror> ::= <thought> <lens> <thought>
        RULE_LENS_IS                                                         = 15, // <lens> ::= is
        RULE_LENS_AINT                                                       = 16, // <lens> ::= aint
        RULE_LENS_BIGGER                                                     = 17, // <lens> ::= bigger
        RULE_LENS_SMALLER                                                    = 18, // <lens> ::= smaller
        RULE_LENS_NOTBIGGER                                                  = 19, // <lens> ::= notbigger
        RULE_LENS_NOTSMALLER                                                 = 20, // <lens> ::= notsmaller
        RULE_IMBUE_RUNE_GETS_SEAL                                            = 21, // <imbue> ::= <essence> rune gets <thought> seal
        RULE_ETCH_RUNE_BECOMES_SEAL                                          = 22, // <etch> ::= rune becomes <thought> seal
        RULE_RIFT_WHEN_LBRACKET_RBRACKET_DO_LBRACE_RBRACE                    = 23, // <rift> ::= when '[' <mirror> ']' do '{' <page> '}'
        RULE_RIFT_WHEN_LBRACKET_RBRACKET_DO_LBRACE_RBRACE_ELSE_LBRACE_RBRACE = 24, // <rift> ::= when '[' <mirror> ']' do '{' <page> '}' else '{' <page> '}'
        RULE_LOOP_SPIN_LBRACKET_RBRACKET_LBRACE_RBRACE                       = 25, // <loop> ::= spin '[' <mirror> ']' '{' <page> '}'
        RULE_LOOP_DRIFT_LBRACKET_SEMI_RBRACKET_LBRACE_RBRACE                 = 26, // <loop> ::= drift '[' <etch> <mirror> ';' <etch> ']' '{' <page> '}'
        RULE_CARVE_MARK_RUNE_LPAREN_RPAREN_LBRACE_RBRACE                     = 27, // <carve> ::= mark <essence> rune '(' <etchings> ')' '{' <page> '}'
        RULE_ETCHINGS                                                        = 28, // <etchings> ::= <etching>
        RULE_ETCHINGS_COMMA                                                  = 29, // <etchings> ::= <etching> ',' <etchings>
        RULE_ETCHING_RUNE                                                    = 30, // <etching> ::= <essence> rune
        RULE_CHANT_RUNE_LPAREN_RPAREN_SEAL                                   = 31, // <chant> ::= rune '(' <ripples> ')' seal
        RULE_RIPPLES                                                         = 32, // <ripples> ::= <thought>
        RULE_RIPPLES_COMMA                                                   = 33, // <ripples> ::= <thought> ',' <ripples>
        RULE_WEAVE                                                           = 34, // <weave> ::= <imbue>
        RULE_WEAVE2                                                          = 35, // <weave> ::= <etch>
        RULE_WEAVE3                                                          = 36, // <weave> ::= <rift>
        RULE_WEAVE4                                                          = 37, // <weave> ::= <loop>
        RULE_WEAVE5                                                          = 38, // <weave> ::= <carve>
        RULE_WEAVE6                                                          = 39, // <weave> ::= <chant>
        RULE_PAGE                                                            = 40, // <page> ::= <weave>
        RULE_PAGE2                                                           = 41, // <page> ::= <weave> <page>
        RULE_MYTHSCRIPT_OPEN_CLOSE                                           = 42  // <myth-script> ::= open <page> close
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
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

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMP :
                //'&'
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

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
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

                case (int)SymbolConstants.SYMBOL_TILDE :
                //'~'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AINT :
                //aint
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BECOMES :
                //becomes
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BIGGER :
                //bigger
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CLOSE :
                //close
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DRIFT :
                //drift
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ECHO :
                //echo
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GETS :
                //gets
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IS :
                //is
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MARK :
                //mark
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NOTBIGGER :
                //notbigger
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NOTSMALLER :
                //notsmaller
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OPEN :
                //open
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RUNE :
                //rune
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEAL :
                //seal
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHARD :
                //shard
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SMALLER :
                //smaller
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SPARK :
                //spark
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SPIN :
                //spin
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WAVE :
                //wave
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHEN :
                //when
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARVE :
                //<carve>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHANT :
                //<chant>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ECHO2 :
                //<echo>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ESSENCE :
                //<essence>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ETCH :
                //<etch>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ETCHING :
                //<etching>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ETCHINGS :
                //<etchings>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IMBUE :
                //<imbue>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LENS :
                //<lens>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LINK :
                //<link>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOOP :
                //<loop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MIRROR :
                //<mirror>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MYTHMINUSSCRIPT :
                //<myth-script>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PAGE :
                //<page>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RIFT :
                //<rift>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RIPPLES :
                //<ripples>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THOUGHT :
                //<thought>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WEAVE :
                //<weave>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHISPER :
                //<whisper>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_ESSENCE_SPARK :
                //<essence> ::= spark
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ESSENCE_WAVE :
                //<essence> ::= wave
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ESSENCE_RUNE :
                //<essence> ::= rune
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ESSENCE_ECHO :
                //<essence> ::= echo
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THOUGHT :
                //<thought> ::= <thought> <link> <whisper>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THOUGHT2 :
                //<thought> ::= <whisper>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHISPER :
                //<whisper> ::= <echo>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHISPER_LBRACKET_RBRACKET :
                //<whisper> ::= '[' <thought> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ECHO_RUNE :
                //<echo> ::= rune
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ECHO_SHARD :
                //<echo> ::= shard
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LINK_TILDE :
                //<link> ::= '~'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LINK_CARET :
                //<link> ::= '^'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LINK_AMP :
                //<link> ::= '&'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LINK_PERCENT :
                //<link> ::= '%'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MIRROR :
                //<mirror> ::= <thought> <lens> <thought>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LENS_IS :
                //<lens> ::= is
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LENS_AINT :
                //<lens> ::= aint
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LENS_BIGGER :
                //<lens> ::= bigger
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LENS_SMALLER :
                //<lens> ::= smaller
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LENS_NOTBIGGER :
                //<lens> ::= notbigger
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LENS_NOTSMALLER :
                //<lens> ::= notsmaller
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IMBUE_RUNE_GETS_SEAL :
                //<imbue> ::= <essence> rune gets <thought> seal
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ETCH_RUNE_BECOMES_SEAL :
                //<etch> ::= rune becomes <thought> seal
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RIFT_WHEN_LBRACKET_RBRACKET_DO_LBRACE_RBRACE :
                //<rift> ::= when '[' <mirror> ']' do '{' <page> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RIFT_WHEN_LBRACKET_RBRACKET_DO_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<rift> ::= when '[' <mirror> ']' do '{' <page> '}' else '{' <page> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOP_SPIN_LBRACKET_RBRACKET_LBRACE_RBRACE :
                //<loop> ::= spin '[' <mirror> ']' '{' <page> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOOP_DRIFT_LBRACKET_SEMI_RBRACKET_LBRACE_RBRACE :
                //<loop> ::= drift '[' <etch> <mirror> ';' <etch> ']' '{' <page> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CARVE_MARK_RUNE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<carve> ::= mark <essence> rune '(' <etchings> ')' '{' <page> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ETCHINGS :
                //<etchings> ::= <etching>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ETCHINGS_COMMA :
                //<etchings> ::= <etching> ',' <etchings>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ETCHING_RUNE :
                //<etching> ::= <essence> rune
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CHANT_RUNE_LPAREN_RPAREN_SEAL :
                //<chant> ::= rune '(' <ripples> ')' seal
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RIPPLES :
                //<ripples> ::= <thought>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RIPPLES_COMMA :
                //<ripples> ::= <thought> ',' <ripples>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WEAVE :
                //<weave> ::= <imbue>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WEAVE2 :
                //<weave> ::= <etch>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WEAVE3 :
                //<weave> ::= <rift>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WEAVE4 :
                //<weave> ::= <loop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WEAVE5 :
                //<weave> ::= <carve>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WEAVE6 :
                //<weave> ::= <chant>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PAGE :
                //<page> ::= <weave>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PAGE2 :
                //<page> ::= <weave> <page>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MYTHSCRIPT_OPEN_CLOSE :
                //<myth-script> ::= open <page> close
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
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
