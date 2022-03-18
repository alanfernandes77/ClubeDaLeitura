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
            if (_serviceManager.GetFriendService().GetFriends().Count == 0 && _serviceManager.GetMagazineService().GetMagazines().Count == 0)
            {
                Message.Send("É necessário ter 1 amigo e 1 revista cadastrada para que seja possível registrar um empréstimo.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetFriendService().List(false);
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
                    if (friend.HasLoan)
                    {
                        Console.WriteLine();
                        Message.Send("Este amigo possuí um empréstimo em aberto.\nSó é possível 1 empréstimo por amigo.", ConsoleColor.Red, true);
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine();
                        _serviceManager.GetMagazineService().List(false);
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

                            Console.Write("Insira a data prevista a ser devolvida: ");
                            DateTime devolutionDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            if (devolutionDate < loanDate)
                            {
                                Console.WriteLine();
                                Message.Send("A data de devolução deve ser maior que a data do empréstimo.", ConsoleColor.Red, true);
                                Console.ReadKey();
                                return;
                            }
                            else
                            {
                                friend.HasLoan = true;
                                _serviceManager.GetLoanService().Register(new Loan(friend, magazine, loanDate, devolutionDate));

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