using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using SQLite;
using WheelMap.Models;

namespace WheelMap.Services
{
    public class AccountRepository
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public AccountRepository(string dbPath)
        {
            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Account>();
        }

        public IEnumerable<Account> GetAll()
        {
            try
            {
                var todos = conn.Table<Account>().ToList();

                return todos;
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }

            return new List<Account>();
        }

        public Account Get(int id)
        {
            try
            {
                return conn.Get<Account>(id);
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }

            return new Account();
        }

        public Account Get(string email)
        {
            try
            {
                return conn.Get<Account>(x => x.Email == email);
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }

            return new Account();
        }

        public int Add(Account newAccount)
        {
            int insertedItems = 0;
            try
            {
                conn.CreateTable<Account>();

                if (newAccount != null)
                {
                    List<Account> emailCheck = GetAll().Where(x => x.Email == newAccount.Email).ToList();

                    if (emailCheck.Count >= 1)
                    {
                        // Email (Account) already exists
                        insertedItems = -1;
                        StatusMessage = string.Format($"Account with this email already exist {newAccount.Email}");
                    }
                    else
                    {
                        // Create new account
                        insertedItems = conn.Insert(newAccount);
                        StatusMessage = string.Format("{0} record(s) added (Account Item: {1})", insertedItems, newAccount.Email);
                    }
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", newAccount.Email, ex.Message);
            }
            finally
            {
                Debug.WriteLine(StatusMessage);
            }

            return insertedItems;
        }

        public int Update(Account item)
        {
            int result = 0;
            try
            {
                if (item != null)
                    result = conn.Update(item);

                return result;
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }
            return result;
        }

        public int Delete(Account item)
        {
            int result = 0;
            try
            {
                if (item != null)
                {
                    result = conn.Delete<Account>(item.Id);
                }

                return result;
            }
            catch (Exception ex)
            {
                StatusMessage = ex.Message;
            }
            return result;
        }

        public int Login(Account account)
        {
            int loggedIn = 0;

            if (account != null)
            {
                var accountExist = GetAll().Any(x => x.Email == account.Email);

                if (accountExist)
                {
                    var currentAccount = GetAll().FirstOrDefault(x => x.Email == account.Email);

                    if (currentAccount.Password == account.Password)
                    {
                        // Logged In
                        loggedIn = 1;
                    }
                    else
                    {
                        // Password Incorrect
                        loggedIn = 0;
                    }
                }
                else
                {
                    // Account does not exist
                    loggedIn = -1;
                }
            }

            return loggedIn;
        }
    }
}
