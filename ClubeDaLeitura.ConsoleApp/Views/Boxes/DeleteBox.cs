using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Boxes
{
    internal class DeleteBox
    {
        private readonly ServiceManager _serviceManager;

        public DeleteBox(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();
            if (_serviceManager.GetBoxService().GetBoxes().Count == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetBoxService().List(false);

                Console.WriteLine();
                Console.Write("Insira um ID: ");

                int id = Convert.ToInt32(Console.ReadLine());
                Box box = _serviceManager.GetBoxService().FindById(id);
                if (box == null)
                {
                    Console.WriteLine();
                    Message.Send("Caixa não encontrada.", ConsoleColor.Red, true);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    _serviceManager.GetBoxService().Delete(box);

                    Console.WriteLine();
                    Message.Send("Caixa deletada com sucesso!", ConsoleColor.Green, true);
                    Console.ReadKey();
                }
            }
        }
    }
}