using EnsekDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekServices.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAllAccounts();
    }
}
