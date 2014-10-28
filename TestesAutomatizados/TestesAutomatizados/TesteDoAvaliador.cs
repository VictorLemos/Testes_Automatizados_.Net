using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesAutomatizados.Models;
using NUnit.Framework;

namespace TestesAutomatizados
{
    [TestFixture]
    public class TesteDoAvaliador
    {
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario victor;
        private Usuario larissa;

        [SetUp]// executa antes de cada metodo de teste...
        public void CriaAvaliador()
        {
            this.leiloeiro = new Avaliador();
            this.joao = new Usuario("João");
            this.victor = new Usuario("Victor");
            this.larissa = new Usuario("Larissa");
        }


        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            //CriaAvaliador(); -> chamado com [SetUp]

            Leilao leilao = new CriadorDeLeilao().Para("XboxOne")
                .Lance(joao, 300)
                .Lance(victor, 360)
                .Lance(larissa, 420)
                .Constroi();

            //2a parte: acao
            leiloeiro.Avalia(leilao);

            //3a parte: validacao
            Assert.AreEqual(420, leiloeiro.MaiorLance);
            Assert.AreEqual(300, leiloeiro.MenorLance);
        }

        [Test]
        public void DeveEntederLeilaoComApenasUmLance()
        {
            //CriaAvaliador(); -> chamado com [SetUp]

            Leilao leilao = new CriadorDeLeilao().Para("XboxOne Novo")
                .Lance(joao, 1000.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            Assert.AreEqual(1000, leiloeiro.MaiorLance);
            Assert.AreEqual(1000, leiloeiro.MenorLance);

        }

        [Test]
        public void DeveEncontrarOsTresMaioresLances()
        {
            //CriaAvaliador(); -> chamado com [SetUp]

            Leilao leilao = new CriadorDeLeilao().Para("XboxOne")
                .Lance(joao, 100.0)
                .Lance(larissa, 200.0)
                .Lance(joao, 300.0)
                .Lance(larissa, 400.0)
                .Constroi();

            leiloeiro.Avalia(leilao);

            //TresMaiores devolve uma lista -- entao o ponho em um tipo lista
            var maiores = leiloeiro.TresMaiores;

            Assert.AreEqual(4, maiores.Count);
            Assert.AreEqual(400, maiores[0].Valor);
            Assert.AreEqual(300, maiores[1].Valor);
            Assert.AreEqual(200, maiores[2].Valor);
        }

        [Test]
        [ExpectedException(typeof(Exception))]//Passando a exception que foi criada na classe Avaliador...
            //Ou seja fica verde se essa exception acontecer
        public void NaoDeveAvaliarLeiloesSemNenhumLanceDado()
        {
           
                Leilao leilao = new CriadorDeLeilao().Para("XboxOne").Constroi();

                leiloeiro.Avalia(leilao);
          

        }
    }
}
