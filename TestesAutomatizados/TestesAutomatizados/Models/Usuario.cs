using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesAutomatizados.Models
{
    class Usuario
    {
        private int p;

        public int Id { get; private set; }
        public string Nome { get;  private set; }

        public Usuario(string nome) : this(0, nome)
        {
        }

        public Usuario(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
        public override bool Equals(object obj)
        {
            //Se objeto for nulo ou tipo não bater ja retorna falso...
            if (obj == null || obj.GetType() != obj.GetType())
            {
                return false;
            }

            Usuario outro = (Usuario)obj;

            return outro.Id == this.Id && outro.Nome.Equals(this.Nome);
        }

    }
}
