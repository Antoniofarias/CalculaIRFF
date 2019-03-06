using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaSalarioLiquido
{
    public class CalculaINSS
    {
        public double contribuicaoInss;

        public const double valorInss1 = 1751.81;
        public const double valorInss2 = 1751.82;
        public const double valorInss3 = 2919.72;
        public const double valorInss4 = 2919.73;
        public const double valorInss5 = 5839.45;

        public const double aliqInss1 = 0.08;
        public const double aliqInss2 = 0.09;
        public const double aliqInss3 = 0.11;

        public double INSS(double salarioBruto)
        {
            if (salarioBruto <= valorInss1)
            {
                contribuicaoInss = salarioBruto * aliqInss1;
            }
            else if (salarioBruto <= valorInss3)
            {
                contribuicaoInss = salarioBruto * aliqInss2;
            }
            else if (salarioBruto <= valorInss5)
            {
                contribuicaoInss = salarioBruto * aliqInss3;
            }
            else
            {
                contribuicaoInss = 642.34;
            }
            return contribuicaoInss;
        }
    }
}
