using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Enum;
using XGame.Domain.Interfaces.Repositories;
using XGame.Infra.Persistence.Repositories.Base;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogo : RepositoryBase<Jogo, Guid>, IRepositoryJogo
    {
        protected readonly XGameContext _context;

        public RepositoryJogo(XGameContext context) : base(context)
        {
            _context = context;
        }
    }
}
