using System;
using System.Collections.Generic;
using ClubeDaLeitura.ConsoleApp.Entities;

namespace ClubeDaLeitura.ConsoleApp.Services
{
    internal class ReservationService
    {
        private readonly List<Reservation> _reservationsList;

        public ReservationService()
        {
            _reservationsList = new List<Reservation>();
        }

        public void Register(Reservation reservation)
        {
            GetList().Add(reservation);
        }

        public void Delete(Reservation reservation)
        {
            GetList().Remove(reservation);
        }

        public void List()
        {
            foreach (Reservation reservation in GetList())
            {
                Console.WriteLine(reservation);
            }
        }

        public Reservation FindById(int id) => GetList().Find(x => x.Id == id);

        public List<Reservation> GetList() => _reservationsList;
    }
}