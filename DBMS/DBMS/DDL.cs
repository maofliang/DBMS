using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    class DDL
    {
        FileOp f = new FileOp();

        //新建表
        public bool create(string tableName1, List<TableMode> tableModeList1)
        {
            if(f.create_table_files(tableName1)==1)
            {
                if (f.write_table_field(tableName1, tableModeList1) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //修改表字段
        public bool edit(string tableName1,TableMode tableMode1)
        {
            return true;
        }

        //修改表名
        public bool rename(string oldName1,string newName1)
        {
            if(f.rename_table(oldName1, newName1)==1)
            {
                return true;
            }
            return false;
        }

        //删除表
        public bool drop(string tableName1)
        {
            if (f.delete_table_files(tableName1) == 1)
            {
                return true;
            }
            return false;
        }
    }
}
