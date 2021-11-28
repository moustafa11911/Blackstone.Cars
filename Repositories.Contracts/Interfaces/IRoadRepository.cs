using Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contracts.Interfaces
{
    public interface IRoadRepository
    {
        Road GetById(int id);
    }
}
