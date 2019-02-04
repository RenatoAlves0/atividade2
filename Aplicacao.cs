using System;


namespace Atividade1
{
    class Aplicacao
    {
        public const decimal Juros = 0.6M;

        

        static void Main(string[] args)
        {
            int sum = 1;
            int id_contaCorrente = 1;
            int id_contaPoupanca = 1;

            using (var dbcontext = new StoreContext())
            {
                
                dbcontext.Set<Agencia>().RemoveRange(dbcontext.Agencias);
                dbcontext.Set<Banco>().RemoveRange(dbcontext.Bancos);
                dbcontext.Set<Cliente>().RemoveRange(dbcontext.Clientes);
                dbcontext.Set<ContaCorrente>().RemoveRange(dbcontext.ContasCorrentes);
                dbcontext.Set<ContaPoupanca>().RemoveRange(dbcontext.ContasPoupanca);
                dbcontext.Set<Solicitacao>().RemoveRange(dbcontext.Solicitacoes);
                dbcontext.SaveChanges();


                

                Banco bb = new Banco();
                dbcontext.Bancos.Add(bb);
                dbcontext.SaveChanges();

                

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

                        dbcontext.Agencias.Add(agencia);
                        dbcontext.SaveChanges();

                    }
                    else if (op == 2)
                    {
                        Cliente cliente = new Cliente();
                        Console.WriteLine("Digite o nome do cliente: ");
                        string nome_cliente = Console.ReadLine();
                        cliente.Nome = nome_cliente;
                        dbcontext.Clientes.Add(cliente);
                        dbcontext.SaveChanges();

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
                                dbcontext.ContasCorrentes.Add(cc);
                                dbcontext.SaveChanges();
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
                                dbcontext.ContasPoupanca.Add(cp);
                                dbcontext.SaveChanges();
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
                        dbcontext.Solicitacoes.Add(solicitacao);
                        dbcontext.SaveChanges();

                    }
                    else if (op == 0)
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("OPÇÃO INVÁLIDA");
                    }


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