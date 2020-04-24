using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace utca_Roland
{
    class Program
    {
        struct Adat
        {
            public int oldal;
            public int hossza;
            public string kerites;
            public int hazszam;
        }
        static void Main(string[] args)
        {
            Adat[] adatok = new Adat[1000];
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Desktop\2018-oktober\kerites.txt");
            int n = 0;
            int paros = 0;
            int paratlan = -1;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] darabol = sor.Split();
                adatok[n].oldal = int.Parse(darabol[0]);
                adatok[n].hossza = int.Parse(darabol[1]);
                adatok[n].kerites = darabol[2];

                if (adatok[n].oldal == 0)
                {
                    adatok[n].hazszam = paros += 2;
                }
                else
                {
                    adatok[n].hazszam = paratlan += 2;
                }
                n++;
            }
            //2.feladat 
            //Írja a képernyőre, hogy hány telket adtak el az utcában! 
            Console.WriteLine("2.Feladat\nAz eladott telkek száma: {0}", n);

            //3.feladat
            if (adatok[n - 1].oldal == 0)
            {
                Console.WriteLine("A páros oldalon adták el az utolsó telket.");
                Console.WriteLine("Az utolsó telek házszáma: {0}", adatok[n - 1].hazszam);

            }
            if (adatok[n - 1].oldal == 1)
            {
                Console.WriteLine("A páratlan oldalon adták el az utolsó telket.");
                Console.WriteLine("Az utolsó telek házszáma: {0}", adatok[n - 1].hazszam);

            }

            //4.feladat 
            string szin1 = null, szin2 = null;
            int szamlalo = 0;
            int k = 0;
            for (int i = 0; n > i; i++)
            {
                if (adatok[i].oldal == 1)
                {
                    szamlalo++;
                    if (adatok[i].kerites != ":" && adatok[i].kerites != "#" && szamlalo == 1)
                    {
                        szin1 = adatok[i].kerites;

                    }
                    if (adatok[i].kerites != ":" && adatok[i].kerites != "#" && szamlalo == 2)
                    {
                        szin2 = adatok[i].kerites;
                        if (szin1 == szin2)
                        {
                            Console.WriteLine("A szomszédossal egyezik a kerítés színe: {0}", adatok[k].hazszam);
                            //break;
                        }
                        szin1 = szin2;
                    }
                    szamlalo = 1;
                    k = i;
                }
            }
            Console.ReadKey();//
        }
    }
}
