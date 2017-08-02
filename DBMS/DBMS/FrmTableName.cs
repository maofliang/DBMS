using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBMS
{
    public partial class FrmTableName : Form
    {
        FileOp f = new FileOp();

        bool isCreate; //是否为创建表
        bool createFlag = false; //是否已经创建表
        string oldTableName, newTableName; //旧表名，新表名

        public FrmTableName(bool isCreate, string tableName1)
        {
            InitializeComponent();
            this.isCreate = isCreate;
            this.oldTableName = tableName1;
        }

        private void FrmTableName_Load(object sender, EventArgs e)
        {
            if (isCreate==true)
            {
                this.Text = "新建表";
            }
            else
            {
                this.Text = "修改表名";
                txtSetTableName.Text = oldTableName;
            }
        }

        //点击确定按钮
        private void btnSetTableName_Click(object sender, EventArgs e)
        {
            newTableName = txtSetTableName.Text;
            if(newTableName=="")
            {
                MessageBox.Show("表名不能为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //新建表
            if (isCreate == true)
            {
                List<string> tableNameList = f.get_table_names();
                foreach (string tableName in tableNameList)
                {
                    if (newTableName.Equals(tableName))
                    {
                        MessageBox.Show("表名已存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                createTableFile();
                this.Close();
            }
            //重命名
            else
            {
                //新旧表名相同，不需要改动
                if (newTableName.Equals(oldTableName))
                {
                    this.Close();
                }
                //新旧表名不同，需要更改表名
                else
                {
                    List<string> tableNameList = f.get_table_names();
                    foreach (string tableName in tableNameList)
                    {
                        if (newTableName.Equals(tableName))
                        {
                            MessageBox.Show("表名已存在！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    renameTable();
                    this.Close();
                }
            }
        }

        //点击取消按钮
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //新建一个表文件
        private void createTableFile()
        {
            f.create_table_files(newTableName);
            createFlag = true;
        }

        //更改表名
        private void renameTable()
        {
            f.rename_table(oldTableName, newTableName);
        }

        //获取新表名
        public string getTableName()
        {
            return newTableName;
        }

        //获取新表名
        public bool getCreateFlag()
        {
            return createFlag;
        }
    }
}
