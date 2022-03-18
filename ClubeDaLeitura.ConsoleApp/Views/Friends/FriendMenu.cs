using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Friends
{
    internal class FriendMenu
    {
        private readonly ServiceManager _serviceManager;
        private readonly RegisterFriend _registerFriend;
        private readonly ListFriends _listFriends;
        private readonly EditFriend _editFriend;
        private readonly DeleteFriend _deleteFriend;

        public FriendMenu(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
            _registerFriend = new(_serviceManager);
            _editFriend = new(_serviceManager);
            _listFriends = new(_serviceManager);
            _deleteFriend = new(_serviceManager);
        }

        public void Show()
        {
            bool run = true;

            while (run)
            {
                Console.Clear();
                Message.Send("Modulo selecionado: Amigo", ConsoleColor.DarkYellow, true);
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
                        _registerFriend.Show();
                        break;

                    case 2:
                        _listFriends.Show();
                        break;

                    case 3:
                        _editFriend.Show();
                        break;

                    case 4:
                        _deleteFriend.Show();
                        break;

                    case 0:
                        run = false;
                        break;
                }
            }
        }
    }
}