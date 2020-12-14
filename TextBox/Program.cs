using System;

namespace TextBox
{
    class Program
    {
        static void Main(string[] args)
        {
            TextBox tBox = new TextBox("лол", ConsoleColor.Blue);
            TextBox.TextUpdated = TextChange;
            while(true)
            {
                tBox.Text = Console.ReadLine();
                tBox.Output();
                if (tBox.Text == "quit")
                {
                    break;
                }
                else if (Enum.TryParse(tBox.Text,out ConsoleColor color))
                {
                    tBox.FontColor = color;
                }
            }
        }
        static void TextChange(string oldText, string newText)
        {
            Console.WriteLine($"Текст поля был изменен с {oldText} на {newText}");
        }
    }
}
