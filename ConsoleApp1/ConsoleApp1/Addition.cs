using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Addition
    {
        string sumString = "";
        public void Add(string number1,string number2)
        {
            if(!CheckIfNumbers(number1,number2))      
                return; 
            
            List<int>num1 = new List<int>();
            List<int>num2 = new List<int>();
            List<int>sum=new List<int>();
            ConvertToInt(number1, num1);
            ConvertToInt(number2, num2);
         
            var maxDigit = Math.Max(num1.Count, num2.Count);
            //145 num1
            //14 num2
            if(num1.Count < maxDigit)
            {
                var addMultiplier = maxDigit - num1.Count;
                for (int i = 0; i < addMultiplier; i++)
                {
                    num1.Insert(0, 0);
                }
            }
            //145 num1
            //014 num2
            if (num2.Count < maxDigit)
            {
                var addMultiplier = maxDigit - num2.Count;
                for (int i = 0; i < addMultiplier; i++)
                {
                    num2.Insert(0, 0);
                }
            }

        
            num1.Reverse();
            num2.Reverse();
           //541
           //410
           

            int carry=0;
            for (int i = 0; i < maxDigit; i++)
            {
                int tempSum;
                if (carry == 1)
                {
                    tempSum = num1[i] + num2[i]+1;
                    carry = 0;
                }
                else
                {
                    tempSum = num1[i] + num2[i];
                }
                 
                
                if (tempSum / 10 == 1 ? true : false)
                {
                    carry++;
                    tempSum -= 10;
                }
                sum.Add(tempSum);


            }
            if(carry == 1)
            {
                sum.Add(carry);
            }
            sum.Reverse();
            
      
           
            for (int i = 0; i < sum.Count; i++)
            {
                sumString = sumString.Insert(sumString.Length, sum[i].ToString());

            }
            
            Console.WriteLine("Summary: " + sumString);


        }
        public bool CheckIfNumbers(string number1,string number2)
        {
            StringBuilder sb = new StringBuilder(number1);
            sb.Append(number2);
            string s = sb.ToString();
            foreach (var item in s )
            {
                if (Char.IsNumber(item) ? false : true)
                {
                    Console.WriteLine("given number has not a number,it contains this: " + item);
                    return false;
                    
                }
              
            }
            return true;
           
        }
        public void ConvertToInt(string num1,List<int> number1)
        {
            foreach (var item in num1)
            {
                number1.Add(int.Parse(item.ToString()));
            }
        }
    }

} 
