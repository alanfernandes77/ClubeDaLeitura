using System;
using System.Collections.Generic;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Services
{
    internal class MagazineService
    {
        private readonly List<Magazine> _magazineList;

        public MagazineService()
        {
            _magazineList = new List<Magazine>();
        }

        public void Register(Magazine magazine)
        {
            GetList().Add(magazine);
        }

        public void Delete(Magazine magazine)
        {
            GetList().Remove(magazine);
        }

        public void List(bool longInfo)
        {
            foreach (Magazine magazine in GetList())
            {
                if (longInfo)
                {
                    Message.Send($"{magazine}", ConsoleColor.DarkYellow, true);
                }
                else
                {
                    Message.Send($"({magazine.Id}) Nome: {magazine.Name} | Categoria: {magazine.Category.Name}", ConsoleColor.DarkYellow, true);

                }
            }
        }

        public void ListAvailableMagazines()
        {
            foreach (Magazine magazine in GetList())
            {
                if (!magazine.WasLoaned)
                {
                    Message.Send($"({magazine.Id}) Nome: {magazine.Name}", ConsoleColor.DarkYellow, true);
                }
            }
        }

        public bool HasMagazinesAvaiable()
        {
            foreach (Magazine magazine in GetList())
            {
                if (!magazine.WasLoaned)
                {
                    return true;
                }
            }
            return false;
        }

        public Magazine FindById(int id) => GetList().Find(x => x.Id == id);

        public List<Magazine> GetList() => _magazineList;
    }
}