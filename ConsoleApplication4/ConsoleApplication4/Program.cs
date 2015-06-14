using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        public static void Main()
        {
            Mass mass = new Mass();
            Console.WriteLine("Введите искомое число от 0 до 100");

            mass.IntCheacking();
            if (mass.Checking(mass.X))
            {
                mass.BinarySeach(mass.X);
                Console.WriteLine("Искомое число в массиве находится под номером {0}", mass.XNumber + 1);
                Console.WriteLine("Потребовалось {0} повторений", mass.repetitions);
            }
            else Console.WriteLine("Число находится за предеами массива");
            Console.ReadLine();
            Main();
        }
    }

    class Mass
    {
        public int repetitions = 0;
        public int[] MyArray = new int[101];
        public int XNumber, X;
        private int Border, MaxBorder, MinBorder;
        public Mass()
        {
            Filling();
            MinBorder = 0;
            MaxBorder = MyArray.Length;
            if (AnEven(Border)) Border = MaxBorder / 2;
            else Border = (MaxBorder + 1) / 2;
        }
        private void Filling()
        {
            for (int i = 0; i < MyArray.Length; i++) MyArray[i] = i;
        }

        public bool Checking(int x) //метод проверяет не выходит ли искомый элемент за пределы массива
        {
            if ((x < MyArray[0]) || (x > MyArray[MyArray.Length-1])) return false;
            else return true;
        }
        public void BinarySeach(int x) //медод бинарного поиска
        {

            while (true)
            {
                repetitions++;
                if (x == MyArray[Border]) 
                {
                    XNumber = Border;
                    break;
                }
                    
                else
                {

                    if (x < MyArray[Border])
                    {
                            MaxBorder = Border-1;
                            Border = (MaxBorder + MinBorder) / 2; 
                    }


                    if (x > MyArray[Border])
                    {
                            MinBorder = Border+1;
                            Border = (MaxBorder + MinBorder) / 2;  
                    }
                }
            }
        }

        public void IntCheacking()
        {
            if (!Int32.TryParse(Console.ReadLine(), out X))
            {
                Console.WriteLine("Необходимо ввести число");
                Program.Main();
            }
        }

        private bool AnEven(int number)
        {
            if (number % 2 == 0) return true;
            else return false;
        }
    }
}
