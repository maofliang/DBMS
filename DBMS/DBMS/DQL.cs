using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace DBMS
{
    class DQL
    {
        public ArrayList rtn;

        //复杂查询
        public void Select(ArrayList[] a)
        {
            FileOp f = new FileOp();

            ArrayList temp = new ArrayList();
            List<TableMode> tableModeList = new List<TableMode>();
            List<List<object>> recordList = new List<List<object>>();
            int all = 1, len = 0, tbnum = a[1].Count, bei = 1, m = 0, lenadd = 0;
            //获取all，len变量
            foreach (string k in a[1])
            {
                tableModeList = f.read_table_field(k);
                recordList = f.read_all_record(k, tableModeList);
                all *= recordList.Count;
                len += tableModeList.Count;
            }
            string[,] get = new string[all + 1, len];
            //合并多张表的数据
            foreach (string k in a[1])
            {
                tableModeList = new List<TableMode>();
                tableModeList = f.read_table_field(k);
                recordList = f.read_all_record(k, tableModeList);
                for (int i = 0; i < tableModeList.Count; i++)
                {
                    get[0, i + lenadd] = k + "." + tableModeList[i].getFieldName();
                    if (tableModeList[i].getFieldType().Equals("int"))
                    {

                        for (int q = 0; q < recordList.Count; q++)
                        {
                            for (m = 0; m < all / recordList.Count / bei; m++)
                            {
                                for (int p = 0; p < bei; p++)
                                {
                                    get[1 + p * all / bei + m + q * all / recordList.Count / bei, i + lenadd] = ((int)recordList[q][i]).ToString();
                                }
                            }
                        }
                    }
                    if (tableModeList[i].getFieldType().Equals("long"))
                    {
                        for (int q = 0; q < recordList.Count; q++)
                        {
                            for (m = 0; m < all / recordList.Count / bei; m++)
                            {
                                for (int p = 0; p < bei; p++)
                                {
                                    get[1 + p * all / bei + m + q * all / recordList.Count / bei, i + lenadd] = ((long)recordList[q][i]).ToString();
                                }
                            }
                        }
                    }
                    if (tableModeList[i].getFieldType().Equals("double"))
                    {
                        for (int q = 0; q < recordList.Count; q++)
                        {
                            for (m = 0; m < all / recordList.Count / bei; m++)
                            {
                                for (int p = 0; p < bei; p++)
                                {
                                    get[1 + p * all / bei + m + q * all / recordList.Count / bei, i + lenadd] = ((double)recordList[q][i]).ToString();
                                }
                            }
                        }
                    }
                    if (tableModeList[i].getFieldType().Equals("char") || tableModeList[i].getFieldType().Equals("varchar"))
                    {
                        for (int q = 0; q < recordList.Count; q++)
                        {
                            for (m = 0; m < all / recordList.Count / bei; m++)
                            {
                                for (int p = 0; p < bei; p++)
                                {
                                    get[1 + p * all / bei + m + q * all / recordList.Count / bei, i + lenadd] = (string)recordList[q][i];
                                }
                            }
                        }
                    }
                }
                lenadd += tableModeList.Count;
                bei *= recordList.Count;
            }
            //
            string[,] ta; int t; string pattern; Regex expression; int qa; string[] ms;
            ArrayList kong = new ArrayList(); bool pe = false;
            ta = (string[,])get.Clone();
            ms = new string[get.GetLength(1)];
            for (int fd = 0; fd < get.GetLength(1); fd++)
            {
                pe = false;
                foreach (string k in a[0])
                {
                    pattern = @".*\." + k.Trim();
                    expression = new Regex(pattern);
                    if (k.Trim().Equals("*") || k.Trim().Equals(get[0, fd].Trim()) || expression.IsMatch(get[0, fd].Trim()))
                    {
                        pe = true;
                        break;
                    }
                }
                if (pe)
                {
                    ms[fd] = get[0, fd];
                }
                else
                {
                    ms[fd] = "###";
                }

            }
            if (a[0].Count == 0)
            {
                for (int u = 1; u < all + 1; u++)
                {
                    ms = new string[ta.GetLength(1)];
                    for (int fd = 0; fd < ta.GetLength(1); fd++)
                    {
                        ms[fd] = ta[u, fd];
                    }
                    kong.Add(ms);
                }
            }
            kong.Add(ms);
            //筛选数据
            foreach (string[,] k in a[2])
            {
                ta = (string[,])get.Clone();
                for (int i = 0; i < k.GetLength(0); i++)
                {
                    pattern = @".*\." + k[i, 0].Trim();
                    expression = new Regex(pattern);
                    for (t = 0; t < len; t++)
                    {
                        if (k[i, 0].Trim().Equals(ta[0, t].Trim()) || expression.IsMatch(ta[0, t].Trim()))
                        {
                            break;
                        }
                    }
                    if (t == len)
                    {
                        this.rtn = null;
                        return;
                    }
                    qa = -1;
                    if (k[i, 2].Equals("t"))
                    {
                        if (k[i, 3].Equals("="))
                        {
                            qa = 1;
                        }
                        else if (k[i, 3].Equals(">"))
                        {
                            qa = 2;
                        }
                        else if (k[i, 3].Equals("<"))
                        {
                            qa = 3;
                        }
                        else if (k[i, 3].Equals(">="))
                        {
                            qa = 4;
                        }
                        else if (k[i, 3].Equals("<="))
                        {
                            qa = 5;
                        }
                        else if (k[i, 3].Equals("><") || k[i, 3].Equals("<>"))
                        {
                            qa = 6;
                        }
                    }
                    if (k[i, 2].Equals("f"))
                    {
                        if (k[i, 3].Equals("="))
                        {
                            qa = 6;
                        }
                        else if (k[i, 3].Equals(">"))
                        {
                            qa = 5;
                        }
                        else if (k[i, 3].Equals("<"))
                        {
                            qa = 4;
                        }
                        else if (k[i, 3].Equals(">="))
                        {
                            qa = 3;
                        }
                        else if (k[i, 3].Equals("<="))
                        {
                            qa = 2;
                        }
                        else if (k[i, 3].Equals("><") || k[i, 3].Equals("<>"))
                        {
                            qa = 1;
                        }
                    }
                    bool jjl = false; string jel = ""; int y;
                    for (int u = 1; u < all + 1; u++)
                    {
                        jjl = false;
                        for (y = 0; y < len; y++)
                        {
                            pattern = @".*\." + k[i, 1].Trim();
                            expression = new Regex(pattern);
                            if (expression.IsMatch(ta[0, y].Trim()) || k[i, 1].Trim() == ta[0, y].Trim())
                            {
                                jel = k[i, 1];
                                k[i, 1] = ta[u, y];
                                jjl = true;
                                break;
                            }
                        }
                        switch (qa)
                        {
                            case 1:
                                if (!k[i, 1].Trim().Equals(ta[u, t].Trim()))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                            case 2:
                                if (Convert.ToDouble(ta[u, t]) <= Convert.ToDouble(k[i, 1]))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                            case 3:
                                if (Convert.ToDouble(ta[u, t]) >= Convert.ToDouble(k[i, 1]))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                            case 4:
                                if (Convert.ToDouble(ta[u, t]) < Convert.ToDouble(k[i, 1]))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                            case 5:
                                if (Convert.ToDouble(k[i, 1]) > Convert.ToDouble(ta[u, t]))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                            case 6:
                                if (k[i, 1].Equals(ta[u, t]))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                        }
                        if (jjl)
                        {
                            k[i, 1] = jel;
                        }
                    }
                }
                for (int u = 1; u < all + 1; u++)
                {
                    if (!ta[u, 0].Equals("###"))
                    {
                        ms = new string[ta.GetLength(1)];
                        for (int fd = 0; fd < ta.GetLength(1); fd++)
                        {
                            ms[fd] = ta[u, fd];
                        }
                        get[u, 0] = "###";
                        kong.Add(ms);
                    }
                }
            }
            if (a[2].Count == 0)
            {
                for (int u = 1; u < all + 1; u++)
                {
                    ms = new string[ta.GetLength(1)];
                    for (int fd = 0; fd < ta.GetLength(1); fd++)
                    {
                        ms[fd] = ta[u, fd];
                    }
                    kong.Add(ms);
                }
            }
            this.rtn = kong;
        }

        //只有一个条件的查询语句
        public void Select(string tableName, string qua)
        {
            FileOp f = new FileOp();
            Where wh = new Where(qua);
            //获取字段信息
            List<TableMode> tableModeList = new List<TableMode>();
            tableModeList = f.read_table_field(tableName);
            ArrayList rtn = wh.returnList;
            string[,] ta; int t; string pattern; Regex expression; int qa; string[] ms;
            ArrayList kong = new ArrayList();
            //获取表中的记录
            List<List<object>> recordList = new List<List<object>>();
            recordList = f.read_all_record(tableName, tableModeList);
            int all = recordList.Count;
            int len = tableModeList.Count;
            string[,] get = new string[all + 1, len + 1];
            //将字段名列表写到kong中
            string[] po = new string[tableModeList.Count + 1];
            for (int r = 0; r < tableModeList.Count; r++)
            {
                po[r] = tableModeList[r].getFieldName();
            }
            kong.Add(po);
            //将tableModeList和recordList写入get数组中
            for (int i = 0; i < all; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    get[i + 1, j] = recordList[i][j].ToString();
                }
                get[i + 1, len] = (i + 1).ToString();
            }
            for (int i = 0; i < tableModeList.Count; i++)
            {
                get[0, i] = tableModeList[i].getFieldName();
            }
            ta = (string[,])get.Clone();
            //筛选数据
            foreach (string[,] k in rtn)
            {
                for (int i = 0; i < k.GetLength(0); i++)
                {
                    pattern = @".*\." + k[i, 0].Trim();
                    expression = new Regex(pattern);
                    for (t = 0; t < len - 1; t++)
                    {
                        if (k[i, 0].Trim().Equals(ta[0, t].Trim()) || expression.IsMatch(ta[0, t].Trim()))
                        {
                            break;
                        }
                    }
                    if (t == len - 1)
                    {
                        this.rtn = null;
                        return;
                    }
                    qa = -1;
                    if (k[i, 2].Equals("t"))
                    {
                        if (k[i, 3].Equals("="))
                        {
                            qa = 1;
                        }
                        else if (k[i, 3].Equals(">"))
                        {
                            qa = 2;
                        }
                        else if (k[i, 3].Equals("<"))
                        {
                            qa = 3;
                        }
                        else if (k[i, 3].Equals(">="))
                        {
                            qa = 4;
                        }
                        else if (k[i, 3].Equals("<="))
                        {
                            qa = 5;
                        }
                        else if (k[i, 3].Equals("><") || k[i, 3].Equals("<>"))
                        {
                            qa = 6;
                        }
                    }
                    if (k[i, 2].Equals("f"))
                    {
                        if (k[i, 3].Equals("="))
                        {
                            qa = 6;
                        }
                        else if (k[i, 3].Equals(">"))
                        {
                            qa = 5;
                        }
                        else if (k[i, 3].Equals("<"))
                        {
                            qa = 4;
                        }
                        else if (k[i, 3].Equals(">="))
                        {
                            qa = 3;
                        }
                        else if (k[i, 3].Equals("<="))
                        {
                            qa = 2;
                        }
                        else if (k[i, 3].Equals("><") || k[i, 3].Equals("<>"))
                        {
                            qa = 1;
                        }
                    }
                    for (int u = 1; u < all + 1; u++)
                    {
                        switch (qa)
                        {
                            case 1:
                                if (!k[i, 1].Trim().Equals(ta[u, t].Trim()))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                            case 2:
                                if (Convert.ToDouble(ta[u, t]) <= Convert.ToDouble(k[i, 1]))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                            case 3:
                                if (Convert.ToDouble(ta[u, t]) >= Convert.ToDouble(k[i, 1]))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                            case 4:
                                if (Convert.ToDouble(ta[u, t]) < Convert.ToDouble(k[i, 1]))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                            case 5:
                                if (Convert.ToDouble(k[i, 1]) > Convert.ToDouble(ta[u, t]))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                            case 6:
                                if (k[i, 1].Equals(ta[u, t]))
                                {
                                    ta[u, 0] = "###";
                                }
                                break;
                        }
                    }
                }
                for (int u = 1; u < all + 1; u++)
                {
                    if (!ta[u, 0].Equals("###"))
                    {
                        ms = new string[ta.GetLength(1)];
                        for (int fd = 0; fd < ta.GetLength(1); fd++)
                        {
                            ms[fd] = ta[u, fd];
                        }
                        get[u, 0] = "###";
                        //将有效的记录信息添加到kong中
                        kong.Add(ms);
                    }
                }
            }
            if (qua.Equals(""))
            {
                for (int u = 1; u < all + 1; u++)
                {
                    ms = new string[ta.GetLength(1)];
                    for (int fd = 0; fd < ta.GetLength(1); fd++)
                    {
                        ms[fd] = ta[u, fd];
                    }
                    kong.Add(ms);
                }
            }
            this.rtn = kong;
        }
    }
}
