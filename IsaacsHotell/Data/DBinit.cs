using IsaacsHotell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacsHotell.Data
{
    public class DBinit
    {
        public static void Initialiser(HotellDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Rum.Any())
            {
            //    var anställda = new List<Anställd> {
            //                        new Anställd{Förnamn="Anders", Efternamn="Anka", Roll="Admin"},
            //                        new Anställd{Förnamn="Bertil", Efternamn="Bengtsson", Roll="Receptionist"},
            //                        new Anställd{Förnamn="Ceasar", Efternamn="Cello", Roll="Städare"}
            //};
            //    context.Anställda.AddRange(anställda);
            //    context.SaveChanges();

            //    var rum = new List<Rum> {
            //                        new Rum{Namn="Jan",Antalsovplatser=2, Smutsigt=false, Bokningar=new List<Bokning>{
            //                                                                                                        } },
            //                        new Rum{Namn="Feb",Antalsovplatser=2, Smutsigt=false, Bokningar=new List<Bokning>() },
            //                        new Rum{Namn="Mar",Antalsovplatser=2, Smutsigt=false ,Bokningar=new List<Bokning>()},
            //                        new Rum{Namn="Apr",Antalsovplatser=2, Smutsigt=false, Bokningar=new List<Bokning>()},
            //                        new Rum{Namn="Maj",Antalsovplatser=2, Smutsigt=false, Bokningar=new List<Bokning>()},

            //                        new Rum{Namn="Juni",Antalsovplatser=1, Smutsigt=false, },
            //                        new Rum{Namn="Juli",Antalsovplatser=1, Smutsigt=false, },
            //                        new Rum{Namn="Aug", Antalsovplatser=1, Smutsigt=false, },
            //                        new Rum{Namn="Sep", Antalsovplatser=1, Smutsigt=false, },
            //                        new Rum{Namn="Aug", Antalsovplatser=1, Smutsigt=false, },

            //    //få in en bokning?
            //    };
            //    context.Rum.AddRange(rum);
            //    context.SaveChanges();

            //    var gäster = new List<Gäst> {

            //                        new Gäst{Förnamn="Alf", Efternamn="Aronsson"},
            //                        new Gäst{Förnamn="Bert", Efternamn="Båt"},
            //                        new Gäst{Förnamn="Alf", Efternamn="Aronsson"},
            //};
            //    context.Gäster.AddRange(gäster);
            //    context.SaveChanges();

            //    //context.Rum.Remove();


            //    //i gäster vill jag få en order. Och i rum vill jag få in en bokning

            }
            else
            {
                Console.WriteLine("Databas finns");
            }

        }
    }
}
