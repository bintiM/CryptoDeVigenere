using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyrptoDeVignere
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Das ist ein Test";

            Console.WriteLine(encryptVignere(test, "ABC"));

            Console.ReadLine();

        }


        static string encryptVignere(string plainText, string key)
        {
            StringBuilder encryptedText = new StringBuilder();

            char[] messageChars = plainText.ToCharArray();
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            char[] keyArray = key.ToUpper().ToCharArray();

            int i = 0; // iterator für den key


            //Iteriere durch jedes Zeichen im Klartext
            foreach (char c in plainText.ToUpper())
            {
                //erstelle verschiebung aus dem key
                int shift = Array.IndexOf(alphabet, keyArray[i]);


                //Prüfe ob das Zeichen ein Buchstabe im Alphabet ist
                if (alphabet.Contains(c))
                {
                    //Wenn ja, berechne die neue Position und füge den neuen Buchstaben
                    //dem verschlüsselten Text hinzu
                    var newIndex = Array.IndexOf(alphabet, c) + shift; 

                    if (newIndex >= alphabet.Length)
                        newIndex = newIndex - alphabet.Length;

                    encryptedText.Append(alphabet[newIndex]);
                }
                else
                {
                    //Ansonsten Zeichen unverschlüsselt übernehmen
                    //Beispielsweise Leerzeichen, Satzzeichen unverschlüsselt in den verschlüsselten Text
                    encryptedText.Append(c);
                }

                i++;

                //reset key Iterator
                if (i == keyArray.Length)
                    i = 0;

            }

            return encryptedText.ToString();
        }
    }
}
