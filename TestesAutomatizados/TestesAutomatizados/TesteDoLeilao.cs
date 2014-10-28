using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestesAutomatizados.Models;

namespace TestesAutomatizados
{
    [TestFixture]
    class TesteDoLeilao
    {
        private Avaliador leiloeiro;
        private Usuario victor;
        private Usuario jennifer;

        [SetUp]// executa antes de cada metodo de teste...
        public void CriaAvaliador()
        {
            this.leiloeiro = new Avaliador();
            this.victor = new Usuario("Victor");
            this.jennifer = new Usuario("Jennifer");
        }

        [Test]
        public void DeveReceberUmLance()
        {

            Leilao leilao = new CriadorDeLeilao().Para("Moto G")
                .Lance(victor, 800)
                .Constroi();

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(800, leilao.Lances[0].Valor);
        }

        [Test]
        public void DeveReceberVariosLances()
        {

            Leilao leilao = new CriadorDeLeilao().Para("Moto G")
                .Lance(victor, 800)
                .Lance(jennifer, 1000)
                .Constroi();

            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(800, leilao.Lances[0].Valor);
            Assert.AreEqual(1000, leilao.Lances[1].Valor);
        }


        [Test]
        public void NaoDeveAceitarDoisLancesSeguidosDoMesmoUsuario()
        {
            Leilao leilao = new CriadorDeLeilao().Para("Moto G")
                          .Lance(victor, 800)
                          .Lance(victor, 1000)
                          .Constroi();

            Assert.AreEqual(1, leilao.Lances.Count);
            Assert.AreEqual(800, leilao.Lances[0].Valor);

        }

        
        [Test]
        public void NaoDeveAceitarMaisDoQue5LancesDeUmMesmoUsuario()
        {

            Leilao leilao = new CriadorDeLeilao().Para("Moto G")
               .Lance(victor, 800)
               .Lance(jennifer, 1000)
               .Lance(victor, 2000)
               .Lance(jennifer, 3000)
               .Lance(victor, 4000)
               .Lance(jennifer, 5000)
               .Lance(victor, 6000)
               .Lance(jennifer, 7000)
               .Lance(victor, 8000)
               .Lance(jennifer, 9000)
               .Constroi();

            
            Assert.AreEqual(10, leilao.Lances.Count);
            var ultimo = leilao.Lances.Count - 1;
            Lance ultimoLance = leilao.Lances[ultimo];

            Assert.AreEqual(9000, ultimoLance.Valor);


        }

    }
}
