using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using DemoApp.Model;

namespace DemoApp.Helper
{
    public class DbHelper
    {
        private readonly SQLiteAsyncConnection db;

        public DbHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<UserModel>();
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


        public async Task<List<UserModel>> getUsers()
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

