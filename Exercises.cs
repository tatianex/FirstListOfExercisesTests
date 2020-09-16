using System;
using System.Collections.Generic;

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
    }
}