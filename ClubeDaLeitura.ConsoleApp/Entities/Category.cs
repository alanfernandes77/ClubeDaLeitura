using System;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Entities
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxLoanDays { get; set; }

        public Category(string name, int maxLoanDays)
        {
            Id = new Random().Next(1, 10000);
            Name = name;
            MaxLoanDays = maxLoanDays;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine($"Quantidade máxima de dias para empréstimo: {MaxLoanDays}");
            return sb.ToString();
        }
    }
}