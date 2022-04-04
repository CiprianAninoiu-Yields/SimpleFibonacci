using SimpleFibonacci.Functions;
using System;

namespace SimpleFibonacci
{
    public class SimpleFibonacci
    {
        static void Main(string[] args)
        {

            var endSession = false;

            Console.WriteLine("This program retrieves the nth element in the Fibonacci sequence.");

            while (endSession == false) {

                SolveFibo();

                endSession = RetryDialogResponse();
            }

        }

        #region Solve Fibo
        private static void SolveFibo()
        {
            Console.WriteLine("Please enter a value for 'n'.");
            var input = Console.ReadLine();
            Console.WriteLine(' ');

            var validationResult = ValidationService.ValidateFiboIndex(input);
            if (validationResult.IsValid == false)
            {
                Console.WriteLine(validationResult.Message);
                return;
            }

            Console.WriteLine("The nth element in the Fibonacci sequence is:");
            Console.WriteLine(FindNthFibo(Convert.ToInt32(input)));
            Console.WriteLine(' ');
        }

        private static int FindNthFibo(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
            {
                return FindNthFibo(n - 1) + FindNthFibo(n - 2);
            }
        }
        #endregion

        #region Retry Dialog
        private static bool RetryDialogResponse()
        {
            var endSession = false;
            var response = ReadRetryDialogInput();
            Console.WriteLine(' ');

            var validationResult = ValidationService.ValidateRetryResponse(response);
            while (validationResult.IsValid == false)
            {
                Console.WriteLine(validationResult.Message);
                response = ReadRetryDialogInput();
                validationResult = ValidationService.ValidateRetryResponse(response);
            }

            switch (Convert.ToInt32(response))
            {
                case 1:
                    {
                        break;
                    }
                case 2:
                    {
                        endSession = true;
                        break;
                    }
            }
            return endSession;
        }
        private static string ReadRetryDialogInput()
        {
            Console.WriteLine("Would you like to try again?");
            Console.WriteLine(" 1: Yes");
            Console.WriteLine(" 2: No");
            return Console.ReadLine();
        }
        #endregion


    }

}
