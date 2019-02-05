using System;
using static System.Console;

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

            Banco banco = new Banco();
            bool init = true;
            while (init)
            {
               
                MenuAgencia();
                int op = int.Parse(ReadLine());

                if (op == 1)
                {
                    Agencia agencia = new Agencia();
                    agencia.IdAgencia = sum;
                    banco.AdicionarAgencia(agencia);
                    sum++;

                }
                else if (op == 2)
                {
                    Cliente cliente = new Cliente();
                    WriteLine("digite o nome do titular: ");
                    string nome_cliente = ReadLine();
                    cliente.Nome = nome_cliente;

                    WriteLine("Temos 2 tipos de conta, qual deseja?\n");
                    WriteLine("1 - Conta Corrente: ");
                    WriteLine("2 - Conta Poupança: ");

                    int tipo_conta = int.Parse(ReadLine());
                    if (tipo_conta == 1)
                    {
                        ContaCorrente cc = new ContaCorrente(cliente.Nome);
                        WriteLine("Digite o numero da agência: ");
                        int numAgencia = int.Parse(ReadLine());

                        Agencia agencia = banco.buscaAgencia(numAgencia);
                        if (agencia != null)
                        {
                            cc.Id = id_contaCorrente;
                            agencia.AdicionarContaCorrente(cc);
                            id_contaCorrente++;
                        }
                        else
                        {
                            WriteLine("Dados errado, tente novamente.");
                        }
                        
                    }
                    else if (tipo_conta == 2)
                    {
                        ContaPoupanca cp = new ContaPoupanca(Juros, DateTime.Now, cliente.Nome);
                        WriteLine("Digite o numero da agência: ");
                        int numAgencia = int.Parse(ReadLine());

                        Agencia agencia = banco.buscaAgencia(numAgencia);
                        if (agencia != null)
                        {
                            cp.Id = id_contaPoupanca;
                            agencia.AdicionarContaPoupanca(cp);
                            id_contaPoupanca++;
                        }
                        else
                        {
                            WriteLine("Dados errado, tente novamente.");
                        }
                        
                    }
                }
                else if (op == 3)
                {
                    Solicitacao solicitacao = new Solicitacao();
                    solicitacao.realizarSolicitacao(banco);

                    
                }
                else if (op == 4)
                {
                    banco.listaIdAgencias();


                }
                else if( op == 0)
                {
                    init = false;
                }


            }
        }

        public static void MenuAgencia()
        {
            WriteLine("Bem vindo ao nosso Banco, oque deseja?");
            WriteLine(" 1 - Cadastrar Agência  ");
            WriteLine(" 2 - Criar Conta ");
            WriteLine(" 3 - Abrir uma Sessão ");
            WriteLine(" 4 - Listar agências ");
            WriteLine(" 0 - Sair");
        }



    }
}
