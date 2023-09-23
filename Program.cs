using System;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace ContadorCalorias // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Nome, Sexo, Escolha;
            double Dias, Altura, Peso, Idade, TMB, CaloriasAtividadeFisica, CaloriasConsumidasDiariamente, PesoDesejaQueimar, IMC, CentimetrosParaMetros,
                TempoParaQueimar, CaloriasTotaisGastasNoDia, CaloriasFinais;
            Console.WriteLine("Informe seu primeiro nome:");
            Nome = Console.ReadLine();
            Console.WriteLine("Infome seu peso (ex: 97):");
            Peso = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe sua altura (ex 185):");
            Altura = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe seu sexo (F = Feminino e M = Masculino):");
            Sexo = (Console.ReadLine());
            Console.WriteLine("Informe sua idade (ex: 21):");
            Idade = double.Parse(Console.ReadLine());
            Console.WriteLine("Escolha uma das opções:\n1. Já sei quantas calorias gasto e quantos dias pretendo seguir a dieta\n2. Tenho uma meta de queima de gordura e queria saber em quantos dias vou alcançar essa meta");
            Escolha = (Console.ReadLine());
            Console.WriteLine("Quantas calorias você gasta com atividade físicas:\n1 hora de academia = 300\n30 minutos de caminhada = 150\n30 minutos de corrida = 240");
            CaloriasAtividadeFisica = double.Parse(Console.ReadLine());
            Console.WriteLine("Quantas calorias você consome diariamente (ex 1500):");
            CaloriasConsumidasDiariamente = double.Parse(Console.ReadLine());
            CentimetrosParaMetros = Altura / 100;
            IMC = Peso / (CentimetrosParaMetros * CentimetrosParaMetros);
            if (Sexo == "M" || Sexo == "m")
            {
                TMB = 66.5 + (13.75 * Peso) + (5.003 * Altura) - (6.75 * Idade);
            }
            else
            {
                TMB = 655.1 + (9.563 * Peso) + (1.850 * Altura) - (4.676 * Idade);
            }

            CaloriasTotaisGastasNoDia = CaloriasAtividadeFisica + TMB - CaloriasConsumidasDiariamente;

            if (Escolha == "1")
            {
                Console.WriteLine("Durante quantos dias você pretende seguir essa dieta (ex: 30):");
                Dias = double.Parse(Console.ReadLine());
                CaloriasFinais = CaloriasTotaisGastasNoDia * Dias / 7500;
                Console.WriteLine(Nome + ", seguindo essa dieta durante " + Dias + " dias você vai queimar " + CaloriasFinais.ToString("F0") + " Quilos de gordura corporal");
            }
            else
            {
                Console.WriteLine("Quantos quilos de gordura você quer perder (ex: 10):");
                PesoDesejaQueimar = double.Parse(Console.ReadLine());
                TempoParaQueimar = (PesoDesejaQueimar * 7500) / CaloriasTotaisGastasNoDia;
                Console.WriteLine(Nome + ", aqui estão alguns dados sobre seu gasto calórico:" +
                    "\nTaxa metabólica basal: " + TMB.ToString("F0") + " calorias" +
                    "\nCalorias gastas em atividades físicas: " + CaloriasAtividadeFisica + " calorias" +
                    "\nCalorias consumidas diariamente: " + CaloriasConsumidasDiariamente + " calorias " +
                    "\n" + Nome + ", levando em conta que você está gastando " + CaloriasConsumidasDiariamente + " calorias por dia,\nvocê vai precisar seguir essa dieta durante " + TempoParaQueimar.ToString("F0") + " dias para queimar esses " + PesoDesejaQueimar + " Quilos de gordura corporal");
            }
            if (IMC <= 18.5)
            {
                Console.WriteLine("Seu IMC (Índice de Massa Corporal): " + IMC.ToString("F2") + " ----> Você está abaixo do peso");
            }
            if (IMC >= 18.6 && IMC <= 24.9)
            {
                Console.WriteLine("Seu IMC (Índice de Massa Corporal): " + IMC.ToString("F2") + " ----> Você está no seu peso ideal");
            }
            if (IMC >= 25.0 && IMC <= 29.9)
            {
                Console.WriteLine("Seu IMC (Índice de Massa Corporal): " + IMC.ToString("F2") + " ----> Você está levemente acima do peso");
            }
            if (IMC >= 30.0 && IMC <= 34.9)
            {
                Console.WriteLine("Seu IMC (Índice de Massa Corporal): " + IMC.ToString("F2") + " ----> Você está com obesidade grau 1");
            }
            if (IMC >= 35.0 && IMC <= 39.9)
            {
                Console.WriteLine("Seu IMC (Índice de Massa Corporal): " + IMC.ToString("F2") + " ----> Você está com obesidade grau 2 (severa)");
            }
            if (IMC >= 40.0)
            {
                Console.WriteLine("Seu IMC (Índice de Massa Corporal): " + IMC.ToString("F2") + " ----> Você está com obesidade grau 3 (mórbida)");
            }
        }
    }
}