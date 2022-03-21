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

        public Loan(Friend friend, Magazine magazine, DateTime loanDate)
        {
            Id = new Random().Next(1, 10000);
            Friend = friend;
            Magazine = magazine;
            LoanDate = loanDate;
            DevolutionDate = loanDate.AddDays(magazine.Category.MaxLoanDays); 
            LoanStatus = EnumLoanStatus.Aberto;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"ID: {Id}");
            sb.AppendLine($"Amigo emprestado: {Friend.Name}");
            sb.AppendLine($"Revista emprestada: {Magazine.Name}");
            sb.AppendLine($"Data em que foi emprestada: {LoanDate:dd/MM/yyyy}");
            sb.AppendLine($"Data prevista de devolução: {LoanDate.AddDays(Magazine.Category.MaxLoanDays):dd/MM/yyyy}");
            if (LoanStatus == EnumLoanStatus.Fechado)
            {
                sb.AppendLine($"Data de devolução: {DevolutionDate}");
            }
            sb.AppendLine($"Status: {LoanStatus}");
            return sb.ToString();
        }
    }
}