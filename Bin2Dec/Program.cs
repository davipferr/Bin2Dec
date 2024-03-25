/*       
    Tier: 1-Beginner

    Binary is the number system all digital computers are based on. 
    Therefore it's important for developers to understand binary, or base 2, 
    mathematics. The purpose of Bin2Dec is to provide practice and understanding 
    of how binary calculations.

    Bin2Dec allows the user to enter strings of up to 8 binary digits, 
    0's and 1's, in any sequence and then displays its decimal equivalent.

    This challenge requires that the developer implementing it follow 
    these constraints:

    Arrays may not be used to contain the binary digits entered by the user
    Determining the decimal equivalent of a particular binary digit in the 
    sequence must be calculated using a single mathematical function, 
    for example the natural logarithm. It's up to you to figure out which 
    function to use.

    User Stories

    User can enter up to 8 binary digits in one input field
    User must be notified if anything other than a 0 or 1 was entered
    User views the results in a single output field containing the decimal (base 10) 
    equivalent of the binary number that was entered

    Bonus features

    User can enter a variable number of binary digits

*/

using System;

namespace Bin2Dec
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número binário: ");
            string bin = Console.ReadLine() ?? "";

            validateInput validateInput = new validateInput();

            validateInput.checkInputLength(bin);

            validateInput.checkInputData(bin);

            ConvertBinToDec convertBin = new ConvertBinToDec();

            int result = convertBin.ToDecimal(bin);

            Console.WriteLine($"Binário: {bin} -> Decimal: {result}");
        }
    }

    public class validateInput
    {
        public void checkInputLength(string input, int limitLength = 8)
        {
            if (input.Length > limitLength)
            {
                throw new Exception("Input tem mais de 8 caracteres");
            }
            else if (input.Length == 0)
            {
                throw new Exception("Input vázio");
            }
        }

        public void checkInputData(string input)
        {
            int len = input.Length;

            for(int i = 0; i < len; i++)
            {
                if(input[i] != '1' && input[i] != '0')
                {
                    Console.WriteLine($"{i}");
                    throw new Exception($"Valore do binário devem ser 1 ou 0 -> {input[i]}");
                }
            }
        }
    }

    public class ConvertBinToDec
    {
        public int ToDecimal(string bin)
        {   
            int decimalValue = 0;
            int binLength = bin.Length;

            for(int i = binLength - 1; i >= 0; i--)
            {
                // se bit igual 1 cálculo o valor dele e somo
                if (bin[i] == '1' ) {
                    decimalValue += CalcPow(2, binLength - 1 - i);
                }
            }

            return decimalValue;
        }

        private int CalcPow(int n, int expo)
        {
            // se exponente for negativo retorna erro
            if (expo < 0)
            {
                throw new Exception("exponente negativo");
            }

            // todo número elevado a 0 é igual a 1
            else if (expo == 0)
            {
                return n = 1;
            }

            int temp = n;

            // como começo a contar do zero preciso colocar exponente -1
            for(int i = 0; i < expo - 1 ; i++)
            {
                n *= temp;
            }

            return n;
        }
    }
}
