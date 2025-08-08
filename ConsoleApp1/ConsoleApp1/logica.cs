using System;
using System.Collections.Generic;

namespace Programa_Medias_Turmas
{
    class Media_Turmas
    {
        //f(x) para verificar a quantidade de alunos inseridos
        static int Verificacao_Qtd_Alunos(int qtd_Alunos)
        {
            while (qtd_Alunos <= 0 || qtd_Alunos > 20)
            {
                Console.Write("Escreva uma quantidade entre 1 e 20: ");
                qtd_Alunos = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            return qtd_Alunos;
        }

        //f(x) para inserir os nomes dentro da lista alunos
        static List<string> Inserir_Nomes(List<string> lista_alunos, int qtd_Alunos)
        {
            Console.WriteLine("---Inserção de Nomes---\n");
            Console.Write($"Escreva o nome dos {qtd_Alunos} alunos, um de cada vez:\n");

            for (int i = 1; i <= qtd_Alunos; i++)
            {
                Console.Write($"{i}º Aluno: ");
                lista_alunos.Add(Console.ReadLine());
                Console.WriteLine("------");
            }
            Console.WriteLine();
            return lista_alunos;
        }

        //f(x) para inserir as notas dentro de lista_notas - CORRIGIDA
        static List<double> Insercao_Notas(List<string> lista_alunos, List<double> lista_notas,
                                          string[] materias, int qtd_Alunos, int max_nota, int min_nota)
        {
            Console.WriteLine("---Inserção de Notas---\n");

            for (int i = 0; i < qtd_Alunos; i++)
            {
                for (int j = 0; j < materias.Length; j++)
                {
                    double nota_inserida_user;

                    Console.Write($"Nota do {lista_alunos[i]} em {materias[j]}: ");
                    nota_inserida_user = Convert.ToDouble(Console.ReadLine());

                    while (nota_inserida_user < min_nota || nota_inserida_user > max_nota)
                    {
                        Console.Write($"Insira uma nota entre {min_nota} e {max_nota}: ");
                        nota_inserida_user = Convert.ToDouble(Console.ReadLine());
                    }

                    lista_notas.Add(nota_inserida_user);
                }
                Console.WriteLine("------");
            }
            return lista_notas;
        }

        //f(x) para mostrar notas de cada Aluno
        static void Mostrar_Notas(int qtd_Alunos, List<string> lista_alunos,
                                 string[] materias, List<double> lista_notas)
        {
            Console.WriteLine("---Notas dos Alunos---\n");
            int cont = 0;

            for (int i = 0; i < qtd_Alunos; i++)
            {
                for (int j = 0; j < materias.Length; j++)
                {
                    Console.WriteLine($"Nota do {lista_alunos[i]} em {materias[j]}: {lista_notas[cont]}");
                    cont++;
                }
                Console.WriteLine("------");
            }
            Console.WriteLine();
        }

        //f(x) para calcular as medias
        static List<double> Calcular_Medias(List<double> lista_notas)
        {
            List<double> lista_medias = new List<double>();
            double soma_notas = 0;
            int cont = 0;

            for (int i = 0; i < lista_notas.Count; i++)
            {
                soma_notas += lista_notas[i];
                cont++;

                if (cont == 3)
                {
                    lista_medias.Add(soma_notas / 3.0);
                    cont = 0;
                    soma_notas = 0;
                }
            }
            return lista_medias;
        }

        //f(x) para mostrar as médias
        static void Mostrar_Medias(List<string> lista_alunos, List<double> lista_medias)
        {
            Console.WriteLine("---Média Final---\n");
            for (int i = 0; i < lista_alunos.Count; i++)
            {
                Console.WriteLine($"{lista_alunos[i]}: {lista_medias[i]:F2}");
            }
        }

        static void Main(string[] args)
        {
            const int max_nota = 20;
            const int min_nota = 0;

            Console.WriteLine("---Médias---\n");

            Console.Write("Escreva a quantidade de alunos: ");
            int qtd_Alunos = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            qtd_Alunos = Verificacao_Qtd_Alunos(qtd_Alunos);

            List<string> lista_alunos = new List<string>();
            Inserir_Nomes(lista_alunos, qtd_Alunos);

            string[] materias = new string[] { "PT", "MAT", "FQ" };
            List<double> lista_notas = new List<double>();

            Insercao_Notas(lista_alunos, lista_notas, materias, qtd_Alunos, max_nota, min_nota);

            Mostrar_Notas(qtd_Alunos, lista_alunos, materias, lista_notas);

            List<double> lista_medias = Calcular_Medias(lista_notas);
            Mostrar_Medias(lista_alunos, lista_medias);
        }
    }
}