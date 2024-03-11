using System.Globalization;
using System;

namespace Aula01 {

    class Aluno
    {
        private long id;
        private string nome;
        private long rgm;
        private DateTime dataNas;
        private string curso;
        private string bolsista;
        private long rg;
        private string genero;

        public long getID()
        {
            return id;
        }

        public void setID(long id)
        {
            this.id = id;
        }

        public string getNome()
        {
            return nome;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public long getRGM()
        {
            return rgm;
        }

        public void setRGM(long rgm)
        {
            this.rgm = rgm;
        }

        public DateTime getDataNas()
        {
            return dataNas;
        }

        public void setDataNas(DateTime dataNas)
        {
            this.dataNas = dataNas;
        }

        public string getCurso()
        {
            return curso;
        }

        public void setCurso(string curso)
        {
            this.curso = curso;
        }

        public string getBolsista()
        {
            return bolsista;
        }

        public void setBolsista(string bolsista)
        {
            this.bolsista = bolsista;
        }

        public long getRG()
        {
            return rg;
        }

        public void setRG(long rg)
        {
            this.rg = rg;
        }

        public string getGenero()
        {
            return genero;
        }

        public void setGenero(string genero)
        {
            this.genero = genero;
        }
    }
}