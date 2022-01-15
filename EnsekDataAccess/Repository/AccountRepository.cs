using EnsekDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace EnsekDataAccess.Repository
{
    public class AccountRepository
    {
        private EnsekEntities _ensekEntities;

        public AccountRepository()
        {
            _ensekEntities = new EnsekEntities();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            var collection = _ensekEntities.Accounts.ToList();
            if(collection.Count <= 0)
                AddAccounts();
            return collection.AsQueryable().OrderBy(c => c.AccountId);
        }

        public void AddAccounts()
        {
            var path = @"C:\Users\Nahmaan\source\repos\EnsekWebApi\EnsekWebApi\Test_Accounts.csv";
            var accounts = new List<Account>();
            using (var sr = new StreamReader(path))
            {
                // read first line and ignore - headers
                var headers = sr.ReadLine()?.Split(',');
                if (headers == null) return;
                while (!sr.EndOfStream)
                {
                    var rows = sr.ReadLine()?.Split(',');
                    accounts.Add(new Account()
                    {
                        AccountId = Convert.ToInt32(rows?[0]),
                        FirstName = rows?[1],
                        LastName = rows?[2]
                    });
                }
            }

            if (accounts.Count > 0)
            {
                _ensekEntities.Accounts.AddRange(accounts);
                _ensekEntities.SaveChanges();
            }
        }
        }
    }
