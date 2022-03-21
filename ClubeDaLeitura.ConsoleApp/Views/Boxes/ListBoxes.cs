using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Boxes
{
    internal class ListBoxes
    {
        private readonly ServiceManager _serviceManager;

        public ListBoxes(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();

            if (_serviceManager.GetBoxService().GetList().Count == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetBoxService().List(true);

                Console.ReadKey();
            }
        }
    }
}