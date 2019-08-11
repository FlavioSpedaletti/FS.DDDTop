using FS.DDDTop.Domain.Entities;
using FS.DDDTop.Domain.Interfaces;
using FS.DDDTop.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FS.DDDTop.Infra.Data.Repositories
{
    public class ReclamacaoRepository : RepositoryBase<Reclamacao>, IReclamacaoRepository
    {
        protected EFContext _db;
        public ReclamacaoRepository(EFContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Reclamacao> BuscarPorDescricao(string descricao)
        {
            return _db.Reclamacoes.Where(p => p.Descricao.Contains(descricao));
        }
    }
}
