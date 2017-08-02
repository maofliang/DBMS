using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    class DML
    {
        FileOp f = new FileOp();

        //插入多条记录
        public bool insert(string tableName1, List<TableMode> tableModeList1, List<List<object>> recordList1)
        {
            for(int i=0;i<recordList1.Count;i++)
            {
                f.insert_record(tableName1, tableModeList1, recordList1[i]);
            }
            return true;
        }

        //删除记录
        public bool delete(string tableName1, int[] posList1)
        {
            for (int i = 0; i < posList1.Length; i++)
            {
                f.delete_index(tableName1, posList1[i]);
                for (int j = i; j < posList1.Length; j++)
                {
                    if (posList1[j] > posList1[i])
                    {
                        posList1[j]--;
                    }
                }
            }
            return true;
        }

        //修改记录
        public bool update(string tableName1, List<TableMode> tableModeList1, int[] posList1, List<List<object>> recordNewList1)
        {
            //先删除符合条件的记录
            for (int i = 0; i < posList1.Length; i++)
            {
                f.delete_index(tableName1, posList1[i]);
                for (int j = i; j < posList1.Length; j++)
                {
                    if (posList1[j] > posList1[i])
                    {
                        posList1[j]--;
                    }
                }
            }
            //再将修改过的记录写入
            for (int t = 0; t < recordNewList1.Count; t++)
            {
                f.insert_record(tableName1, tableModeList1, recordNewList1[t]);
            }
            return true;
        }
    }
}
