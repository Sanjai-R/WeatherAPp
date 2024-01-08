using System;

using System.Threading.Tasks;
using System.Collections.Generic;
using mauiMyApp.Model;
using SQLite;
using mauiMyApp.Constants;
using mauiMyApp.Interface;

namespace mauiMyApp.Helper
{
    public class SqliteDb : ISqliteDb
    {
        private SQLiteAsyncConnection db;
        public const string DatabaseFilename = "TestSQlite.db3";

        //public SqliteDb()
        //{
        //    if (db is not null)
        //        return;

        //    db = new SQLiteAsyncConnection(Constant.DatabasePath);
        //    db.CreateTableAsync<UserModel>().Wait();
        //    //db = new SQLiteAsyncConnection(dbPath);
        //    //db.CreateTableAsync<UserModel>().Wait();
        //    //Console.WriteLine("table created successfullly");
        //}
        public SqliteDb()
        {
            Init();
            Console.WriteLine("Db Constructor Called");
            //Init();
        }
        public async void Init()
        {

            if (db is not null)
                return;

            db = new SQLiteAsyncConnection(Constant.DatabasePath);
            var result = await db.CreateTableAsync<UserModel>();
        }

        public async Task<int> CreateUser(UserModel user)
        {
            try
            {
                return await db.InsertAsync(user);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating user: {ex.Message}");
                throw;
            }
        }


        public async Task<List<UserModel>> GetUsers()
        {
            try
            {
                return await db.Table<UserModel>().ToListAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating user: {ex.Message}");
                throw;
            }

        }

        public async Task<Boolean> DeleteAllUsers()
        {
            try
            {
                await db.DeleteAllAsync<UserModel>();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating user: {ex.Message}");
                throw;
            }

        }

        public async Task<Boolean> LoginUser(string email, string password)
        {
            try
            {
                var user = await db.Table<UserModel>().Where(u => u.email.Equals(email) && u.password.Equals(password)).FirstOrDefaultAsync();
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating user: {ex.Message}");
                throw;
            }
        }


    }
}