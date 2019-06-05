using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {

            // Test comment

            /*
            Create an application to solve the following problem. Please find if each pair of query has the same meaning.


            SYNONYMS = [ ('rate', 'ratings', 'rates'), 
                         ('approval', 'popularity'), ] 

            QUERIES = [ ('obama approval rate', 'obama popularity ratings'), 
                        ('obama popularity rates', 'obama approval ratings'),
                        ('obama approval rating’, 'obama TV ratings')
                        ('obama approval rate', 'popularity ratings obama’)]

            Output = [true, true, false, true]

            Note: the last sentence in query data set is bonus point.
            */

            List<List<string>> synnonyms = new List<List<string>>();
            synnonyms.Add(new List<string>() { "rate", "ratings", "rates" });
            synnonyms.Add(new List<string>() { "approval", "popularity" });

            List<List<string>> queries = new List<List<string>>();
            queries.Add(new List<string>() { "obama approval rate", "obama popularity ratings" });
            queries.Add(new List<string>() { "obama popularity rates", "obama approval ratings" });
            queries.Add( new List<string>() { "obama approval rating", "obama TV ratings" });
            queries.Add( new List<string>() { "obama approval rate", "popularity ratings obama’" });

            foreach (var sentences in queries)
            {
                string fSentence = sentences[0];
                string sSentence = sentences[1];

                int firstSynonymeFirstSentenceFounded = GetSynonymePosition(synnonyms[0], fSentence);
                int firstSynonymeSeccondSentenceFounded = GetSynonymePosition(synnonyms[0], sSentence);
                int seccondSynonymeFirstSentenceFounded = GetSynonymePosition(synnonyms[1], fSentence);
                int seccondSynonymeSeccondSentenceFounded = GetSynonymePosition(synnonyms[1], sSentence);
              
                if (firstSynonymeFirstSentenceFounded == firstSynonymeSeccondSentenceFounded && seccondSynonymeFirstSentenceFounded == seccondSynonymeSeccondSentenceFounded)
                {
                    // Correct
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }

            Console.ReadKey();
        }

        private static int GetSynonymePosition(List<string> synonyme, string sentence)
        {
            foreach (var word in synonyme)
            {
                int counter = 0;
                foreach (var splWord in sentence.Split(' '))
                {
                    if (!string.IsNullOrEmpty(splWord))
                    {
                        // Take position only not empty words
                        if (word == splWord)
                        {
                            // Add to collection.
                            return counter;
                        }

                    }
                }
            }
            return -1;
        }
    }
}
