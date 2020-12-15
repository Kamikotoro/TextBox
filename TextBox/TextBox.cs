using System;
using System.Collections.Generic;
using System.Text;

namespace TextBox
{
    public class TextBox
    {

        public Action<string,string> TextUpdated;
        public Action<ConsoleColor> ColorUpdated;
        public Action<ConsoleColor> BackgroundColorUpdated;

        private string text;
        private ConsoleColor color = default;
        private ConsoleColor backgroundColor = default;
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
                ColorUpdated?.Invoke(value);
            }
        }
        public ConsoleColor BackColor
        {
            get => backgroundColor;
            set
            {
                backgroundColor = value;
                if ((int)backgroundColor == 16)
                {
                    backgroundColor = 0;
                }
                BackgroundColorUpdated?.Invoke(value);
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
        public TextBox(string text, ConsoleColor fontColor,ConsoleColor backgroundColor) : this(text)
        {
            this.backgroundColor = backgroundColor;
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