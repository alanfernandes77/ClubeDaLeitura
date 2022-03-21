﻿using System;
using ClubeDaLeitura.ConsoleApp.Services;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Views.Categories
{
    internal class ListCategories
    {
        private readonly ServiceManager _serviceManager;
        public ListCategories(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public void Show()
        {
            Console.Clear();

            if (_serviceManager.GetCategoryService().GetList().Count == 0)
            {
                Message.Send("Nenhum registro encontrado.", ConsoleColor.Red, true);
                Console.ReadKey();
                return;
            }
            else
            {
                _serviceManager.GetCategoryService().List(true);

                Console.ReadKey();
            }
        }
    }
}