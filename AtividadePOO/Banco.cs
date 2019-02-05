using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Atividade1
{
    public class Banco
    {
         
        List<Agencia> agencias = new List<Agencia>();

        public void AdicionarAgencia(Agencia agencia)
        {
    
            agencias.Add(agencia);
            WriteLine("Agência " + agencia.IdAgencia + " criada com sucesso!");
            WriteLine("Numero de agencias: " + (agencias.Count-1) + "\n");
        }

        public int IdBanco { get; set; }

        public List<Agencia> Agencias { get; }

        public Agencia buscaAgencia(int num)
        {
            Agencia ag = null;
            foreach (var agencia in agencias)
            {
                if (agencia.IdAgencia == num)
                {
                    ag = agencia;
                    return ag;
                }
            }
            WriteLine("Dados errados ou Agencia existe, tente novamente.\n");
            return null;
            
            
        }

        public void listaIdAgencias()
        {
            foreach (var agencia in agencias)
            {
                WriteLine("Agencia = " + agencia.IdAgencia + "\n");
            }
        }

    }
}
