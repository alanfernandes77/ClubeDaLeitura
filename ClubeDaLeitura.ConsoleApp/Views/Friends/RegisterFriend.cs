using System;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Friends
{ 
    internal class RegisterFriend
    {
        private readonly ServiceManager _serviceManager;

        public RegisterFriend(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();
            
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Message.Send($"Este campo não pode ser nulo.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                Console.Write("Nome do Responsável: ");
                string responsibleName = Console.ReadLine();
                if (string.IsNullOrEmpty(responsibleName))
                {
                    Message.Send($"Este campo não pode ser nulo.", ConsoleColor.Red, true);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.Write("Telefone: ");
                    string phoneNumber = Console.ReadLine();
                    if (string.IsNullOrEmpty(phoneNumber))
                    {
                        Message.Send($"Este campo não pode ser nulo.", ConsoleColor.Red, true);
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.Write("Endereço: ");
                        string address = Console.ReadLine();
                        if (string.IsNullOrEmpty(address))
                        {
                            Message.Send($"Este campo não pode ser nulo.", ConsoleColor.Red, true);
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            _serviceManager.GetFriendService().Register(new Friend(name, responsibleName, phoneNumber, address));

                            Console.WriteLine();
                            Message.Send("Amigo registrado com sucesso!", ConsoleColor.Green, true);
                            Console.ReadKey();
                        }
                    }
                }
            }
        }
    }
}