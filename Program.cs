using System;

namespace cadastro_GameFlix
{
    class Program
    {
        static GameRepositorio repositorio = new GameRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarGames();
						break;
					case "2":
						InserirGame();
						break;
					case "3":
						AtualizarGame();
						break;
					case "4":
						ExcluirGame();
						break;
					case "5":
						VisualizarGames();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("GameFlix agradece a preferência.");
			Console.ReadLine();
        }
        private static void ExcluirGame()
		{
            Console.Write("Digite o id do game: ");
            int indiceGame = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceGame);
		}

        private static void VisualizarGames()
		{
			Console.Write("Digite o id do game: ");
			int indiceGame = int.Parse(Console.ReadLine());

			var game = repositorio.RetornaPorId(indiceGame);

			Console.WriteLine(game);
		}

        private static void AtualizarGame()
		{
			Console.Write("Digite o id do Game: ");
			int indiceGame = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Game: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da franquia: ");
            int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Game: ");
			string entradaDescricao = Console.ReadLine();

			Game atualizaGame = new Game(id: indiceGame,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceGame, atualizaGame);
		}
        private static void ListarGames()
		{
			Console.WriteLine("Listar games");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum game cadastrado.");
				return;
			}

			foreach (var game in lista)
			{
                var excluido = game.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", game.retornaId(), game.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirGame()
		{
			Console.WriteLine("Inserir novo Game");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Game: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Franquia: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Game: ");
			string entradaDescricao = Console.ReadLine();

			Game novoGame = new Game(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoGame);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("GameFlix agradece sua preferência!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar games");
			Console.WriteLine("2- Inserir novo game");
			Console.WriteLine("3- Atualizar game");
			Console.WriteLine("4- Excluir game");
			Console.WriteLine("5- Visualizar game");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
