using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Reservations
{
    internal class RegisterReservation
    {
        private readonly ServiceManager _serviceManager;

        public RegisterReservation(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();
            if (_serviceManager.GetFriendService().GetList().Count == 0 && _serviceManager.GetMagazineService().GetList().Count == 0)
            {
                Message.Send("É necessário ter 1 amigo e 1 revista cadastrada para realizar uma reserva.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                if (!_serviceManager.GetFriendService().HasFriendsAvailable())
                {
                    Message.Send("Não há amigos disponíveis.", ConsoleColor.Red, true);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    _serviceManager.GetFriendService().ListAvailableFriends();
                    Console.WriteLine();
                    Console.Write("Insira o ID do amigo: ");
                    int friendId = Convert.ToInt32(Console.ReadLine());
                    Friend friend = _serviceManager.GetFriendService().FindById(friendId);
                    if (friend == null)
                    {
                        Console.WriteLine();
                        Message.Send("Amigo não encontrado.", ConsoleColor.Red, true);
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        if (friend.HasLoan)
                        {
                            Console.WriteLine();
                            Message.Send("Este amigo possui um empréstimo em aberto.\nSó é possível realizar uma reserva após o empréstimo ativo ser quitado.", ConsoleColor.Red, true);
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            if (!_serviceManager.GetMagazineService().HasMagazinesAvaiable())
                            {
                                Message.Send("Não há revistas disponíveis.", ConsoleColor.Red, true);
                                Console.ReadKey();
                                return;
                            }
                            else
                            {
                                Console.WriteLine();
                                _serviceManager.GetMagazineService().ListAvailableMagazines();
                                Console.WriteLine();
                                Console.Write("Insira o ID da revista: ");
                                int magazineId = Convert.ToInt32(Console.ReadLine());
                                Magazine magazine = _serviceManager.GetMagazineService().FindById(magazineId);
                                if (magazine == null)
                                {
                                    Console.WriteLine();
                                    Message.Send("Revista não encontrada.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    return;
                                }
                                else
                                {
                                    _serviceManager.GetReservationService().Register(new Reservation(friend, magazine));
                                    Console.WriteLine();
                                    Message.Send("Reserva realizada com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
