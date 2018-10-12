using Insurance.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Data.Login.Contracts
{
    public interface ILoginRepository : IBaseRepository
    {
        void GetLoginDetails(string name);
    }
}
