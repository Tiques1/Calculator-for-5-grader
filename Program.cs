using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Calculator // я торопился, поэтому и код хреновый, потом обязательно займусь рефакторингом 😁😣😣
{
    class Program
    {
        public static void Main()
        {
            Switcher();          
        }
        
        public static int Menu()
        {
            int whichstringisgreen = 1;
            int lastgreen = 1;
            int y = 0;
            int x = 0;
            do
            {
                
                if (x != Console.WindowWidth/2 || y != Console.WindowHeight/2 || lastgreen != whichstringisgreen)
                {
                    try
                    {
                        Console.Clear();
                        x = Console.WindowWidth / 2;
                        y = Console.WindowHeight / 2;
                        Console.SetCursorPosition(x - 30, y - 10);
                        Console.WriteLine("Главное меню");
                        Console.SetCursorPosition(x - 30, y + 2 - 10);
                        Console.WriteLine("При помощи стрелок выберите пункт и нажмите ENTER, чтобы подтвердить");
                        Console.SetCursorPosition(x - 30, y + 4 - 10);

                        if (whichstringisgreen == 1)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("1.Перевод целых чисел из любой системы счисления в любую другую(от 1 до 50)");
                        Console.ForegroundColor = ConsoleColor.White;

                        if (whichstringisgreen == 2)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(x - 30, y + 6 - 10);
                        Console.WriteLine("2.Перевод целых чисел в римскую систему счисления");
                        Console.ForegroundColor = ConsoleColor.White;

                        if (whichstringisgreen == 3)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(x - 30, y + 8 - 10);
                        Console.WriteLine("3.Перевод целых чисел из римской системы счисления");
                        Console.ForegroundColor = ConsoleColor.White;

                        if (whichstringisgreen == 4)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(x - 30, y + 10 - 10);
                        Console.WriteLine("4.Сложение в любой системе счисления");
                        Console.ForegroundColor = ConsoleColor.White;

                        if (whichstringisgreen == 5)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(x - 30, y + 12 - 10);
                        Console.WriteLine("5.Умножение в любой системе счисления");
                        Console.ForegroundColor = ConsoleColor.White;

                        if (whichstringisgreen == 6)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(x - 30, y + 14 - 10);
                        Console.WriteLine("6.Вычитание в любой системе счисления");
                        Console.ForegroundColor = ConsoleColor.White;

                        if (whichstringisgreen == 7)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(x - 30, y + 16 - 10);
                        Console.WriteLine("7.Выход");
                        Console.ForegroundColor = ConsoleColor.White;
                        lastgreen = whichstringisgreen;
                    }
                    catch 
                    {
                        Thread.Sleep(300);
                    }
                    
                }
                ConsoleKey pressed;
                pressed = Console.ReadKey().Key;

                if (pressed == ConsoleKey.DownArrow && whichstringisgreen < 7)
                {
                    whichstringisgreen += 1;
                    continue;
                }
                if (pressed == ConsoleKey.UpArrow && whichstringisgreen > 1)
                    whichstringisgreen -= 1;
                if (pressed == ConsoleKey.Enter)
                    return whichstringisgreen;
            }
            while (true);   
        }
        public static int ToRome()
        {

                
            Console.SetCursorPosition(Console.WindowWidth/2 - 40, Console.WindowHeight/2 - 10);
            Console.WriteLine("В римской системе счисления есть только следующие символы: I - 1, V - 5, X - 10, L - 50, C - 100, D - 500, M - 1000");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 9); 
            Console.WriteLine("В римской системе счисления каждое число складывается, и сумма это и будет число в десятичной системе счисления");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 8); 
            Console.WriteLine("Например, число II будет 2 (1 + 1 = 2), число VIII это 8 (5 + 1 + 1 + 1), число LX это 60 (50 + 10)");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 7); 
            Console.WriteLine("Исключение составляют цифры 4 и 9. Чтобы записать их, нужно наоборот – вычитать");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 6);
            Console.WriteLine("Пример: 4 это IV, 9 это IX, число 40 это XL, 90 это XC, 400 это CD, 900 это СM");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 4);
            Console.WriteLine("Введите целое число для перевода в римскую систему счисления");
            int number = 0;
            try
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 2);
                Console.WriteLine("Ваше число:");
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 1);
                number = Convert.ToInt32(Console.ReadLine());

               
            }
            catch
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод! Для продолжения нажмите ENTER");
                Console.ForegroundColor = ConsoleColor.White;
                if (Console.ReadLine() == " ")
                    return 2;
                else
                    return 2;
            }
            int numbefore = number;
            string romes = "";
            while(number != 0)
            {                
                if(number - 1000 >= 0)
                {
                    number -= 1000;
                    romes += "M";
                    continue;
                }
                if (number - 500 >= 0)
                {
                    number -= 500;
                    romes += "D";
                    continue;
                }
                if (number - 100 >= 0)
                {
                    number -= 100;
                    romes += "C";
                    continue;
                }
                if (number - 50 >= 0)
                {
                    number -= 50;
                    romes += "L";
                    continue;
                }
                if (number - 10 >= 0)
                {
                    number -= 10;
                    romes += "X";
                    continue;
                }
                if (number - 5 >= 0)
                {
                    number -= 5;
                    romes += "V";
                }
                if (number - 1 >= 0)
                {
                    number -= 1;
                    romes += "I";
                }
            }
            romes = romes.Replace("VIIII", "IX");
            romes = romes.Replace("IIII", "IV");
            romes = romes.Replace("LXXXX", "XC");
            romes = romes.Replace("XXXX", "XL");
            romes = romes.Replace("DCCCC", "CM");
            romes = romes.Replace("CCCC", "CD");
            
            int[] nums = new int[numbefore.ToString().Length];
            int z = numbefore.ToString().Length - 1;

            for (int p = 0;p < numbefore.ToString().Length + z; p++)
            {
                nums[p] = numbefore%10;
                numbefore/=10;
               
            }
            Array.Reverse(nums);

            int j = 1;
            for(int i = 0; i<nums.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 + j);
                Console.WriteLine(nums[i]*Math.Pow(10,nums.Length - i - 1) + " ----> " + ToRomeSup(nums[i] * (int)Math.Pow(10, nums.Length - i - 1)));
                j += 2;
            }

            Console.SetCursorPosition(Console.WindowWidth/2 - 40,Console.WindowHeight/2 + j);
            Console.WriteLine("Ответ:" + romes);
            j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 + j);
            Console.WriteLine("Для выхода нажмите enter");
            if(Console.ReadLine() != "2935093409524")
                return 8;
            return 8;
           
        }
        public static string ToRomeSup(int number)
        {
            string romes = "";
            while (number != 0)
            {
                if (number - 1000 >= 0)
                {
                    number -= 1000;
                    romes += "M";
                    continue;
                }
                if (number - 500 >= 0)
                {
                    number -= 500;
                    romes += "D";
                    continue;
                }
                if (number - 100 >= 0)
                {
                    number -= 100;
                    romes += "C";
                    continue;
                }
                if (number - 50 >= 0)
                {
                    number -= 50;
                    romes += "L";
                    continue;
                }
                if (number - 10 >= 0)
                {
                    number -= 10;
                    romes += "X";
                    continue;
                }
                if (number - 5 >= 0)
                {
                    number -= 5;
                    romes += "V";
                }
                if (number - 1 >= 0)
                {
                    number -= 1;
                    romes += "I";
                }
            }
            romes = romes.Replace("VIIII", "IX");
            romes = romes.Replace("IIII", "IV");
            romes = romes.Replace("LXXXX", "XC");
            romes = romes.Replace("XXXX", "XL");
            romes = romes.Replace("DCCCC", "CM");
            romes = romes.Replace("CCCC", "CD");
            return romes;
        }
        public static int Converter()
        {
            int j = 0;
            string num0 = "";
            
            int num1 = 0;
            int sys1 = 0;
            int sys2 = 0;
            Dictionary<string, string> literal = new Dictionary<string, string> { {"10","A"}, { "11", "B" }, { "12", "C" }, { "13", "D" }, { "14", "E" }, { "15", "F" }, { "16", "G" },
                { "17", "H" }, { "18", "I" }, { "19", "J" }, { "20", "K" }, { "21", "L" }, { "22", "M" }, { "23", "N" }, { "24", "O" }, { "25", "P" }, { "26", "Q" }, { "27", "R" }, { "28", "S" },
                { "29", "T" }, { "30", "U" }, { "31", "V" }, { "32", "W" }, { "33", "X" }, { "34", "Y" }, { "35", "Z" }, { "36", "a" }, { "37", "b" }, { "38", "c" }, { "39", "d" }, { "40", "e" },
                { "41", "f" }, { "42", "g" }, { "43", "h" }, { "44", "i" }, { "45", "j" }, { "46", "k" }, { "47", "l" }, { "48", "m" }, { "49", "n" }, { "50", "o" }, };
            Dictionary<string, string> literalreverse = new Dictionary<string, string> { {"A","10"}, { "B", "11" }, { "C", "12" }, { "D", "13" }, { "E", "14" }, { "F", "15" }, { "G", "16" },
                { "H", "17" }, { "I", "18" }, { "J", "19" }, { "K", "20" }, { "L", "21" }, { "M", "22" }, { "N", "23" }, { "O", "24" }, { "P", "25" }, { "Q", "26" }, { "R", "27" }, { "S", "28" },
                { "T", "29" }, { "U", "30" }, { "V", "31" }, { "W", "32" }, { "X", "33" }, { "Y", "34" }, { "Z", "35" }, { "a", "36" }, { "b", "37" }, { "c", "38" }, { "d", "39" }, { "e", "40" },
                { "f", "41" }, { "g", "42" }, { "h", "43" }, { "i", "44" }, { "j", "45" }, { "k", "46" }, { "l", "47" }, { "m", "48" }, { "n", "49" }, { "o", "50" }, };

            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Для перевода из любой системы счисления в любую другую нужно:"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("1) Привести число к десятичной системе счисления следующим образом:"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Каждый разряд числа умножить на основание системы счисления в степени разряда числа, начиная с нуля. И сложить"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("2) Из десятичной системы счисления перевести в другую слудующим образом:"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Число делить на основание сс до тех пор, пока число не станет меньше основания"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Затем записать подряд каждый остаток и в конце само число и развернуть"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Если есть числа, которые не являются цифрами(то есть они не являются 0,1,2,3,4,5,6,7,8 или 9, то заменяем их буквами"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("10→A; 11->B; 12->C; 13->D; 14->E; 15->F; 16->G; 17->H; 18->I; 19->J; 20->K; 21->L; 22->M; 23->N; 24->O; 25->P; 26->Q; 27->R; 28->S;"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("29->T; 30->U; 31->V; 32->W; 33->X; 34->Y; 35->Z; 36->a; 37->b; 38->c; 39->d; 40->e; 41->f; 42->g; 43->h; 44->i; 45->j; 46->k; 47->l; 48->m; 49->n; 50->o"); j += 8;

            try
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine("Введите целое число"); j += 2;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                num0 = Console.ReadLine(); j += 2;
                if (num0 == "")
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы не ввели число");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (Console.ReadLine() == " ")
                        return 1;
                    else
                        return 1;
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine("Введите систему счисления числа от 2 до 50"); j += 2;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                sys1 = Convert.ToInt32(Console.ReadLine()); j += 2;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine("Введите систему счисления, в которую хотите перевести. От 2 до 50"); j += 2;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                sys2 = Convert.ToInt32(Console.ReadLine()); j += 2;
            }
            catch
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорректный ввод! Для продолжения нажмите ENTER");
                Console.ForegroundColor = ConsoleColor.White;
                if (Console.ReadLine() == " ")
                    return 1;
                else
                    return 1;
            }
            if (sys1 > 50 || sys2 > 50 || sys1 < 2 || sys2 < 2)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ну просил же: основание от 2 до 50");
                Console.ForegroundColor = ConsoleColor.White;
                if (Console.ReadLine() == " ")
                    return 1;
                else
                    return 1;
            }
            
            string[] num10 = new string[num0.Length];
            if (!int.TryParse(num0.ToString(), out num1))
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Извините, не осилил перевод чисел с буквами");
                Console.ForegroundColor = ConsoleColor.White;
                if (Console.ReadLine() == " ")
                    return 1;
                else
                    return 1;
            }
   
            
            double[] check = new double[num1.ToString().Length];
            int numforcheck = num1;
            
            while(numforcheck != 0)
            {
                if (numforcheck % 10 >= sys1)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Сударь, да у вас цифры больше основания");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (Console.ReadLine() == " ")
                        return 1;
                    else
                        return 1;
                }                   
                numforcheck /= 10;
            }
            bool flag = false;
            bool flag10 = false;
            double summa = 0;
            int z = num1.ToString().Length;
            List<double> perevod = new List<double>();
            List<double> perevodnoten = new List<double>();
            string[] output = new string[num1.ToString().Length];
            string[] perevka = new string[num1.ToString().Length];
            if (sys1 == 10) // перевод из 10 в какую-то
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine("Перевод из " + sys1 + " в " + sys2); j += 2;
                while (num1>=sys2)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                    Console.Write(num1 + " делим на основание сс" + sys2 + " пока " + num1 + " не будет меньше " + sys2 + ". " + num1 + "/" + sys2 + "= ");
                    if (num1 / sys2 < sys2)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(num1 / sys2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" остаток: "); 
                    Console.ForegroundColor = ConsoleColor.Red; j += 2;
                    Console.Write(num1 % sys2); 
                    Console.ForegroundColor = ConsoleColor.White;
                    perevod.Add( num1 % sys2);
                    num1 /= sys2;
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine("Теперь записываем остатки в обратном порядке, сначала записывая то, чему равно само число:"); j += 2;

                perevod.Add(num1);
                perevod.Reverse();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine(string.Join(" ", perevod)); j += 2;

                
                
                output = string.Join(" ", perevod).Split(" ");

                for (int hj = 0; hj < output.Length; hj++)
                {
                    if (Convert.ToInt32(output[hj]) > 9 && Convert.ToInt32(output[hj]) <= 50)
                    {
                        output[hj] = literal[output[hj]];
                    }
                }

            }
            else if(sys2 == 10) // перевод из какой-то в дес.
            {
                
                
                for (int i = 0; i < z; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                    Console.Write("Берем один разряд числа - это " + num1%10 + " и умножаем его на основание в степени(разряд цифры): " + num1%10 + "*" + sys1 + "^" + i + " = " + num1 % 10 * Math.Pow(sys1, i)); j += 2;
                    perevodnoten.Add((num1 % 10) * Math.Pow(sys1, i));
                    num1 /= 10;
                }
                foreach (double s in perevodnoten)
                    summa += s;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.Write("Теперь складываем результаты и получаем: " + summa); j += 2;
                
                flag = true;
            }
            else // полный перевод
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine("Перевод из " + sys1 + " в " + 10); j += 2;
                for (int i = 0; i < z; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                    Console.Write("Берем один разряд числа - это " + num1 % 10 + " и умножаем его на основание в степени(разряд цифры): " + num1 % 10 + "*" + sys1 + "^" + i + " = " + num1 % 10 * Math.Pow(sys1, i)); j += 2;
                    perevodnoten.Add((num1 % 10) * Math.Pow(sys1, i));
                    num1 /= 10;
                }
                foreach (double s in perevodnoten)
                    summa += s;
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.Write("Теперь складываем результаты и получаем: " + summa); j += 2;

                num1 = Convert.ToInt32(summa);
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine("Перевод из " + 10 + " в " + sys2); j += 2;
                while (num1 >= sys2)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                    Console.Write(num1 + " делим на основание сс" + sys2 + " пока " + num1 + " не будет меньше " + sys2 + ". " + num1 + "/" + sys2 + "= ");
                    if (num1 / sys2 < sys2)
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(num1 / sys2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" остаток: ");
                    Console.ForegroundColor = ConsoleColor.Red; j += 2;
                    Console.Write(num1 % sys2);
                    Console.ForegroundColor = ConsoleColor.White;
                    perevod.Add(num1 % sys2);
                    num1 /= sys2;
                }
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine("Теперь записываем остатки в обратном порядке, сначала записывая то, чему равно само число:"); j += 2;

                perevod.Add(num1);
                perevod.Reverse();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine(string.Join(" ", perevod)); j += 2;



                output = string.Join(" ", perevod).Split(" ");

                for (int hj = 0; hj < output.Length; hj++)
                {
                    if (Convert.ToInt32(output[hj]) > 9 && Convert.ToInt32(output[hj]) <= 50)
                    {
                        output[hj] = literal[output[hj]];
                    }
                }
            }
            
            
            
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            if (flag)
                Console.WriteLine("Ответ: " + summa);
            else               
                Console.WriteLine("Ответ:" + string.Join("", output));
            j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Для выхода нажмите enter");j += 2;
            if (Console.ReadLine() != "2935093409524")
                return 8;
            return 8;
        }
        public static int FromRome()
        {
            int j = 0;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Для перевода из любой системы счисления в любую другую нужно:"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("1) Привести число к десятичной системе счисления следующим образом:"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Каждый разряд числа умножить на основание системы счисления в степени разряда числа, начиная с нуля. И сложить"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("2) Из десятичной системы счисления перевести в другую слудующим образом:"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Число делить на основание сс до тех пор, пока число не станет меньше основания"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Затем записать подряд каждый остаток и в конце само число и развернуть"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Введите число в римской системе счисления"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            string number = "";
            try
            {
                number = Console.ReadLine().ToUpper(); 
            }
            catch
            {
                return 3;
            }
            foreach(char s in number)
            {
                if (!(s == 'I' || s == 'V' || s == 'X' || s == 'L' || s == 'C' || s == 'D' || s == 'M'))
                    return 3;
            }
            j += 2;

            List<int> summa = new List<int>();

            while (number != "")
            {
                if (number.Contains("IV"))
                {
                    summa.Add(4);
                    number = number.Remove(number.IndexOf("IV"), 2); 
                }
                if (number.Contains("IX"))
                {
                    summa.Add(9);
                    number = number.Remove(number.IndexOf("IX"), 2); 
                }
                if (number.Contains("XL"))
                {
                    summa.Add(40);
                    number = number.Remove(number.IndexOf("XL"), 2); 
                }
                if (number.Contains("XC"))
                {
                    summa.Add(90);
                    number = number.Remove(number.IndexOf("XC"), 2); 
                }
                if (number.Contains("CD"))
                {
                    summa.Add(400);
                    number = number.Remove(number.IndexOf("CD"), 2); 
                }
                if (number.Contains("CM"))
                {
                    summa.Add(900);
                    number = number.Remove(number.IndexOf("CM"), 2);
                }
                if (number.Contains("M"))
                {
                    summa.Add(1000);
                    number = number.Remove(number.IndexOf("M"), 1); 
                }
                if (number.Contains("D"))
                {
                    summa.Add(500);
                    number = number.Remove(number.IndexOf("D"), 1); 
                }
                if (number.Contains("C"))
                {
                    summa.Add(100);
                    number = number.Remove(number.IndexOf("C"), 1); 
                }
                if (number.Contains("L"))
                {
                    summa.Add(50);
                    number = number.Remove(number.IndexOf("L"), 1); 
                }
                if (number.Contains("X"))
                {
                    summa.Add(10);
                    number = number.Remove(number.IndexOf("X"), 1); 
                }
                if (number.Contains("V"))
                {
                    summa.Add(5);
                    number = number.Remove(number.IndexOf("V"), 1); 
                }
                if (number.Contains("I"))
                {
                    summa.Add(1);
                    number = number.Remove(number.IndexOf("I"), 1); 
                }

            }
            Dictionary<double, string> symbols = new Dictionary<double, string>
            {
                {1, "I" },
                {5, "V" },
                {10, "X" },
                {50, "L" },
                {100, "C" },
                {500, "D" },
                {1000, "M" },
                {4, "IV" },
                {9, "IX" },
                { 40, "XL"},
                {90, "XC" },
                {400, "CD" },
                {900, "CM" }
            };
            summa.Sort();
            summa.Reverse();
            foreach(double x in summa)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
                Console.WriteLine(symbols[x] + " ----> " + x); j += 2;
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Ответ: " + summa.Sum()); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Для выхода нажмите enter"); j += 2;
            if (Console.ReadLine() != "2935093409524")
                return 8;
            return 8;
        }
        public static int Add()
        {
            int j = 0;
            int result = 0;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Сложение в различных системах счисления осуществляется в точности так же, как и в десятичной"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Если в десятичной системе счисления при сложении столбиком,"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("когда сумма двух чисел получалась больше 10, мы преносили единичку(разряд десятков) на разряд влево");j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("и просто записывали разряд единиц, то здесь то же самое, только максимальная сумма изменяется вместе со значением системы счисления"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Если хотим складывать в различных системах, увы, придется привести к одной"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Посмотрим на примере ваших чисел. Введите число:"); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            int number = 0;
            try
            {
                number = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                return 4;
            }

            

            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Ответ: " + result); j += 2;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 40, Console.WindowHeight / 2 - 10 + j);
            Console.WriteLine("Для выхода нажмите enter"); j += 2;
            if (Console.ReadLine() != "2935093409524")
                return 8;
            return 8;
        }
        public static void Switcher()
        {
            int swc = 8;
            while (true)
            {               
                switch (swc)
                {
                    case 1: swc = Converter();  Console.Clear(); continue; // готов, заниматься переводом букв в цифры я уже не могу
                    case 3: swc = FromRome(); Console.Clear(); continue; // готов
                    case 4: swc = Add();  Console.Clear(); continue; // в работе
                    /*case 6: swc = Minus();  Console.Clear(); continue;
                    case 5: swc = Multiply();  Console.Clear(); continue;*/                    
                    case 2: swc = ToRome(); Console.Clear(); continue; // готов
                    case 8: swc = Menu(); Console.Clear();  continue;
                    case 7: break;                 
                }
                if (swc == 7)
                    break;
            }
        }
    }
}