using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Entities
{
    internal class Penalty
    {
        public int Amount { get; set; }
        public decimal Value { get; set; }

        public Penalty(int amount, decimal value)
        {
            Amount = amount;
            Value = value;
        }

        public void PayOff()
        {
            Amount = 0;
            Value = 0;
        }

        public decimal GetTotalValue() => Amount * Value;

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Valor: R$ {Value}");
            sb.AppendLine($"Valor total: R$ {Value * Amount} ({Amount} x {Value})");
            sb.AppendLine($"Quantidade aplicada: {Amount}");
            return sb.ToString();
        }
    }
}