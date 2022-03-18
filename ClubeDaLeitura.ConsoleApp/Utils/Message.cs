using System;

namespace ClubeDaLeitura.ConsoleApp.Utils
{
    internal class Message
    {
        public static void Send(string message, ConsoleColor color, bool writeLine)
        {
            if (writeLine)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = color;
                Console.Write(message);
                Console.ResetColor();
            }
        }
    }
}