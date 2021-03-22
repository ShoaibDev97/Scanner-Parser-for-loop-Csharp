using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
    class Tokenizer
    {
        public List<string> Tokenize(string text)
        {
            Keywords keywords = new Keywords();
            Symbols symbols = new Symbols();
            Operators operators = new Operators();
            List<string> tokens = new List<string>();

            #region keywordsCheck
            if (text.Contains(keywords.FOR))
            {
                tokens.Add("<keyword,for>");
                text = text.Replace(keywords.FOR, "");
            }
            if (text.Contains(keywords.BREAK))
            {
                tokens.Add("<keyword,break>");
                text = text.Replace(keywords.BREAK, "");

            }
            if (text.Contains(keywords.INT))
            {
                tokens.Add("<keyword,int>");
                text = text.Replace(keywords.INT, "");

            }
            #endregion

            #region operatorsCheck
            if (text.Contains(operators.EQUAL))
            {
                tokens.Add("<operator, = >");
                text = text.Replace(operators.EQUAL, "");

            }
            if (text.Contains(operators.PLUS))
            {
                tokens.Add("<operator, + >");
                text = text.Replace(operators.PLUS, "");

            }
            if (text.Contains(operators.MINUS))
            {
                tokens.Add("<operator, - >");
                text = text.Replace(operators.MINUS, "");

            }
            if (text.Contains(operators.PLUSPLUS))
            {
                tokens.Add("<operator, ++ >");
                text = text.Replace(operators.PLUSPLUS, "");

            }
            if (text.Contains(operators.MINUSMINUS))
            {
                tokens.Add("<operator, -- >");
                text = text.Replace(operators.MINUSMINUS, "");

            }

            if (text.Contains(operators.LESS))
            {
                tokens.Add("<operator, < >");
                text = text.Replace(operators.LESS, "");

            }
            if (text.Contains(operators.GREATER))
            {
                tokens.Add("<operator, > >");
                text = text.Replace(operators.GREATER, "");

            }
            if (text.Contains(operators.LESSEQUAL))
            {
                tokens.Add("<operator, <= >");
                text = text.Replace(operators.LESSEQUAL, "");

            }
            if (text.Contains(operators.GREATEREQUAL))
            {
                tokens.Add("<operator, >= >");
                text = text.Replace(operators.GREATEREQUAL, "");

            }
            #endregion

            #region symbolsCheck
            if (text.Contains(symbols.CURLYBRACKEROPEN))
            {
                tokens.Add("<symbol, { >");
                text = text.Replace(symbols.CURLYBRACKEROPEN, "");

            }
            if (text.Contains(symbols.CURLYBRACKERCLOSE))
            {
                tokens.Add("<symbol, } >");
                text = text.Replace(symbols.CURLYBRACKERCLOSE, "");

            }
            if (text.Contains(symbols.ROUNDBRACKEROPEN))
            {
                tokens.Add("<symbol, ( >");
                text = text.Replace(symbols.ROUNDBRACKEROPEN, "");

            }
            if (text.Contains(symbols.ROUNDBRACKERCLOSE))
            {
                tokens.Add("<symbol, ) >");
                text = text.Replace(symbols.ROUNDBRACKERCLOSE, "");

            }
            if (text.Contains(symbols.TERMINATOR))
            {
                tokens.Add("<symbol, ; >");
                text = text.Replace(symbols.TERMINATOR, "");

            }

            #endregion


            #region constantCheck
            int i = 0;
            string[] leftOvers = text.Split(' ');
            foreach (var item in leftOvers)
            {
                if (int.TryParse(item, out i))
                {
                    tokens.Add("<constant," + item + ">");

                }
            }

            #endregion


            #region identifierCheck

            foreach (var item in leftOvers)
            {
                if (item != "")
                {
                    if (!int.TryParse(item, out i))
                    {
                        tokens.Add("<identifiers," + item + ">");

                    }

                }
            }

            #endregion


            return tokens;
        }
    }
}
