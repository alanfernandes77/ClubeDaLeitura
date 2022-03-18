using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Boxes
{
    internal class BoxMenu
    {
        private readonly ServiceManager _serviceManager;
        private readonly RegisterBox _registerBox;
        private readonly ListBoxes _listBoxes;
        private readonly EditBox _editBox;
        private readonly DeleteBox _deleteBox;

        public BoxMenu(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _registerBox = new RegisterBox(_serviceManager);
            _listBoxes = new ListBoxes(_serviceManager);
            _editBox = new EditBox(_serviceManager);
            _deleteBox = new DeleteBox(_serviceManager);
        }

        public void Show()
        {
            bool run = true;

            while (run)
            {
                Console.Clear();
                Message.Send("Modulo selecionado: Caixa", ConsoleColor.DarkYellow, true);
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
                        _registerBox.Show();
                        break;

                    case 2:
                        _listBoxes.Show();
                        break;

                    case 3:
                        _editBox.Show();
                        break;

                    case 4:
                        _deleteBox.Show();
                        break;

                    case 0:
                        run = false;
                        break;
                }
            }
        }
    }
}