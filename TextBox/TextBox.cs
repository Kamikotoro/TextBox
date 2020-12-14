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
        private ConsoleColor color = default;
        public ConsoleColor FontColor
        {
            get => color;
            set 
            {
                color = value;
                if ((int)color == 16)
                {
                    color = 0;
                }
            }
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
            this.color = fontColor;
        }
       
        public void Clear()
        {
            Text = "";
        }
        public void Output()
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}