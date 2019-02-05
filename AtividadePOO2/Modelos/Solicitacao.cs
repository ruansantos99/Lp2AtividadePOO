    using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static System.Console;

namespace Atividade1
{
    public class Solicitacao
    {
        
        public void realizarSolicitacao(Banco banco)
        {
            WriteLine("Digite o numero da agência: ");
            int numAgencia = int.Parse(Console.ReadLine());

            WriteLine("Digite o tipo da conta:");
            WriteLine("1 - Corrente:");
            WriteLine("2 - Poupança:");
            int tipo_conta = int.Parse(Console.ReadLine());

            if (tipo_conta == 1)
            {

                Agencia agencia = Aplicacao.buscaAgencia(numAgencia);
                if (agencia == null)
                {
                    return;
                }

                WriteLine("Digite o numero da sua conta: ");
                int num_conta = int.Parse(Console.ReadLine());

                ContaCorrente cc = Aplicacao.buscaContaCorrente(num_conta);
                if (cc == null)
                {
                    return;
                }

                WriteLine("Que operação deseja realizar? ");
                WriteLine("1 - Consultar Saldo:");
                WriteLine("2 - Sacar:");
                WriteLine("3 - Depositar:");
                int operacao = int.Parse(Console.ReadLine());

                if (operacao == 1)
                {
                    WriteLine("Situação da conta:");
                    WriteLine("Conta = " + cc.Id);
                    WriteLine("Titular = " + cc.Titular);
                    WriteLine("Seu saldo é = R$ " + cc.Saldo + "\n");
                }
                else if (operacao == 2)
                {
                    //Console.WriteLine("SAQUE");
                    //Console.WriteLine("Digite o valor para saque: ");
                    //cc.Sacar(decimal.Parse(Console.ReadLine()));
                    using (var db = new StoreContext())
                    {
                        WriteLine("Sua operação é SAQUE");
                        WriteLine("Quanto deseja sacar?");
                        var founded = db.Set<ContaCorrente>().First(c => c.Id == cc.Id);
                        founded.Sacar(decimal.Parse(Console.ReadLine()));
                        db.SaveChanges();
                    }
                }
                else if (operacao == 3)
                {
                    //Console.WriteLine("DEPÓSITO");
                    //Console.WriteLine("Digite o valor para depositar: ");
                    //cc.Depositar(decimal.Parse(Console.ReadLine()));
                    using (var db = new StoreContext())
                    {
                        WriteLine("Sua operação é DEPÓSITO");
                        WriteLine("Quanto deseja depositar: ");
                        var founded = db.Set<ContaCorrente>().First(c => c.Id == cc.Id);
                        founded.Depositar(decimal.Parse(Console.ReadLine()));
                        db.SaveChanges();
                    }

                }
            }
            else if (tipo_conta == 2)
            {
                WriteLine("Digite o numero da conta: ");
                int num_conta = int.Parse(Console.ReadLine());
                Agencia agencia = Aplicacao.buscaAgencia(numAgencia);
                if (agencia == null)
                {
                    return;
                }
                ContaPoupanca cp = Aplicacao.buscaContaPoupanca(num_conta);
                if (cp == null)
                {
                    return;
                }

                WriteLine("Que operação deseja realizar? ");
                WriteLine("1 - Consultar Saldo:");
                WriteLine("2 - Sacar:");
                WriteLine("3 - Depositar:");
                int operacao = int.Parse(Console.ReadLine());

                if (operacao == 1)
                {
                    WriteLine("Situação da conta:");
                    WriteLine("Conta = " + cp.Id);
                    WriteLine("Titular = " + cp.Titular);
                    WriteLine("Seu saldo é = R$ " + cp.Saldo + "\n");
                }
                else if (operacao == 2)
                {
                    //Console.WriteLine("SAQUE");
                    //Console.WriteLine("Digite o valor para saque: ");
                    //cp.Sacar(decimal.Parse(Console.ReadLine()));

                    using (var db = new StoreContext())
                    {
                        WriteLine("Sua operação é SAQUE");
                        WriteLine("Quanto deseja saque: ");
                        var founded = db.Set<ContaPoupanca>().First(p => p.Id == cp.Id);
                        founded.Sacar(decimal.Parse(Console.ReadLine()));
                        db.SaveChanges();
                    }
                }
                else if (operacao == 3)
                {
                    //Console.WriteLine("DEPÓSITO");
                    //Console.WriteLine("Digite o valor para depositar: ");
                    //cp.Depositar(decimal.Parse(Console.ReadLine()));

                    using (var db = new StoreContext())
                    {
                        WriteLine("Sua operação é DEPÓSITO");
                        WriteLine("Quanto deseja depositar: ");
                        var founded = db.Set<ContaPoupanca>().First(p => p.Id == cp.Id);
                        founded.Depositar(decimal.Parse(Console.ReadLine()));
                        db.SaveChanges();
                    }




                }
            }
        }


        [Key]
        public int Id { get; set; }

    }
}
