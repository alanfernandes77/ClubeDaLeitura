using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Magazines
{
    internal class MagazineMenu
    {
        private readonly ServiceManager _serviceManager;
        private readonly RegisterMagazine _registerMagazine;
        private readonly ListMagazines _listMagazines;
        private readonly EditMagazine _editMagazine;
        private readonly DeleteMagazine _deleteMagazine;

        public MagazineMenu(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _registerMagazine = new RegisterMagazine(_serviceManager);
            _listMagazines = new ListMagazines(_serviceManager);
            _editMagazine = new EditMagazine(_serviceManager);
            _deleteMagazine = new DeleteMagazine(_serviceManager);
        }

        public void Show()
        {
            bool run = true;

            while (run)
            {
                Console.Clear();
                Message.Send("Modulo selecionado: Revista", ConsoleColor.DarkYellow, true);
                Console.WriteLine();
                Console.WriteLine("1 -> Registrar");
                Console.WriteLine("2 -> Listar");
                Console.WriteLine("3 -> Editar");
                Console.WriteLine("4 -> Excluir");
                Console.WriteLine();
                Console.WriteLine("0 -> Voltar");
                Console.WriteLine();
                Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        _registerMagazine.Show();
                        break;

                    case 2:
                        _listMagazines.Show();
                        break;

                    case 3:
                        _editMagazine.Show();
                        break;

                    case 4:
                        _deleteMagazine.Show();
                        break;

                    case 0:
                        run = false;
                        break;
                }
            }
        }
    }
}