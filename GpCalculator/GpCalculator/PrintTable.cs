namespace GpCalculator
{
    public class PrintTable
    {
        Dictionary<string, int[]> convertedGrades = new Dictionary<string, int[]>();
        public PrintTable(Dictionary<string, int[]> convertedGrades)
        {
            this.convertedGrades = convertedGrades;
        }
        public void Table ()
        {
            Dictionary<int, string> gradeScale = new Dictionary<int, string> { { 5, "A/Excellent" }, { 4,  "B/Very Good" }, { 3, "C/Good"}, { 2, "D/Fair"}, { 1, "E/Pass" }, { 0, "F/Fail"} };

            Console.WriteLine("|---------------|-------------|-------|------------|------------|-------------|");
            Console.WriteLine("| COURSE & CODE | COURSE UNIT | GRADE | GRADE-UNIT | WEIGHT Pt. |   REMARK    |");
            Console.WriteLine("|---------------|-------------|-------|------------|------------|-------------|");
            foreach (var courseCode in convertedGrades.Keys)
            {
                if (courseCode != "ccu" && courseCode != "cgu" && courseCode != "cwpt")
                {
                    Console.WriteLine("|    "+courseCode+"     |      "+convertedGrades[courseCode][1]+"      |   "+gradeScale[convertedGrades[courseCode][0]].Substring(0, 1)+"   |       "+convertedGrades[courseCode][0]+"    |"+"     "+convertedGrades[courseCode][2].ToString().PadRight(6, ' ') + " | "+" "+gradeScale[convertedGrades[courseCode][0]].Substring(2).PadRight(11,' ') + "|");
                }
            }
            Console.WriteLine("|--------------------------------------------------|------------|-------------|");
            Console.WriteLine();
            Console.WriteLine("Total Course Unit Registered is " + convertedGrades["ccu"][0]);
            Console.WriteLine();
            Console.WriteLine("Total Course Unit Passed is " + convertedGrades["cgu"][0]);
            Console.WriteLine();
            Console.WriteLine("Total Weight Point is " + convertedGrades["cwpt"][0]);
            Console.WriteLine();
            if(convertedGrades["ccu"][0] != 0)
            {
                Console.WriteLine("Your GPA is = " + Math.Round((decimal)convertedGrades["cwpt"][0] / convertedGrades["ccu"][0], 2) + " to 2 decimal places.");
            }
            else Console.WriteLine("GPA cannot be determined for 0 unit courses");

        }
    }
}

