using FS.DDDTop.Domain.Entities;
using FS.DDDTop.Domain.Interfaces;
using FS.DDDTop.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FS.DDDTop.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(EFContext db) : base(db)
        {
        }
    }
}
