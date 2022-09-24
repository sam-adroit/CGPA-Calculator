using System;
using System.Reflection.Metadata.Ecma335;

namespace GpCalculator
{
    class Program
    {
        public static void Main(string[] args)
        { 
            var studentInput = UserInput.getInput();
            GradeConverter studentGrade = new GradeConverter(studentInput);
            var convertedGrade = studentGrade.unitConverter();
            PrintTable resultDisplay = new PrintTable(convertedGrade);
            resultDisplay.Table();

        }
    }
}

