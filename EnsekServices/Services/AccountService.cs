using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsekDataAccess.Models;
using EnsekDataAccess.Repository;
using EnsekServices.Interfaces;

namespace EnsekServices.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? new AccountRepository();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _accountRepository.GetAllAccounts().OrderBy(x => x.AccountId);
        }
    }
}
