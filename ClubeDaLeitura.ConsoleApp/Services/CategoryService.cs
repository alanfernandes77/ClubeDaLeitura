using System;
using System.Collections.Generic;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Services
{
    internal class CategoryService
    {
        private readonly List<Category> _categoryList;

        public CategoryService()
        {
            _categoryList = new List<Category>();
        }

        public void Register(Category category)
        {
            GetList().Add(category);
        }

        public void Delete(Category category)
        {
            GetList().Remove(category);
        }

        public void List(bool longInfo)
        {
            foreach (Category category in GetList())
            {
                if (longInfo)
                {
                    Message.Send($"{category}", ConsoleColor.DarkYellow, true);
                }
                else
                {
                    Message.Send($"({category.Id}) Nome: {category.Name}", ConsoleColor.DarkYellow, true);

                }
            }
        }


        public Category FindById(int id) => GetList().Find(x => x.Id == id);

        public List<Category> GetList() => _categoryList;
    }
}