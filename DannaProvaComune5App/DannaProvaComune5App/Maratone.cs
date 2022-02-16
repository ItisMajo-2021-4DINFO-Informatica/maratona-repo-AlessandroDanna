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
                        maratona.Ore = campi[2];
                        maratona.Minuti = campi[3];
                        maratona.Citta = campi[4];

                        Aggiungi(maratona);

                    }
                }
            }
        }

        /*public string CercaArtista(string titolo)
        {
            string artista = titolo + "--NON TROVATO--";

            foreach (var brano in elencoBrani)
            {
                if (brano.TitoloBrano == titolo)
                {
                    artista = brano.NomeArtista;
                }
            }

            return artista;
        }

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
