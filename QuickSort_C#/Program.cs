using System;
using System.Collections.Generic;

namespace QuickSort_InCSharp
{
    internal class Program
    {
        public static Random _Random;
        public static int _Option, _ContainExchange, _ContainPartition, _ContainRecursive;
        public static int[] _ArrayOne = { 4, 8, -3, 10, -7, -9, 2, -5, 6, 1 };
        public static int[] _Arraytwo = { 4, 8, -3, 10, -7, -9, 2, -5, 6, 1 };
        public static int[] _ArraytThree = { 4, 8, -3, 10, -7, -9, 2, -5, 6, 1 };

        static void Main(string[] args)
        {
            string[] Information = { "[1]Pivote Inicio", "[2]Pivote Mediano", "[3]Pivote Final", "[4]Pivote Random" };
            _Random = new Random();
            do
            {
                _ContainExchange = 1;
                _Option = 0;
                Console.Clear();
                Console.WriteLine("Quicksort\n");
                foreach (var i in Information)
                {
                    Console.WriteLine(i);
                }
                Console.Write("Elige uno: ");
                try { _Option = int.Parse(Console.ReadLine()); } catch { }
                int[] NewVector = GenerarVector(-10, 10);
                switch (_Option)
                {
                    case 1:
                        Console.Clear();
                        _ContainExchange = 1;
                        Console.WriteLine("Pivote inicial");
                        Print(ref _ArrayOne);
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        _ContainExchange = 1;
                        Console.WriteLine("Pivote central");
                        Print(ref _Arraytwo);
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        _ContainExchange = 1;
                        Console.WriteLine("Pivote final");
                        Print(ref _ArraytThree);
                        Console.ReadKey();
                        break;
                    case 4:
                        _Option = _Random.Next(10000);
                        Console.Clear();
                        _ContainExchange = 1;
                        Console.WriteLine("Pivote aleatorio");
                        Print(ref NewVector);
                        Console.ReadKey();
                        break;
                }
            } while (_Option != 5);
        }

        public static void Swap(ref int I, ref int J)
        {
            int Temporary = I;
            I = J;
            J = Temporary;
        }

        public static int Partition(ref int[] array, int FirstIndex, int LastIndex)
        {
            _ContainPartition++;
            int IndexPivot;
            switch (_Option)
            {
                case 1:
                    IndexPivot = FirstIndex;
                    break;

                case 2:
                    IndexPivot = (int)Math.Floor((double)(LastIndex + FirstIndex) / 2);
                    break;

                case 3:
                    IndexPivot = LastIndex;
                    break;

                default:
                    IndexPivot = _Random.Next(FirstIndex, LastIndex);
                    break;
            }
            Console.Write("Partición: " + _ContainPartition + " Intercambio: " + _ContainExchange + "\n");

            Swap(ref array[FirstIndex], ref array[IndexPivot]);
            PrintSwap(ref array, FirstIndex, LastIndex);

            _ContainExchange++;

            int Pivot = array[FirstIndex];
            int Left = FirstIndex + 1;
            int Right = LastIndex;

            while (true)
            {
                while (Left <= Right && array[Left] <= Pivot)
                {
                    Left += 1;
                }

                while (Left <= Right && array[Right] >= Pivot)
                {
                    Right -= 1;
                }

                if (Left <= Right)
                {
                    Console.Write("Partición: " + _ContainPartition + " Intercambio: " + _ContainExchange + "\n");

                    Swap(ref array[Left], ref array[Right]);

                    PrintSwap(ref array, FirstIndex, LastIndex);

                    _ContainExchange++;
                    Left += 1;
                    Right -= 1;
                }
                else
                {
                    break;
                }
            }
            Console.Write("Partición: " + _ContainPartition + " Intercambio: " + _ContainExchange + "\n");

            Swap(ref array[FirstIndex], ref array[Right]);
            PrintSwap(ref array, FirstIndex, LastIndex); ;
            _ContainExchange++;

            return Right;
        }

        public static void QuickSort(ref int[] array, int FirstIndex, int LastIndex)
        {
            if (FirstIndex < LastIndex)
            {
                _ContainRecursive++;

                int pivot = Partition(ref array, FirstIndex, LastIndex);

                QuickSort(ref array, FirstIndex, pivot - 1);
                QuickSort(ref array, pivot + 1, LastIndex);
            }
        }

        public static void Print(ref int[] arr)
        {
            QuickSort(ref arr, 0, arr.Length - 1);

            Console.Write("\nResult:");
            foreach (int i in arr)
            {
                Console.Write(" " + i);
            }

            _ContainExchange = 0;
            _ContainPartition = 0;
            _ContainRecursive = 0;
        }

        public static void PrintSwap(ref int[] arr, int izq, int der)
        {
            Console.Write("[");
            for (int i = izq; i <= der; i++)
            {
                Console.Write(arr[i]);
                if (i < der)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]\n\n");
        }

        public static int[] GenerarVector(int Minon = 0, int Lenght = 10)
        {
            List<int> _List = new List<int>();

            for (int i = Minon; i < Lenght; i++)
            {
                int NewValor = _Random.Next(Minon, Lenght + 1);
                if (_List.Contains(NewValor))
                {
                    i--;
                    continue;
                }
                _List.Add(NewValor);
            }
            return _List.ToArray();
        }
    }
}