using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp.core.interfaces
{
    public interface IClientRepository
    {
        internal Client GetById(int clientId);
    }
}
