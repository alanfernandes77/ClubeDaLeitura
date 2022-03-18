using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;
using ClubeDaLeitura.ConsoleApp.Views.Friends;
using ClubeDaLeitura.ConsoleApp.Views.Boxes;
using ClubeDaLeitura.ConsoleApp.Views.Magazines;
using ClubeDaLeitura.ConsoleApp.Views.Loans;

namespace ClubeDaLeitura.ConsoleApp.Views
{
    internal class MainMenu
    {
        private readonly ServiceManager _serviceManager;
        private readonly FriendMenu _friendMenu;
        private readonly BoxMenu _boxMenu;
        private readonly MagazineMenu _magazineMenu;
        private readonly LoanMenu _loanMenu;

        public MainMenu()
        {
            _serviceManager = new();
            _friendMenu = new FriendMenu(_serviceManager);
            _boxMenu = new BoxMenu(_serviceManager);
            _magazineMenu = new MagazineMenu(_serviceManager); 
            _loanMenu = new LoanMenu(_serviceManager);
        }

        public void Show()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Message.Send("Clube da Leitura v1.0", ConsoleColor.DarkMagenta, true);
                    Console.WriteLine();
                    Message.Send("Módulos:", ConsoleColor.DarkYellow, true);
                    Console.WriteLine();
                    Console.WriteLine("1 -> Amigo");
                    Console.WriteLine("2 -> Caixa");
                    Console.WriteLine("3 -> Revista");
                    Console.WriteLine("4 -> Empréstimo");
                    Console.WriteLine();
                    Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            _friendMenu.Show();
                            break;

                        case 2:
                            _boxMenu.Show();
                            break;

                        case 3:
                            _magazineMenu.Show();
                            break;

                        case 4:
                            _loanMenu.Show();
                            break;

                        case 0:
                            Environment.Exit(0);
                            break;
                    }
                }
            } catch (FormatException)
            {
                Console.WriteLine();
                Message.Send("Valor inválido.", ConsoleColor.Red, true);
                Console.ReadKey();
                Show();
            }
        }
    }
}