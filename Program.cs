using System;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp2
{
    internal class Program
    {
        static string otstup = "   ", chooseStrelka = " > ";

        static void ColorWrite(string s, ConsoleColor color = ConsoleColor.White, bool writeLine = true)
        {
            Console.ForegroundColor = color;
            if (writeLine)
                Console.WriteLine(s);
            else
                Console.Write(s);
            Console.ResetColor();
        }

        static void Waiting()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n"+otstup+"НАЖМИТЕ ЛЮБУЮ КЛАВИШУ ДЛЯ ВОЗВРАЩЕНИЯ В МЕНЮ . . .");
            Console.ResetColor();
            Console.ReadKey();
        }

        static string VvodSOtstupom(ConsoleColor color = ConsoleColor.White)
        {
            ColorWrite("\n" + otstup + chooseStrelka, color, false);
            Console.ForegroundColor = color;
            string s;
            Console.CursorVisible = true;
            s = Console.ReadLine();
            Console.CursorVisible = false;
            Console.ResetColor();
            return s;
        }

        static int ShowMenu(string[] menuStrings, string zaglavie = "")
        {
            int choosedButton = 0;
            Console.Clear();
            while (true)
            {
                Console.WriteLine();
                if (zaglavie != "")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(otstup + zaglavie);
                    Console.WriteLine();
                    Console.ResetColor();
                }

                for (int i = 0; i < menuStrings.Length; i++)
                {
                    if (choosedButton == i && i == menuStrings.Length - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(otstup + chooseStrelka);
                    }
                    else if (choosedButton == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(otstup+chooseStrelka);
                    }
                    else
                    {
                        Console.Write(otstup+otstup);
                    }
                    Console.WriteLine(menuStrings[i]);
                    Console.WriteLine();
                    Console.ResetColor();
                }

                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo knopka;
                        knopka = Console.ReadKey(true);
                        if (knopka.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            return choosedButton;
                        }
                        else if (knopka.Key == ConsoleKey.UpArrow)
                        {
                            choosedButton--;
                            choosedButton = choosedButton < 0 ? menuStrings.Length - 1 : choosedButton;
                            choosedButton %= menuStrings.Length;
                        }
                        else if (knopka.Key == ConsoleKey.DownArrow)
                        {
                            choosedButton++;
                            choosedButton %= menuStrings.Length;
                        }
                        /*Console.Clear(); */Console.SetCursorPosition(0, 0); break;
                    }
                }
                
            }

        }

        static void GenocidChyotnih(ref List<int> array)
        {
            List<int> a = new List<int>(0);
            for(int i = 0; i < array.Count; i++)
            {
                if (array[i] %2 != 0)
                {
                    a.Add(array[i]);
                }
            }
            array = a;
        }

        static void DeleteZeroString(ref int[][] array)
        {
            List<int[]> a = new List<int[]>(0);
            bool flag = false;
            for (int i=0;i<array.Length; i++)
            {
                bool localFlag = false;
                for (int j=0;j<array[i].Length; j++)
                {
                    if (array[i][j] == 0)
                    {
                        localFlag = true;
                    }
                }
                if (!localFlag || flag)
                    a.Add(array[i]);
                if (localFlag && !flag)
                    flag = true;
            }
            array = a.ToArray();
        }

        static List<int> GenerateArray(int a,int b, int length)
        {
            List<int> list = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                list.Add(rnd.Next(Math.Min(a,b),Math.Max(a,b)));
            }
            return list;
        }

        static int[,] GenerateArray(int a, int b, int x, int y)
        {
            Random rnd = new Random();
            int[,] array = new int[x,y];
            for (int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    array[i,j] = rnd.Next(Math.Min(a, b), Math.Max(a, b));
                }
            }
            return array;
        }

        static int[][] GenerateArray(int a, int b, int[] param)
        {
            Random rnd = new Random();
            int[][] array = new int[param.Length][];
            for (int i = 0; i < param.Length; i++)
            {
                array[i] = new int[param[i]];
                for (int j = 0; j < param[i]; j++)
                {
                    array[i][j] = rnd.Next(Math.Min(a, b), Math.Max(a, b));
                }
            }
            return array;
        }

        static void CreateArray(ref int[,] array, int[,] supArray)
        {
            int[,] resArray = new int[array.GetLength(0)+supArray.GetLength(0),array.GetLength(1)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j=0;j< array.GetLength(1); j++)
                {
                    resArray[i,j] = array[i,j];
                }
            }
            for (int i = array.GetLength(0), i1=0; i1 < supArray.GetLength(0); i++,i1++)
            {
                for (int j = 0; j < supArray.GetLength(1); j++)
                {
                    resArray[i, j] = supArray[i1, j];
                }
            }
            array =resArray;
        }


        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int[,] matrix = new int[0, 0];
            int[][] arrays = new int[0][];

            string[] menu = new string[4];
            menu[0] = "ОДНОМЕРНЫЙ МАССИВ";
            menu[1] = "ДВУМЕРНЫЙ МАССИВ";
            menu[2] = "РВАНЫЙ МАССИВ";
            menu[3] = "ВЫЙТИ ИЗ ПРОГРАММЫ";

            string menuZ = "ВЫБЕРИТЕ ТИП МАССИВА: ";

            string[] dMenu = new string[5];
            
            dMenu[3] = "УДАЛИТЬ ЧЁТНЫЕ";

            string dMenuZ = "МЕНЮ ОДНОМЕРНОГО МАССИВА:";

            string[] mMenu = new string[5];
            mMenu[3] = "ДОБАВИТЬ СТРОКИ В МАССИВ";

            string mMenuZ = "МЕНЮ ДВУМЕРНОГО МАССИВА:";

            string[] sMenu = new string[5];
            sMenu[3] = "УДАЛИТЬ ПЕРВУЮ СТРОКУ, В КОТОРОЙ ВСТРЕЧАЕТСЯ 0";

            string sMenuZ = "МЕНЮ РВАНОГО МАССИВА:";

            dMenu[0] = mMenu[0] = sMenu[0] = "СГЕНЕРИРОВАТЬ МАССИВ";
            dMenu[1] = mMenu[1] = sMenu[1] = "СОЗДАТЬ МАССИВ ВРУЧНУЮ";
            dMenu[2] = mMenu[2] = sMenu[2] = "ПЕЧАТЬ МАССИВА";
            dMenu[4] = mMenu[4] = sMenu[4] = "ВЫЙТИ В МЕНЮ ВЫБОРА МАССИВА";

            Console.Title = "ARRAY-102";
            Console.CursorVisible = false;

            while (true)
            {
                int type = ShowMenu(menu, menuZ);

                if (type == 0)
                {
                    while (true)
                    {
                        int move = ShowMenu(dMenu, dMenuZ);
                        if (move == 0)
                        {
                            list = new List<int>(0);
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup +"ВВЕДИТЕ ГРАНИЦЫ ДОПУСТИМЫХ ЗНАЧЕНИЙ ЭЛЕМЕНТОВ МАССИВА:"); Console.ResetColor();

                            string s;
                            int a,b,len;

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out a))
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА РАЦИОНАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out b))
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА РАЦИОНАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ РАЗМЕР МАССИВА:"); Console.ResetColor();

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out len) || len < 1)
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            list = GenerateArray(a, b, len);
                        }
                        else if (move == 1)
                        {
                            list = new List<int>(0);
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ РАЗМЕР БУДУЩЕГО МАССИВА"); Console.ResetColor();
                            string s;
                            int len;

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out len) || len < 1)
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ ЭЛЕМЕНТЫ БУДУЩЕГО МАССИВА"); Console.ResetColor();

                            for (int i=0; i<len; i++)
                            {
                                int a;
                                s = VvodSOtstupom(ConsoleColor.Green);
                                while (!Int32.TryParse(s, out a))
                                {
                                    ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА РАЦИОНАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                    s = VvodSOtstupom(ConsoleColor.Green);
                                }
                                list.Add(a);
                            }
                        }
                        else if (move == 2)
                        {
                            ColorWrite("\n" + otstup + "ВАШ ОДНОМЕРНЫЙ ДИНАМИЧЕСКИЙ МАССИВ:", ConsoleColor.Yellow);
                            int[] spaces = new int[list.Count];
                            for (int i = 0; i < list.Count; i++)
                            {
                                spaces[i] = Math.Max((i + 1).ToString().Length + 2, list[i].ToString().Length);
                            }
                            Console.Write("\n" + otstup);
                            for (int i = 0; i < list.Count; i++)
                            {
                                ColorWrite("№ " + (i + 1) + (new string(' ', spaces[i] - (i + 1).ToString().Length - 2)) + " ", ConsoleColor.Green, false);
                            }
                            Console.Write("\n\n" + otstup);
                            for (int i = 0; i < list.Count; i++)
                            {
                                ColorWrite(list[i] + (new string(' ', spaces[i] - list[i].ToString().Length)) + " ", ConsoleColor.White, false);
                            }
                            Console.WriteLine();
                        }
                        else if (move == 3)
                        {
                            GenocidChyotnih(ref list);
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВСЕ ЧЁТНЫЕ ЭЛЕМЕНТЫ (ЕСЛИ ОНИ БЫЛИ) УДАЛЕНЫ"); Console.ResetColor();
                        }
                        else
                        {
                            break;
                        }
                        Waiting();
                        Console.Clear();
                    }
                }
                else if (type == 1)
                {
                    while (true)
                    {
                        int move = ShowMenu(mMenu, mMenuZ);
                        if (move == 0)
                        {
                            matrix = new int[0,0];

                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ ГРАНИЦЫ ДОПУСТИМЫХ ЗНАЧЕНИЙ ЭЛЕМЕНТОВ МАССИВА:"); Console.ResetColor();

                            string s;
                            int a, b, x,y;

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out a))
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА РАЦИОНАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out b))
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА РАЦИОНАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ РАЗМЕРЫ МАССИВА (СТРОКИ-СТОЛБЦЫ):"); Console.ResetColor();

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out x) || x < 1)
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out y) || y < 1)
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            matrix = GenerateArray(a, b, x,y);
                        }
                        else if (move == 1)
                        {
                            matrix = new int[0, 0];
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ РАЗМЕРЫ МАССИВА (СТРОКИ-СТОЛБЦЫ):"); Console.ResetColor();
                            string s;
                            int x,y;

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out x) || x < 1)
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out y) || y < 1)
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            matrix = new int[x, y];

                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ ЭЛЕМЕНТЫ БУДУЩЕГО МАССИВА"); Console.ResetColor();

                            for (int i = 0; i < x; i++)
                            {
                                Console.WriteLine("\n" + "СТРОКА " + (i + 1) + ", (" + y + " ЭЛЕМЕНТОВ) :");
                                for (int j = 0; j < y; j++)
                                {
                                    int a;
                                    s = VvodSOtstupom(ConsoleColor.Green);
                                    while (!Int32.TryParse(s, out a))
                                    {
                                        ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА РАЦИОНАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                        s = VvodSOtstupom(ConsoleColor.Green);
                                    }
                                    matrix[i, j] = a;
                                }
                            }
                            
                        }
                        else if (move == 2)
                        {
                            ColorWrite("\n" + otstup + "ВАШ ДВУМЕРНЫЙ МАССИВ:", ConsoleColor.Yellow);
                            int[] spaces = new int[matrix.GetLength(1)];
                            for (int i = 0; i < matrix.GetLength(1); i++)
                            {
                                int maxSpace = 0;
                                for (int j=0;j< matrix.GetLength(0); j++)
                                {
                                    if (maxSpace< Math.Max((i + 1).ToString().Length + 2, matrix[j,i].ToString().Length))
                                    {
                                        maxSpace = Math.Max((i + 1).ToString().Length + 2, matrix[j, i].ToString().Length);
                                    }
                                    spaces[i] = maxSpace;
                                }
                                
                            }
                            Console.Write("\n" + new string(' ', (matrix.GetLength(0) + 1).ToString().Length+2) + ' ');
                            for (int i = 0; i < matrix.GetLength(1); i++)
                            {
                                ColorWrite("№ " + (i + 1) + (new string(' ', spaces[i] - (i + 1).ToString().Length - 2)) + " ", ConsoleColor.Green, false);
                            }
                            
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                ColorWrite("\n" +"№ "+ (i+1)+ new string(' ', (matrix.GetLength(0) + 1).ToString().Length+2 - (i+1).ToString().Length) + ' ',ConsoleColor.Green,false);
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    ColorWrite(matrix[i,j] + (new string(' ', spaces[i] - matrix[i, j].ToString().Length)) + " ", ConsoleColor.White, false);
                                }
                                Console.WriteLine();
                            }
                                
                            Console.WriteLine();

                        }
                        else if (move == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ КОЛИЧЕСТВО ДОБАВЛЯЕМЫХ СТРОК:"); Console.ResetColor();
                            string s;
                            int x, y=matrix.GetLength(1);

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out x) || x < 1)
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            int[,] sMatrix = new int[x,y];

                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ ЭЛЕМЕНТЫ ДОБАВЛЯЕМЫХ СТРОК: "); Console.ResetColor();

                            for (int i = 0; i < x; i++)
                            {
                                Console.WriteLine("\n" + "СТРОКА " + (i + 1) + ", ("+y+" ЭЛЕМЕНТОВ) :");
                                for (int j = 0; j < y; j++)
                                {
                                    int a;
                                    s = VvodSOtstupom(ConsoleColor.Green);
                                    while (!Int32.TryParse(s, out a))
                                    {
                                        ColorWrite("\n"+otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА РАЦИОНАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                        s = VvodSOtstupom(ConsoleColor.Green);
                                    }
                                    sMatrix[i, j] = a;
                                }
                            }
                            CreateArray(ref matrix,sMatrix);
                        }
                        else
                        {
                            break;
                        }
                        Waiting();
                        Console.Clear();
                    }
                }
                else if (type == 2)
                {
                    while (true)
                    {
                        int move = ShowMenu(sMenu, sMenuZ);
                        if (move == 0)
                        {
                            arrays = new int[0][];
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ ГРАНИЦЫ ДОПУСТИМЫХ ЗНАЧЕНИЙ ЭЛЕМЕНТОВ МАССИВА:"); Console.ResetColor();

                            string s;
                            int a, b, x, y;

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out a))
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА РАЦИОНАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out b))
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА РАЦИОНАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ КОЛИЧЕСТВО СТРОК МАССИВА:"); Console.ResetColor();

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out x) || x < 1)
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            int[] param = new int[x];

                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ КОЛИЧЕСТВО ЭЛЕМЕНТОВ В КАЖДОЙ СТРОКЕ МАССИВА:"); Console.ResetColor();

                            for (int i = 0; i < x; i++)
                            {
                                Console.WriteLine("\n" + otstup + "СТРОКА " + (i + 1) + " :");

                                s = VvodSOtstupom(ConsoleColor.Green);
                                while (!Int32.TryParse(s, out param[i]) || param[i] < 1)
                                {
                                    ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                    s = VvodSOtstupom(ConsoleColor.Green);
                                }
                            }

                            arrays = GenerateArray(a, b, param);
                        }
                        else if (move == 1)
                        {
                            arrays = new int[0][];
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ КОЛИЧЕСТВО СТРОК МАССИВА:"); Console.ResetColor();
                            string s;
                            int x, y;

                            s = VvodSOtstupom(ConsoleColor.Green);
                            while (!Int32.TryParse(s, out x) || x < 1)
                            {
                                ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                s = VvodSOtstupom(ConsoleColor.Green);
                            }

                            arrays = new int[x][];

                            for (int i = 0; i < x; i++)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n"+otstup + "ВВЕДИТЕ КОЛИЧЕСТВО ЭЛЕМЕНТОВ СТРОКИ " + (i + 1) + ":"); Console.ResetColor();
                                int len;

                                s = VvodSOtstupom(ConsoleColor.Green);
                                while (!Int32.TryParse(s, out len) || len < 1)
                                {
                                    ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА НАТУРАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                    s = VvodSOtstupom(ConsoleColor.Green);
                                }

                                arrays[i] = new int[len];

                                Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВВЕДИТЕ ЭЛЕМЕНТЫ СТРОКИ (" + len + " ЭЛЕМЕНТОВ) :"); Console.ResetColor();

                                for (int j = 0; j < len; j++)
                                {
                                    int a;
                                    s = VvodSOtstupom(ConsoleColor.Green);
                                    while (!Int32.TryParse(s, out a))
                                    {
                                        ColorWrite("\n" + otstup + otstup + "ОЙ! " + s + " НЕ ПОХОЖЕ НА РАЦИОНАЛЬНОЕ ЧИСЛО!", ConsoleColor.Red);
                                        s = VvodSOtstupom(ConsoleColor.Green);
                                    }
                                    arrays[i][j] = a;
                                }
                            }

                        }
                        else if (move == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ВАШ РВАНЫЙ МАССИВ: "); Console.ResetColor();

                            for (int i = 0; i < arrays.GetLength(0); i++)
                            {
                                ColorWrite("\n" + otstup + "СТРОКА " + (i + 1) + " :",ConsoleColor.Green);
                                Console.Write("\n"+otstup);
                                for (int j = 0; j < arrays[i].Length; j++)
                                {
                                    Console.Write(arrays[i][j] + " ");
                                }
                                Console.WriteLine();
                            }
                            
                        }
                        else if (move == 3)
                        {
                            DeleteZeroString(ref arrays);
                            Console.ForegroundColor = ConsoleColor.Yellow; Console.WriteLine("\n" + otstup + "ПЕРВАЯ СТРОКА, В КОТОРОЙ ВСТРЕЧАЕТСЯ 0 (ЕСЛИ ТАКОВАЯ ИМЕЕТСЯ) БЫЛА УДАЛЕНА"); Console.ResetColor();
                        }
                        else
                        {
                            break;
                        }
                        Waiting();
                        Console.Clear();
                    }
                }
                else
                {
                    return;
                }

                
            }
        }
    }
}