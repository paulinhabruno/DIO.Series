using System;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           
           string opcaoUsuario = ObterOpcaoUsuario();

           while (opcaoUsuario.ToUpper() != "X")
           {
               switch(opcaoUsuario)
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
                   //ExcluirSerie();
                   break;
                   case "C":
                   Console.Clear();
                   break;

                   default:
                   throw new ArgumentOutOfRangeException();
               }

               opcaoUsuario = ObterOpcaoUsuario();
           }

           Console.WriteLine("Obrigado por utilizar os nossos serviço.");
           Console.ReadLine();
        }

// Atualizar série

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
                                        
            repositorio.Atualiza(indiceSerie, atualizarSerie);
        }

// listando as séries
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();

            // se a lista estiver vazia
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada,");
                return;
            // se a lista não estiver vazia
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}" , serie.retornaId(), serie.retornaTitulo());
            }
        }

// inserindo a série

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
                                    // está acessando a lista dos gêneros
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i)); 
                                                    //retorna o gênero com valor i
            }
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
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
            Console.WriteLine("DIO Séries a seu dispor!");
            Console.WriteLine("Informa a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
