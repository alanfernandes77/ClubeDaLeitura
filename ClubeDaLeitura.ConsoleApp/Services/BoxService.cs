using System;
using System.Collections.Generic;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Services
{
    internal class BoxService
    {
        private readonly List<Box> _boxList;

        public BoxService()
        {
            _boxList = new List<Box>();
        }

        public void Register(Box box)
        {
            GetBoxes().Add(box);
        }

        public void Delete(Box box)
        {
            GetBoxes().Remove(box);
        }

        public void List(bool longInfo)
        {
            foreach (Box box in GetBoxes())
            {
                if (longInfo)
                {
                    Message.Send($"{box}", ConsoleColor.DarkYellow, true);
                }
                else
                {
                    Message.Send($"({box.Id}) Caixa: {box.Color}", ConsoleColor.DarkYellow, true);

                }
            }
        }

        public Box FindById(int id) => GetBoxes().Find(x => x.Id == id);

        public List<Box> GetBoxes() => _boxList;
    }
}