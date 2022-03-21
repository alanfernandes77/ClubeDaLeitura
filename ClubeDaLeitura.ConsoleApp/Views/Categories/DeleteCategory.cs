using System;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Categories
{
    internal class DeleteCategory
    {
        private readonly ServiceManager _serviceManager;

        public DeleteCategory(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();
            if (_serviceManager.GetCategoryService().GetList().Count == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetCategoryService().List(false);

                Console.WriteLine();
                Console.Write("Insira um ID: ");

                int id = Convert.ToInt32(Console.ReadLine());
                Category category = _serviceManager.GetCategoryService().FindById(id);
                if (category == null)
                {
                    Console.WriteLine();
                    Message.Send("Categoria não encontrada.", ConsoleColor.Red, true);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    _serviceManager.GetCategoryService().Delete(category);

                    Console.WriteLine();
                    Message.Send("Categoria deletada com sucesso!", ConsoleColor.Green, true);
                    Console.ReadKey();
                }
            }
        }
    }
}