using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Entities
{
    internal class Box
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public string Tag { get; set; }
        public int Number { get; set; }

        public Box(string color, string tag, int number)
        {
            Id = new Random().Next(1, 10000);
            Color = color;
            Tag = tag;
            Number = number;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Cor: {Color}");
            sb.AppendLine($"Etiqueta: {Tag}");
            sb.AppendLine($"Número: {Number}");
            return sb.ToString();
        }
    }
}