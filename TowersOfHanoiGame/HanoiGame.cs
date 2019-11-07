using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowersOfHanoiGame
{
    public class HanoiGame
    {

        public static int ddisk = 0;
        public static int ffrom = 0;
        public static int tto = 0;
        public static int aaux = 0;

        public void Setup()
        {


            //輸入高度
            Console.WriteLine("請輸入河內塔的高度(限制輸入整數1~100，若輸入為文字或小數則自動設定為1)：");
            string input = Console.ReadLine();
            int disk = string_test(input);  //若輸入為文字，則disk = 1
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
                    Console.WriteLine("就跟你說要輸入整數，但你輸入的不是整數 (或者數值過大)，故已自動設定為1");
                    return result;
                }
            }

            disk = number_test(disk);  //若輸入的數值不在規定範圍內，則重新輸入 ; 若輸入為文字，則disk = 1
            int number_test(int D)
            {
                try
                {
                    int count = 1;
                    while (D < 1 | D > 100)
                    {
                        count++;
                        if (count > 5)
                        {
                            Console.WriteLine("你輸入的數值不在規定範圍內 (1~100)，且已用完5次輸入機會，無法再次輸入，已自動設定為1");
                            D = 1;
                        }
                        else
                        {
                            Console.WriteLine("你輸入的數值不在規定範圍內 (1~100)，請重新輸入 (這是你在本項目的第{0}次輸入，共有5次機會)：", count);
                            string again = Console.ReadLine();
                            D = string_test(again);
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
            int from = string_test(input);  //若輸入為文字，則from = 1
            from = number_test2(from);  //若輸入的數值不在規定範圍內，則重新輸入 ; 若輸入為文字，則from = 1
            int number_test2(int F)
            {
                try
                {
                    int count = 1;
                    while (F < 1 | F > 3)
                    {
                        count++;
                        if (count > 5)
                        {
                            Console.WriteLine("你輸入的數值不在規定範圍內 (1~3)，且已用完5次輸入機會，無法再次輸入，已自動設定為1");
                            F = 1;
                        }
                        else
                        {
                            Console.WriteLine("你輸入的數值不在規定範圍內 (1~3)，請重新輸入 (這是你在本項目的第{0}次輸入，共有5次機會)：", count);
                            string again = Console.ReadLine();
                            F = string_test(again);
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
            int to = string_test(input);  //若輸入為文字，則to = 1
            to = number_test2(to);  //若輸入的數值不在規定範圍內，則重新輸入 ; 若輸入為文字，則to = 1


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

            //Hanoi(disk, from, to, aux);
            ddisk = disk;
            ffrom = from;
            tto = to;
            aaux = aux;
            Console.ReadKey();
        }


        public void Play()
        {

            Hanoi(ddisk, ffrom, tto, aaux);

            void Hanoi(int Disk, int Src, int Dest, int Aux)
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
        }
    }
}
