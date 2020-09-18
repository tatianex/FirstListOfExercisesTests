using System;
using System.Collections.Generic;
using System.Linq;

namespace entra21_tests
{
    class Exercises
    {
        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1A,
        // então a aplicação deverá retornar todos os números de 1 a 10 de forma crescente
        public int[] Exercise1A()
        {
            var numbers = new int[10];

            for (int counter = 1; counter < 11; counter++)
            {
				numbers[counter - 1] = counter;
            }

            return numbers;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1b,
        // então a aplicação deverá retornar todos os números de 1 a 10 de forma decrescente
        public int[] Exercise1B()
        {
            int[] numbers = new int[10];
            
            for (int counter = 10; counter > 0; counter--)
            {
                numbers[numbers.Length - counter] = counter;
            }

            return numbers;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1c,
        // então a aplicação deverá retornar os números de 1 a 10, mas somente os pares
        public int[] Exercise1C()
        {
            var numbers = new int[5];

            for (int counter = 2; counter < 11; counter+=2)
            {
                var index = (counter / 2) - 1;
				numbers[index] = counter;
            }

            return numbers;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 2,
        // a aplicação deverá retornar a soma dos números de 1 a 100.

        public int Exercise2()
        {
            var sum = 0;

            for (int x = 1; x < 101; x++) {
                sum += x;
            }

            return sum;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 3,
        // a aplicação deverá retornar todos os números ímpares menores de 200.

        public int[] Exercise3()
        {
            var result = new int[1];  // inicializa array com uma posição
            var counter = 0;

            for (int i = 1; i < 200; i += 2) {
                result[counter] = i;

                counter++;

                if (i != 199)
                {
                    // redimensiona o array
                    Array.Resize(ref result, counter+1);
                }
            }

            return result;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 4,
        // então a aplicação deverá retornar a média dos números passados
        // e parar quando for digitado zero
         public double Exercise4(List<int> ages)
        {
            double sum = 0.0;

            var answers = ages.Count;

            foreach (var item in ages)
            {
				sum += item;
            }

            var average = (sum / answers);

            return average;
        }

        // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 5,
        // então a aplicação deverá retornar a % de mulheres que estão entre 18 e 35 anos
        public int Exercise5(int[] ages)
        {
            int groupOfWomemBetween18And35 = 0;
            int percentageOfWomemBetween18And35 = 0;

            foreach (int age in ages) {
                if ((age > 17) && (age < 36)) {
                    groupOfWomemBetween18And35++;
                }
            }

            percentageOfWomemBetween18And35 = ((groupOfWomemBetween18And35 * 100) / 5);
            return percentageOfWomemBetween18And35;
        }

        public double Exercise7(int yearsSmoking, int cigarettes, double cigarettesPrice)
        {
            int totalCigarettesInBox = 20;
            var totalDaysSmoking = yearsSmoking * 365;
            var totalCigarrettesSmoked = cigarettes * totalDaysSmoking;
            double totalBoxesSmoked = totalCigarrettesSmoked / totalCigarettesInBox;
            double totalValueSpent = totalBoxesSmoked * cigarettesPrice;

            return totalValueSpent;
        }
    
        public bool Exercise8(int number1, int number2)
        {
            try
            {
                if (number1 % number2 == 0) return true;
                else return false;
            }
            catch
            {
                return false;
            }           
        }

        public bool Exercise9(double number1, double number2, double number3)
        {
           if (number1 > (number2 + number3)) return true;
           else return false;
        }

        public int Exercise10(int number1, int number2)
        {
            const int areEqual = 0;
            const int aBigger = 1;
            const int bBigger = 2;

            if (number1 == number2) return areEqual;
            else if (number1 > number2) return aBigger;
            else return bBigger;
        }
    
        public double Exercise11(int number1, int number2)
        {
            double result = 0.0d;

            try
            {
                if (number2 != 0)
                {
                    return result = (Convert.ToDouble(number1) / Convert.ToDouble(number2));
                }
                else return 0; 
            }
            catch
            {
                return 0;
            }
        }
    
        public (int, int) Exercise12(int[] numbers)
        {
            (int even, int odd) result = (0, 0);

            foreach (int number in numbers)
            {
                if (number % 2 == 0) result.even += number;
                else result.odd += number;
            }

            return result;
        }
    
        public int Exercise13(int[] numbers)
        {
            int biggestNumber = int.MinValue;

            foreach (int number in numbers)
            {
                if (number > biggestNumber) biggestNumber = number;
            }

            return biggestNumber;
        }
    
        public double[] Exercise14(double[] numbers)
        {
            Array.Sort(numbers);

            return numbers;
        }
    
        public (int, int) Exercise15(int[] numbers)
        {
            // CÓDIGO ORIGINAL USANDO LISTA APENAS PARA PRATICAR
            /*
            var multipleOf3 = new List<int>();
            var multipleOf5 = new List<int>();

             foreach (int number in numbers)
            {
                if (number % 3 == 0) multipleOf3.Add(number);
                if (number % 5 == 0) multipleOf5.Add(number);
            }
            
            var result = (multipleOf3.Count, multipleOf5.Count);
            */

            var totalMultipleOf3 = 0;
            var totalMultipleOf5 = 0;

            foreach (int number in numbers)
            {
                if (number % 3 == 0) totalMultipleOf3++;
                if (number % 5 == 0) totalMultipleOf5++;
            }
            
            var result = (totalMultipleOf3, totalMultipleOf5);

            return result;
        }
    
        public double Exercise16(double salary)
        {
            double salaryWithDiscount1 = (salary - ((salary * 20) / 100));
            double salaryWithDiscount2 = (salary - ((salary * 25) / 100));
            double salaryWithDiscount3 = (salary - ((salary * 30) / 100));

            if (salary <= 600) return Math.Round(salary, 2);
            else if (salary <= 1200) return Math.Round(salaryWithDiscount1, 2);
            else if (salary <= 2000) return Math.Round(salaryWithDiscount2, 2);
            else return Math.Round(salaryWithDiscount3, 2);
        }
    
        public int[] Exercise17(int number)
        {
            var multiplicationTable = new int[10];

            for (int i = 1; i < 11; i++)
            {
                multiplicationTable[i - 1] = number * i;
            }

            return multiplicationTable;
        }
    
        public IEnumerable<int> Exercise17B(int number)
		{
            // Imprimir a tabuada de qualquer número fornecido pelo usuário.
            // DADO que a aplicação esteja pronta, QUANDO o usuário informar um número
            // DEVE retornar a tabuada de 1 a 10

            var multiplicationTable = new List<int>(){
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            return multiplicationTable.Select(item => item * number);
		}
        public double Exercise18(int apples)
        {
            double applesPrice = 0.0d;

            if (apples < 12)
            {
                applesPrice = apples * 1.30d;
                return Math.Round(applesPrice, 2);
            }
            else
            {
                applesPrice = apples * 1.0d;
                return Math.Round(applesPrice, 2);
            }
        }
    }
}