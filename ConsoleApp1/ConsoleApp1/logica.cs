using System;
using System.Collections.Generic;

namespace Programa_Medias_Turmas
{
    class Media_Turmas
    {
        static int Verificacao_Qtd_Alunos(int qtd_Alunos)
        {
            while (qtd_Alunos < 0 || qtd_Alunos >= 20)
            {
                Console.Write("Escreva uma quantidade" +
                    " entre 0 e 20: ");
                qtd_Alunos = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();

            }
            return qtd_Alunos;
        }

        static List<string> Inserir_Nomes(List<string> lista_alunos, int qtd_Alunos)
        {
            Console.WriteLine("---Inserção de Nomes---\n");

            Console.Write($"Escreva o nome dos {qtd_Alunos} alunos, um de cada vez: " + "\n");
            for (int i = 1; i <= qtd_Alunos; i++)
            {
                Console.WriteLine($"{i}º Aluno: ");
                lista_alunos.Add(Console.ReadLine());
                Console.WriteLine("------");

            }
            Console.WriteLine(' ');
            return lista_alunos;
        }

        static void Main(string[] args)
        {
            const int max_nota = 20;
            const int min_nota = 0;


            Console.WriteLine("---Médias---\n");

            Console.Write("Escreva à quantidade de alunos: ");
            int qtd_Alunos = 0;
            qtd_Alunos = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine(' ');
            Verificacao_Qtd_Alunos(qtd_Alunos); //f(x) para ver à qtd dos alunos

            //Console.Write("Qunatidade de alunos: " + qtd_Alunos);


            List<string> lista_alunos = new List<string>(); // Criacão da lista com nomes dos alunos
            Inserir_Nomes(lista_alunos, qtd_Alunos);

            /*
            Console.Write($"Escreva o nome dos {qtd_Alunos} alunos, um de cada vez: " + "\n");
            for (int i = 1; i <= qtd_Alunos; i++)
            {
                Console.WriteLine($"{i}º Aluno: ");
                lista_alunos.Add(Console.ReadLine());

            }
            Console.WriteLine(' ');
            */

            string[] materias = new string[] { "PT", "MAT", "FQ" };
            List<double> lista_notas = new List<double>();

            // output -> Nota do João em PT:
            // output -> Not@ d@ João em MAt:
            // output -> Nota do João em PT
            //input -> 13
            for (int i = 0; i < qtd_Alunos; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Not@ d@ {lista_alunos[i]} " +
                        $"em {materias[j]}: ");
                    lista_notas.Add(Convert.ToDouble(Console.ReadLine()));

                }
                Console.WriteLine("------");
            }


            //Mostra-me as notas de cada um
            //Not@ d@ K em PT: 9
            //Not@ d@ K em MAT: 3
            //Not@ d@ K em FQ: 7

            int cont = 0;
            for (int i = 0; i < qtd_Alunos; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"Not@ d@ {lista_alunos[i]} " +
                        $"em {materias[j]}: {lista_notas[cont++]}");
                    //Não sei como percorrer tbm o array de notas (x-x)
                }
                Console.WriteLine("------");

            }
            cont = 0;
            Console.WriteLine(' ');
            //Fazer médias 
            double soma_notas = 0;
            int cont_2 = 0;
            List<double> lista_medias = new List<double>();

            //Percorre a lista_notas e cálcula as médias de cada aluno
            for (int i = 0; i < lista_notas.Count; i++)
            {
                soma_notas += lista_notas[i];
                cont++;

                if (cont > 2)
                {
                    lista_medias.Add(soma_notas / 3);
                    cont = 0;
                    soma_notas = 0;
                }
            }
            cont = 0;

            Console.WriteLine("---Média Final---");
            for (int i = 0; i < qtd_Alunos; i++)
            {
                Console.WriteLine($"{lista_alunos[i]}: {lista_medias[i]}");
            }

        }
    }
}