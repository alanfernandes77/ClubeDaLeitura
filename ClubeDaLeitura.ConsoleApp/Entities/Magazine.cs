using System;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Entities
{
    internal class Magazine
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int EditionNumber { get; set; }
        public DateTime Year { get; set; }
        public Box Box { get; set; }

        public Magazine(string type, int editionNumber, DateTime year, Box box)
        {
            Id = new Random().Next(1, 10000);
            Type = type;
            EditionNumber = editionNumber;
            Year = year;
            Box = box;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Tipo de coleção: {Type}");
            sb.AppendLine($"Número da Edição: {EditionNumber}");
            sb.AppendLine($"Ano: {Year:yyyy}");
            sb.AppendLine($"Caixa: [({Box.Id}) | {Box.Color} | {Box.Tag} | {Box.Number}]");
            return sb.ToString();
        }
    }
}