using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Atividade1
{
    public class Solicitacao
    {
       public void realizarSolicitacao(Banco banco)
        {
            WriteLine("Digite o numero da agência: ");
            int numAgencia = int.Parse(ReadLine());

            WriteLine("Digite o tipo da conta: 1 - Corrente/ 2 - Poupança");
            WriteLine("1 - Corrente:");
            WriteLine("2 - Poupança:");
            int tipo_conta = int.Parse(ReadLine());

            if (tipo_conta == 1)
            {
                WriteLine("Digite o numero da sua conta: ");
                int num_conta = int.Parse(ReadLine());
                Agencia agencia = banco.buscaAgencia(numAgencia);
                if(agencia == null)
                {
                    return;
                }
                ContaCorrente cc = agencia.getCCorrente(num_conta);
                if(cc == null)
                {
                    return;
                }

                WriteLine("Que operação deseja realizar? ");
                WriteLine("1 - Consultar Saldo:");
                WriteLine("2 - Sacar:");
                WriteLine("3 - Depositar:");
                int operacao = int.Parse(ReadLine());

                if (operacao == 1)
                {
                    WriteLine("Situação da conta:");
                    WriteLine("Conta = " + cc.Id);
                    WriteLine("Titular = " + cc.Titular);
                    WriteLine("Seu saldo é = R$ " + cc.Saldo);
                }
                else if (operacao == 2)
                {
                    WriteLine("Sua operação é SAQUE");
                    WriteLine("Quanto deseja sacar?");
                    cc.Sacar(decimal.Parse(ReadLine()));

                }
                else if (operacao == 3)
                {
                    WriteLine("Sua operação é DEPÓSITO");
                    WriteLine("Quanto deseja depositar: ");
                    cc.Depositar(decimal.Parse(ReadLine()));
                }
            }
            else if (tipo_conta == 2)
            {
                WriteLine("Digite o numero da conta: ");
                int num_conta = int.Parse(ReadLine());
                Agencia agencia = banco.buscaAgencia(numAgencia);
                if (agencia == null)
                {
                    return;
                }
                ContaPoupanca cp = agencia.getCPoupanca(num_conta);
                if (cp == null)
                {
                    return;
                }

                WriteLine("Que operação deseja realizar? ");
                WriteLine("1 - Consultar Saldo:");
                WriteLine("2 - Sacar:");
                WriteLine("3 - Depositar:");
                int operacao = int.Parse(ReadLine());

                if (operacao == 1)
                {
                    WriteLine("Situação da conta:");
                    WriteLine("Conta = " + cp.Id);
                    WriteLine("Titular = " + cp.Titular);
                    WriteLine("Seu saldo é = R$ " + cp.Saldo);
                }
                else if (operacao == 2)
                {
                    WriteLine("Sua operação é SAQUE");
                    WriteLine("Quanto deseja saque: ");
                    cp.Sacar(decimal.Parse(ReadLine()));
                }
                else if (operacao == 3)
                {
                    WriteLine("Sua operação é DEPÓSITO");
                    WriteLine("Quanto deseja depositar: ");
                    cp.Depositar(decimal.Parse(ReadLine()));
                }
            }
        }

    }
}
