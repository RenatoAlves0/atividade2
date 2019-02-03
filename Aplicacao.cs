using System;

namespace Atividade1
{
    class Aplicacao
    {
        public const decimal Juros = 0.6M;

        static void Main(string[] args)
        {
            int sum = 0;
            int id_contaCorrente = 0;
            int id_contaPoupanca = 0;

            Banco bb = new Banco();
            while (true)
            {
                bb.listaIdAgencias();
                MenuAgencia();
                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    Agencia agencia = new Agencia();
                    agencia.IdAgencia = sum;
                    bb.AdicionarAgencia(agencia);
                    sum++;

                }
                else if (op == 2)
                {
                    Cliente cliente = new Cliente();
                    Console.WriteLine("Digite o nome do cliente: ");
                    string nome_cliente = Console.ReadLine();
                    cliente.Nome = nome_cliente;

                    Console.WriteLine("Que tipo de conta deseja criar:\n");
                    Console.WriteLine("1 - Corrente / 2 - Poupança: ");
                    int tipo_conta = int.Parse(Console.ReadLine());
                    if (tipo_conta == 1)
                    {
                        ContaCorrente cc = new ContaCorrente(cliente.Nome);
                        Console.WriteLine("Digite o Id da agência: ");
                        int numAgencia = int.Parse(Console.ReadLine());

                        Agencia agencia = bb.buscaAgencia(numAgencia);
                        if (agencia != null)
                        {
                            cc.Id = id_contaCorrente;
                            agencia.AdicionarContaCorrente(cc);
                            id_contaCorrente++;
                        }
                        else
                        {
                            Console.WriteLine("Por favor tente novamente!");
                        }

                    }
                    else if (tipo_conta == 2)
                    {
                        ContaPoupanca cp = new ContaPoupanca(Juros, DateTime.Now, cliente.Nome);
                        Console.WriteLine("Digite o Id da agência: ");
                        int numAgencia = int.Parse(Console.ReadLine());

                        Agencia agencia = bb.buscaAgencia(numAgencia);
                        if (agencia != null)
                        {
                            cp.Id = id_contaPoupanca;
                            agencia.AdicionarContaPoupanca(cp);
                            id_contaPoupanca++;
                        }
                        else
                        {
                            Console.WriteLine("Por favor tente novamente!");
                        }

                    }
                }
                else if (op == 3)
                {
                    Solicitacao solicitacao = new Solicitacao();
                    solicitacao.realizarSolicitacao(bb);

                }else if(op == 0)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("OPÇÃO INVÁLIDA");
                }


            }
        }

        public static void MenuAgencia()
        {
            Console.WriteLine("|------------------------|");
            Console.WriteLine("| Cadastrar Agência -- 1 |");
            Console.WriteLine("| Criar Conta -------- 2 |");
            Console.WriteLine("| Abrir uma Sessão --- 3 |");
            Console.WriteLine("| Encerrar programa -- 0 |");
            Console.WriteLine("|------------------------|");
        }



    }
}