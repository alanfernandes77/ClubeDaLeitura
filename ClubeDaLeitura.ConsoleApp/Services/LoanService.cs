using System;
using System.Collections.Generic;
using ClubeDaLeitura.ConsoleApp.Enums;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Services
{
    internal class LoanService
    {
        private readonly List<Loan> _loanList;

        public LoanService()
        {
            _loanList = new List<Loan>();
        }

        public void Register(Loan loan)
        {
            GetLoans().Add(loan);
        }

        public void Delete(Loan loan)
        {
            GetLoans().Remove(loan);
        }

        public void ListAllLoans()
        {
            foreach (Loan loan in GetLoans())
            {
                if (loan.LoanStatus == EnumLoanStatus.Aberto)
                {
                    Message.Send($"({loan.Id}) - Amigo: {loan.Friend.Name} | Revista: {loan.Magazine.Type} - STATUS: {loan.LoanStatus}", ConsoleColor.Green, true);
                }
                else
                {
                    Message.Send($"({loan.Id}) - Amigo: {loan.Friend.Name} | Revista: {loan.Magazine.Type} - STATUS: {loan.LoanStatus}", ConsoleColor.DarkGray, true);
                }
            }
        }

        public void ListMonthLoans()
        {
            int monthLoans = 0;
            foreach (Loan loan in GetLoans())
            {

                if (DateTime.Now.Month == loan.LoanDate.Month)
                {
                    if (loan.LoanStatus == EnumLoanStatus.Aberto)
                    {
                        Message.Send($"{loan}", ConsoleColor.Green, true);
                    }
                    else
                    {
                        Message.Send($"{loan}", ConsoleColor.DarkGray, true);
                    }
                    monthLoans++;
                }
            }
            if (monthLoans == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
            }
        }

        public void ListOpenLoans()
        {
            int openLoans = 0; 
            foreach (Loan loan in GetLoans())
            {
                if (loan.LoanStatus == EnumLoanStatus.Aberto)
                {
                    Message.Send($"{loan}", ConsoleColor.Green, true);
                    openLoans++;
                }
            }
            if (openLoans == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
            }
        }

        public void ListCloseLoans()
        {
            int closeLoans = 0;
            foreach (Loan loan in GetLoans())
            {
                if (loan.LoanStatus == EnumLoanStatus.Fechado)
                {
                    Message.Send($"{loan}", ConsoleColor.DarkGray, true);
                    closeLoans++;
                }
            }
            if (closeLoans == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
            }
        }

        public Loan FindById(int id) => GetLoans().Find(x => x.Id == id);

        public List<Loan> GetLoans() => _loanList;
    }
}