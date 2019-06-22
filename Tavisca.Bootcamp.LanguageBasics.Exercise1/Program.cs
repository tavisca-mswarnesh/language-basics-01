using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            //throw new NotImplementedException();
            int a = 0, b = 0, c = 0, ans = -1, actualValue, i = 0;
            string actVal, GivenValue = "";
            int valid = 1;
            for (; equation[i] != '*'; i++)
            {

                if (equation[i] == '?')
                {
                    valid = 0;
                    a = -1;
                }

                if (valid == 1)
                {
                    a *= 10;
                    a += Int32.Parse(equation[i].ToString());
                }
            }
            if (valid == 0)
                GivenValue = equation.Substring(0, i);
            valid = 1;
            i++;
            for (; equation[i] != '='; i++)
            {

                if (equation[i] == '?')
                {
                    valid = 0;
                    b = -1;
                }

                if (valid == 1)
                {
                    b *= 10;
                    b += Int32.Parse(equation[i].ToString());
                }
            }
            if (valid == 0)
                GivenValue = equation.Substring(equation.IndexOf('*') + 1, equation.IndexOf('=') - equation.IndexOf('*') - 1);
            valid = 1;
            i++;
            for (; i < equation.Length; i++)
            {

                if (equation[i] == '?')
                {
                    valid = 0;
                    c = -1;
                }

                if (valid == 1)
                {
                    c *= 10;
                    c += Int32.Parse(equation[i].ToString());
                }
            }
            if (valid == 0)
                GivenValue = equation.Substring(equation.IndexOf('=') + 1);
            valid = 1;
            if (a == -1)
            {
                actualValue = c / b;
                if (c % b != 0)
                    return ans;
            }
            else if (b == -1)
            {
                actualValue = c / a;
                if (c % a != 0)
                    return ans;
            }
            else
            {
                actualValue = a * b;
            }
            actVal = actualValue.ToString();
            if (actVal.Length != GivenValue.Length)
                return ans;
            for (int j = 0; j < actVal.Length; j++)
            {
                if (j == 0 && GivenValue[j] == '?' && actVal[j] != '0')
                    ans = Int32.Parse(actVal[j].ToString());
                else if (GivenValue[j] == '?')
                    ans = Int32.Parse(actVal[j].ToString());
            }
            return ans;
        }
    }
}
