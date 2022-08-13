//Calculadora de INSS E IRRF 2022 Versão 1.0
// Aprimoramentos para a próxima versão:
// Tornar uma calcuradora única, já com o INSS integrado ao IRRF

using System;
class Programa
{
    static void Main(string[] args)

    {
        // Menu para acessar as Calculadoras
        Console.WriteLine("Bem vindo a Calculadora do INSS 2022 e IRRF 2022");
        Console.WriteLine("Digite * para acessar a Calculadora de INSS");
        Console.WriteLine("Digite ! para acessar a Calculadora de IRRF");
        char menu = char.Parse(Console.ReadLine());

        switch (menu)
        {
            case '*':
                Console.WriteLine("Calculadora do INSS 2022");
                Console.WriteLine("Digite o seu salário bruto mensal.");
                //Já que não tem validação de entrada de dados, usei um exemplo para evitar erros.
                Console.WriteLine("Exemplo: 2200,00");
                double salario, inss;
                salario = double.Parse(Console.ReadLine());
                //Condicionais para cada faixa de renda.        
                if (salario <= 1212.00)
                {
                    inss = salario * 0.075;
                    Console.WriteLine("Você está na faixa salárial com Alíquota de 7,5% e sua contribuição INSS é de: R$ " + "{0:F2}" + " ao mês.", inss);
                }
                else if (salario >= 1212.01 && salario <= 2427.35)
                {
                    inss = (((salario - 1212.00) * 0.090) + 90.90);
                    Console.WriteLine("Você está na faixa salárial com Alíquota de 9% e sua contribuição INSS é de: R$ " + "{0:F2}" + " ao mês.", inss);
                }

                else if (salario >= 2427.36 && salario <= 3641.03)
                {
                    inss = (((salario - 2427.36) * 0.12) + 90.90 + 109.38);
                    Console.WriteLine("Você está na faixa salárial com Alíquota de 12% e sua contribuição INSS é de: R$ " + "{0:F2}" + " ao mês.", inss);
                }
                else if (salario >= 3641.04 && salario <= 7087.22)
                {
                    inss = (((salario - 3641.03) * 0.14) + 90.90 + 109.38 + 145.64);
                    Console.WriteLine("Você está na faixa salárial com Alíquota de 14% e sua contribuição INSS é de: R$ " + "{0:F2}" + " ao mês.", inss);
                }
                break;

            case '!':
                Console.WriteLine("Bem vindo a cáculadora de IRRF 2022");
                Console.WriteLine("Digite o seu salário bruto mensal.");
                //Já que não tem validação de entrada de dados, usei um exemplo para evitar erros.
                Console.WriteLine("Exemplo: 2200,00");

                double baseDeCalculo, imposto7, imposto15, imposto22, imposto27, pensao, dependentes;
                pensao = 0;
                dependentes = 0;
                int dependentesQTD = 0;
                inss = 0;
                baseDeCalculo = 0;

                //Variável digitada pelo usuário convertido de string para double.
                salario = double.Parse(Console.ReadLine());

                Console.WriteLine("Paga algum valor de pensão alimentícia? 1 para Sim, 2 para Não.");

                char menuPensao = char.Parse(Console.ReadLine());
                switch (menuPensao)
                {
                    case '1':
                        Console.WriteLine("Digite o valor da pensão alimentícia");
                        pensao = double.Parse(Console.ReadLine());
                        break;
                    case '2':
                        pensao = 0;
                        break;
                }

                Console.WriteLine("Tem dependentes? 1 para Sim, 2 para Não.");
                char menuDependentes = char.Parse(Console.ReadLine());
                switch (menuDependentes)
                {
                    case '1':
                        Console.WriteLine("Digite o número de dependentes");
                        dependentesQTD = int.Parse(Console.ReadLine());
                        dependentes = dependentesQTD * 189.59;
                        break;
                    case '2':
                        dependentes = 0;
                        break;

                }
                Console.WriteLine("Contribui para o INSS? 1 para Sim, 2 para Não.");
                char menuINSS = char.Parse(Console.ReadLine());
                switch (menuINSS)
                {
                    case '1':
                        Console.WriteLine("Digite o valor de contribuição paga.");
                        inss = double.Parse(Console.ReadLine());
                        break;
                    case '2':
                        dependentes = 0;
                        break;

                }

                baseDeCalculo = salario - inss - pensao - dependentes;


                //Retonando o valor digitado ao usuário
                Console.WriteLine("Salário bruto: R$ " + "{0:F2}", salario);
                Console.WriteLine("Pensão Alimentícia no valor de : R$ " + "{0:F2}", pensao);
                Console.WriteLine("Dependentes: " + dependentesQTD + " com dedução de: R$ " + "{0:F2}", dependentes);
                Console.WriteLine("Sua base de cáculo para o IR é de: R$ " + "{0:F2}", baseDeCalculo);


                //Variáveis dos cálculos de alíquota por faixa salárial.              

                imposto7 = ((baseDeCalculo * 0.075) - 142.80);
                imposto15 = ((baseDeCalculo * 0.15) - 354.80);
                imposto22 = ((baseDeCalculo * 0.2250) - 636.13);
                imposto27 = ((baseDeCalculo * 0.2750) - 869.36);

                //Condicionais para cada faixa salárial, imprimindo duas casas decimas após a vírgula.
                if (baseDeCalculo > 1903.98 && baseDeCalculo <= 2826.65)
                    Console.WriteLine("A alíquota para sua faixa salárial é de: 7.5%\r\nImposto a pagar: R$ " + "{0:F2}", imposto7);
                else
                    if (baseDeCalculo >= 2826.66 && baseDeCalculo <= 3751.05)
                    Console.WriteLine("A alíquota para sua faixa salárial é de: 15%\r\nImposto a pagar: R$ " + "{0:F2}", imposto15);
                else
                 if (baseDeCalculo >= 3751.06 && baseDeCalculo <= 4664.68)
                    Console.WriteLine("A alíquota para sua faixa salárial é de: 22,5%\r\nImposto a pagar: R$ " + "{0:F2}", imposto22);

                else
                  if (baseDeCalculo >= 4664.69)
                    Console.WriteLine("A alíquota para sua faixa salárial é de: 27,50%\r\nImposto a pagar: R$ " + "{0:F2}", imposto27);
                //Se a faixa salárial não se encaixar em nenhuma condicional, retorna insenção de impostos.
                else
                    Console.WriteLine("Sua faixa salárial é isenta de impostos.");
                break;

            default:
                Console.WriteLine("Você digitou o comando errado.");
                break;

        }

    }


}