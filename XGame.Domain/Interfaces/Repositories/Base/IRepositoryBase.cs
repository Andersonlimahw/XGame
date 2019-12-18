using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace XGame.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<TEntidade, TId>
        where TEntidade : class
        where TId: struct
    {
        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties);
        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> ListarEOrdernarPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool asc, params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> OrdenarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade ObterPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        bool Existe(Func<TEntidade, bool> where);

        TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties);
        TEntidade Adicionar(TEntidade entidade);

        TEntidade Editar(TEntidade entidade);

        void Remover(TEntidade entidade);

        IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> enditdade);
    }
}
