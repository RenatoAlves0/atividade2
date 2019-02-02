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
                    Console.WriteLine("digite o nome do cliente: ");
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

                    //Console.WriteLine("Digite o Id da agência: ");
                    //int numAgencia = int.Parse(Console.ReadLine());

                    //Console.WriteLine("Digite o tipo da conta: 1 - Corrente/ 2 - Poupança");
                    //int tipo_conta = int.Parse(Console.ReadLine());

                    //if (tipo_conta == 1)
                    //{
                    //    Console.WriteLine("Digite o numero da conta: ");
                    //    int num_conta = int.Parse(Console.ReadLine());
                    //    Agencia agencia = bb.buscaAgencia(numAgencia);
                    //    ContaCorrente cc =  agencia.getCCorrente(num_conta);

                    //    Console.WriteLine("O que deseja realizar: ");
                    //    Console.WriteLine("1 - Consultar Saldo / 2 - Sacar / 3 -  Depositar");
                    //    int operacao = int.Parse(Console.ReadLine());

                    //    if (operacao == 1)
                    //    {
                    //        Console.WriteLine("********************");
                    //        Console.WriteLine("Conta = " + cc.Id);
                    //        Console.WriteLine("Titular = " + cc.Titular);
                    //        Console.WriteLine("Seu saldo é = R$ " + cc.Saldo);
                    //        Console.WriteLine("********************");
                    //    }
                    //    else if (operacao == 2)
                    //    {
                    //        Console.WriteLine("SAQUE");
                    //        Console.WriteLine("Digite o valor para saque: ");
                    //        cc.Sacar(decimal.Parse(Console.ReadLine()));

                    //    }
                    //    else if (operacao == 3)
                    //    {
                    //        Console.WriteLine("DEPÓSITO");
                    //        Console.WriteLine("Digite o valor para depositar: ");
                    //        cc.Depositar(decimal.Parse(Console.ReadLine()));
                    //    }
                    //}
                    //else if (tipo_conta == 2)
                    //{
                    //    Console.WriteLine("Digite o numero da conta: ");
                    //    int num_conta = int.Parse(Console.ReadLine());
                    //    Agencia agencia = bb.buscaAgencia(numAgencia);
                    //    ContaPoupanca cp = agencia.getCPoupanca(num_conta);

                    //    Console.WriteLine("O que deseja realizar: ");
                    //    Console.WriteLine("1 - Consultar Saldo / 2 - Sacar / 3 -  Depositar");
                    //    int operacao = int.Parse(Console.ReadLine());

                    //    if (operacao == 1)
                    //    {
                    //        Console.WriteLine("********************");
                    //        Console.WriteLine("Conta = " + cp.Id);
                    //        Console.WriteLine("Titular = " + cp.Titular);
                    //        Console.WriteLine("Seu saldo é = R$ " + cp.Saldo);
                    //        Console.WriteLine("********************");
                    //    }
                    //    else if (operacao == 2)
                    //    {
                    //        Console.WriteLine("SAQUE");
                    //        Console.WriteLine("Digite o valor para saque: ");
                    //        cp.Sacar(decimal.Parse(Console.ReadLine()));
                    //    }
                    //    else if (operacao == 3)
                    //    {
                    //        Console.WriteLine("DEPÓSITO");
                    //        Console.WriteLine("Digite o valor para depositar: ");
                    //        cp.Depositar(decimal.Parse(Console.ReadLine()));
                    //    }
                    //}
                }


            }
        }

        public static void MenuAgencia()
        {
            Console.WriteLine("|------------------------|");
            Console.WriteLine("| Cadastrar Agência -- 1 |");
            Console.WriteLine("| Criar Conta -------- 2 |");
            Console.WriteLine("| Abrir uma Sessão --- 3 |");
            Console.WriteLine("|------------------------|");
        }



    }
}
