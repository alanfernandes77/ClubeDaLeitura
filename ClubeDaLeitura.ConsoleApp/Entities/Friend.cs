using System;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Entities
{
    internal class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResponsibleName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Penalty Penalty { get; set; }
        public bool HasLoan { get; set; }
        public bool HasPenalty { get; set; }

        public Friend(string name, string responsibleName, string phoneNumber, string address)
        {
            Id = new Random().Next(1, 10000);
            Name = name;
            ResponsibleName = responsibleName;
            PhoneNumber = phoneNumber;
            Address = address;
            HasLoan = false;
            HasPenalty = false;
            Penalty = null;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine($"Nome do Responsável: {ResponsibleName}");
            sb.AppendLine($"Telefone: {PhoneNumber}");
            sb.AppendLine($"Endereço: {Address}");
            if (Penalty != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                sb.AppendLine($"Multas: {Penalty.Amount} - Total: R$ {Penalty.Value * Penalty.Amount}");
                Console.ResetColor();
            }
            return sb.ToString();
        }
    }
}