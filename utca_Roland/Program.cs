﻿using System;
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

            //5.feladat

            Console.Write("Kérem adjon meg egy házszámot: ");
            int bekert_hazszam = int.Parse(Console.ReadLine());
            string hazszin = null;
            for(int i = 0;i< n;i++ )
            {
                if (bekert_hazszam == adatok[i].hazszam)
                {
                    if(adatok[i].kerites != ":" && adatok[i].kerites != "#")
                    {
                        Console.WriteLine("A kerités szine: {0}",adatok[i].kerites);
                        hazszin = adatok[i].kerites;
                    }
                    else
                    {
                        Console.WriteLine("A kerités állapota: {0}",adatok[i].kerites);
                        hazszin = adatok[i].kerites;
                    }
                }

            }

            //5.b feladat
            szin1 = null;
            szin2 = null; 
            for (int i = 'A';i <= 'Z';i++)
            {              
                for (int j = 0;j<n;j++)
                {
                    if (bekert_hazszam - 2 == adatok[j].hazszam)
                    {
                        szin1 = adatok[j].kerites;
                    }
                    if (bekert_hazszam + 2 == adatok[j].hazszam)
                    {
                        szin2 = adatok[j].kerites;
                    }
                }
                if (Convert.ToChar(szin1) != Convert.ToChar(i) && Convert.ToChar(szin2) != Convert.ToChar(i) && Convert.ToChar(hazszin) != Convert.ToChar(i))
                {
                    Console.WriteLine("Egy lehetséges festési szín: {0}", Convert.ToChar(i));
                    break;
                }
            }

            //6.feladat
            StreamWriter ir = new StreamWriter(@"C:\Users\Rendszergazda\Desktop\2018-oktober\utcakep.txt");
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].oldal == 1)
                {
                    for (int j = 0;j<adatok[i].hossza;j++)
                    {
                        ir.Write(adatok[i].kerites);
                    }
                }
            }
            ir.WriteLine();
            for (int i = 0; i < n; i++)
            {
                if (adatok[i].oldal == 1)
                {
                    int hsz_kar = adatok[i].hazszam.ToString().Length;
                    for (int j = 0; j < adatok[i].hossza - hsz_kar + 1; j++)
                    {
                        if (j == 0)
                        {
                            ir.Write(adatok[i].hazszam);
                        }
                        else
                        {
                            ir.Write(" ");
                        }
                    }
                }
            }
            ir.Close();
            Console.ReadKey();
        }
    }
}
