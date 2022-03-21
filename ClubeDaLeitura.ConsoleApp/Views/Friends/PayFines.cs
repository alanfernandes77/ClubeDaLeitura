using System;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Friends
{
    internal class PayFines
    {
        private readonly ServiceManager _serviceManager;

        public PayFines(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();
            if (!_serviceManager.GetFriendService().HasPenalty())
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetFriendService().ListPenaltyFriends();

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
                    if (!friend.HasPenalty)
                    {
                        Console.WriteLine();
                        Message.Send("Este amigo não possui multas abertas.", ConsoleColor.Red, true);
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        bool run = true;
                        while (run)
                        {
                            Console.Clear();
                            Message.Send($"Multas encontradas de {friend.Name}:", ConsoleColor.DarkCyan, true);
                            Console.WriteLine();
                            Console.WriteLine(friend.Penalty);
                            Message.Send($"Deseja quitar estas multas?", ConsoleColor.DarkYellow, true);
                            Console.WriteLine();
                            Console.WriteLine("1 -> Sim");
                            Console.WriteLine();
                            Console.WriteLine("0 -> Voltar");
                            Console.WriteLine();
                            Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                            int option = Convert.ToInt32(Console.ReadLine());
                            switch (option)
                            {
                                case 1:
                                    friend.Penalty = null;
                                    friend.HasPenalty = false;
                                    Console.WriteLine();
                                    Message.Send("Multas quitadas com sucesso!.", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
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
}