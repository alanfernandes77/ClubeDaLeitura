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
            GetMagazines().Add(magazine);
        }

        public void Delete(Magazine magazine)
        {
            GetMagazines().Remove(magazine);
        }

        public void List(bool longInfo)
        {
            foreach (Magazine magazine in GetMagazines())
            {
                if (longInfo)
                {
                    Message.Send($"{magazine}", ConsoleColor.DarkYellow, true);
                }
                else
                {
                    Message.Send($"({magazine.Id}) Tipo de coleção: {magazine.Type}", ConsoleColor.DarkYellow, true);

                }
            }
        }

        public Magazine FindById(int id) => GetMagazines().Find(x => x.Id == id);

        public List<Magazine> GetMagazines() => _magazineList;
    }
}