using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Magazines
{
    internal class RegisterMagazine
    {
        private readonly ServiceManager _serviceManager;

        public RegisterMagazine(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();
            if (_serviceManager.GetBoxService().GetBoxes().Count == 0)
            {
                Message.Send("Para registrar uma revista é necessário ter ao menos 1 caixa registrada.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                Console.Write("Insira o tipo da coleção: ");
                string type = Console.ReadLine();
                if (string.IsNullOrEmpty(type))
                {
                    Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.Write("Insira o número da edição: ");
                    int editionNumber = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Insira o ano da revista: ");
                    DateTime year = DateTime.ParseExact(Console.ReadLine(), "yyyy", CultureInfo.InvariantCulture);
                    Console.WriteLine();

                    _serviceManager.GetBoxService().List(false);

                    Console.WriteLine();
                    Console.Write("Insira o ID da caixa que deseja guardar esta revista: ");
                    int boxId = Convert.ToInt32(Console.ReadLine());
                    Box box = _serviceManager.GetBoxService().FindById(boxId);

                    if (box == null)
                    {
                        Message.Send("Caixa não encontrada.", ConsoleColor.Red, true);
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        _serviceManager.GetMagazineService().Register(new Magazine(type, editionNumber, year, box));

                        Console.WriteLine();
                        Message.Send("Revista registrada com sucesso!", ConsoleColor.Green, true);
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}