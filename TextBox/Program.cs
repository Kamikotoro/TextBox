using System;

namespace TextBox
{
    class Program
    {
        static void Main(string[] args)
        {

            TextBox tBox = new TextBox("", ConsoleColor.Blue);
            TextBox.TextUpdated = TextChange;
            while (true)
            {

                ConsoleKeyInfo Key = Console.ReadKey();
                ConsoleKey KeyPressed = Key.Key;
                Console.Clear();
                if (KeyPressed == ConsoleKey.Escape)
                {
                    break;
                }
                else if (KeyPressed == ConsoleKey.OemPlus)
                {
                    tBox.FontColor++;
                    Console.WriteLine($"\nЦвет текста изменен на \"{tBox.FontColor}\"\n");
                    tBox.Output();
                    continue;
                }
                else if (KeyPressed == ConsoleKey.Backspace)
                {
                    if (tBox.Text.Length != 0)
                    {
                        tBox.Text = tBox.Text.Remove(tBox.Text.Length - 1);
                    }
                    //tBox.Text = tBox.Text.TrimEnd(tBox.Text[tBox.Text.Length - 1]);
                    tBox.Output();
                    continue;
                }
                else if (KeyPressed == ConsoleKey.Enter)
                {
                    continue;
                }
                else if (KeyPressed == ConsoleKey.Delete)
                {
                    tBox.Clear();
                }
                tBox.Text += Key.KeyChar;
                tBox.Output();

            }
        }
        static void TextChange(string oldText, string newText)
        {
            Console.WriteLine($"\nТекст поля был изменен " +
                $"\n с \"{oldText}\" " +
                $"\n на \"{newText}\"");

        }
    }
}
