using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersOfHanoiGame
{
    public class HanoiGame
    {
        public void Setup()
        {

            

            //輸入高度
            Console.WriteLine("請輸入河內塔的高度(限制輸入整數1~100，若輸入為文字或小數則自動設定為1)：");
            
            string input = Console.ReadLine();
            string Input = input;
            int disk = string_test(Input);  //若輸入為文字，則disk = 1
            int string_test(string I)
            {
                try
                {
                    int result = int.Parse(I);
                    return result;
                }
                catch (Exception)
                {
                    int result = 1;
                    Console.WriteLine("就跟你說要輸入整數，但你輸入的不是整數，所以已自動設定為1");
                    return result;
                }
            }

            int Disk = disk;
            disk = number_test(Disk);  //若輸入的數值不在規定範圍內，則重新輸入
            int number_test(int D)
            {
                try
                {
                    while (D < 1
                        | D > 100)
                    {
                        Console.WriteLine("你輸入的數值不在規定範圍內，請重新輸入：");
                        string again = Console.ReadLine();
                        string Again = again;
                        D = string_test2(Again);  //若輸入為文字，則 D = disk = 1
                        int string_test2(string A)
                        {
                            try
                            {
                                int result2 = int.Parse(A);
                                return result2;
                            }
                            catch (Exception)
                            {
                                int result2 = 1;
                                Console.WriteLine("就跟你說要輸入整數，但你輸入的不是整數，所以已自動設定為1");
                                return result2;
                            }
                        }
                    }
                    int result = D;
                    return result;
                }
                catch (Exception)
                {
                    int result = 1;
                    return result;
                }
            }



            Console.WriteLine("起始地的柱子:(1,2,3)(限制輸入整數1~3，若輸入為文字或小數則自動設定為1)");
            input = Console.ReadLine();
            string Input2 = input;
            int from = string_test3(Input2);  //若輸入為文字，則from = 1
            int string_test3(string I)
            {
                try
                {
                    int result = int.Parse(I);
                    return result;
                }
                catch (Exception)
                {
                    int result = 1;
                    Console.WriteLine("就跟你說要輸入整數，但你輸入的不是整數，所以已自動設定為1");
                    return result;
                }
            }

            int From = from;
            from = number_test2(From);  //若輸入的數值不在規定範圍內，則重新輸入
            int number_test2(int F)
            {
                try
                {
                    while (F < 1 | F > 3)
                    {
                        Console.WriteLine("你輸入的數值不在規定範圍內，請重新輸入：");
                        string again = Console.ReadLine();
                        string Again = again;
                        F = string_test4(Again);  //若輸入為文字，則 F = from = 1
                        int string_test4(string A)
                        {
                            try
                            {
                                int result2 = int.Parse(A);
                                return result2;
                            }
                            catch (Exception)
                            {
                                int result2 = 1;
                                Console.WriteLine("就跟你說要輸入整數，但你輸入的不是整數，所以已自動設定為1");
                                return result2;
                            }
                        }
                    }
                    int result = F;
                    return result;
                }
                catch (Exception)
                {
                    int result = 1;
                    return result;
                }
            }



            Console.WriteLine("目的地的柱子：(1,2,3)(限制輸入整數1~3，若輸入為文字或小數則自動設定為1)");
            input = Console.ReadLine();
            string Input3 = input;
            int to = string_test5(Input3);  //若輸入為文字，則to = 1
            int string_test5(string I)
            {
                try
                {
                    int result = int.Parse(I);
                    return result;
                }
                catch (Exception)
                {
                    int result = 1;
                    Console.WriteLine("就跟你說要輸入整數，但你輸入的不是整數，所以已自動設定為1");
                    return result;
                }
            }

            int To = to;
            to = number_test3(To);  //若輸入的數值不在規定範圍內，則重新輸入
            int number_test3(int T)
            {
                try
                {
                    while (T < 1 | T > 3)
                    {
                        Console.WriteLine("你輸入的數值不在規定範圍內，請重新輸入：");
                        string again = Console.ReadLine();
                        string Again = again;
                        T = string_test6(Again);  //若輸入為文字，則 T = to = 1
                        int string_test6(string A)
                        {
                            try
                            {
                                int result3 = int.Parse(A);
                                return result3;
                            }
                            catch (Exception)
                            {
                                int result3 = 1;
                                Console.WriteLine("就跟你說要輸入整數，但你輸入的不是整數，所以已自動設定為1");
                                return result3;
                            }
                        }
                    }
                    int result = T;
                    return result;
                }
                catch (Exception)
                {
                    int result = 1;
                    return result;
                }
            }



            #region // 取得 第三柱子
            /* 例如 輸入 1 3  得到  2
             *      輸入 1 2  得到  3
             *      輸入 2 3  得到  1
             */
            int aux = 0;
            int[] temp = { 1, 2, 3 };
            foreach (int item in temp)
            {
                if (item != from && item != to)
                {
                    aux = item;
                    break;
                }
            }
            #endregion

            Hanoi(disk, from, to, aux);
            Console.ReadKey();
        }

        public void Hanoi(int Disk, int Src, int Dest, int Aux)
        {
            //參考演算法: http://notepad.yehyeh.net/Content/DS/CH02/4.php
            //參考演算法: http://program-lover.blogspot.com/2008/06/tower-of-hanoi.html
            if (Disk == 1)
            {
                    Console.WriteLine($"將第{Disk}個圓盤由{Src}移到{Dest} ");
            }
            else
            {
                Hanoi(Disk - 1, Src, Aux, Dest);
                Console.WriteLine($"將第{Disk}個圓盤由{Src}移到{Dest} ");
                Hanoi(Disk - 1, Aux, Dest, Src);
            }
        }

        public void Play()
        {

        }
    }
}
