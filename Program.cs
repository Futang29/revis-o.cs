using System;

namespace revisão
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];//indica Aluno.Length
            var indicealuno = 0;
            string opcaoUsuario = ObterOpçãoUsuário();

            while (opcaoUsuario.ToUpper() != "4")
            //sair do programa
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno.");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno.");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal Nota))
                        {
                        aluno.Nota = Nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal.");
                        }

                        alunos[indicealuno] = aluno;
                        indicealuno++;
                        //adicionar um aluno e nota
                        break;

                    case "2":

                        foreach(var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))//ocultar espaços no array nulos
                            {
                            Console.WriteLine($"ALUNO: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        //escrever a lista de alunos
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral <4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO: {conceitoGeral}");
                        //calcular media geral dos alunos e um conceito para a mesma
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();//exceção utilizada para parar o programa
                }
                opcaoUsuario = ObterOpçãoUsuário();
            }
        }

        private static string ObterOpçãoUsuário()
        {
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geal");
            Console.WriteLine("4- Sair");
            Console.WriteLine();
            //quadro de opções

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
