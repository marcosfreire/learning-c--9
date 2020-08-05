namespace Learning.CSharp.Nine.ExemploRelationalPatterns
{
    public class LearningRelationalPatterns
    {
        public enum ClassificacaoIMC
        {
            Magreza,
            Normal,
            Sobrepeso,
            Obesidade,
            ObesidadeGrave
        }

        public class MedidasPessoa
        {
            public double Peso { get; set; }
            public double Altura { get; set; }
            public double IMC => Peso / (Altura * Altura);
        }

        public static ClassificacaoIMC AnalisarPeso(double imc) =>
                imc switch
                {
                    < 18.5 => ClassificacaoIMC.Magreza,
                    < 25.0 => ClassificacaoIMC.Normal,
                    < 29.9 => ClassificacaoIMC.Sobrepeso,
                    < 40.0 => ClassificacaoIMC.Obesidade,
                    _ => ClassificacaoIMC.ObesidadeGrave
                };
    }
}
