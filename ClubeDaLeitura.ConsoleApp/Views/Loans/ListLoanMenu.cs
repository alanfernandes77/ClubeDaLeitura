using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Loans
{
    internal class ListLoanMenu
    {
        private readonly ServiceManager _serviceManager;

        public ListLoanMenu(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            bool run = true;

            while (run)
            {
                Console.Clear();
                Message.Send("O que deseja visualizar?", ConsoleColor.DarkYellow, true);
                Console.WriteLine();
                Console.WriteLine("1 -> Empréstimos do mês");
                Console.WriteLine("2 -> Abertos");
                Console.WriteLine("3 -> Fechados");
                Console.WriteLine();
                Console.WriteLine("0 -> Voltar");
                Console.WriteLine();
                Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        _serviceManager.GetLoanService().ListMonthLoans();
                        Console.ReadKey();
                        Show();
                        run = false;
                        break;

                    case 2:
                        Console.Clear();
                        _serviceManager.GetLoanService().ListOpenLoans();
                        Console.ReadKey();
                        Show();
                        run = false;
                        break;

                    case 3:
                        Console.Clear();
                        _serviceManager.GetLoanService().ListCloseLoans();
                        Console.ReadKey();
                        Show();
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