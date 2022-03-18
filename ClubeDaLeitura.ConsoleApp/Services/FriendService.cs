using System;
using System.Collections.Generic;
using ClubeDaLeitura.ConsoleApp.Entities;
using ClubeDaLeitura.ConsoleApp.Utils;

namespace ClubeDaLeitura.ConsoleApp.Services
{
    internal class FriendService
    {
        private readonly List<Friend> _friendsList;

        public FriendService()
        {
            _friendsList = new List<Friend>();
        }

        public void Register(Friend friend)
        {
            GetFriends().Add(friend);
        }

        public void Delete(Friend friend)
        {
            GetFriends().Remove(friend);
        }

        public void List(bool longInfo)
        {
            foreach (Friend friend in GetFriends())
            {
                if (longInfo)
                {
                    Message.Send($"{friend}", ConsoleColor.DarkYellow, true);
                }
                else
                {
                    Message.Send($"({friend.Id}) {friend.Name}", ConsoleColor.DarkYellow, true);

                }
            }
        }

        public Friend FindById(int id) => GetFriends().Find(x => x.Id == id);

        public List<Friend> GetFriends() => _friendsList;
    }
}