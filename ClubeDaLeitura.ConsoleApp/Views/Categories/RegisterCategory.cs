using System;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Categories
{
    internal class RegisterCategory
    {
        private readonly ServiceManager _serviceManager;

        public RegisterCategory(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();
            Console.Write("Insira o nome da categoria: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine();
                Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                Console.Write("Insira a quantidade máxima de dias que uma revista desta categoria poderá ser emprestada: ");
                int maxLoanDays = Convert.ToInt32(Console.ReadLine());

                _serviceManager.GetCategoryService().Register(new Category(name, maxLoanDays));

                Console.WriteLine();
                Message.Send("Categoria cadastrada com sucesso!", ConsoleColor.Green, true);
                Console.ReadKey();
            }
        }
    }
}