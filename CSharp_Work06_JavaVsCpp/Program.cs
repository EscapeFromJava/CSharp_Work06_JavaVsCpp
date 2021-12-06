using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp_Work06_JavaVsCpp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"INPUT.txt";
            string s = File.ReadAllText(input);
            char[] arrS = s.ToCharArray();
            string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] arrLetters = letters.ToCharArray();
            bool flag_big_reg = CheckOne(arrS, arrLetters);
            bool flag_cherta = CheckTwo(arrS, arrLetters);
            bool flag_all_min = CheckFree(arrS);
            string sym = "_";
            char sym2 = '_';
            if (flag_big_reg)
            {
                if (flag_cherta) // большой регистр (Java)
                {
                    for (int i = arrS.Length - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < arrLetters.Length; j++)
                        {
                            if (arrS[i] == arrLetters[j])
                            {
                                s = s.Insert(i, sym);
                                break;
                            }
                        }
                    }
                    s = s.ToLower();
                }
                else //большой регистр и есть черта (error)
                    s = "Error!";
            }
            else // нижний регистр 
            {
                if (flag_all_min) //все нижний регистр без подчеркиваний (c++ and Java)
                {
                    ;
                }
                else  //все нижний регистр с подчеркиванием (c++)
                {
                    for (int i = arrS.Length - 1; i >= 0; i--)
                    {
                        for (int j = 0; j < arrLetters.Length; j++)
                        {
                            if (arrS[i] == sym2)
                            {
                                arrS[i+1] = char.ToUpper(arrS[i+1]);
                                break;
                            }
                        }
                    }
                    s = new string(arrS);
                    s = s.Replace("_", "");
                }
            }


            string output = @"OUTPUT.txt";
            File.WriteAllText(output, s);
        }
        static bool CheckOne(char[] arr1, char[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool CheckTwo(char[] arr1, char[] arr2)
        {
            char elem = '_';
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        if (arr1[i-1] == elem)
                        return false;
                    }
                }
            }
            return true;
        }

        static bool CheckFree(char[] arr1)
        {
            char elem = '_';
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == elem)
                    return false;
            }
            return true;
        }
    }
}
