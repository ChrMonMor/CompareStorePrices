using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CompareStorePrices
{
    public static class TargetStoresEnum
    {
        public const string
            Netto = "https://www.netto.dk/netto-avis/", // this is an image
            Fakta = "https://fakta.coop.dk/tilbudsavis/", // this is html (Hurray!)
            Føtex = "https://avis.foetex.dk/naeste-uges-avis/", // this is an image
            Aldi = "https://tilbudsavis.aldi.dk/aktuel-avis/", // this is an image
            Rema1000 = "https://rema1000.dk/avis", // this is an image, also has no active paper
            Menu = "https://ugensavis.meny.dk/"; // this is a image
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            var contents = client.DownloadString(TargetStoresEnum.Fakta);

            OrderHtmlToArrays(contents);
            
            Console.ReadLine();
        }
        public static string OrderHtmlToArrays(string dlString)
        {
            dlString = dlString.Replace(">", ">\n");
            string[] lins = dlString.Split('\n');
            for (int i = 0; i < lins.Length; i++)
            {
                if (lins[i].Contains("<script"))
                {
                    for (int j = i; j < lins.Length; j++)
                    {
                        if (lins[j].Contains("</script>"))
                        {
                            lins[j] = "";
                            i = j;
                            break;
                        }
                        lins[j] = "";
                    }
                    lins[i] = "";
                }
                Console.WriteLine(lins[i]);
            }

            return dlString;
        }
        private
    }
}
