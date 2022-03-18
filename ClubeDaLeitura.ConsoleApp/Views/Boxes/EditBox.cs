using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Boxes
{
    internal class EditBox
    {
        private readonly ServiceManager _serviceManager;

        public EditBox(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            bool run = true;
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
                    while (run)
                    {
                        Console.WriteLine();
                        Message.Send("O que deseja alterar?", ConsoleColor.DarkYellow, true);
                        Console.WriteLine();
                        Console.WriteLine("1 -> Cor");
                        Console.WriteLine("2 -> Etiqueta");
                        Console.WriteLine("3 -> Numero");
                        Console.WriteLine();
                        Console.WriteLine("0 -> Voltar");
                        Console.WriteLine();
                        Message.Send("Opção: ", ConsoleColor.DarkCyan, false);

                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("Insira uma nova cor: ");
                                string newColor = Console.ReadLine();
                                if (string.IsNullOrEmpty(newColor))
                                {
                                    Console.WriteLine();
                                    Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    box.Color = newColor;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 2:
                                Console.Clear();
                                Console.Write("Insira uma nova etiqueta: ");
                                string newTag = Console.ReadLine();
                                if (string.IsNullOrEmpty(newTag))
                                {
                                    Console.WriteLine();
                                    Message.Send("Este campo não pode ser nulo.", ConsoleColor.Red, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                else
                                {
                                    box.Tag = newTag;
                                    Console.WriteLine();
                                    Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                    Console.ReadKey();
                                    run = false;
                                }
                                break;

                            case 3:
                                Console.Clear();
                                Console.Write("Insira um novo número: ");
                                int newNumber = Convert.ToInt32(Console.ReadLine());
                                box.Number = newNumber;
                                Console.WriteLine();
                                Message.Send("Campo alterado com sucesso!", ConsoleColor.Green, true);
                                Console.ReadKey();
                                run = false;
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