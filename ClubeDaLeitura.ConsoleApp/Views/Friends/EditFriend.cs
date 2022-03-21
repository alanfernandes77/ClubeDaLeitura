using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Friends
{
    internal class EditFriend
    {
        private readonly ServiceManager _serviceManager;

        public EditFriend(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            bool run = true;
            Console.Clear();
            if (_serviceManager.GetFriendService().GetList().Count == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetFriendService().List(false);

                Console.WriteLine();
                Console.Write("Insira um ID: ");

                int id = Convert.ToInt32(Console.ReadLine());
                Friend friend = _serviceManager.GetFriendService().FindById(id);
                if (friend == null)
                {
                    Console.WriteLine();
                    Message.Send("Amigo não encontrado.", ConsoleColor.Red, true);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    while (run)
                    {
                        Console.WriteLine();
                        Message.Send("O que deseja alterar?", ConsoleColor.DarkYellow, true);
                        Console.WriteLine();
                        Console.WriteLine("1 -> Nome");
                        Console.WriteLine("2 -> Nome do Responsável");
                        Console.WriteLine("3 -> Telefone");
                        Console.WriteLine("4 -> Endereço");
                        Console.WriteLine();
                        Console.WriteLine("0 -> Voltar");
                        Console.WriteLine();
                        Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("Insira um novo nome: ");
                                string newName = Console.ReadLine();
                                if (string.IsNullOrEmpty(newName))
                                {
                                    Console.WriteLine();
                                    Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    friend.Name = newName;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 2:
                                Console.Clear();
                                Console.Write("Insira o novo nome do reponsável: ");
                                string newResponsibleName = Console.ReadLine();
                                if (string.IsNullOrEmpty(newResponsibleName))
                                {
                                    Console.WriteLine();
                                    Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    friend.ResponsibleName = newResponsibleName;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 3:
                                Console.Clear();
                                Console.Write("Insira um novo telefone: ");
                                string newPhoneNumber = Console.ReadLine();
                                if (string.IsNullOrEmpty(newPhoneNumber))
                                {
                                    Console.WriteLine();
                                    Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    friend.PhoneNumber = newPhoneNumber;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 4:
                                Console.Clear();
                                Console.Write("Insira um novo endereço: ");
                                string newAddress = Console.ReadLine();
                                if (string.IsNullOrEmpty(newAddress))
                                {
                                    Console.WriteLine();
                                    Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    friend.Address = newAddress;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 0:
                                run = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}