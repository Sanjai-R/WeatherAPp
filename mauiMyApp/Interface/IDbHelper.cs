using System;
using mauiMyApp.Model;

namespace mauiMyApp.Interface
{
	public interface ISqliteDb
    {

        void Init();
        public Task<int> CreateUser(UserModel userModel);
        public Task<List<UserModel>> GetUsers();
		public Task<Boolean> DeleteAllUsers();
        public Task<Boolean> LoginUser(string email, string password);
    }
}

