using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Loans
{
    internal class DeleteLoan
    {
        private readonly ServiceManager _serviceManager;

        public DeleteLoan(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
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
                    _serviceManager.GetLoanService().Delete(loan);

                    Console.WriteLine();
                    Message.Send("Empréstimo deletado com sucesso!", ConsoleColor.Green, true);
                    Console.ReadKey();
                }
            }
        }
    }
}