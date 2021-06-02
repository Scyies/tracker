using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        //Atributos

        private Genero Genero {get; set;}

        private string Titulo {get; set;}

        private bool Assistir {get; set;}

        //Métodos

        public Serie(int id, Genero genero, string titulo)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Assistir = false;
        }

        public override string ToString()
        {
            //Enviroment.NewLine https://docs.microsoft.com/pt-br/dotnet/api/system.environment.newline?view=net-5.0
            string retorno = " ";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Marcou como assistido: " + this.Assistir;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaAssistir()
        {
            return this.Assistir;
        }
        public void Assistido()
        {
            this.Assistir = true;
        }

    }
}