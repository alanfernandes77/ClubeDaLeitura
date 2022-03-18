using System;
using System.Globalization;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Enums;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Loans
{
    internal class EditLoan
    {
        private readonly ServiceManager _serviceManager;

        public EditLoan(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            bool run = true;
            Console.Clear();
            if (_serviceManager.GetLoanService().GetLoans().Count == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetLoanService().ListAllLoans();

                Console.WriteLine();
                Console.Write("Insira um ID: ");

                int id = Convert.ToInt32(Console.ReadLine());
                Loan loan = _serviceManager.GetLoanService().FindById(id);
                if (loan == null)
                {
                    Console.WriteLine();
                    Message.Send("Empréstimo não encontrado.", ConsoleColor.Red, true);
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
                        Console.WriteLine("1 -> Amigo");
                        Console.WriteLine("2 -> Revista");
                        Console.WriteLine("3 -> Data do Empréstimo");
                        Console.WriteLine("4 -> Data de Devolução");
                        Console.WriteLine("5 -> Status do Empréstimo");
                        Console.WriteLine();
                        Console.WriteLine("0 -> Voltar");
                        Console.WriteLine();
                        Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.Clear();
                                Console.Clear();
                                _serviceManager.GetFriendService().List(false);
                                Console.WriteLine();
                                Console.Write("Insira um novo ID de amigo: ");
                                int newFriendId = Convert.ToInt32(Console.ReadLine());
                                Friend newFriend = _serviceManager.GetFriendService().FindById(newFriendId);
                                if (newFriend == null)
                                {
                                    Console.WriteLine();
                                    Message.Send("Amigo não encontrado.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    loan.Friend = newFriend;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 2:
                                Console.Clear();
                                _serviceManager.GetMagazineService().List(false);
                                Console.WriteLine();
                                Console.Write("Insira um novo ID de revista: ");
                                int newMagazineId = Convert.ToInt32(Console.ReadLine());
                                Magazine newMagazine = _serviceManager.GetMagazineService().FindById(newMagazineId);
                                if (newMagazine == null)
                                {
                                    Console.WriteLine();
                                    Message.Send("Revista não encontrada.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    loan.Magazine = newMagazine;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 3:
                                Console.Clear();
                                Console.Write("Insira uma nova data de empréstimo: ");
                                DateTime newLoanDate = DateTime.ParseExact(Console.ReadLine(), "yyyy", CultureInfo.InvariantCulture);
                                if (newLoanDate > loan.DevolutionDate)
                                {
                                    Console.WriteLine();
                                    Message.Send("A nova data de empréstimo não pode ser maior que a data atual de devolução.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    loan.LoanDate = newLoanDate;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 4:
                                Console.Clear();
                                Console.Write("Insira uma nova data de devolução: ");
                                DateTime newDevolutionDate = DateTime.ParseExact(Console.ReadLine(), "yyyy", CultureInfo.InvariantCulture);
                                if (newDevolutionDate < loan.LoanDate)
                                {
                                    Console.WriteLine();
                                    Message.Send("A nova data de devolução não pode ser menor que a data atual do empréstimo.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    loan.DevolutionDate = newDevolutionDate;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 5:
                                Console.Clear();
                                Message.Send("Selecione abaixo: ", ConsoleColor.DarkYellow, true);
                                Console.WriteLine();
                                Console.WriteLine("1 -> Definir como ABERTO");
                                Console.WriteLine("2 -> Definir como FECHADO");
                                Console.WriteLine();
                                Console.WriteLine("0 -> Voltar");
                                Console.WriteLine();
                                Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                                int option2 = Convert.ToInt32(Console.ReadLine());
                                switch (option2)
                                {
                                    case 1:
                                        if (loan.LoanStatus == EnumLoanStatus.Aberto)
                                        {
                                            Console.WriteLine();
                                            Message.Send("Este empréstimo já está definido como ABERTO.", ConsoleColor.Red, true);
                                            Console.ReadKey();
                                            run = false;
                                        }
                                        else
                                        {
                                            loan.LoanStatus = EnumLoanStatus.Aberto;
                                            Console.WriteLine();
                                            Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                            Console.ReadKey();
                                            run = false;
                                        }
                                        break;

                                    case 2:
                                        if (loan.LoanStatus == EnumLoanStatus.Fechado)
                                        {
                                            Console.WriteLine();
                                            Message.Send("Este empréstimo já está definido como FECHADO.", ConsoleColor.Red, true);
                                            Console.ReadKey();
                                            run = false;
                                        }
                                        else
                                        {
                                            loan.LoanStatus = EnumLoanStatus.Fechado;
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

                                Console.WriteLine();
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