namespace WebPatient.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_CalcularIMC()
        {
            var patient = new Patient
            {
                Altura = 1.75,
                Peso = 70
            };

            var imc = patient.GetIMC();

            Assert.AreEqual(22.86, Math.Round(imc, 2));
        }

        [TestMethod]
        public void Test_ObterPesoIdeal_Homem()
        {
            var patient = new Patient
            {
                Sexo = "M",
                Altura = 1.75
            };

            var pesoIdeal = patient.ObterPesoIdeal();

            Assert.AreEqual(69.225, pesoIdeal, 0.001);
        }

        [TestMethod]
        public void Test_ObterPesoIdeal_Mulher()
        {
            var patient = new Patient
            {
                Sexo = "F",
                Altura = 1.50
            };

            var pesoIdeal = patient.ObterPesoIdeal();

            Assert.AreEqual(48.45, pesoIdeal, 0.001);
        }

        [TestMethod]
        public void Test_ObterCpfOfuscado()
        {
            var patient = new Patient
            {
                Cpf = "12345678900"
            };

            var cpfOfuscado = patient.ObterCpfOfuscado();

            Assert.AreEqual("***.567.***-**", cpfOfuscado);
        }

        [TestMethod]
        public void Test_ObterSituacaoIMC()
        {
            var patient = new Patient
            {
                Altura = 1.75,
                Peso = 70
            };

            patient.GetIMC();

            var situacaoIMC = patient.ObterSituacaoIMC();

            Assert.AreEqual("Peso normal", situacaoIMC);
        }
    }
}
