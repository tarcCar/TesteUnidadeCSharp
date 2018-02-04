using System;
using System.Collections.Generic;
namespace Caelum.Leilao
{

    public class Leilao
    {

        public string Descricao { get; set; }
        public IList<Lance> Lances { get; set; }

        public Leilao(string descricao)
        {
            this.Descricao = descricao;
            this.Lances = new List<Lance>();
        }

        public void Propoe(Lance lance)
        {
            if(PodeAdicionar(lance.Usuario))
            Lances.Add(lance);
        }

        private bool PodeAdicionar(Usuario usuario)
        {
            return Lances.Count == 0 ||
                (!UltimoUsuario(usuario) 
                && TotalDeLancesDo(usuario) < 5);
        }
        private bool UltimoUsuario(Usuario usuario)
        {
            var ultimoIndex = Lances.Count - 1;
            return usuario.Equals(Lances[ultimoIndex].Usuario);
        }
        private int TotalDeLancesDo(Usuario usuario)
        {
            int total = 0;

            foreach (var item in Lances)
            {
                if (item.Usuario.Equals(usuario)) total++;
            }
            return total;
        }

        public void DobraLance(Usuario usuario)
        {
            for (int i = Lances.Count -1 ; i >= 0; i--)
            {
               if (Lances[i].Usuario.Equals(usuario))
                {
                    Propoe(new Lance(usuario, Lances[i].Valor*2));
                    break;
                }
            }
        }
    }
}