using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Reservations
{
    internal class ReservationMenu
    {
        private readonly ServiceManager _serviceManager;
        private readonly RegisterReservation _registerReservation;
        private readonly ListReservations _listReservations;

        public ReservationMenu(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _registerReservation = new(_serviceManager);
            _listReservations = new(_serviceManager);
        }

        public void Show()
        {
            bool run = true;

            while (run)
            {
                Console.Clear();
                Message.Send("Módulo: Reserva", ConsoleColor.DarkYellow, true);
                Console.WriteLine();
                Console.WriteLine("1 -> Registrar");
                Console.WriteLine("2 -> Listar");
                Console.WriteLine("3 -> Deletar");
                Console.WriteLine();
                Console.WriteLine("0 -> Voltar");
                Console.WriteLine();
                Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        _registerReservation.Show();
                        break;

                    case 2:
                        _listReservations.Show();
                        break;

                    case 3:
                        break;

                    case 0:
                        run = false;
                        break;
                }
            }
        }
    }
}
