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
            GetList().Add(friend);
        }

        public void Delete(Friend friend)
        {
            GetList().Remove(friend);
        }

        public void List(bool longInfo)
        {
            foreach (Friend friend in GetList())
            {
                if (longInfo)
                {
                    {
                        Message.Send($"{friend}", ConsoleColor.DarkYellow, true);
                    }
                }
                else
                {
                    Message.Send($"({friend.Id}) {friend.Name}", ConsoleColor.DarkYellow, true);
                }
            }
        }

        public void ListAvailableFriends()
        {
            foreach (Friend friend in GetList())
            {
                if (!friend.HasLoan && !friend.HasPenalty)
                {
                    Message.Send($"({friend.Id}) {friend.Name}", ConsoleColor.DarkYellow, true);
                }
            }
        }

        public void ListPenaltyFriends()
        {
            foreach (Friend friend in GetList())
            {
                if (friend.HasPenalty)
                {
                    Message.Send($"({friend.Id}) {friend.Name}", ConsoleColor.DarkYellow, true);
                }
            }
        }

        public bool HasFriendsAvailable()
        {
            foreach (Friend friend in GetList())
            {
                if (!friend.HasLoan)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasPenalty()
        {
            foreach (Friend friend in GetList())
            {
                if (!friend.HasPenalty)
                {
                    return true;
                }
            }
            return false;
        }

        public Friend FindById(int id) => GetList().Find(x => x.Id == id);

        public List<Friend> GetList() => _friendsList;
    }
}