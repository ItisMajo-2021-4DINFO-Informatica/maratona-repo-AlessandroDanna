using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DannaProvaComune5App
{
    class Maratone
    {
        public List<Maratona> elencoMaratone;

        public Maratone()
        {
            elencoMaratone = new List<Maratona>();
        }

        public void Aggiungi(Maratona maratona)
        {
            elencoMaratone.Add(maratona);
        }

       

        public int CalcolaTempo(string tempo)
        {
            int minuti = 0;
            int ore = int.Parse(tempo.Substring(0, 2));
            int minutiParziali = int.Parse(tempo.Substring(3, 2));
            return minuti;
        }

        public void LeggiDati()
        {
            using (FileStream flussoDati = new FileStream("maratona.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader lettoreDati = new StreamReader(flussoDati))
                {
                    while (!lettoreDati.EndOfStream)
                    {
                        string linea = lettoreDati.ReadLine();
                        string[] campi = linea.Split('%');
               
                        Maratona maratona = new Maratona();
                        maratona.NomeAtleta = campi[0];
                        maratona.SocietaAppartenenza = campi[1];
                        maratona.Tempo = campi[2];
                        maratona.Citta = campi[3];

                        Aggiungi(maratona);

                    }
                }
            }
        }

        public string CercaTempo(string nome)
        {
            string tempo = nome + "--NON TROVATO--";

            foreach (var maratona in elencoMaratone)
            {
                if (maratona.NomeAtleta == nome)
                {
                    tempo = maratona.NomeAtleta;
                }
            }

            return tempo;
        }

        public string CercaAtleti(string citta)
        {
            string atleti = citta + "--NON TROVATO--";
            
            foreach (var maratona in elencoMaratone)
            {
                if(maratona.Citta == citta)
                {
                    atleti = maratona.NomeAtleta;
                }
            }
            return atleti;
        }
        /*
        public string ContaBrani(string album)
        {
            string numBraniStr = album + "--NON TROVATO--";
            int numBrani = 0;

            foreach (var brano in elencoBrani)
            {
                if (brano.TitoloAlbum == album)
                {
                    numBrani++;
                }
            }

            if (numBrani != 0)
            {
                numBraniStr = numBrani.ToString();
            }
            return numBraniStr;
        }

        public string CalcolaDurata()
        {
            string durata = "0";

            return durata.ToString();
        }*/
    }
}
