using System;
namespace Calculator 
{
	public class Solver : ISolve
	{
		string total = "";
        public string displayTotal = "";
        public string displayResult= "";

        public void Accumulate(string s)
		{
			if (total.Length == 0)
			{
				total = "!";
			}
			total += s;

            if (s == "n")
            {
                displayTotal += "-";
            }
            else
            {
                displayTotal += s;
            }
		}

        public void Clear()
		{
			total = "";
            displayTotal = "";
            displayResult = "";
        }

        public double Solve()
		{
			total += "!";

            // Checks for an 'x' (multiplication) in the total string, if found, I grab the number to its left and put it into string A, then I grab the number
            // on the right and pus it into string B. Then everything before the collected numbers is stored into strng front, and everything after,
            // stored into string back.
            for (int i = 0; i < total.Length; i++)
			{
				if (total[i] == 'x' || total[i] == 'X')
				{
					int numATail = (i - 1);
					int numBHead = (i + 1);
					int numAHead = 0;
					int numBTail = 0;

                    for (int j = numATail; j > 0; j--)
					{
						if ((j == '+') || (j == '-') || (j == 'x') || (j == '/') || (j == '%') || j== '!')
						{
							numAHead = j + 1;
						}
					}

                    for (int j = numBHead; j < total.Length; j++)
                    {
                        if ((j == '+') || (j == '-') || (j == 'x') || (j == '/') || (j == '%') || j == '!')
                        {
                            numBTail = j - 1;
                        }
                    }

					string A = total.Substring(numAHead, ((numATail - numAHead) + 1));
					string B = total.Substring(numBHead, ((numBTail - numBHead) + 1));
					string front = total.Substring(0, (numAHead));
                    string back = total.Substring(numBTail + 1, (total.Length - numBTail));
                    double numA = 0;
					double numB = 0;

                    // After sorting everything into new strings, I convert A and B to numbers, mutiply them, and convert the result into string product.
                    // Then I replace string total with (front + product + back)
                    if (A.Contains('n'))
					{
						A.Remove('n');
						numA = Convert.ToDouble(A);
						numA *= -1;
                    }
					else
					{
                        numA = Convert.ToDouble(A);
                    }

                    if (B.Contains('n'))
                    {
                        B.Remove('n');
                        numB = Convert.ToDouble(B);
                        numB *= -1;
                    }
                    else
                    {
                        numB = Convert.ToDouble(B);
                    }

                    string product = Convert.ToString((numA * numB));
					product.Replace('-', 'n');

					total = (front + product + back);
                }
            }

            // Checks for a '/' (division) in the total string, if found, I grab the number to its left and put it into string A, then I grab the number
            // on the right and pus it into string B. Then everything before the collected numbers is stored into strng front, and everything after,
            // stored into string back.
            for (int i = 0; i < total.Length; i++)
            {
                if (total[i] == '/')
                {
                    int numATail = (i - 1);
                    int numBHead = (i + 1);
                    int numAHead = 0;
                    int numBTail = 0;

                    for (int j = numATail; j > 0; j--)
                    {
                        if ((j == '+') || (j == '-') || (j == 'x') || (j == '/') || (j == '%') || j == '!')
                        {
                            numAHead = j + 1;
                        }
                    }

                    for (int j = numBHead; j < total.Length; j++)
                    {
                        if ((j == '+') || (j == '-') || (j == 'x') || (j == '/') || (j == '%') || j == '!')
                        {
                            numBTail = j - 1;
                        }
                    }

                    string A = total.Substring(numAHead, ((numATail - numAHead) + 1));
                    string B = total.Substring(numBHead, ((numBTail - numBHead) + 1));
                    string front = total.Substring(0, (numAHead));
                    string back = total.Substring(numBTail + 1, (total.Length - numBTail));
                    double numA = 0;
                    double numB = 0;

                    // After sorting everything into new strings, I convert A and B to numbers, divide them, and convert the result into string quotient.
                    // Then I replace string total with (front + quotient + back)
                    if (A.Contains('n'))
                    {
                        A.Remove('n');
                        numA = Convert.ToDouble(A);
                        numA *= -1;
                    }
                    else
                    {
                        numA = Convert.ToDouble(A);
                    }

                    if (B.Contains('n'))
                    {
                        B.Remove('n');
                        numB = Convert.ToDouble(B);
                        numB *= -1;
                    }
                    else
                    {
                        numB = Convert.ToDouble(B);
                    }

                    string quotient = Convert.ToString((numA / numB));
                    quotient.Replace('-', 'n');

                    total = (front + quotient + back);
                }
            }

            // Checks for a '%' (modular division) in the total string, if found, I grab the number to its left and put it into string A, then I grab the number
            // on the right and pus it into string B. Then everything before the collected numbers is stored into string front, and everything after,
            // stored into string back.
            for (int i = 0; i < total.Length; i++)
            {
                if (total[i] == '%')
                {
                    int numATail = (i - 1);
                    int numBHead = (i + 1);
                    int numAHead = 0;
                    int numBTail = 0;

                    for (int j = numATail; j > 0; j--)
                    {
                        if ((j == '+') || (j == '-') || (j == 'x') || (j == '/') || (j == '%') || j == '!')
                        {
                            numAHead = j + 1;
                        }
                    }

                    for (int j = numBHead; j < total.Length; j++)
                    {
                        if ((j == '+') || (j == '-') || (j == 'x') || (j == '/') || (j == '%') || j == '!')
                        {
                            numBTail = j - 1;
                        }
                    }

                    string A = total.Substring(numAHead, ((numATail - numAHead) + 1));
                    string B = total.Substring(numBHead, ((numBTail - numBHead) + 1));
                    string front = total.Substring(0, (numAHead));
                    string back = total.Substring(numBTail + 1, (total.Length - numBTail));
                    double numA = 0;
                    double numB = 0;

                    // After sorting everything into new strings, I convert A and B to numbers, divide them, and convert the remainder into string remainder.
                    // Then I replace string total with (front + quotient + back)
                    if (A.Contains('n'))
                    {
                        A.Remove('n');
                        numA = Convert.ToDouble(A);
                        numA *= -1;
                    }
                    else
                    {
                        numA = Convert.ToDouble(A);
                    }

                    if (B.Contains('n'))
                    {
                        B.Remove('n');
                        numB = Convert.ToDouble(B);
                        numB *= -1;
                    }
                    else
                    {
                        numB = Convert.ToDouble(B);
                    }

                    string remainder = Convert.ToString((numA % numB));
                    remainder.Replace('-', 'n');

                    total = (front + remainder + back);
                }
            }

            // Checks for a '+' (addition) in the total string, if found, I grab the number to its left and put it into string A, then I grab the number
            // on the right and pus it into string B. Then everything before the collected numbers is stored into strng front, and everything after,
            // stored into string back.
            for (int i = 0; i < total.Length; i++)
            {
                if (total[i] == '+')
                {
                    int numATail = (i - 1);
                    int numBHead = (i + 1);
                    int numAHead = 0;
                    int numBTail = 0;

                    for (int j = numATail; j > 0; j--)
                    {
                        if ((j == '+') || (j == '-') || (j == 'x') || (j == '/') || (j == '%') || j == '!')
                        {
                            numAHead = j + 1;
                        }
                    }

                    for (int j = numBHead; j < total.Length; j++)
                    {
                        if ((j == '+') || (j == '-') || (j == 'x') || (j == '/') || (j == '%') || j == '!')
                        {
                            numBTail = j - 1;
                        }
                    }

                    string A = total.Substring(numAHead, ((numATail - numAHead) + 1));
                    string B = total.Substring(numBHead, ((numBTail - numBHead) + 1));
                    string front = total.Substring(0, (numAHead));
                    string back = total.Substring(numBTail + 1, (total.Length - numBTail));
                    double numA = 0;
                    double numB = 0;

                    // After sorting everything into new strings, I convert A and B to numbers, add them, and convert the result into string sum.
                    // Then I replace string total with (front + quotient + back)
                    if (A.Contains('n'))
                    {
                        A.Remove('n');
                        numA = Convert.ToDouble(A);
                        numA *= -1;
                    }
                    else
                    {
                        numA = Convert.ToDouble(A);
                    }

                    if (B.Contains('n'))
                    {
                        B.Remove('n');
                        numB = Convert.ToDouble(B);
                        numB *= -1;
                    }
                    else
                    {
                        numB = Convert.ToDouble(B);
                    }

                    string sum = Convert.ToString((numA + numB));
                    sum.Replace('-', 'n');

                    total = (front + sum + back);
                }
            }

            // Checks for a '-' (subtraction) in the total string, if found, I grab the number to its left and put it into string A, then I grab the number
            // on the right and pus it into string B. Then everything before the collected numbers is stored into strng front, and everything after,
            // stored into string back.
            for (int i = 0; i < total.Length; i++)
            {
                if (total[i] == '-')
                {
                    int numATail = (i - 1);
                    int numBHead = (i + 1);
                    int numAHead = 0;
                    int numBTail = 0;

                    for (int j = numATail; j > 0; j--)
                    {
                        if ((j == '+') || (j == '-') || (j == 'x') || (j == '/') || (j == '%') || j == '!')
                        {
                            numAHead = j + 1;
                        }
                    }

                    for (int j = numBHead; j < total.Length; j++)
                    {
                        if ((j == '+') || (j == '-') || (j == 'x') || (j == '/') || (j == '%') || j == '!')
                        {
                            numBTail = j - 1;
                        }
                    }

                    string A = total.Substring(numAHead, ((numATail - numAHead) + 1));
                    string B = total.Substring(numBHead, ((numBTail - numBHead) + 1));
                    string front = total.Substring(0, (numAHead));
                    string back = total.Substring(numBTail + 1, (total.Length - numBTail));
                    double numA = 0;
                    double numB = 0;

                    // After sorting everything into new strings, I convert A and B to numbers, subtract them, and convert the result into string product.
                    // Then I replace string total with (front + difference + back)
                    if (A.Contains('n'))
                    {
                        A.Remove('n');
                        numA = Convert.ToDouble(A);
                        numA *= -1;
                    }
                    else
                    {
                        numA = Convert.ToDouble(A);
                    }

                    if (B.Contains('n'))
                    {
                        B.Remove('n');
                        numB = Convert.ToDouble(B);
                        numB *= -1;
                    }
                    else
                    {
                        numB = Convert.ToDouble(B);
                    }

                    string difference = Convert.ToString((numA - numB));
                    difference.Replace('-', 'n');

                    total = (front + difference + back);
                }
            }

            total.Remove('!');
            total.Replace('-', 'n');
            displayResult = total;
            return Convert.ToDouble(total);
        }
        public Solver()
		{
			
		}
	}
}

