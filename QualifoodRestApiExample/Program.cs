using System;
using System.Threading.Tasks;

namespace QualifoodRestApiExample
{
    static class Program
    {
        static async Task Main(string[] args)
        {
            var client = new QualifoodHttpClient();
            await client.LogIn("QualifoodBenutzername", "QualifoodPasswort");

            var dokumentenbereiche = await client.GetDokumentenbereiche();

            foreach (var bereich in dokumentenbereiche)
            {
                Console.WriteLine($"{bereich.Titel}: {bereich.Beschreibung}");
            }

            Console.Read();
        }
    }
}
