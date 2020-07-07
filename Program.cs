using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace testing
{
    class Program
    { 
        static void Main(string[] args)
        {

            string password;

            // Change these to make the minimum number of items required larger or smaller.
            int min_special_count = 2;
            int min_letter_count = 6;
            int min_number_count = 2;
            int min_length = 6;

            // Don't change these.
            int letter_count = 0;
            int special_count = 0;
            int number_count = 0;

            // All the arrays that hold the checked data.
            char[] password_to_char;
            char[] numbers = { '0','1','2','3','4','5','6','7','8','9' };
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            char[] special_chars = { '#','@','%','!','&','$' };

            Console.WriteLine(@"
Your password must contain...
    * {0} numbers
    * {1} letters
    * {2} special chars, I.E. ""$,%,!""
    * Minimum length {3} characters long",
    min_number_count,
    min_letter_count,
    min_special_count,
    min_length);
            
            // Grabs password and converts it to readable values.
            Console.Write("Value: ");
            password = Console.ReadLine();

            password_to_char = password.ToCharArray();


            // Loops thru the password array, and checks each of the requirements and increases counters as necessary.
            for(int i = 0; i < password_to_char.Length; i++)
            {
                for(int j = 0; j < letters.Length; j++)
                {
                    if(password_to_char[i] == letters[j])
                    {
                        letter_count++;
                    }
                }

                for (int j = 0; j < special_chars.Length; j++)
                {
                    if (password_to_char[i] == special_chars[j])
                    {
                        special_count++;
                    }
                }

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (password_to_char[i] == numbers[j])
                    {
                        number_count++;
                    }
                }
            }

            //Console.WriteLine("Special Chars count: {0}", special_char_count);
            //Console.WriteLine("Alphabet Count: {0}", alphabet_count);

            // Checks the requirements and notifies you if you meet them.
            if(special_count >= min_special_count && letter_count >= min_letter_count && number_count >= min_number_count && password_to_char.Length >= min_length)
            {
                Console.WriteLine("Your password is great!");
                Console.WriteLine("Press any key to exit program...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Weak password, try again.");
                Console.WriteLine(@"
Your password contained:
    *{0} out of {1} numbers required.
    *{2} out of {3} letters required.
    *{4} out of {5} special chars required.
    *Length was {6} out of {7} chars required.",
    number_count, min_number_count,
    letter_count, min_letter_count,
    special_count, min_special_count,
    password_to_char.Length, min_length);

                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();

                Console.Clear();
                GC.Collect();
                Main(args);
            }


        }
    }
}
