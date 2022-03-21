using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Categories
{
    internal class CategoryMenu
    {
        private readonly ServiceManager _serviceManager;
        private readonly RegisterCategory _registerCategory;
        private readonly ListCategories _listCategories;
        private readonly DeleteCategory _deleteCategory;

        public CategoryMenu(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _registerCategory = new RegisterCategory(_serviceManager);
            _listCategories = new ListCategories(_serviceManager);
            _deleteCategory = new DeleteCategory(_serviceManager);
        }

        public void Show()
        {
            bool run = true;

            while (run)
            {
                Console.Clear();
                Message.Send("Modulo selecionado: Categoria", ConsoleColor.DarkYellow, true);
                Console.WriteLine();
                Console.WriteLine("1 -> Registrar");
                Console.WriteLine("2 -> Listar");
                Console.WriteLine("3 -> Excluir");
                Console.WriteLine();
                Console.WriteLine("0 -> Voltar");
                Console.WriteLine();
                Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        _registerCategory.Show();
                        break;

                    case 2:
                        _listCategories.Show();
                        break;

                    case 3:
                        _deleteCategory.Show();
                        break;

                    case 0:
                        run = false;
                        break;
                }
            }
        }
    }
}