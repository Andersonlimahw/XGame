using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Entities.Base;

namespace XGame.Domain.Entities
{
    public class Jogo : EntityBase
    {
        protected Jogo()
        {

        }
        private void ValidarEntidade()
        {
            new AddNotifications<Jogo>(this)
                .IfNullOrInvalidLength(x => x.Nome, 1, 100, "Nome é obrigatório e deve ter de 1 a 100 caracteres")
                .IfNullOrInvalidLength(x => x.Descricao, 1, 255, "Descrição é obrigatório e deve ter de 1 a 255 caracteres")
                .IfNullOrInvalidLength(x => x.Genero, 1, 30, "Genero é obrigatório e deve ter de 1 a 30 caracteres");
        }
        public Jogo(string nome, string descricao, string produtora, string distribuidora, string genero, string site)
        {
            Nome = nome;
            Descricao = descricao;
            Produtora = produtora;
            Distribuidora = distribuidora;
            Genero = genero;
            Site = site;

            ValidarEntidade();
        }

        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public string Produtora { get; private set; }

        public string Distribuidora { get; private set; }

        public string Genero { get; private set; }

        public string Site { get; private set; }

        public void Alterar(string nome, string descricao, string produtora, string distribuidora, string genero, string site)
        {
            Nome = nome;
            Descricao = descricao;
            Produtora = produtora;
            Distribuidora = distribuidora;
            Genero = genero;
            Site = site;

            ValidarEntidade();
        }
        
    }
}
