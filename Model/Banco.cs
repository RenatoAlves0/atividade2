using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Atividade1
{
    public class Banco
    {
         
        List<Agencia> agencias = new List<Agencia>();

        public void AdicionarAgencia(Agencia a)
        {
            agencias.Add(a);
            Console.WriteLine("Agência " + a.IdAgencia + " criada com sucesso!");
            Console.WriteLine("Numero de agencias: " + agencias.Count);
        }

        [Key]
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
            Console.WriteLine("A agência digitada não exite, por favor, verifique se o ID está correto:");
            return null;
            
            
        }

        public void listaIdAgencias()
        {
            foreach (var agencia in agencias)
            {
                Console.WriteLine("Agencia = " + agencia.IdAgencia);
            }
        }

    }
}
