using System;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Boxes
{
    internal class RegisterBox
    {
        private readonly ServiceManager _serviceManager;

        public RegisterBox(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        } 

        public void Show()
        {
            Console.Clear();
            Console.Write("Insira a cor da caixa: ");
            string color = Console.ReadLine();
            if (string.IsNullOrEmpty(color))
            {
                Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                Console.Write("Insira a etiqueta da caixa: ");
                string tag = Console.ReadLine();
                if (string.IsNullOrEmpty(tag))
                {
                    Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.Write("Insira o número da caixa: ");
                    int number = Convert.ToInt32(Console.ReadLine());

                    _serviceManager.GetBoxService().Register(new Box(color, tag, number));

                    Console.WriteLine();
                    Message.Send("Caixa registrada com sucesso!", ConsoleColor.Green, true);
                    Console.ReadKey();
                }
            }
        }
    }
}
