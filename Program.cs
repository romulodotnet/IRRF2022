//Calculadora de INSS E IRRF 2022 Versão 1.3
// Aprimoramentos para a próxima versão:
// Criar uma API.

using System;
class Programa
{
    static void Main(string[] args)

    {
        // Menu para acessar as Calculadoras
        Console.WriteLine("Bem vindo a Calculadora do IRRF 2022");
        Console.WriteLine("Salário Bruto (Mensal).");
        //Já que não tem validação de entrada de dados, usei um exemplo para evitar erros.
        Console.WriteLine("Exemplo: 2200,00");
        double salario, inss;
        salario = double.Parse(Console.ReadLine());
        inss = 0;
        //Condicionais Cálculo de INSS para cada faixa de renda.        
        if (salario <= 1212.00)
        {
            inss = salario * 0.075;            
        }
        else if (salario >= 1212.01 && salario <= 2427.35)
        {
            inss = (((salario - 1212.00) * 0.090) + 90.90);            
        }

        else if (salario >= 2427.36 && salario <= 3641.03)
        {
            inss = (((salario - 2427.36) * 0.12) + 90.90 + 109.38);            
        }
        else if (salario >= 3641.04 && salario <= 7087.22)
        {
            inss = (((salario - 3641.03) * 0.14) + 90.90 + 109.38 + 145.64);            
        }

        //Variaveis do Cálculo de IR

        double baseDeCalculo, imposto7, imposto15, imposto22, imposto27, pensao, dependentes, totalDeducao;
        pensao = 0;
        dependentes = 0;
        int dependentesQTD = 0;
        baseDeCalculo = 0;

        Console.WriteLine("Pensão Alimentícia");

        pensao = double.Parse(Console.ReadLine());

        Console.WriteLine("Dependentes (Quantidade)");
        dependentesQTD = int.Parse(Console.ReadLine());

        //Cada dependente é multiplicado pela dedução de R$ 189,59
        dependentes = dependentesQTD * 189.59;

        totalDeducao = (dependentes + inss) + pensao;
        baseDeCalculo = salario - inss - pensao - dependentes;


        //Retonando o valor digitado ao usuário + Cálculos.
        Console.WriteLine("Salário bruto: R$ " + "{0:F2}", salario);
        Console.WriteLine("Dependentes: R$ " + "{0:F2}", dependentes);
        Console.WriteLine("Previdência/INSS: R$ " + "{0:F2}", inss);        
        Console.WriteLine("Pensão Alimentícia: R$ " + "{0:F2}", pensao);        
        Console.WriteLine("Total deduções: R$ " + "{0:F2}", totalDeducao);
        Console.WriteLine("Base de Cálculo: R$ " + "{0:F2}", baseDeCalculo);


        //Variáveis dos cálculos de alíquota por faixa salárial de IR              

        imposto7 = ((baseDeCalculo * 0.075) - 142.80);
        imposto15 = ((baseDeCalculo * 0.15) - 354.80);
        imposto22 = ((baseDeCalculo * 0.2250) - 636.13);
        imposto27 = ((baseDeCalculo * 0.2750) - 869.36);

        //Condicionais para cada faixa salárial, imprimindo duas casas decimas após a vírgula.
        if (baseDeCalculo > 1903.98 && baseDeCalculo <= 2826.65)
            Console.WriteLine("Alíquota de: 7.5%\r\nImposto IR: R$ " + "{0:F2}", imposto7);
        else
            if (baseDeCalculo >= 2826.66 && baseDeCalculo <= 3751.05)
            Console.WriteLine("Alíquota de: 15%\r\nImposto IR: R$ " + "{0:F2}", imposto15);
        else
         if (baseDeCalculo >= 3751.06 && baseDeCalculo <= 4664.68)
            Console.WriteLine("Alíquota de: 22,5%\r\nImposto IR: R$ " + "{0:F2}", imposto22);

        else
          if (baseDeCalculo >= 4664.69)
            Console.WriteLine("Alíquota de: 27,50%\r\nImposto IR: R$ " + "{0:F2}", imposto27);
        //Se a faixa salárial não se encaixar em nenhuma condicional, retorna insenção de impostos.
        else
            Console.WriteLine("Sua faixa salárial é isenta de impostos.");

    }

}

