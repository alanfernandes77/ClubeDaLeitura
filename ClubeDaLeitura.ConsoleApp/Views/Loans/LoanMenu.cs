using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Loans
{
    internal class LoanMenu
    {
        private readonly ServiceManager _serviceManager;
        private readonly RegisterLoan _registerLoan;
        private readonly ListLoanMenu _listLoanMenu;
        private readonly EditLoan _editLoan;
        private readonly DeleteLoan _deleteLoan;

        public LoanMenu(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _registerLoan = new RegisterLoan(_serviceManager);
            _listLoanMenu = new ListLoanMenu(_serviceManager);
            _editLoan = new EditLoan(_serviceManager);
            _deleteLoan = new DeleteLoan(_serviceManager);
        }

        public void Show()
        {
            bool run = true;

            while (run)
            {
                Console.Clear();
                Message.Send("Modulo selecionado: Empréstimo", ConsoleColor.DarkYellow, true);
                Console.WriteLine();
                Console.WriteLine("1 -> Registrar");
                Console.WriteLine("2 -> Listar");
                Console.WriteLine("3 -> Editar");
                Console.WriteLine("4 -> Deletar");
                Console.WriteLine();
                Console.WriteLine("0 -> Voltar");
                Console.WriteLine();
                Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        _registerLoan.Show();
                        break;

                    case 2:
                        _listLoanMenu.Show();
                        break;

                    case 3:
                        _editLoan.Show();
                        break;

                    case 4:
                        _deleteLoan.Show();
                        break;

                    case 0:
                        run = false;
                        break;
                }
            }
        }
    }
}