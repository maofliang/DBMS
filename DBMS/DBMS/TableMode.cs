using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS
{
    class TableMode
    {
        private char[] fieldName = new char[64]; //字段名
        private char[] fieldType = new char[8]; //字段类型
        private int fieldLength = 0; //字段长度
        private char[] notNull = new char[1] { 'f' }; //该字段是否允许为空
        private char[] isKey = new char[1] { 'f' }; //该字段是否为主键

        public void setFieldName(string fieldName1)
        {
            //将String类型的字段名保存为char[]类型
            Array.Copy(fieldName1.ToCharArray(), fieldName, fieldName1.ToCharArray().Length);
        }

        public string getFieldName()
        {
            //将char[]类型的字段名转换为String类型
            return new string(fieldName).Replace("\0", "");
        }

        public void setFieldType(string fieldType1)
        {
            //将String类型的字段名保存为char[]类型
            Array.Copy(fieldType1.ToCharArray(), fieldType, fieldType1.ToCharArray().Length);
        }

        public string getFieldType()
        {
            //将char[]类型的字段名转换为String类型
            return new string(fieldType).Replace("\0", "");
        }

        public void setFieldLength(int fieldLength1)
        {
            //设置字段长度
            fieldLength = fieldLength1;
        }

        public int getFieldLength()
        {
            //获取字段长度
            return fieldLength;
        }

        public void setNotNull(char[] notNull1)
        {
            //设置是否允许为空
            this.notNull = notNull1;
        }

        public char[] getNotNull()
        {
            //获取是否允许为空
            return notNull;
        }

        public void setIsKey(char[] isKey1)
        {
            //设置是否为主键
            this.isKey = isKey1;
        }

        public char[] getIsKey()
        {
            //获取是否为主键
            return isKey;
        }
    }
}
