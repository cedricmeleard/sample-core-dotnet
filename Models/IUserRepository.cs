using System.Collections.Generic;

namespace UserApi.Models
{
    public interface IUserRepository
    {
        void Add(UserItem item);
        IEnumerable<UserItem> GetAll();
        UserItem Find(string key);
        UserItem Remove(string key);
        void Update(UserItem item);    
    }
}