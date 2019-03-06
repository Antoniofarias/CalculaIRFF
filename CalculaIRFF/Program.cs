using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculaSalarioLiquido
{
    public class Program
    {
        static void Main(string[] args)
        {
            double baseCalculoIrff;
            double salarioLiquido;

            double valorVt;
            const double aliqVt = 0.06;

            Console.WriteLine("Digite o valor de seu salário");
            double salarioBruto = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da pensão");
            double pensao = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Digite quantidade de dependentes");
            double qntDependente = double.Parse(Console.ReadLine());
            double dependente = qntDependente * 189.59;

            Console.WriteLine("Digite o valor de outros descontos");
            double outrosDesc = double.Parse(Console.ReadLine());

            CalculaINSS inss = new CalculaINSS();
            CalculaIRFF irff = new CalculaIRFF();

            valorVt = salarioBruto * aliqVt;

            inss.INSS(salarioBruto);

            baseCalculoIrff = salarioBruto - inss.contribuicaoInss - dependente - pensao;

            if (baseCalculoIrff <= irff.valorIrff1)
            {
                baseCalculoIrff = (baseCalculoIrff * irff.aliqIrff1) - irff.deducaoIrff1;
            }
            else if (baseCalculoIrff <= irff.valorIrff3)
            {
                baseCalculoIrff = (baseCalculoIrff * irff.aliqIrff2) - irff.deducaoIrff2;
            }
            else if (baseCalculoIrff <= irff.valorIrff5)
            {
                baseCalculoIrff = (baseCalculoIrff * irff.aliqIrff3) - irff.deducaoIrff3;
            }
            else if (baseCalculoIrff <= irff.valorIrff7)
            {
                baseCalculoIrff = (baseCalculoIrff * irff.aliqIrff4) - irff.deducaoIrff4;
            }
            else if(baseCalculoIrff > irff.valorIrff8)
            {
                baseCalculoIrff = (baseCalculoIrff * irff.aliqIrff5) - irff.deducaoIrff5;
            }
                            
                salarioLiquido = salarioBruto - baseCalculoIrff - inss.contribuicaoInss - valorVt - outrosDesc;

            Console.Clear();
            Console.WriteLine("Desconto de pensão: " + pensao);
            Console.WriteLine("Desconto de IRFF: " + baseCalculoIrff);
            Console.WriteLine("Desconto VT: " + valorVt);
            Console.WriteLine("Desconto INSS: " + inss.contribuicaoInss);
            Console.WriteLine("Desconto Outros: " + outrosDesc);
            Console.WriteLine("Salário líquido é: " + salarioLiquido);

            Console.ReadKey();
        }
        
    }
}
