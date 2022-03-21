using System;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Entities
{
    internal class Reservation
    {
        public int Id { get; set; }
        public Friend Friend { get; set; }
        public Magazine Magazine { get; set; }
        public DateTime DevolutionDate { get; set; }

        public Reservation(Friend friend, Magazine magazine)
        {
            Id = new Random().Next(1, 10000);
            Friend = friend;
            Magazine = magazine;
            DevolutionDate = DateTime.Now.AddDays(2);
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Amigo: {Friend.Name}");
            sb.AppendLine($"Revista: {Magazine.Name}");
            sb.AppendLine($"Date de devolução: {DevolutionDate:dd/MM/yyyy}");
            return sb.ToString();
        }
    }
}