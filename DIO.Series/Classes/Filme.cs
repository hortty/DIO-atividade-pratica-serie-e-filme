using System;

namespace DIO.Series
{
    public class Filme : Serie
    {
        private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Filme(int id, Genero genero, string titulo, string descricao, int ano) : base(id,genero,titulo,descricao,ano)
		{
			this.Id = id;
		    Genero = genero;
			Titulo = titulo;
			Descricao = descricao;
			Ano = ano;
            Excluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero do Filme: " + Genero + Environment.NewLine;
            retorno += "Titulo do Filme: " + Titulo + Environment.NewLine;
            retorno += "Descrição do Filme: " + Descricao + Environment.NewLine;
            retorno += "Ano de Início do Filme: " + Ano + Environment.NewLine;
            retorno += "Se foi excluido: " + Excluido;
			return retorno;
		}
		public override string retornaTitulo()
		{
			return this.Titulo;
		}

		public override int retornaId()
		{
			return this.Id;
		}
        public override bool retornaExcluido()
		{
			return this.Excluido;
		}
		public override void Excluir() {
            this.Excluido = true;
        }
    }
}