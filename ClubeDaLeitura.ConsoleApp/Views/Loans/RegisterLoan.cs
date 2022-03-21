using System;
using System.Globalization;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Loans
{
    internal class RegisterLoan
    {
        private readonly ServiceManager _serviceManager;

        public RegisterLoan(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public void Show()
        {
            Console.Clear();
            if (_serviceManager.GetFriendService().GetList().Count == 0 && _serviceManager.GetMagazineService().GetList().Count == 0)
            {
                Message.Send("É necessário ter 1 amigo e 1 revista cadastrada para que seja possível registrar um empréstimo.", ConsoleColor.Red, true);
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
                    Console.Write("Insira o ID do amigo a ser emprestado: ");
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
                        if (friend.HasPenalty)
                        {
                            Console.WriteLine();
                            Message.Send("Este amigo possui multas em aberto.", ConsoleColor.Red, true);
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            if (friend.HasLoan)
                            {
                                Console.WriteLine();
                                Message.Send("Este amigo possuí um empréstimo em aberto.\nSó é possível 1 empréstimo por amigo.", ConsoleColor.Red, true);
                                Console.ReadKey();
                                return;
                            }
                            else
                            {
                                if (!_serviceManager.GetMagazineService().HasMagazinesAvaiable())
                                {
                                    Console.WriteLine();
                                    Message.Send("Não há revistas disponíveis.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    _serviceManager.GetMagazineService().ListAvailableMagazines();
                                    Console.WriteLine();
                                    Console.Write("Insira o ID da revista a ser emprestada: ");
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
                                        Console.WriteLine();
                                        Console.Write("Insira a data que será emprestada: ");
                                        DateTime loanDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                                        friend.HasLoan = true;
                                        magazine.WasLoaned = true;
                                        _serviceManager.GetLoanService().Register(new Loan(friend, magazine, loanDate));

                                        Console.WriteLine();
                                        Message.Send("Empréstimo registrado com sucesso!", ConsoleColor.Green, true);
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
}