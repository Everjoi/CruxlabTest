using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;



namespace CruxlabTest 
{
    internal class Program
    {

        static void Main()
        {


            string filePath = "C:\\Users\\kosho\\source\\repos\\CruxlabTest\\CruxlabTest\\FIle\\RequirementsWithPassword.txt"; // file path

            // using Regular Expression
            int validPasswordsCount = CountValidPasswords(filePath);
            Console.WriteLine("Count of valid passwords: " + validPasswordsCount);


            // using some algoritm
            int validPasswordsCount1 = CountValidPasswords1(filePath);
            Console.WriteLine("Count of valid passwords: " + validPasswordsCount1);


        }

        private static  int CountValidPasswords(string filePath)
        {
            int count = 0;

            var lines = File.ReadAllLines(filePath).ToList<string>();
            foreach(string line in lines)
            {
                if(IsValidPassword(line))
                    count++;                
            }

            return count;
        }

        private static bool IsValidPassword(string line)
        {

            Regex regex = new Regex(@"(\w) (\d+)-(\d+): (\w+)");

            Match match = regex.Match(line);
            if(match.Success)
            {
                char requiredChar = match.Groups[1].Value[0];      
                int minCount = Convert.ToInt32(match.Groups[2].Value);  
                int maxCount = Convert.ToInt32(match.Groups[3].Value);  
                string password = match.Groups[4].Value;            

                int charCount = 0;
                for(int i = 0;i < password.Length;i++)
                {
                    if(password[i] == requiredChar)
                        charCount++;
                }


                if(charCount >= minCount && charCount <= maxCount)
                { 
                    return true;
                }
                
            }

            return false;
        }


        private static int CountValidPasswords1(string filePath)
        {
            int count = 0;

            var lines = File.ReadAllLines(filePath).ToList<string>();

            foreach(var line in lines)
            {
                if(IsValidPassword1(line))
                    count++;
            }

            return count;
        }

        private static bool IsValidPassword1(string line)
        {
            string trimLine = line.Replace(" ","");
            string password = trimLine.Substring(5);
            char requiredChar = trimLine[0];
            int minCount = Convert.ToInt32(trimLine[1].ToString());
            int maxCount = Convert.ToInt32(trimLine[3].ToString());
            int charCount = 0;

            for(int i = 0;i < password.Length;i++)
            {
                if(password[i] == requiredChar)
                    charCount++;

            }


            if(charCount >= minCount && charCount <= maxCount)
            {
                return true;
            }

            return false;
        }
       

 

    }
}