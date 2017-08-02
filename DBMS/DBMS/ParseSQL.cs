using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;

namespace DBMS
{
    class ParseSQL
    {
        public ArrayList selectr = new ArrayList();

        //对sql语句进行分割
        public string[][] parseset(string set)
        {
            Regex r1 = new Regex(@",");
            string[] get = r1.Split(set);
            string[][] value = new string[get.Length][];
            Regex r2 = new Regex(@"=");
            int i = 0;
            foreach (string s in get)
            {
                value[i] = r2.Split(s);
                i++;
            }
            return value;
        }
        
        //语法分析
        public bool parse(string sql)
        {
            try
            {
                FileOp f = new FileOp();

                sql = sql.ToLower();
                string tableName;
                string state = null;
                ArrayList value = new ArrayList();
                //拆分语句
                Regex r1 = new Regex(@"( )+");
                sql = r1.Replace(sql, " ");
                string[] para = sql.Split(new char[] { ' ' });
                string op = para[0];
                
                //创建表
                if (op.Equals("create"))
                {
                    DDL ddl = new DDL();
                    //拆分语句
                    string[] group, ech;
                    string pattern = @"create\s+table\s+([^\s]+)\s*\(\s*(.+)\s*\)";
                    Regex expression = new Regex(pattern);
                    Match m = expression.Match(sql);
                    string tbName = m.Groups[1].ToString();
                    string inf = m.Groups[2].ToString();
                    pattern = @",";
                    expression = new Regex(pattern);
                    group = expression.Split(inf);
                    pattern = @"\s+";
                    expression = new Regex(pattern);
                    //新建字段列表
                    List<TableMode> tableModeList = new List<TableMode>();
                    //保存所有字段名
                    string[] fieldNameList = new string[group.Length];
                    for (int i = 0; i < group.Length; i++)
                    {
                        TableMode tableMode = new TableMode();
                        ech = expression.Split(group[i]);
                        fieldNameList[i] = ech[0];
                        //设置字段名
                        tableMode.setFieldName(ech[0]);
                        if (ech.Length < 2) continue;
                        //设置字段类型
                        tableMode.setFieldType(ech[1]);
                        if (ech.Length < 3) continue;
                        //设置字段长度
                        tableMode.setFieldLength(Convert.ToInt32(ech[2]));
                        if (ech.Length < 4) continue;
                        //设置notNull
                        char[] notNull = new char[1];
                        if (ech[3].Equals("true")) notNull[0] = 't';
                        else notNull[0] = 'f';
                        tableMode.setNotNull(notNull);
                        if (ech.Length < 5) continue;
                        //设置isKey
                        char[] isKey = new char[1];
                        if (ech[4].Equals("true")) isKey[0] = 't';
                        else isKey[0] = 'f';
                        tableMode.setIsKey(isKey);
                        tableModeList.Add(tableMode);
                    }
                    //检测字段名是否重复
                    if (IsRepeat(fieldNameList))
                    {
                        return false;
                    }
                    return ddl.create(tbName, tableModeList);
                }
                //编辑表字段
                else if (op.Equals("edit"))
                {
                    DDL ddl = new DDL();
                    //拆分语句
                    string pattern = @"edit\s+table\s+([^\s]+)\s*\(\s*(.+)\s*\)";
                    Regex expression = new Regex(pattern);
                    Match m = expression.Match(sql);
                    string tbName = m.Groups[1].ToString();
                    string inf = m.Groups[2].ToString();
                    pattern = @"\s+";
                    expression = new Regex(pattern);
                    //设置字段信息
                    TableMode tableMode = new TableMode();
                    string[] ech = expression.Split(inf);
                    tableMode.setFieldName(ech[0]);
                    if (ech.Length >= 2)
                    {
                        tableMode.setFieldType(ech[1]);
                    }
                    if (ech.Length >= 3)
                    {
                        tableMode.setFieldLength(int.Parse(ech[2]));
                    }
                    if (ech.Length >= 4)
                    {
                        char[] notNull = new char[1];
                        if (ech[3].Equals("true")) notNull[0] = 't';
                        else notNull[0] = 'f';
                        tableMode.setNotNull(notNull);
                    }
                    if (ech.Length >= 5)
                    {
                        char[] isKey = new char[1];
                        if (ech[4].Equals("true")) isKey[0] = 't';
                        else isKey[0] = 'f';
                        tableMode.setIsKey(isKey);
                    }
                    return ddl.edit(tbName, tableMode);
                }
                //修改表名
                else if (op.Equals("rename"))
                {
                    DDL ddl = new DDL();
                    //拆分语句
                    string pattern = @"rename\s+table\s+([^\s]+)\s+([^\s]+)";
                    Regex expression = new Regex(pattern);
                    Match m = expression.Match(sql);
                    string oldName = m.Groups[1].ToString();
                    string newName = m.Groups[2].ToString();
                    return ddl.rename(oldName, newName);
                }
                //删除表
                else if (op.Equals("drop"))
                {
                    DDL ddl = new DDL();
                    //拆分语句
                    string pattern = @"drop\s+table\s+([^\s]+)";
                    Regex expression = new Regex(pattern);
                    Match m = expression.Match(sql);
                    string tbName = m.Groups[1].ToString();
                    ddl.drop(tbName);
                    return true;
                }
                //插入记录
                else if (op.Equals("insert"))
                {
                    if (!para[1].Equals("into"))
                        return false;
                    if (!para[3].Equals("values"))
                        return false;
                    DML dml = new DML();
                    tableName = para[2];
                    //拆分语句
                    string pattern1 = @"\([^()]*\)";
                    MatchCollection matches = Regex.Matches(sql, pattern1);
                    for (int i = 0; i < matches.Count; i++)
                    {
                        Match match = matches[i];
                        state = match.Value;
                        state = state.Substring(1, state.Length - 2);
                        state = r1.Replace(state, "");
                        string[] values = state.Split(new char[] { ',' });
                        value.Add(values);
                    }
                    //获取所有字段
                    List<TableMode> tableModeList = new List<TableMode>();
                    tableModeList = f.read_table_field(tableName);
                    //object[,] recordList = new object[value.Count, tableModeList.Count];
                    List<List<object>> recordList = new List<List<object>>();
                    string sup;
                    foreach (string[] rec in value)
                    {
                        List<object> record = new List<object>();
                        for (int i = 0; i < tableModeList.Count; i++)
                        {
                            if (rec.Length <= i)
                            {
                                sup = "0";
                            }
                            else
                            {
                                sup = rec[i];
                            }
                            if (tableModeList[i].getFieldType().Equals("int"))
                            {
                                record.Add(Convert.ToInt32(sup));
                            }
                            if (tableModeList[i].getFieldType().Equals("long"))
                            {
                                record.Add(Convert.ToInt64(sup));
                            }
                            if (tableModeList[i].getFieldType().Equals("double"))
                            {
                                record.Add(Convert.ToDouble(sup));
                            }
                            if (tableModeList[i].getFieldType().Equals("char") || tableModeList[i].getFieldType().Equals("varchar"))
                            {
                                record.Add(Convert.ToString(sup));
                            }
                        }
                        recordList.Add(record);
                    }
                    dml.insert(tableName, tableModeList, recordList);
                    return true;
                }
                //删除记录
                else if (op.Equals("delete"))
                {
                    if (!para[1].Equals("from"))
                        return false;
                    if (!para[3].Equals("where"))
                        return false;
                    DML dml = new DML();
                    tableName = para[2];
                    //拆分语句
                    string pattern2 = @"where[\s\S]*";
                    MatchCollection matches = Regex.Matches(sql, pattern2);
                    for (int i = 0; i < matches.Count; i++)
                    {
                        Match match = matches[i];
                        state = match.Value;
                        state = state.Substring(5, state.Length - 5);
                    }
                    Where where = new Where(state);
                    DQL dql = new DQL();
                    dql.Select(tableName, state);
                    int j = 0;
                    //获取需要删除的记录的索引的位置
                    int[] allpos = new int[dql.rtn.Count - 1];
                    foreach (string[] p in dql.rtn)
                    {
                        if (j != 0)
                        {
                            allpos[j - 1] = int.Parse(p[p.Length - 1]);
                        }
                        j++;
                    }
                    value = where.returnList;
                    dml.delete(tableName, allpos);
                    return true;
                }
                //修改表中数据
                else if (op.Equals("update"))
                {
                    DML dml = new DML();
                    tableName = para[1];
                    //拆分语句
                    string pattern3 = @"\([\s\S]*\)";
                    MatchCollection matches = Regex.Matches(sql, pattern3);
                    for (int i = 0; i < matches.Count; i++)
                    {
                        Match match = matches[i];
                        state = match.Value;
                        state = state.Substring(1, state.Length - 2);
                    }
                    string sql1 = state;
                    string pattern5 = @"set[\s\S]*where";
                    MatchCollection matches2 = Regex.Matches(sql1, pattern5);
                    for (int i = 0; i < matches2.Count; i++)
                    {
                        Match match = matches2[i];
                        state = match.Value;
                        state = state.Substring(3, state.Length - 8);
                    }
                    string[][] s = parseset(state);
                    value.Add(s);
                    string pattern4 = @"where[\s\S]*";
                    MatchCollection matches1 = Regex.Matches(sql1, pattern4);
                    for (int i = 0; i < matches1.Count; i++)
                    {
                        Match match = matches1[i];
                        state = match.Value;
                        state = state.Substring(5, state.Length - 5);
                    }
                    Where wh = new Where(state);
                    DQL dql = new DQL();
                    dql.Select(tableName, state);
                    int[] allpos = new int[dql.rtn.Count - 1];
                    //获取所有字段
                    List<TableMode> tableModeList = new List<TableMode>();
                    tableModeList = f.read_table_field(tableName);
                    //
                    int j = 0;
                    List<List<object>> recordNewList = new List<List<object>>();
                    //记录需要修改的字段的位置
                    ArrayList posField = new ArrayList();
                    foreach (string[] p in dql.rtn)
                    {
                        if (j != 0)
                        {
                            allpos[j - 1] = int.Parse(p[p.Length - 1]);
                            foreach (int[] n in posField)
                            {
                                p[n[0]] = s[n[1]][1].Trim();
                            }
                            List<object> recordNew = new List<object>();
                            for (int i = 0; i < tableModeList.Count; i++)
                            {
                                if (tableModeList[i].getFieldType().Equals("int"))
                                {
                                    recordNew.Add(Convert.ToInt32(p[i]));
                                }
                                if (tableModeList[i].getFieldType().Equals("long"))
                                {
                                    recordNew.Add(Convert.ToInt64(p[i]));
                                }
                                if (tableModeList[i].getFieldType().Equals("double"))
                                {
                                    recordNew.Add(Convert.ToDouble(p[i]));
                                }
                                if (tableModeList[i].getFieldType().Equals("char") || tableModeList[i].getFieldType().Equals("varchar"))
                                {
                                    recordNew.Add(Convert.ToString(p[i]));
                                }
                            }
                            recordNewList.Add(recordNew);
                        }
                        else
                        {
                            //寻找要修改的字段的列
                            for (int h = 0; h < p.Length - 1; h++)
                            {
                                int[] m = new int[2];
                                for (int i = 0; i < s.Length; i++)
                                {
                                    if (p[h].Equals(s[i][0].Trim()))
                                    {
                                        m[0] = h;
                                        m[1] = i;
                                        posField.Add(m);
                                    }
                                }
                            }
                        }
                        j++;
                    }
                    return dml.update(tableName, tableModeList, allpos, recordNewList);
                }
                //复杂查询
                else if (op.Equals("select"))
                {
                    DQL dql = new DQL();
                    //拆分语句
                    ArrayList[] get = new ArrayList[3];
                    string temp;
                    string[] tempb;
                    get[0] = new ArrayList();
                    get[1] = new ArrayList();
                    get[2] = new ArrayList();
                    string pattern = @"select\s+([^\s]+)\s+from\s+([^\s]+)";
                    Regex expression = new Regex(pattern);
                    Match m = expression.Match(sql);
                    for (int i = 1; i < 3; i++)
                    {
                        temp = m.Groups[i].ToString();
                        pattern = @",";
                        expression = new Regex(pattern);
                        tempb = expression.Split(temp);
                        for (int j = 0; j < tempb.Length; j++)
                        {
                            get[i - 1].Add(tempb[j]);
                        }
                    }
                    pattern = @"where (.*)";
                    expression = new Regex(pattern);
                    Where wh = new Where(expression.Match(sql).Groups[1].ToString());
                    get[2] = wh.returnList;
                    dql.Select(get);
                    if (dql.rtn != null)
                    {
                        this.selectr = dql.rtn;
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool IsRepeat(string[] yourValue)
        {
            bool value = false;
            for (int i = 0; i < yourValue.Length; i++)
            {
                for (int j = 1; j < yourValue.Length; j++)
                {
                    if (i != j && yourValue[i].Equals(yourValue[j]))
                    {
                        value = true;
                    }
                }
            }
            return value;
        }
    }
}
