using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Reservations
{
    internal class ListReservations
    {
        private readonly ServiceManager _serviceManager;
        
        public ListReservations(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();
            if (_serviceManager.GetReservationService().GetList().Count == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Registros encontrados: {_serviceManager.GetReservationService().GetList().Count}");
                Console.WriteLine();
                _serviceManager.GetReservationService().List();
                Console.ReadKey();
            }
        }
    }
}