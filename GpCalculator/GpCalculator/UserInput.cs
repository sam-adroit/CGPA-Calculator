using System.Text.RegularExpressions;

namespace GpCalculator
{
    public class UserInput 
    {
        public static Dictionary<string, int[]> getInput()
        {
            Dictionary<string, int[]> studentA = new Dictionary<string, int[]>();
            bool input = true;
            string courseCode = "";
            int[] scoreAndUnit = new int[2];
            Console.WriteLine("Welcome to the GP Calculator App. \n To calculate your GP Input the following according to the prompt: \n 1. Your course code e.g MTH101, CHM102, PHY101 etc. \n 2. Score (0-99) \n 3. grade \n \n \n");
            while (input)
            {
                Regex rgLetter = new Regex("^[a-zA-Z]{3}$");
                Regex rgNo = new Regex("^[0-9]{3}$");
                Console.WriteLine("Type the course code e.g MTH101, CHM102, PHY101");
                courseCode = Console.ReadLine();

                if (courseCode.Length != 6 || courseCode.Contains(" ") || courseCode == "")
                {
                    Console.WriteLine("Course code cannot be empty, should not contain space or less than 6 character like CHM101");
                    continue;
                }

                if (!rgLetter.IsMatch(courseCode.Substring(0, 3)) || !rgNo.IsMatch(courseCode.Substring(3)))
                {
                    Console.WriteLine("The first 3 character of course code should be a letter and last three character a number e.g MTH101.");
                    continue;
                }

                courseCode = courseCode.Substring(0, 3).ToUpper() + courseCode.Substring(3);


                if (studentA.ContainsKey(courseCode))
                {
                    Console.WriteLine("You have already filled this course code");
                    continue;
                }


                bool arrInputNotFilled = true;

                while (arrInputNotFilled)
                {
                    Console.WriteLine("Please put your score in " + courseCode + "   PS: 0-99");
                    bool passScore = true;
                    while (passScore)
                    {
                        bool correctScore = int.TryParse(Console.ReadLine(), out int score);
                        if (correctScore && score < 100 && score > 0)
                        {
                            scoreAndUnit[0] = score;
                            passScore = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input, use number between 0-99");
                        }
                    }


                    Console.WriteLine("Please put the Course unit for " + courseCode + "    PS: 0-9");
                    bool passCode = true;
                    while (passCode)
                    {
                        bool correctUnit = int.TryParse(Console.ReadLine(), out int unit);
                        if (correctUnit && unit >= 0 && unit <= 9)
                        {
                            scoreAndUnit[1] = unit;
                            passCode = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input, use number between 0-9");
                        }
                    }

                    studentA[courseCode] = scoreAndUnit;
                    scoreAndUnit = new int[] { 0, 0 };
                    arrInputNotFilled = false;
                }
                arrInputNotFilled = true;

                Console.WriteLine("Do you want to add more Courses? \n Y - add more course \n N - Calculate GP");
                bool cont = true;

                while (cont)
                {
                    string addMore = Console.ReadLine();

                    if (addMore.ToUpper() == "Y")
                    {
                        cont = false;
                    }
                    else if (addMore.ToUpper() == "N")
                    {
                        input = false;
                        cont = false;
                    }
                    else
                    {
                        Console.WriteLine("Please type Y or N to add more course or Calculate GP");
                    }
                }

                
            }
            return studentA;
        }
    }
}

