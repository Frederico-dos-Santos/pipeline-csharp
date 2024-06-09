using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebPatient
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Sobrenome { get; set; }

        [Required]
        public string Sexo { get; set; }

        [Required]
        public DateTime Nascimento { get; set; }

        [Required]
        public double Altura { get; set; }

        [Required]
        public double Peso { get; set; }

        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }

        private double imc;

        public float GetIMC()
        {
            return (float)imc;
        }

        public double ObterPesoIdeal()
        {
            if (Sexo.ToLower() == "m")
                return (72.7 * Altura) - 58;

            return (62.1 * Altura) - 44.7;
        }

        public String ObterCpfOfuscado()
        {
            return string.Concat("***.", Cpf.AsSpan(4, 3), ".***-**");
        }

        public String ObterSituacaoIMC()
        {
            if (imc < 17)
                return "Muito abaixo do peso";

            if (imc <= 18.49)
                return "Abaixo do peso";

            if (imc <= 24.99)
                return "Peso normal";

            if (imc <= 29.99)
                return "Acima do peso";

            if (imc <= 34.99)
                return "Obesidade grau 1";

            if (imc <= 39.99)
                return "Obesidade grau 2";

            return "Obesidade grau 3";
        }

        private double CalcularIMC()
        {
            return imc = Peso / (Altura * Altura);
        }

        private byte CalcularIdade()
        {
            DateTime hoje = DateTime.Today;

            int idade = hoje.Year - Nascimento.Year;

            if (Nascimento.Date > hoje.AddYears(idade))
                idade--;

            return (byte)idade;
        }

        private Boolean ValidarCPF()
        {
            int v1 = 0;
            int v2 = 0;

            for (int i = 0; i < Cpf.Length; i++)
            {
                v1 += Cpf[i] * (9 - (i % 10));
                v2 += Cpf[i] * (9 - ((i + 1) % 10));
            }

            v1 = (v1 % 11) % 10;
            v2 += v1 * 9;
            v2 = (v2 % 11) % 10;

            return (v1 == Cpf[9] && v2 == Cpf[10]);
        }

    }

}