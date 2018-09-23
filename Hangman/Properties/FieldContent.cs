using System;
using System.Text;

namespace Hangman
{
    public class FieldContent
    {
        private FieldType Typ;
        private Food food;

        public FieldContent(FieldType typ)
        {
            this.Typ = typ;
        }


        public string Render()

        {
            Console.OutputEncoding = Encoding.Unicode;
            if (Typ == FieldType.border)
            {
                return "#";
            }
            else if (Typ == FieldType.empty)
            {
                return " ";
            }
            else if (Typ == FieldType.snake)
            {
                return "■";
            }
            else if (Typ == FieldType.apple)
            {
                return "O";
            }

            return " ";
        }

        public enum FieldType
        {
            border,
            empty,
            snake,
            apple,
        }
    }
}