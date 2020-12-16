using System;
using System.Collections.Generic;

namespace TextBox
{
    class Program
    {
        static void Main(string[] args)
        {

            TextBox tBox = new TextBox("", ConsoleColor.Blue); TextBox tBox2 = new TextBox("", ConsoleColor.Red);
            
            List<TextBox> tBoxes = new List<TextBox>();
            tBoxes.Add(tBox);
            
            Action Update;
            Update = tBox.Output;

            tBox.TextUpdated += (sender, e) => Console.WriteLine($"\nТекст поля {1} был изменен\n с \"{e.OldText}\"\n на \"{e.NewText}\"");
            tBox.ColorUpdated += (sender,color) => Console.WriteLine($"\nЦвет текста поля 1 изменен на \"{color}\"\n");
            tBox.BackgroundColorUpdated += (sender, color) => Console.WriteLine($"\nЦвет фона поля 1 изменен на \"{color}\"\n");
            int i = 0;

            while (true)
            {
                
                ConsoleKeyInfo key = Console.ReadKey();
                ConsoleKey keyPressed = key.Key;
                Console.Clear();
                if (keyPressed == ConsoleKey.Escape)
                {
                    break;
                }
                else if (keyPressed == ConsoleKey.OemPlus)
                {
                    tBoxes[i].FontColor++;
                    Update?.Invoke();
                    continue;
                }
                else if (keyPressed == ConsoleKey.OemMinus)
                {
                    tBoxes[i].BackColor++;
                    Update?.Invoke();
                    continue;
                }
                else if (keyPressed == ConsoleKey.Backspace)
                {
                    if (tBoxes[i].Text.Length != 0)
                    {
                        tBoxes[i].Text = tBoxes[i].Text.Remove(tBoxes[i].Text.Length - 1);
                    }
                    //tBox.Text = tBox.Text.TrimEnd(tBox.Text[tBox.Text.Length - 1]);
                    Update?.Invoke();
                    continue;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    Update?.Invoke();
                    continue;
                }
                else if (keyPressed == ConsoleKey.Delete)
                {
                    tBoxes[i].Clear();
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    if (!(i + 1 >= tBoxes.Count))
                    {
                        i++;
                    }
                    else
                    {
                        i++;
                        tBoxes.Add(new TextBox(""));
                        Update += tBoxes[i].Output;
                        tBoxes[i].ColorUpdated += (sender, color) => Console.WriteLine($"\nЦвет текста поля {i+1} изменен на \"{tBoxes[i].FontColor}\"\n");
                        tBoxes[i].TextUpdated += (sende,e) => Console.WriteLine($"\nТекст поля {i+1} был изменен\n с \"{e.OldText}\"\n на \"{e.NewText}\"");
                        tBoxes[i].BackgroundColorUpdated += (sender, color) => Console.WriteLine($"\nЦвет фона поля {i+1} изменен на \"{color}\"\n");
                    }
                    Update?.Invoke();
                    continue;
                }
                else if (keyPressed == ConsoleKey.UpArrow)
                {
                    if (!(i - 1 < 0))
                    {
                        i--;
                    }
                    else i = 0;
                    Update?.Invoke();
                    continue;
                }

            tBoxes[i].Text += key.KeyChar;
                Update?.Invoke();

            }
        }

    }
}
