using System;
using System.Globalization;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Magazines
{
    internal class EditMagazine
    {
        private readonly ServiceManager _serviceManager;

        public EditMagazine(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            bool run = true;
            Console.Clear();
            if (_serviceManager.GetMagazineService().GetMagazines().Count == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetMagazineService().List(false);

                Console.WriteLine();
                Console.Write("Insira um ID: ");

                int id = Convert.ToInt32(Console.ReadLine());
                Magazine magazine = _serviceManager.GetMagazineService().FindById(id);
                if (magazine == null)
                {
                    Console.WriteLine();
                    Message.Send("Revista não encontrada.", ConsoleColor.Red, true);
                    Console.ReadKey();
                    return;
                }
                else
                {
                    while (run)
                    {
                        Console.WriteLine();
                        Message.Send("O que deseja alterar?", ConsoleColor.DarkYellow, true);
                        Console.WriteLine();
                        Console.WriteLine("1 -> Tipo de Coleção");
                        Console.WriteLine("2 -> Número de Edição");
                        Console.WriteLine("3 -> Ano");
                        Console.WriteLine("4 -> Caixa");
                        Console.WriteLine();
                        Console.WriteLine("0 -> Voltar");
                        Console.WriteLine();
                        Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("Insira um novo tipo de coleção: ");
                                string newType = Console.ReadLine();
                                if (string.IsNullOrEmpty(newType))
                                {
                                    Console.WriteLine();
                                    Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    magazine.Type = newType;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 2:
                                Console.Clear();
                                Console.Write("Insira um novo número de edição: ");
                                int newEditionNumber = Convert.ToInt32(Console.ReadLine());
                                magazine.EditionNumber = newEditionNumber;
                                Console.WriteLine();
                                Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                Console.ReadKey();
                                run = false;
                                break;

                            case 3:
                                Console.Clear();
                                Console.Write("Insira um novo ano: ");
                                DateTime newYear = DateTime.ParseExact(Console.ReadLine(), "yyyy", CultureInfo.InvariantCulture);
                                magazine.Year = newYear;
                                Console.WriteLine();
                                Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                Console.ReadKey();
                                run = false;
                                break;

                            case 4:
                                Console.Clear();
                                _serviceManager.GetBoxService().List(false);
                                Console.WriteLine();
                                Console.Write("Insira um novo ID de caixa: ");
                                int newBoxId = Convert.ToInt32(Console.ReadLine());
                                Box newBox = _serviceManager.GetBoxService().FindById(newBoxId);
                                if (newBox == null)
                                {
                                    Console.WriteLine();
                                    Message.Send("Caixa não encontrada.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    magazine.Box = newBox;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 0:
                                run = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}