using System.Collections.Generic;

namespace UserApi.Models
{
    public interface IUserRepository
    {
        void Add(UserItem item);
        IEnumerable<UserItem> GetAll();
        IEnumerable<UserItem> GetAll(string name);
        UserItem Find(string key);
        UserItem Remove(string key);
        void Update(UserItem item);    
    }
}