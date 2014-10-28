using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesAutomatizados.Models
{
     class Avaliador
    {
        //Se maior de todos inicia com menor valor possivel logo
        //Primeiro leilao entra no IF...
        private double maiorDetodos = Double.MinValue;

        //Maior valor possivel para ter certeza que menor valor possivel
        //entre no else IF...
        private double menorDeTodos = Double.MaxValue;

         //Lista para pegar os maiores valores....
        private List<Lance> maiores;

         public void Avalia(Leilao leilao)
        {
            if (leilao.Lances.Count == 0)
            {
                throw new Exception("Não é possivel avaliar um leilao sem lances");
            }

            //para cada leilao dentro de leilao em lances
            foreach (var lance in leilao.Lances)
            {
                if (lance.Valor > maiorDetodos)
                {
                    maiorDetodos = lance.Valor;
                }
                if (lance.Valor < menorDeTodos){
                    menorDeTodos = lance.Valor;
                }
            }
            pegaOsMaioresNo(leilao);
        }

         //Metodo para pegar os 3 maiores valores.....
         private void pegaOsMaioresNo(Leilao leilao)
         {
             maiores = new List<Lance>(leilao.Lances.OrderByDescending(x => x.Valor));
             //pois só quero os 3 maiores...
             maiores.GetRange(0, maiores.Count > 3 ? 3 : maiores.Count);
         }

         //Lista que pega os 3 maiores valores...
         public List<Lance> TresMaiores
         {
             get { return this.maiores;  }
         }


        public double MaiorLance
        {
            get { return maiorDetodos; }
        }

        public double MenorLance
        {
            get { return menorDeTodos;  }
        }
    }
}
