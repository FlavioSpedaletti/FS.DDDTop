using FS.DDDTop.Domain.Entities;
using FS.DDDTop.Domain.Interfaces;
using FS.DDDTop.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FS.DDDTop.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        EFContext _db;
        public ClienteRepository(EFContext db) : base(db)
        {
            _db = db;
        }

        public Cliente GetByIdComEagerLoading(int id)
        {
            var cliente = _db.Clientes.Where(c => c.ClienteId == id).Include(c => c.Reclamacoes).SingleOrDefault();
            return cliente;
        }
    }
}
