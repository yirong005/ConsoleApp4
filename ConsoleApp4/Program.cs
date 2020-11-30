using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mytick = buyticket();
            int[] randontick = createrandomticket();
           int aa= ticketequals(mytick, randontick);
            switch (aa)
            {
                case 1:
                    Console.WriteLine("1等奖");
                    break;
                case 2:
                    Console.WriteLine("2等奖");
                    break;
                case 3:
                    Console.WriteLine("3等奖");
                    break;
                case 4:
                    Console.WriteLine("4等奖");
                    break;
                case 5:
                    Console.WriteLine("5等奖");
                    break;
                case 6:
                    Console.WriteLine("6等奖");
                    break;
                case 0:
                    Console.WriteLine("你没有中奖00000000");
                    break;

            }
        }
        private static int[] buyticket()
        {
            int[] tick = new int[7];
            for (int i = 0; i < 6;)
            {
                Console.WriteLine("请输入第{0}个红色号码",i+1);
                int number = int.Parse(Console.ReadLine());
                if (number < 1 || number > 33)
                    Console.WriteLine("号码超出范围");
                else if(Array.IndexOf(tick,number)>=0)
                {
                    Console.WriteLine("号码重复");
                }
                else
                {
                    tick[i++] = number;
                }
               
            }
            int bluenumber;
            do
            {
                Console.WriteLine("输入蓝色号码");
                bluenumber = int.Parse(Console.ReadLine());
                if (bluenumber >= 1 && bluenumber <= 16)
                {
                    tick[6] = bluenumber;
                    break;
                }
                else
                    Console.WriteLine("号码超出范围");
            } while (true);
            return tick;
        }
        static Random random = new Random();
        private static int[]createrandomticket()
        {
            int[] ticket = new int[7];
            for (int i = 0; i < 6; i++)
            {
                int number = random.Next(1, 34);
                if(Array.IndexOf(ticket,number)<0)
                {
                    ticket[i] = number;
                }
            }
            ticket[6] = random.Next(1, 17);
            Array.Sort(ticket, 0, 6);
            return ticket;
        }
        private static int ticketequals(int[] mytick, int[] rantick)
        {
            int blucount = mytick[6] == rantick[6] ? 1 : 0;
            int redcount = 0;
            for (int i = 0; i < 6; i++)
            {
                if (Array.IndexOf(mytick, rantick[i]) >= 0)
                    redcount++;
            }
            int level;
            if (blucount + redcount == 7)
                level = 1;
            else if (redcount == 6)
                level = 2;
            else if (redcount + blucount == 6)
                level = 3;
            else if (redcount + blucount == 5)
                level = 4;
            else if (redcount + blucount == 4)
                level = 5;
            else if (blucount == 1)
                level = 6;
            else
                level = 0;
            return level;
        }


        private static bool isyear(int year)
        {
            return ((year%4==0&&year%100!=0)||(year%400==0));
        }
        private static int gettotaldays(int year,int month,int day)
        {
            
            int[] daysmonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (isyear(year)) daysmonth[1] = 29;
            int days = 0;
            for (int i = 0; i < month-1; i++)
            {
                days += daysmonth[i];
            }
            days += day;
            return days;
        }
    }
}
