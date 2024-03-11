using System.Globalization;
using System;

namespace Aula01 {

    class Livro
    {
        private long id;
        private long isbn;
        private string titulo;
        private string autor;
        private int ano;
        private string genero;
        private int edicao;
        private int quantidade;


        public long getISBN()
        {
            return isbn;
        }

        public void setISBN(long isbn)
        {
            this.isbn = isbn;
        }

        public string getTitulo()
        {
            return titulo;
        }

        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public string getAutor()
        {
            return autor;
        }

        public void setAutor(string autor)
        {
            this.autor = autor;
        }

        public int getAno()
        {
            return ano;
        }

        public void setAno(int ano)
        {
            this.ano = ano;
        }

        public string getGenero()
        {
            return genero;
        }

        public void setGenero(string genero)
        {
            this.genero = genero;
        }

        public int getEdicao()
        {
            return edicao;
        }

        public void setEdicao(int edicao)
        {
            this.edicao = edicao;
        }

        public int getQuantidade()
        {
            return quantidade;
        }

        public void setQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }
    }
}