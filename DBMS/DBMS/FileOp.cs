using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DBMS
{
    class FileOp
    {
        public DirectoryInfo db; //数据库文件夹
        private string path = "../data"; //数据库路径

        public FileOp()
        {
            if (!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
            }
            this.db = new DirectoryInfo(this.path);
        }

        private byte[] get_byte(object data)//将文件转换成二进制流进行存储
        {
            string dataType = data.GetType().ToString();
            if (dataType.Equals("System.Double"))
            {
                return BitConverter.GetBytes((double)data);
            }
            if (dataType.Equals("System.Int32"))
            {
                return BitConverter.GetBytes((int)data);
            }
            if (dataType.Equals("System.Int64"))
            {
                return BitConverter.GetBytes((long)data);
            }
            if (dataType.Equals("System.String"))
            {
                return Encoding.UTF8.GetBytes((string)data);
            }
            if (dataType.Equals("System.Char[]"))
            {
                return Encoding.UTF8.GetBytes((char[])data);
            }
            return new byte[0];
        }

        //获取数据库中所有表的表名
        public List<string> get_table_names()
        {
            List<string> list = new List<string>();
            FileInfo[] fil = this.db.GetFiles("*.dat");
            foreach (FileInfo f in fil)
            {
                list.Add(f.Name.Substring(0, f.Name.LastIndexOf(".")));
            }
            return list;
        }

        //创建数据库相关文件
        public int create_table_files(string name)
        {
            string dbf_path = this.path + "/" + name + ".dbf";
            string dat_path = this.path + "/" + name + ".dat";
            FileStream fs_dbf = new FileStream(dbf_path, FileMode.Create, FileAccess.Write);
            fs_dbf.Close();
            FileStream fs_dat = new FileStream(dat_path, FileMode.Create, FileAccess.Write);
            fs_dat.Close();
            return 1;
        }

        //更改表名
        public int rename_table(string oldname, string newname)
        {
            File.Move(this.path + "/" + oldname + ".dbf", this.path + "/" + newname + ".dbf");
            File.Move(this.path + "/" + oldname + ".dat", this.path + "/" + newname + ".dat");
            return 1;
        }

        //清空表内容
        public int clear_table(string name)
        {
            string dat_path = this.path + "/" + name + ".dat";
            File.Delete(dat_path);
            FileStream fs_dat = new FileStream(dat_path, FileMode.Create, FileAccess.Write);
            fs_dat.Close();
            return 1;
        }

        //删除数据库相关文件
        public int delete_table_files(string name)
        {
            File.Delete(this.path + "/" + name + ".dat");
            File.Delete(this.path + "/" + name + ".dbf");
            return 1;
        }

        //保存字段数据
        public int write_table_field(string name, List<TableMode> tablemodelist)
        {
            byte[] databyte;
            string dbf_path = this.path + "/" + name + ".dbf";
            FileStream fs_dbf = new FileStream(dbf_path, FileMode.Create, FileAccess.Write);
            //写字段数
            databyte = get_byte(tablemodelist.Count);
            fs_dbf.Seek(0, SeekOrigin.Begin);
            fs_dbf.Write(databyte, 0, databyte.Length);
            int i;
            for(i=0;i<tablemodelist.Count;i++)
            {
                //写字段名
                databyte = get_byte(tablemodelist[i].getFieldName());
                fs_dbf.Seek((i + 1) * 128, SeekOrigin.Begin);
                fs_dbf.Write(databyte, 0, databyte.Length);
                //写字段类型
                databyte = get_byte(tablemodelist[i].getFieldType());
                fs_dbf.Seek((i + 1) * 128 + 64, SeekOrigin.Begin);
                fs_dbf.Write(databyte, 0, databyte.Length);
                //写字段长度
                databyte = get_byte(tablemodelist[i].getFieldLength());
                fs_dbf.Seek((i + 1) * 128 + 72, SeekOrigin.Begin);
                fs_dbf.Write(databyte, 0, databyte.Length);
                //写是否允许为空
                databyte = get_byte(tablemodelist[i].getNotNull());
                fs_dbf.Seek((i + 1) * 128 + 76, SeekOrigin.Begin);
                fs_dbf.Write(databyte, 0, databyte.Length);
                //写是否为主键
                databyte = get_byte(tablemodelist[i].getIsKey());
                fs_dbf.Seek((i + 1) * 128 + 77, SeekOrigin.Begin);
                fs_dbf.Write(databyte, 0, databyte.Length);
            }
            fs_dbf.Close();
            return 1;
        }

        //读取字段数据
        public List<TableMode> read_table_field(string name)
        {
            byte[] databyte;
            List<TableMode> tableModeList = new List<TableMode>();
            string dbf_path = this.path + "/" + name + ".dbf";
            FileStream fs_dbf = new FileStream(dbf_path, FileMode.Open, FileAccess.Read);
            //获取字段数
            databyte = new byte[4];
            fs_dbf.Seek(0, SeekOrigin.Begin);
            fs_dbf.Read(databyte, 0, databyte.Length);
            int count = System.BitConverter.ToInt32(databyte, 0);
            int i;
            for(i=0;i< count;i++)
            {
                TableMode tableMode = new TableMode();
                //读字段名
                databyte = new byte[64];
                fs_dbf.Seek((i + 1) * 128, SeekOrigin.Begin);
                fs_dbf.Read(databyte, 0, databyte.Length);
                tableMode.setFieldName(Encoding.UTF8.GetString(databyte).Replace("\0", ""));
                //读字段类型
                databyte = new byte[8];
                fs_dbf.Seek((i + 1) * 128 + 64, SeekOrigin.Begin);
                fs_dbf.Read(databyte, 0, databyte.Length);
                tableMode.setFieldType(Encoding.UTF8.GetString(databyte).Replace("\0", ""));
                //读字段长度
                databyte = new byte[4];
                fs_dbf.Seek((i + 1) * 128 + 72, SeekOrigin.Begin);
                fs_dbf.Read(databyte, 0, databyte.Length);
                tableMode.setFieldLength(System.BitConverter.ToInt32(databyte, 0));
                //读是否允许为空
                databyte = new byte[1];
                fs_dbf.Seek((i + 1) * 128 + 76, SeekOrigin.Begin);
                fs_dbf.Read(databyte, 0, databyte.Length);
                tableMode.setNotNull(Encoding.UTF8.GetChars(databyte));
                //读是否为主键
                databyte = new byte[1];
                fs_dbf.Seek((i + 1) * 128 + 77, SeekOrigin.Begin);
                fs_dbf.Read(databyte, 0, databyte.Length);
                tableMode.setIsKey(Encoding.UTF8.GetChars(databyte));
                //将tableMode写入tableModeList
                tableModeList.Add(tableMode);
            }
            fs_dbf.Close();
            return tableModeList;
        }

        //读取所有记录
        public List<List<object>> read_all_record(string name, List<TableMode> tableModeList)
        {
            byte[] databyte;
            List<List<object>> recordlist = new List<List<object>>();
            string dat_path = this.path + "/" + name + ".dat";
            FileStream fs_dat = new FileStream(dat_path, FileMode.Open, FileAccess.Read);
            //获取字段数
            databyte = new byte[4];
            fs_dat.Seek(0, SeekOrigin.Begin);
            fs_dat.Read(databyte, 0, databyte.Length);
            //获取记录数
            int count = System.BitConverter.ToInt32(databyte, 0);
            int i, j;
            for(i=0;i< count;i++)
            {
                List<object> record = new List<object>();
                //从索引中读取记录的位置
                databyte = new byte[4];
                fs_dat.Seek(1024 + i * 4, SeekOrigin.Begin);
                fs_dat.Read(databyte, 0, databyte.Length);
                int pos = System.BitConverter.ToInt32(databyte, 0);
                int l = 0;
                //读取一条记录
                for (j = 0; j < tableModeList.Count; j++)
                {
                    //读取记录第j列的值
                    databyte = new byte[tableModeList[j].getFieldLength()];
                    fs_dat.Seek(pos * 1024 + l, SeekOrigin.Begin);
                    fs_dat.Read(databyte, 0, databyte.Length);
                    string type = tableModeList[j].getFieldType().ToString();
                    if (type.Equals("int"))
                    {
                        int dataInt = System.BitConverter.ToInt32(databyte, 0);
                        record.Add(dataInt);
                    }
                    else if (type.Equals("long"))
                    {
                        long dataLong = System.BitConverter.ToInt64(databyte, 0);
                        record.Add(dataLong);
                    }
                    else if (type.Equals("double"))
                    {
                        double dataDouble = System.BitConverter.ToDouble(databyte, 0);
                        record.Add(dataDouble);
                    }
                    else
                    {
                        record.Add(new string(Encoding.UTF8.GetChars(databyte)).Replace("\0", ""));//record.Add(Encoding.UTF8.GetString(databyte).Replace("\0", ""));
                    }
                    l += tableModeList[j].getFieldLength();
                }
                recordlist.Add(record);
            }
            fs_dat.Close();
            return recordlist;
        }

        //写一条记录的内容
        public int write_record(string name, List<TableMode> tableModeList, List<Object> data)
        {
            byte[] databyte;
            string dat_path = this.path + "/" + name + ".dat";
            FileStream fs_dat = new FileStream(dat_path, FileMode.Open);
            //读取插入位置
            databyte = new byte[4];
            fs_dat.Seek(4, SeekOrigin.Begin);
            fs_dat.Read(databyte, 0, databyte.Length);
            int pos = System.BitConverter.ToInt32(databyte, 0);
            //读取此记录还未插入时的记录数
            fs_dat.Seek(0, SeekOrigin.Begin);
            fs_dat.Read(databyte, 0, databyte.Length);
            int num = System.BitConverter.ToInt32(databyte, 0);
            //写插入一条记录后的记录数
            num++;
            fs_dat.Seek(0, SeekOrigin.Begin);
            databyte = get_byte(num);
            fs_dat.Write(databyte, 0, databyte.Length);
            //插入一条记录
            if (pos == 0)
            {
                pos = num+4;
            }
            else
            {
                fs_dat.Seek(pos * 1024, SeekOrigin.Begin);
                fs_dat.Read(databyte, 0, databyte.Length);
                fs_dat.Seek(4, SeekOrigin.Begin);
                fs_dat.Write(databyte, 0, databyte.Length);
            }
            int i, l = 0,j;
            for (i = 0; i < data.Count; i++)
            {
                fs_dat.Seek(pos * 1024 + l, SeekOrigin.Begin);
                databyte = get_byte(data[i]);
                fs_dat.Write(databyte, 0, databyte.Length);

                if(databyte.Length< tableModeList[i].getFieldLength())
                {
                    int a1 = databyte.Length, b1 = tableModeList[i].getFieldLength() - databyte.Length,c1;
                    byte[] tianc;
                    string ttt = "";
                    for (c1 = 0; c1 < b1; c1++)
                        ttt = ttt + "\0";
                    fs_dat.Seek(pos * 1024 + l+a1, SeekOrigin.Begin);
                    tianc = get_byte(ttt);
                    fs_dat.Write(tianc, 0, b1);
                }

                l += tableModeList[i].getFieldLength();
            }
            fs_dat.Close();
            //返回插入记录的位置
            return pos;
        }

        //往表中插入一条记录，根据主键插入，first初值为0，总记录数+1
        public int insert_record(string name, List<TableMode> tableModeList, List<Object> data)
        {
            byte[] databyte;
            string dat_path = this.path + "/" + name + ".dat";
            FileStream fs_dat = new FileStream(dat_path, FileMode.Open);
            //读取记录数
            databyte = new byte[4];
            fs_dat.Seek(0, SeekOrigin.Begin);
            fs_dat.Read(databyte, 0, databyte.Length);
            int num = System.BitConverter.ToInt32(databyte, 0);
            //这里的index从0开始
            int index = num, first = 0, end = num;
            List<int> primary = new List<int>();
            List<int> primary1 = new List<int>();
            int i, l = 0, n = tableModeList.Count;
            for (i = 0; i < n; i++)
            {
                if (tableModeList[i].getIsKey()[0]=='t')
                {
                    primary.Add(i);
                    primary1.Add(l);
                }
                l += tableModeList[i].getFieldLength();
            }
            //
            int i1 = 0, n1 = primary.Count;
            if (n1 != 0)
            {
                int pos=0;
                int cp;
                while (first != end)
                {
                    if (i1 == 0)
                    { 
                        index = (end + first - 1) / 2;
                        databyte = new byte[4];
                        fs_dat.Seek(1024 + index * 4, SeekOrigin.Begin);
                        fs_dat.Read(databyte, 0, databyte.Length);
                        pos = System.BitConverter.ToInt32(databyte, 0);
                    }
                    databyte = new byte[tableModeList[primary[i1]].getFieldLength()];
                    fs_dat.Seek(pos * 1024 + primary1[i1], SeekOrigin.Begin);
                    fs_dat.Read(databyte, 0, databyte.Length);
                    cp = compare(data[primary[i1]], databyte, tableModeList[primary[i1]].getFieldType().ToString());
                    if (cp == 0)
                    {
                        i1++;
                        if (i1 == n1)
                        {
                            fs_dat.Close();
                            return -1;
                        }
                    }
                    else if (cp == 1)
                    {
                        end = index;
                        i1 = 0;
                    }
                    else
                    {
                        first = index + 1;
                        i1 = 0;
                    }
                }
                index = first;
            }
            fs_dat.Close();
            //
            int pos2 = write_record(name, tableModeList, data);
            fs_dat = new FileStream(dat_path, FileMode.Open);
            index--;
            for (i = num-1; i>index; i--)
            {
                databyte = new byte[4];
                fs_dat.Seek(1024 + i * 4, SeekOrigin.Begin);
                fs_dat.Read(databyte, 0, databyte.Length);
                fs_dat.Seek(1024 + (i + 1) * 4, SeekOrigin.Begin);
                fs_dat.Write(databyte, 0, databyte.Length);
            }
            index++;
            //
            fs_dat.Seek(1024 + index * 4, SeekOrigin.Begin);
            databyte = get_byte(pos2);
            fs_dat.Write(databyte, 0, databyte.Length);
            fs_dat.Close();
            //返回值从1开始
            return index+1;
        }

        //比较字符的顺序
        public int compare(Object data1, byte[] databyte, string type)
        {
            if (type.Equals("int"))
            {
                int a = (int)data1;
                int b = System.BitConverter.ToInt32(databyte, 0);
                if (a == b)
                    return 0;
                else if (a < b)
                    return 1;
                else
                    return 2;
            }
            else if (type.Equals("long"))
            {
                long a = (long)data1;
                long b = System.BitConverter.ToInt64(databyte, 0);
                if (a == b)
                    return 0;
                else if (a < b)
                    return 1;
                else
                    return 2;
            }
            else if (type.Equals("double"))
            {
                double a = (double)data1;
                double b = System.BitConverter.ToDouble(databyte, 0);
                if (a == b)
                    return 0;
                else if (a < b)
                    return 1;
                else
                    return 2;
            }
            else
            {
                string a = (string)data1;
                string b = new string(Encoding.UTF8.GetChars(databyte)).Replace("\0", "");//Encoding.UTF8.GetString(databyte);
                if (a.Equals(b))
                    return 0;
                else if (a.CompareTo(b) == -1)
                    return 1;
                else
                    return 2;
            }
        }

        //删除一条记录
        public int delete_record(string name,int pos)
        {
            byte[] databyte;
            string dat_path = this.path + "/" + name + ".dat";
            FileStream fs_dat = new FileStream(dat_path, FileMode.Open);
            //获取位置
            databyte = new byte[4];
            fs_dat.Seek(4, SeekOrigin.Begin);
            fs_dat.Read(databyte, 0, databyte.Length);
            int pos1 = System.BitConverter.ToInt32(databyte, 0);
            //获取此记录还未删除时的记录数
            databyte = new byte[4];
            fs_dat.Seek(0, SeekOrigin.Begin);
            fs_dat.Read(databyte, 0, databyte.Length);
            int num = System.BitConverter.ToInt32(databyte, 0);
            //
            num--;
            fs_dat.Seek(0, SeekOrigin.Begin);
            databyte = get_byte(num);
            fs_dat.Write(databyte, 0, databyte.Length);
            //
            if (pos1==0&&pos==num+5)
            {
                ;
            }
            else
            {
                fs_dat.Seek(pos * 1024, SeekOrigin.Begin);
                databyte = get_byte(pos1);
                fs_dat.Write(databyte, 0, databyte.Length);
                //
                fs_dat.Seek(4, SeekOrigin.Begin);
                databyte = get_byte(pos);
                fs_dat.Write(databyte, 0, databyte.Length);
            }
            fs_dat.Close();
            return 1;
        }

        //删除索引，index为索引位置
        public int delete_index(string name, int index)
        {
            byte[] databyte;
            string dat_path = this.path + "/" + name + ".dat";
            FileStream fs_dat = new FileStream(dat_path, FileMode.Open);
            databyte = new byte[4];
            fs_dat.Seek(0, SeekOrigin.Begin);
            fs_dat.Read(databyte, 0, databyte.Length);
            int num = System.BitConverter.ToInt32(databyte, 0);
            //
            databyte = new byte[4];
            fs_dat.Seek(1024 + (index - 1) * 4, SeekOrigin.Begin);
            fs_dat.Read(databyte, 0, databyte.Length);
            int pos = System.BitConverter.ToInt32(databyte, 0);
            //
            fs_dat.Close();
            delete_record(name, pos);
            fs_dat = new FileStream(dat_path, FileMode.Open);
            //
            int i;
            for (i = index; i < num; i++)
            {
                databyte = new byte[4];
                fs_dat.Seek(1024 + i * 4, SeekOrigin.Begin);
                fs_dat.Read(databyte, 0, databyte.Length);
                fs_dat.Seek(1024 + (i - 1) * 4, SeekOrigin.Begin);
                fs_dat.Write(databyte, 0, databyte.Length);
            }
            fs_dat.Close();
            return pos;
        }

        //根据位置读取索引，index从1开始
        public int read_index(string name, int index)
        {
            byte[] databyte;
            string dbf_path = this.path + "/" + name + ".dbf";
            FileStream fs_dbf = new FileStream(dbf_path, FileMode.Open);
            //读取索引，即文件位置
            databyte = new byte[4];
            fs_dbf.Seek(17 * 128 + (index - 1) * 4, SeekOrigin.Begin);
            fs_dbf.Read(databyte, 0, databyte.Length);
            int pos = System.BitConverter.ToInt32(databyte, 0);
            fs_dbf.Close();
            return pos;
        }

        public int field_change(string name, List<TableMode> old1, List<TableMode> new1, List<int> address)
        {
            byte[] databyte;
            string dat_path = this.path + "/" + name + ".dat";
            FileStream fs_dat = new FileStream(dat_path, FileMode.Open);
            databyte = new byte[4];
            fs_dat.Seek(0, SeekOrigin.Begin);
            fs_dat.Read(databyte, 0, databyte.Length);
            int num = System.BitConverter.ToInt32(databyte, 0);
            int i, pos, l, j;
            for (i = 0; i < num; i++)
            {
                databyte = new byte[4];
                fs_dat.Seek(1024 + i * 4, SeekOrigin.Begin);
                fs_dat.Read(databyte, 0, databyte.Length);
                pos = System.BitConverter.ToInt32(databyte, 0);
                l = 0;
                List<object> record = new List<object>();
                record.Add((int)0);
                //
                for (j = 0; j < old1.Count; j++)
                {
                    //读取记录第j列的值
                    databyte = new byte[old1[j].getFieldLength()];
                    fs_dat.Seek(pos * 1024 + l, SeekOrigin.Begin);
                    fs_dat.Read(databyte, 0, databyte.Length);
                    string type = old1[j].getFieldType().ToString();
                    if (type.Equals("int"))
                    {
                        int dataInt = System.BitConverter.ToInt32(databyte, 0);
                        record.Add(dataInt);
                    }
                    else if (type.Equals("long"))
                    {
                        long dataLong = System.BitConverter.ToInt64(databyte, 0);
                        record.Add(dataLong);
                    }
                    else if (type.Equals("double"))
                    {
                        double dataDouble = System.BitConverter.ToDouble(databyte, 0);
                        record.Add(dataDouble);
                    }
                    else
                    {
                        record.Add(new string(Encoding.UTF8.GetChars(databyte)).Replace("\0", "")); //record.Add(Encoding.UTF8.GetString(databyte).Replace("\0", ""));
                    }
                    l += old1[j].getFieldLength();
                }
                //
                l = 0;
                for (j = 0; j < new1.Count; j++)
                {
                    string type = new1[j].getFieldType().ToString();
                    if (type.Equals("int"))
                    {
                        int dataInt = Convert.ToInt32(record[address[j]]);
                        databyte = get_byte(dataInt);
                    }
                    else if (type.Equals("long"))
                    {
                        long dataLong = Convert.ToInt64(record[address[j]]);
                        databyte = get_byte(dataLong);
                    }
                    else if (type.Equals("double"))
                    {
                        double dataDouble = Convert.ToDouble(record[address[j]]);
                        databyte = get_byte(dataDouble);
                    }
                    else
                    {
                        string datastring = record[address[j]].ToString();
                        databyte = get_byte(datastring);
                    }
                    fs_dat.Seek(pos * 1024 + l, SeekOrigin.Begin);
                    fs_dat.Write(databyte, 0, databyte.Length);

                    if (databyte.Length < new1[j].getFieldLength())
                    {
                        int a1 = databyte.Length, b1 = new1[j].getFieldLength() - databyte.Length, c1;
                        byte[] tianc;
                        string ttt = "";
                        for (c1 = 0; c1 < b1; c1++)
                            ttt = ttt + "\0";
                        fs_dat.Seek(pos * 1024 + l + a1, SeekOrigin.Begin);
                        tianc = get_byte(ttt);
                        fs_dat.Write(tianc, 0, b1);
                    }

                    l += new1[j].getFieldLength();
                }
            }
            //
            int flag = 0, last = 0;
            List<int> primary = new List<int>();
            List<int> primary1 = new List<int>();
            l = 0;
            for (i = 0; i < new1.Count; i++)
            {
                if (new1[i].getIsKey()[0] == 't')
                {
                    if (flag == 0)
                    {
                        if (address[i] != 0)
                        {
                            if (old1[address[i]-1].getIsKey()[0] != 't')
                                flag = 1;
                            else
                            {
                                string oldtype = old1[address[i]-1].getFieldType().ToString();
                                string newtype = new1[i].getFieldType().ToString();
                                if (oldtype.Equals("char") || oldtype.Equals("varchar"))
                                {
                                    if ((!newtype.Equals("char")) && (!newtype.Equals("varchar")))
                                        flag = 1;
                                }
                                else
                                {
                                    if (newtype.Equals("char") || newtype.Equals("varchar"))
                                        flag = 1;
                                }
                            }
                            if (address[i] < last)
                                flag = 1;
                            else
                                last = address[i];
                        }
                    }
                    primary.Add(i);
                    primary1.Add(l);
                }
                l += new1[i].getFieldLength();
            }
            //
            if (flag == 1)
            {

                int[] pile;
                int i1, f1;
                int temp;
                byte[] databyte1;
                pile = new int[num];
                for (i = 0; i < num; i++)
                {
                    databyte = new byte[4];
                    fs_dat.Seek(1024 + i * 4, SeekOrigin.Begin);
                    fs_dat.Read(databyte, 0, databyte.Length);
                    pos = System.BitConverter.ToInt32(databyte, 0);
                    pile[i] = pos;
                }
                for (i = 0; i < num; i++)
                {
                    for (j = i + 1; j < num; j++)
                    {
                        i1 = 0;
                        f1 = 0;
                        while (f1 == 0)
                        {
                            databyte = new byte[new1[primary[i1]].getFieldLength()];
                            fs_dat.Seek(pile[i] * 1024 + primary1[i1], SeekOrigin.Begin);
                            fs_dat.Read(databyte, 0, databyte.Length);
                            databyte1 = new byte[new1[primary[i1]].getFieldLength()];
                            fs_dat.Seek(pile[j] * 1024 + primary1[i1], SeekOrigin.Begin);
                            fs_dat.Read(databyte1, 0, databyte.Length);
                            string type = new1[primary[i1]].getFieldType().ToString();
                            if (type.Equals("int"))
                            {
                                int dataInt = System.BitConverter.ToInt32(databyte, 0);
                                int dataInt1 = System.BitConverter.ToInt32(databyte1, 0);
                                if (dataInt > dataInt1)
                                    f1 = 1;
                                else if (dataInt < dataInt1)
                                    f1 = 2;
                            }
                            else if (type.Equals("long"))
                            {
                                long dataLong = System.BitConverter.ToInt64(databyte, 0);
                                long dataLong1 = System.BitConverter.ToInt64(databyte1, 0);
                                if (dataLong > dataLong1)
                                    f1 = 1;
                                else if (dataLong < dataLong1)
                                    f1 = 2;
                            }
                            else if (type.Equals("double"))
                            {
                                double dataDouble = System.BitConverter.ToDouble(databyte, 0);
                                double dataDouble1 = System.BitConverter.ToDouble(databyte1, 0);
                                if (dataDouble > dataDouble1)
                                    f1 = 1;
                                else if (dataDouble < dataDouble1)
                                    f1 = 2;
                            }
                            else
                            {
                                string datastring = new string(Encoding.UTF8.GetChars(databyte)).Replace("\0", "");//Encoding.UTF8.GetString(databyte).Replace("\0", "");
                                string datastring1 = new string(Encoding.UTF8.GetChars(databyte1)).Replace("\0", "");//Encoding.UTF8.GetString(databyte1).Replace("\0", "");
                                if (datastring.CompareTo(datastring1) > 0)
                                    f1 = 1;
                                else if (datastring.CompareTo(datastring1) < 0)
                                    f1 = 2;
                            }
                            if (f1 == 1)
                            {
                                temp = pile[i];
                                pile[i] = pile[j];
                                pile[j] = temp;
                            }
                            else if (f1 == 0)
                            {
                                i1++;
                                if (i1 == primary.Count)
                                    break;
                            }
                        }
                    }
                }
                for (i = 0; i < num; i++)
                {
                    fs_dat.Seek(1024 + i * 4, SeekOrigin.Begin);
                    databyte = get_byte(pile[i]);
                    fs_dat.Write(databyte, 0, databyte.Length);
                }

            }
            fs_dat.Close();
            return 1;
        }
    }
}
