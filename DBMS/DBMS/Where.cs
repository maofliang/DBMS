using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace DBMS
{
    class Where
    {
        public ArrayList returnList = new ArrayList();

        public Where(string letter)
        {
            if (letter.Equals(""))
            {
                return;
            }
            string[] temp;
            string[,] myget;
            string pattern = @"or";
            Regex expression = new Regex(pattern);
            string[] get = expression.Split(letter);
            for (int i = 0; i < get.Length; i++)
            {
                pattern = @"and";
                expression = new Regex(pattern);
                temp = expression.Split(get[i]);
                myget = where_and(temp);
                returnList.Add(myget);
            }
        }
        public string[,] where_and(string[] letter)
        {
            string[] temp; string pattern; Regex expression;
            string[,] rt = new string[letter.Length, 4];
            Match ttp;
            for (int i = 0; i < letter.Length; i++)
            {
                pattern = @"not\s+";
                expression = new Regex(pattern);
                if (expression.IsMatch(letter[i]))
                {
                    rt[i, 2] = "f";
                    letter[i] = expression.Replace(letter[i], "");
                }
                else
                {
                    rt[i, 2] = "t";

                }
                pattern = @"[=|>|<]+";
                expression = new Regex(pattern);
                temp = expression.Split(letter[i]);
                rt[i, 0] = temp[0];
                rt[i, 1] = temp[1];
                ttp = expression.Match(letter[i]);
                rt[i, 3] = ttp.ToString();
            }
            return rt;
        }
    }
}
