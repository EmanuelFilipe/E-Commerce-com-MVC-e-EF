using CasaDoCodigo.Data.Repositories;
using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Data.Interfaces
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
    }
}