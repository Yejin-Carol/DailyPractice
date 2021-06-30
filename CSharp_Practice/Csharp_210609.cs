using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Review_0609
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q5. Sum of Arrays
            int[,] arr1 =
            {
                {1, 2, 3}, {4, 5, 6}, {7, 8, 9}
            };

            int[,] arr2 =
            {
                {10, 20, 30}, {40, 50, 60}, {70, 80, 90}
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //Console.Write(arr1[i, j] + " ");
                    //Console.Write(arr2[i, j] + " ");
                    Console.Write(arr1[i, j] + arr2[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("===================================");
            //Q6. Multiplication Table
            int[][] arrInt3 = new int[9][];//set row
            for (int i = 0; i < 8; i++)
            {
                arrInt3[i] = new int[9];//set column
                for (int j = 0; j < 8; j++)
                {
                    arrInt3[i][j] = (j+2)*(i+1);
                    Console.Write("{0}x{1}={2}\t", (j+2),(i+1), arrInt3[i][j]);
                }
                Console.WriteLine();
            }

            //Q7 File Control Program
            Console.WriteLine("----------------------");
            Console.WriteLine("File control program v1.1");
            Console.WriteLine("----------------------");
            Console.WriteLine("1. create name and save to file");
            Console.WriteLine("2. read name from file");
            Console.WriteLine("3. exit");

            char[] name1 = new char[5]
            {
                '김', '박', '이', '최', '장'
            };
            char[] name2 = new char[5]
            {
                '바', '사', '아', '자', '차'
            };
            char[] name3 = new char[5]
            {
                '가', '나', '다', '라', '마'
            };

            Random random = new Random();





        }
    }
}

