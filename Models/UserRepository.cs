using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Globalization;

namespace UserApi.Models
{
    public class UserRepository : IUserRepository
    {
        private static ConcurrentDictionary<string, UserItem> _users =
              new ConcurrentDictionary<string, UserItem>();

        public UserRepository()
        {
            //generate stub
            Add(new UserItem
            {
                Headshot = "https://randomuser.me/api/portraits/women/63.jpg",
                Name = "Jacinta Moura",
                Archetype = "CSS integator",
                Age = 25,
                Status = "Dating",
                Location = "Rennes, France",
                Income = 30000
            });
            Add(new UserItem
            {
                Headshot = "https://randomuser.me/api/portraits/men/49.jpg",
                Name = "Nicklas Mortensen",
                Archetype = "SexNewBrandShop C.E.O",
                Age = 45,
                Status = "Single",
                Location = "Riga, Georgia",
                Income = 456700
            });
            Add(new UserItem
            {
                Headshot = "https://randomuser.me/api/portraits/women/36.jpg",
                Name = "Nanna Rasmussen",
                Archetype = "Window shopper",
                Age = 32,
                Status = "Married",
                Location = "New York,USA",
                Income = 25000
            });
            Add(new UserItem
            {
                Headshot = "https://randomuser.me/api/portraits/women/27.jpg",
                Name = "Pu ning mah",
                Archetype = "Iphone manufacturer",
                Age = 65,
                Status = "Single",
                Location = "Behjing, China",
                Income = 500
            });
            Add(new UserItem
            {
                Headshot = "https://randomuser.me/api/portraits/women/87.jpg",
                Name = "Selma Nielsen",
                Archetype = "Tram pussher",
                Age = 35,
                Status = "Dating",
                Location = "Seattle, USA",
                Income = 45000
            });
            Add(new UserItem
            {
                Headshot = "https://randomuser.me/api/portraits/men/11.jpg",
                Name = "Chad Price",
                Archetype = "Film maker",
                Age = 30,
                Status = "Single",
                Location = "Paris, France",
                Income =18000
            });
        }

        public IEnumerable<UserItem> GetAll(string name)
        {
            if (string.IsNullOrEmpty(name))
                return _users.Values;

            return _users.Values.Where(p => p.Name.IndexOf(name, StringComparison.CurrentCultureIgnoreCase) != -1);
        }

        public IEnumerable<UserItem> GetAll()
        {
            return _users.Values;
        }

        public void Add(UserItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _users[item.Key] = item;
        }

        public UserItem Find(string key)
        {
            UserItem item;
            _users.TryGetValue(key, out item);
            return item;
        }

        public UserItem Remove(string key)
        {
            UserItem item;
            _users.TryRemove(key, out item);
            return item;
        }

        public void Update(UserItem item)
        {
            _users[item.Key] = item;
        }

    }
}