using System;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
		static FilmesRepositorio repositorio2 = new FilmesRepositorio();

        static void Main(string[] args)
        {
			Console.Clear();
			Console.WriteLine();
            Console.WriteLine("          ####        MENU PRINCIPAL        ####");
			Console.WriteLine();
			Console.WriteLine("Qual opcao voce quer? Serie - 1 / Filme - 2 / Sair do Programa - X");
            string opcao = Console.ReadLine();

		while (opcao.ToUpper() != "X") {

        if(opcao=="1") {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
		        }

				opcaoUsuario = ObterOpcaoUsuario();
			}
        }
        else if(opcao=="2") {
            string opcaoUsuario2 = ObterOpcaoUsuario();

			while (opcaoUsuario2.ToUpper() != "X")
			{
				switch (opcaoUsuario2)
				{
					case "1":
						ListarFilmes();
						break;
					case "2":
						InserirFilme();
						break;
					case "3":
						AtualizarFilme();
						break;
					case "4":
						ExcluirFilme();
						break;
					case "5":
						VisualizarFilme();
						break;
					case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
		        }

				opcaoUsuario2 = ObterOpcaoUsuario();
			}
        }
			Console.Clear();
			Console.WriteLine();
			Console.WriteLine("          ####        MENU PRINCIPAL        ####");
			Console.WriteLine();
			Console.WriteLine("Qual opcao voce quer? Serie - 1 / Filme - 2 / Sair do Programa - X");
            opcao = Console.ReadLine();
		}
			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

		public static void ListarFilmes() {
			Console.WriteLine("Listar filmes");

			var lista = repositorio2.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
		public static void InserirFilme() {
			Console.WriteLine("Inserir novo filme");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorio2.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio2.Insere(novoFilme);	
		}
		public static void AtualizarFilme() {
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio2.Atualiza(indiceFilme, atualizaFilme);
		}
		public static void ExcluirFilme() {
			 Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			repositorio2.Exclui(indiceFilme);
		}
		public static void VisualizarFilme() {
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorio2.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);
		}

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
		
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries e Filmes a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries ou Filmes");
			Console.WriteLine("2- Inserir nova série ou filme");
			Console.WriteLine("3- Atualizar série ou filme");
			Console.WriteLine("4- Excluir série ou filme");
			Console.WriteLine("5- Visualizar série ou filme");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Menu Principal");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
