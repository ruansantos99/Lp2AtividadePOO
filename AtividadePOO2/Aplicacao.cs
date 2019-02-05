using System;
using System.Linq;
using static System.Console;


namespace Atividade1
{
    public class Aplicacao
    {
        public const decimal Juros = 0.6M;

        

        static void Main(string[] args)
        {

            using (var dbcontext = new StoreContext())
            {

                dbcontext.Set<Banco>().RemoveRange(dbcontext.Bancos);
                Banco bb = new Banco();
                dbcontext.Bancos.Add(bb);
                dbcontext.SaveChanges();



                while (true)
                {
                    
                    MenuAgencia();
                    int op = int.Parse(ReadLine());

                    if (op == 1)
                    {
                        Agencia agencia = new Agencia();
                        dbcontext.Agencias.Add(agencia);
                        dbcontext.SaveChanges();

                    }
                    else if (op == 2)
                    {
                        Cliente cliente = new Cliente();
                        WriteLine("digite o nome do titular: ");
                        string nome_cliente = ReadLine();
                        cliente.Nome = nome_cliente;
                        dbcontext.Clientes.Add(cliente);
                        dbcontext.SaveChanges();

                        WriteLine("Temos 2 tipos de conta, qual deseja?\n");
                        WriteLine("1 - Conta Corrente: ");
                        WriteLine("2 - Conta Poupança: ");
                        int tipo_conta = int.Parse(ReadLine());
                        if (tipo_conta == 1)
                        {
                            ContaCorrente cc = new ContaCorrente(cliente.Nome);
                            WriteLine("Digite o numero da agência: ");
                            int numAgencia = int.Parse(ReadLine());

                            Agencia agencia = Aplicacao.buscaAgencia(numAgencia);
                            if (agencia != null)
                            {
                                cc.AgenciaId = agencia.Id;
                                dbcontext.ContasCorrentes.Add(cc);
                                dbcontext.SaveChanges();
                                WriteLine("Conta " + cc.Id + " de titular " + cc.Titular + " criada com sucesso!\n");
                            }
                            else
                            {
                                WriteLine("Dados errado, tente novamente.\n");
                            }

                        }
                        else if (tipo_conta == 2)
                        {   
                            ContaPoupanca cp = new ContaPoupanca(Juros, DateTime.Now, cliente.Nome);
                            WriteLine("Digite o numero da agência: ");
                            int numAgencia = int.Parse(ReadLine());

                            Agencia agencia = Aplicacao.buscaAgencia(numAgencia);
                            if (agencia != null)
                            {
                                cp.AgenciaId = agencia.Id;
                                dbcontext.ContasPoupanca.Add(cp);
                                dbcontext.SaveChanges();
                                WriteLine("Conta " + cp.Id + " de titular " + cp.Titular + " criada com sucesso!\n");
                            }
                            else
                            {
                                WriteLine("Dados errado, tente novamente.\n");
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
                        WriteLine("OPÇÃO INVÁLIDA");
                    }


                }
            }
        }

        public static void MenuAgencia()
        {
            WriteLine("Bem vindo ao nosso Banco, oque deseja?");
            WriteLine(" 1 - Cadastrar Agência  ");
            WriteLine(" 2 - Criar Conta ");
            WriteLine(" 3 - Abrir uma Sessão ");
            WriteLine(" 0 - Sair");
        }

        
        public static Agencia buscaAgencia(int num)
        {

            using (var db = new StoreContext())
            {
                try
                {
                    var agencia = db.Agencias
                    .Single(a => a.Id == num);
                    return agencia;
                }
                catch (Exception)
                {
                    WriteLine("O numero de agência está errado ou não existe, por favor, verifique se o Numero está correto:\n");
                    return null;
                }
            }
        }

        public static Cliente buscaCliente(int num)
        {

            using (var db = new StoreContext())
            {
                try
                {
                    var cliente = db.Clientes
                    .Single(c => c.Id == num);
                    return cliente;
                }
                catch (Exception)
                {
                    WriteLine("O está errado ou não existe, por favor, verifique se o Numero está correto:\n");
                    return null;
                }
            }
        }

        public static ContaCorrente buscaContaCorrente(int num)
        {

            using (var db = new StoreContext())
            {
                try
                {
                    var cc = db.ContasCorrentes
                    .Single(c => c.Id == num);
                    return cc;
                }
                catch (Exception)
                {
                    WriteLine("O numero da conta está errado ou não existe, por favor, verifique se o Numero está correto:\n");
                    return null;
                }
            }
        }

        public static ContaPoupanca buscaContaPoupanca(int num)
        {

            using (var db = new StoreContext())
            {
                try
                {
                    var cp = db.ContasPoupanca
                    .Single(p => p.Id == num);
                    return cp;
                }
                catch (Exception)
                {
                    WriteLine("O numero da conta está errado ou não existe, por favor, verifique se o Numero está correto:\n");
                    return null;
                }
            }
        }

        



    }
}