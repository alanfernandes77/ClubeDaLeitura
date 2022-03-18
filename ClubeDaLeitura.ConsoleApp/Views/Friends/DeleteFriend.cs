using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Friends
{
    internal class DeleteFriend
    {
        private readonly ServiceManager _serviceManager;

        public DeleteFriend(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();
            if (_serviceManager.GetFriendService().GetFriends().Count == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetFriendService().List(false);

                Console.WriteLine();
                Console.Write("Insira um ID: ");

                int id = Convert.ToInt32(Console.ReadLine());
                Friend friend = _serviceManager.GetFriendService().FindById(id);
                if (friend == null)
                {
                    Console.WriteLine();
                    Message.Send("Amigo não encontrado.", ConsoleColor.Red, true);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    _serviceManager.GetFriendService().Delete(friend);

                    Console.WriteLine();
                    Message.Send("Amigo deletado com sucesso!", ConsoleColor.Green, true);
                    Console.ReadKey();
                }
            }
        }
    }
}