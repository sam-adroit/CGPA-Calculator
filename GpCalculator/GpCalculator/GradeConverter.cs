namespace GpCalculator
{
    public class GradeConverter
    {
        Dictionary<string, int[]> userGrades = new Dictionary<string, int[]>();
        public GradeConverter(Dictionary<string, int[]> userGrades)
        {
            this.userGrades = userGrades;
        }

        public Dictionary<string, int[]> unitConverter()
        {
            Dictionary<string , int[]> convertedUnit = new Dictionary<string , int[]>();
            int sumOfGu = 0;
            int sumOfWpt = 0;
            int sumOfCu = 0;

            //0 = score
            //1 = cu
            
            foreach(var key in userGrades.Keys)
            {
                convertedUnit[key] = new int[3];
                convertedUnit[key][1] = userGrades[key][1];
                if(userGrades[key][0] >= 70)
                {
                    convertedUnit[key][0] = 5;
                    convertedUnit[key][2] = 5 * convertedUnit[key][1];
                } else if(userGrades[key][0] >= 60 && userGrades[key][0] < 70)
                {
                    convertedUnit[key][0] = 4;
                    convertedUnit[key][2] = 4 * convertedUnit[key][1];
                }
                else if (userGrades[key][0] >= 50 && userGrades[key][0] < 60)
                {
                    convertedUnit[key][0] = 3;
                    convertedUnit[key][2] = 3 * convertedUnit[key][1];
                }
                else if (userGrades[key][0] >= 45 && userGrades[key][0] < 50)
                {
                    convertedUnit[key][0] = 2;
                    convertedUnit[key][2] = 2 * convertedUnit[key][1];
                }
                else if (userGrades[key][0] >= 40 && userGrades[key][0] < 45)
                {
                    convertedUnit[key][0] = 1;
                    convertedUnit[key][2] = 1 * convertedUnit[key][1];
                }else
                {
                    convertedUnit[key][0] = 0;
                    convertedUnit[key][2] = 0;
                }

                sumOfCu += convertedUnit[key][1];
                sumOfGu += convertedUnit[key][0] != 0 ? convertedUnit[key][1]:0;
                sumOfWpt += convertedUnit[key][2];
            }
            convertedUnit["ccu"] = new int[] { sumOfCu};
            convertedUnit["cgu"] = new int[]{sumOfGu};
            convertedUnit["cwpt"] = new int[] { sumOfWpt };
            return convertedUnit;
        }
    }
}

