// *****************************************************
// Morse
// MorseCode.cs
// 
// Author: Steve Palmer (spalmer@cix)
// 
// Created: 14/07/2014 13:55
//  
// Copyright (C) 2014 Steve Palmer. All Rights Reserved.
// *****************************************************

using System;
using System.Text;

namespace Morse
{
    public static class MorseCode
    {
        /// <summary>
        ///     Convert a string to Morse.
        /// </summary>
        /// <param name="input">Input string of letters</param>
        /// <returns>Morse code equivalent of input</returns>
        public static string ToMorse(string input)
        {
            StringBuilder str = new StringBuilder();
            foreach (char ch in input)
            {
                switch (Char.ToUpper(ch))
                {
                    case 'A':
                        str.Append(".-");
                        break;

                    case 'B':
                        str.Append("-...");
                        break;

                    case 'C':
                        str.Append("-.-.");
                        break;

                    case 'D':
                        str.Append("-..");
                        break;

                    case 'E':
                        str.Append(".");
                        break;

                    case 'F':
                        str.Append("..-.");
                        break;

                    case 'G':
                        str.Append("--.");
                        break;

                    case 'H':
                        str.Append("....");
                        break;

                    case 'I':
                        str.Append("..");
                        break;

                    case 'J':
                        str.Append(".---");
                        break;

                    case 'K':
                        str.Append("-.-");
                        break;

                    case 'L':
                        str.Append(".-..");
                        break;

                    case 'M':
                        str.Append("--");
                        break;

                    case 'N':
                        str.Append("-.");
                        break;

                    case 'O':
                        str.Append("---");
                        break;

                    case 'P':
                        str.Append(".--.");
                        break;

                    case 'Q':
                        str.Append("--.-");
                        break;

                    case 'R':
                        str.Append(".-.");
                        break;

                    case 'S':
                        str.Append("...");
                        break;

                    case 'T':
                        str.Append("-");
                        break;

                    case 'U':
                        str.Append("..-");
                        break;

                    case 'V':
                        str.Append("...-");
                        break;

                    case 'W':
                        str.Append(".--");
                        break;

                    case 'X':
                        str.Append("-..-");
                        break;

                    case 'Y':
                        str.Append("-.--");
                        break;

                    case 'Z':
                        str.Append("--..");
                        break;
                }
                str.Append(" ");
            }
            return str.ToString();
        }
    }
}