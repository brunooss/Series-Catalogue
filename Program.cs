using Series.Classes;
using System;

namespace Series
{
	class Program
	{
		static SerieRepository repo = new SerieRepository();
		static void Main(string[] args)
		{
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.DarkBlue;

			string opcaoUsuario = GetUserOption();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListSeries();
						break;
					case "2":
						InsertSeries();
						break;
					case "3":
						UpdateSerie();
						break;
					case "4":
						DeleteSerie();
						break;
					case "5":
						WatchSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = GetUserOption();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static void DeleteSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repo.Delete(indiceSerie);
		}

		private static void WatchSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repo.ReturnById(indiceSerie);

			Console.WriteLine(serie);
		}

		private static void UpdateSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int inputGender = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string inputTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int inputAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string inputDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										gender: (Gender)inputGender,
										title: inputTitle,
										releaseYear: inputAno,
										description: inputDescricao);

			repo.Update(indiceSerie, atualizaSerie);
		}
		private static void ListSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repo.List();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluded = serie.ReturnExcluded();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.ReturnId(), serie.ReturnTitle(), (excluded ? "*Excluído*" : ""));
			}
		}

		private static void InsertSeries()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Gender)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int inputGender = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string inputTitle = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int inputAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string inputDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repo.NextId(),
										gender: (Gender)inputGender,
										title: inputTitle,
										releaseYear: inputAno,
										description: inputDescricao);

			repo.Insert(novaSerie);
		}

		private static string GetUserOption()
		{
			Console.WriteLine();
			Console.WriteLine("Este é o Serviço de Listagem de Séries! O que você deseja?");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar as séries cadastradas");
			Console.WriteLine("2- Adicionar nova série");
			Console.WriteLine("3- Atualizar informações de alguma série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar informações de alguma série");
			Console.WriteLine("C- Limpar a Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
