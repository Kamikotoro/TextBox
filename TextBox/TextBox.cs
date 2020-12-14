using System;
using System.Collections.Generic;
using System.Text;

namespace TextBox
{
    public class TextBox
    {
        public delegate void TextChanged(string oldText, string newText);
        public static TextChanged TextUpdated;
        private string text;
        private ConsoleColor Color = ConsoleColor.White;
        public ConsoleColor FontColor
        {
            get => Color;
            set => Color = value;
        }
        public string Text
        {
            get => text;
            set
            {
                string oldText = text;
                text = value;
                TextUpdated?.Invoke(oldText, value);
            }
        }

        public TextBox(string text)
        {
            this.text = text;
        }
        public TextBox(string text, ConsoleColor fontColor) : this(text)
        {
            this.Color = fontColor;
        }
       
        public void Clear()
        {
            text = "";
        }
        public void Output()
        {
            Console.ForegroundColor = Color;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}