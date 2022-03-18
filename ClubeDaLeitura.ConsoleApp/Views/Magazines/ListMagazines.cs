using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Magazines
{
    internal class ListMagazines
    {
        private readonly ServiceManager _serviceManager;

        public ListMagazines(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();

            if (_serviceManager.GetMagazineService().GetMagazines().Count == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetMagazineService().List(true);

                Console.ReadKey();
            }
        }
    }
}