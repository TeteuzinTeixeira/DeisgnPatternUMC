using System.Globalization;
using System;

namespace Aula01 {

    class Livro
    {
        private long id;
        private long ibsm;
        private string titulo;
        private string autor;
        private int ano;
        private string genero;
        private string editora;
        private int quantidade;

        public long getID()
        {
            return id;
        }

        public void setID(long id)
        {
            this.id = id;
        }

        // public long getIBSM()
        // {
        //     return ibsm;
        // }

        // public void setIBSM(long ibsm)
        // {
        //     this.ibsm = ibsm;
        // }

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

        public string getEditora()
        {
            return editora;
        }

        public void setEditora(string editora)
        {
            this.editora = editora;
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