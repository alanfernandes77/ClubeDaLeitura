using System;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Entities
{
    internal class Magazine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EditionNumber { get; set; }
        public DateTime Year { get; set; }
        public Box Box { get; set; }

        public Category Category { get; set; }
        public bool WasLoaned { get; set; }

        public Magazine(string name, int editionNumber, DateTime year, Box box, Category category)
        {
            Id = new Random().Next(1, 10000);
            Name = name;
            EditionNumber = editionNumber;
            Year = year;
            Box = box;
            Category = category;
            WasLoaned = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Nome: {Name}");
            sb.AppendLine($"Número da Edição: {EditionNumber}");
            sb.AppendLine($"Ano: {Year:yyyy}");
            sb.AppendLine($"Caixa: [({Box.Id}) - {Box.Color} | {Box.Tag} | {Box.Number}]");
            sb.AppendLine($"Categoria: [({Category.Id}) - {Category.Name}]");
            return sb.ToString();
        }
    }
}