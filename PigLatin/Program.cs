using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigLatin
{
    class Program
    {
        static List<char> Vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'y' };

        static void Main(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("------    PigLatin Application   --------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");

            place:

            Console.Write("Enter a word to be converted to Pig Latin: ");
            string input = Console.ReadLine();


            int VowelIndex = getVowelPosition(input);

            string PigLatin = "";

            //first case is special
            if ((Vowels.Contains(input[0]))&(input[0]!='y'))
            {

                PigLatin = getPigLatin(input, VowelIndex, true);

            }
            else
            {
                PigLatin = getPigLatin(input, VowelIndex, false);
            }

            Console.WriteLine(PigLatin);

            goto place;

        }

        private static string getPigLatin(string input,int VowelIndex, bool StartsWithVowel)
        {

            if (VowelIndex > -1)
            {
                if (StartsWithVowel)
                {
                    return input.Substring(VowelIndex, input.Length - (VowelIndex)) + input.Substring(0, VowelIndex) + "way";
                }
                else
                {
                    return input.Substring(VowelIndex, input.Length - (VowelIndex)) + input.Substring(0, VowelIndex) + "ay";
                }
            }
            else
            {
                return "This does not contain a vowel.";
            }
        }

        private static int getVowelPosition(string input)
        {
            int VowelIndex = -1;

            bool SpecialYstart = false;

            if (input[0] == 'y')
            {
                SpecialYstart=true;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (Vowels.Contains(input[i]))
                {
                    if ((SpecialYstart) & (i == 0))
                    {

                    }
                    else
                    {
                        VowelIndex = i;
                        break;
                    }
                }
            }

            return VowelIndex;   
        }
    }
}
