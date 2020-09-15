using Xunit;
using System.Collections.Generic;

namespace entra21_tests
{
    public class ExercisesTest
    {
        [Fact]
        public void should_return_an_array_from_1_to_10()
        {
            // BDD - Behavior Driven Design
            // Dado, Quando, Deve

            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1A,
            // então a aplicação deverá retornar todos os número de 1 a 10

            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            var result = exercises.Exercise1A();

            // Deve / Asserções
            var expectedOutput = new int[10]
            {
                1,2,3,4,5,6,7,8,9,10
            };

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], result[i]);
            }
        }

        [Fact]
        public void should_return_an_array_from_10_to_1()
        {
            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1b,
            // então a aplicação deverá retornar todos os números de 1 a 10 de forma decrescente

            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int[] returnedValues = exercises.Exercise1B();

            // Deve / Asserções
            var expectedOutput = new int[10]
            {
                10,9,8,7,6,5,4,3,2,1
            };

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], returnedValues[i]);
            }
        }
        
        [Fact]
        public void should_return_an_array_from_1_to_10_but_only_even()
        {
            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 1c,
            // então a aplicação deverá retornar os números de 1 a 10, mas somente os pares

            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int[] returnedValues = exercises.Exercise1C();

            // Deve / Asserções
            var expectedOutput = new int[5]
            {
                2,4,6,8,10
            };

            Assert.Equal(5, returnedValues.Length);

            for (int i = 0; i < expectedOutput.Length; i++)
            {
                Assert.Equal(expectedOutput[i], returnedValues[i]);
            }
        }

        [Fact]
        public void should_return_5050()
        {
            // Dado que a aplicação está preparada. Quando o usuário chamar o exercício 2,
            // então a aplicação deverá retornar a soma dos números inteiros de 1 a 100

            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int resultSum = exercises.Exercise2();

            // Deve / Asserções
            Assert.Equal(5050, resultSum);
            
        }

        [Fact]
        public void should_return_all_odd_numbers_smaller_than_200()
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int[] result = exercises.Exercise3();

            // Deve / Asserções
            var expectedOutput = new int[]
            {
                1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51,53,55,
                57,59,61,63,65,67,69,71,73,75,77,79,81,83,85,87,89,91,93,95,97,99,101,103,105,
                107,109,111,113,115,117,119,121,123,125,127,129,131,133,135,137,139,141,143,145,
                147,149,151,153,155,157,159,161,163,165,167,169,171,173,175,177,179,181,183,185,
                187,189,191,193,195,197,199
            };

            Assert.Equal(expectedOutput, result);
        }
        
        [Fact]
        public void should_return_return_6_when_passed_4_and_6_and_8()
        {
            // Dado / Setup
            var exercises = new Exercises();
            var myList = new List<int>(){4, 6, 8};

            // Quando / Ação
            double result = exercises.Exercise4(myList);

            // Deve / Asserções
            Assert.Equal(6, result);
        
        }
         
         [Fact]
         public void should_return_7_when_passed_5_and_9()
        {
            // Dado / Setup
            var exercises = new Exercises();

            // criando uma lista com o número 5 na primeira posição e o número 9 na segunda
            var myList = new List<int>(){5, 9};

            // Quando / Ação
            double result = exercises.Exercise4(myList);

            // Deve / Asserções
            Assert.Equal(7, result);
        }

        [Theory]
        [InlineData(new int[5]{0, 12, 15, 17, 2}, 0)]
        [InlineData(new int[5]{40, 52, 38, 39, 37}, 0)]
        [InlineData(new int[5]{17, 12, 15, 22, 11}, 20)]
        [InlineData(new int[5]{18, 36, 14, 41, 29}, 40)]
        [InlineData(new int[5]{18, 35, 14, 37, 25}, 60)]
        [InlineData(new int[5]{15, 34, 19, 31, 26}, 80)]
        [InlineData(new int[5]{30, 23, 35, 33, 28}, 100)]
        public void should_return_percentage_of_women_between_18_and_35_when_passed_5_ages(int[] ages, int expected)
        {
            // Dado / Setup
            var exercises = new Exercises();

            // Quando / Ação
            int result = exercises.Exercise5(ages);
            
            // Deve / Asserções
            Assert.Equal(expected, result);
        }
    
        [Theory]
        [InlineData(3, 5, 5.5, 1501.5)]
        [InlineData(12, 3, 7.5, 4927.5)]
        [InlineData(25, 7, 6.5, 20754.5)]
        public void should_return_value_spent_in_cigarettes_over_years(int yearsSmoking, int cigarettes, double cigarettesPrice, double expected)
        {

            var exercises = new Exercises();

            double result = exercises.Exercise7(yearsSmoking, cigarettes, cigarettesPrice);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(30, 3, true)]
        [InlineData(50, 5, true)]
        [InlineData(5, 50, false)]
        [InlineData(0, 0, false)]
        public void should_return_if_first_number_is_multiple_of_the_second(int number1, int number2, bool expected){

            var exercises = new Exercises();

            var result = exercises.Exercise8(number1, number2);

            Assert.Equal(expected, result);
        }
    
        [Theory]
        [InlineData(309, 201, 45, true)]
        [InlineData(507, 195, 75.5, true)]
        [InlineData(57, 205, 95.2, false)]
        [InlineData(-107, 25, -80, false)]
        [InlineData(-20, -58, -8, true)]
        public void should_return_if_first_number_is_bigger_than_the_last_two(double number1, double number2, double number3, bool expected)
        {
            var exercises = new Exercises();

            var result = exercises.Exercise9(number1, number2, number3);

            Assert.Equal(expected, result);
        }
    }
}