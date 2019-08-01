using FS.DDDTop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FS.DDDTop.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
