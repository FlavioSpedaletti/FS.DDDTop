using FS.DDDTop.Domain.Entities;
using FS.DDDTop.Domain.Interfaces;
using FS.DDDTop.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FS.DDDTop.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        protected EFContext _db;
        public ProdutoRepository(EFContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _db.Produtos.Where(p => p.Nome == nome);
        }
    }
}
