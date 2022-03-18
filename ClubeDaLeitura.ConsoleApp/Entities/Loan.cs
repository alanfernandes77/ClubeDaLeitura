using System;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Enums;

namespace ClubeDaLeitura.ConsoleApp.Entities
{
    internal class Loan
    {
        public int Id { get; set; }
        public Friend Friend { get; set; }
        public Magazine Magazine { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DevolutionDate { get; set; }

        public EnumLoanStatus LoanStatus { get; set; }

        public Loan(Friend friend, Magazine magazine, DateTime loanDate, DateTime devolutionDate)
        {
            Id = new Random().Next(1, 10000);
            Friend = friend;
            Magazine = magazine;
            LoanDate = loanDate;
            DevolutionDate = devolutionDate;
            LoanStatus = EnumLoanStatus.Aberto;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Amigo emprestado: {Friend.Name}");
            sb.AppendLine($"Revista emprestada: {Magazine.Type}");
            sb.AppendLine($"Data em que foi emprestada: {LoanDate:dd/MM/yyyy}");
            sb.AppendLine($"Data prevista de devolução: {DevolutionDate:dd/MM/yyyy}");
            sb.AppendLine($"Status: {LoanStatus}");
            return sb.ToString();
        }
    }
}