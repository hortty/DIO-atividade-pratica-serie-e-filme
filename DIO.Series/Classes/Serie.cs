using System;

namespace DIO.Series
{
    public class Serie
    {
        // Atributos
		public int Id { get; set; }
		private Genero Genero { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Serie(int id, Genero genero, string titulo, string descricao, int ano)
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
            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Titulo: " + Titulo + Environment.NewLine;
            retorno += "Descrição: " + Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + Ano + Environment.NewLine;
            retorno += "Excluido: " + Excluido;
			return retorno;
		}

        public virtual string retornaTitulo()
		{
			return this.Titulo;
		}

		public virtual int retornaId()
		{
			return this.Id;
		}
        public virtual bool retornaExcluido()
		{
			return this.Excluido;
		}
        public virtual void Excluir() {
            this.Excluido = true;
        }
    }
}