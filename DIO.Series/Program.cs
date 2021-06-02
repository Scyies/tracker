using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            try
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
                            AssistirSerie();
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
            catch (Exception)
            {
                Console.WriteLine("Você informou um valor inválido, tente novamente!");
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine();
        }

        private static void AssistirSerie()
        {
            try
            {
                 Console.Write("Digite o id da série que você quer marcar como assistida: ");
                int indiceSerie = int.Parse(Console.ReadLine());

                repositorio.Assistir(indiceSerie);

                Console.WriteLine();
                Console.WriteLine("Mudança feita com sucesso!");
            }
            catch (Exception)
            {
                Console.WriteLine("Você informou um ID inválido, tente novamente!");
            }
           
        }

        private static void VisualizarSerie()
        {
            try
            {
            Console.Write("Digite o id da série que você quer verificar: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine();
            Console.WriteLine(serie);
            }
            catch (Exception)
            {
                Console.WriteLine("Você informou um valor inválido, tente novamente!");
            }
        }

        private static void AtualizarSerie()
        {
            try
            {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));                
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo
                                            );

            repositorio.Atualiza(indiceSerie, atualizaSerie);

            Console.WriteLine();
            Console.WriteLine("Atualização concluída com sucesso!");
            }
            catch (Exception)
            {
                Console.WriteLine("Você informou um ID inválido, tente novamente!");
            }
        }

        private static void ListarSeries()
        {
            
            Console.WriteLine("Listar séries");
            
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaAssistir();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Já foi assistido*" : ""));
            }
            Console.WriteLine();
            Console.WriteLine("Essas são suas séries cadastradas");
        }
        
        private static void InserirSerie()
        {
            try
            {
            Console.WriteLine("Inserir nova série");

            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-5.0
            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-5.0
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");

            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");

            string entradaTitulo = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.PorximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo
                                        );
            repositorio.Insere(novaSerie);
            Console.WriteLine();
            Console.WriteLine("Série adicionada com sucesso!");
            }
            catch (Exception)
            {
                Console.WriteLine("Você informou um valor inválido, tente novamente!");
            }
        }

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Marcar série como assistida");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
