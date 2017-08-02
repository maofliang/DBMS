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
    public partial class FrmTableDesign : Form
    {
        FileOp f = new FileOp();

        List<TableMode> oldTableModeList = new List<TableMode>(); //保存旧字段信息
        List<TableMode> newTableModeList = new List<TableMode>(); //保存新字段信息
        List<int> address = new List<int>(); //保存修改标记

        bool isCreate; //是否为创建表
        string tableName; //打开表的表名

        public FrmTableDesign(bool isCreate, string tableName1)
        {
            InitializeComponent();
            this.isCreate = isCreate;
            this.tableName = tableName1;
        }

        private void FrmTableDesign_Load(object sender, EventArgs e)
        {
            if (isCreate == true)
            {
                this.Text = "新建表";
                //开始时创建一行
                int index = dgvFields.Rows.Add();
                //赋初值
                dgvFields.Rows[index].Cells[3].Value = false;
                dgvFields.Rows[index].Cells[4].Value = false;
                dgvFields.Rows[index].Cells[5].Value = 0;
            }
            else
            {
                this.Text = "设计表-" + tableName;
                //获取字段列表，并显示到dgvFields控件中
                oldTableModeList = f.read_table_field(tableName);
                for (int i = 0; i < oldTableModeList.Count; i++)
                {
                    int index = dgvFields.Rows.Add();
                    dgvFields.Rows[index].Cells[0].Value = oldTableModeList[i].getFieldName();
                    ((DataGridViewComboBoxCell)dgvFields.Rows[index].Cells[1]).Value = oldTableModeList[i].getFieldType();
                    dgvFields.Rows[index].Cells[2].Value = oldTableModeList[i].getFieldLength();
                    if (oldTableModeList[i].getNotNull()[0] == 't')
                    {
                        ((DataGridViewCheckBoxCell)dgvFields.Rows[index].Cells[3]).Value = true;
                    }
                    else
                    {
                        ((DataGridViewCheckBoxCell)dgvFields.Rows[index].Cells[3]).Value = false;
                    }
                    if (oldTableModeList[i].getIsKey()[0] == 't')
                    {
                        ((DataGridViewCheckBoxCell)dgvFields.Rows[index].Cells[4]).Value = true;
                    }
                    else
                    {
                        ((DataGridViewCheckBoxCell)dgvFields.Rows[index].Cells[4]).Value = false;
                    }
                    dgvFields.Rows[i].Cells[5].Value = i + 1;
                }
            }
        }

        //键盘事件，只能输入数字和删除键
        private void dgvFields_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //字段长度的列只能输入数字和删除键
        private void dgvFields_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvFields.CurrentCell.ColumnIndex == 2)
            {
                e.Control.KeyPress -= new KeyPressEventHandler(dgvFields_KeyPress);
                e.Control.KeyPress += new KeyPressEventHandler(dgvFields_KeyPress);
            }
            else
            {
                e.Control.KeyPress -= new KeyPressEventHandler(dgvFields_KeyPress);
            }
        }

        //主键只能选一个
        /*private void dgvFields_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                for (int i = 0; i < dgvFields.Rows.Count; i++)
                {
                    if (i != e.RowIndex)
                    {
                        ((DataGridViewCheckBoxCell)dgvFields.Rows[i].Cells[4]).Value = false;
                    }
                }
            }
        }*/

        //添加字段
        private void tsBtnAddField_Click(object sender, EventArgs e)
        {
            int index = dgvFields.Rows.Add();
            //赋初值
            dgvFields.Rows[index].Cells[3].Value = false;
            dgvFields.Rows[index].Cells[4].Value = false;
            dgvFields.Rows[index].Cells[5].Value = 0;
            //使新建字段字段名处于编辑状态
            dgvFields.CurrentCell = dgvFields.Rows[dgvFields.Rows.Count - 1].Cells[0];
        }

        //插入字段
        private void tsBtnInsertField_Click(object sender, EventArgs e)
        {
            //获取选中行的行号
            int curRowIndex = dgvFields.CurrentRow.Index;
            //在选中行之前插入一行
            dgvFields.Rows.Insert(curRowIndex, new DataGridViewRow());
            //赋初值
            dgvFields.Rows[curRowIndex].Cells[3].Value = false;
            dgvFields.Rows[curRowIndex].Cells[4].Value = false;
            dgvFields.Rows[curRowIndex].Cells[5].Value = 0;
            //使新建字段字段名处于编辑状态
            dgvFields.CurrentCell = dgvFields.Rows[curRowIndex].Cells[0];
        }

        //删除字段
        private void tsBtnDelField_Click(object sender, EventArgs e)
        {
            //弹出确认保存对话框
            DialogResult dr = MessageBox.Show("你确定要删除该字段吗？", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //点击确定
            if (dr == DialogResult.OK)
            {
                dgvFields.Rows.Remove(dgvFields.CurrentRow);
                //如果删除了所有行，新建一行
                if (dgvFields.Rows.Count == 0)
                {
                    int index = dgvFields.Rows.Add();
                    //赋初值
                    dgvFields.Rows[index].Cells[3].Value = false;
                    dgvFields.Rows[index].Cells[4].Value = false;
                    dgvFields.Rows[index].Cells[5].Value = 0;
                }
            }
            //点击取消
            else
            {
                ;
            }
        }

        //保存
        private void tsBtnSavaFields_Click(object sender, EventArgs e)
        {
            //结束单元格的编辑状态以保存修改的内容
            dgvFields.EndEdit();
            //新建表的保存
            if (isCreate == true)
            {
                if (checkCells() == 0)
                {
                    if (saveDgvToList() != 0)
                        return;
                    FrmTableName frmTableName = new FrmTableName(true, null);
                    frmTableName.ShowDialog();
                    //获取是否成功创建了表文件
                    if (frmTableName.getCreateFlag())
                    {
                        //获取创建的表名
                        string newTableName = frmTableName.getTableName();
                        //将字段信息写入文件
                        f.write_table_field(newTableName, newTableModeList);
                        this.Close();
                    }
                    else
                    {
                        newTableModeList.Clear();
                    }
                }
                else
                {
                    return;
                }
            }
            //设计表的保存
            else
            {
                if (checkCells() == 0)
                {
                    if (saveDgvToList() != 0)
                        return;
                    //弹出确认保存对话框
                    DialogResult dr = MessageBox.Show("你确定要保存表\"" + tableName + "\"吗？", "确认保存", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    //点击确定
                    if (dr == DialogResult.OK)
                    {
                        f.write_table_field(tableName, newTableModeList);
                        //调整记录字段位置
                        f.field_change(tableName, oldTableModeList, newTableModeList, address);
                        this.Close();
                    }
                    //点击取消
                    else
                    {
                        newTableModeList.Clear();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        //检测所填字段信息是否符合要求
        private int checkCells()
        {
            int i;
            for(i=0;i<dgvFields.Rows.Count;i++)
            {
                if (dgvFields.Rows[i].Cells[4].Value.Equals(true))
                {
                    ((DataGridViewCheckBoxCell)dgvFields.Rows[i].Cells[3]).Value = true;
                }
                if (dgvFields.Rows[i].Cells[0].Value == null || dgvFields.Rows[i].Cells[0].Value.ToString().Trim().Equals(""))
                {
                    error(i + 1, "字段名不能为空");
                    return 1;
                }
                if(dgvFields.Rows[i].Cells[0].Value.ToString().Length>64)
                {
                    error(i + 1, "字段名不能多于64个字符");
                    return 1;
                }
                if(dgvFields.Rows[i].Cells[1].Value==null)
                {
                    error(i + 1, "请选择一个字段类型");
                    return 2;
                }
                else if(dgvFields.Rows[i].Cells[1].Value.Equals("int"))
                {
                    dgvFields.Rows[i].Cells[2].Value = 4;
                }
                else if (dgvFields.Rows[i].Cells[1].Value.Equals("long"))
                {
                    dgvFields.Rows[i].Cells[2].Value = 8;
                }
                else if (dgvFields.Rows[i].Cells[1].Value.Equals("double"))
                {
                    dgvFields.Rows[i].Cells[2].Value = 8;
                }
                if (dgvFields.Rows[i].Cells[2].Value == null)
                {
                    error(i + 1, "请设置字段长度");
                    return 3;
                }
            }
            return 0;
        }

        //将控件中的字段信息保存到newTableModeList中
        private int saveDgvToList()
        {
            for (int i = 0; i < dgvFields.Rows.Count; i++)
            {
                TableMode tableMode = new TableMode();
                tableMode.setFieldName(dgvFields.Rows[i].Cells[0].Value.ToString());
                tableMode.setFieldType(dgvFields.Rows[i].Cells[1].Value.ToString());
                int fieldLength;
                try
                {
                    fieldLength = Convert.ToInt32(dgvFields.Rows[i].Cells[2].Value);
                }
                catch
                {
                    error(i + 1, "字段长度不能完成到int的转换");
                    return 1;
                }
                tableMode.setFieldLength(fieldLength);
                char[] notNull = new char[1];
                if (dgvFields.Rows[i].Cells[3].Value == null || dgvFields.Rows[i].Cells[3].Value.Equals(false))
                {
                    notNull[0] = 'f';
                }
                else
                {
                    notNull[0] = 't';
                }
                tableMode.setNotNull(notNull);
                char[] isKey = new char[1];
                if (dgvFields.Rows[i].Cells[4].Value == null || dgvFields.Rows[i].Cells[4].Value.Equals(false))
                {
                    isKey[0] = 'f';
                }
                else
                {
                    isKey[0] = 't';
                }
                tableMode.setIsKey(isKey);
                newTableModeList.Add(tableMode);
                address.Add(Convert.ToInt32(dgvFields.Rows[i].Cells[5].Value));
            }
            return 0;
        }

        //显示错误信息
        private void error(int t, string detail)
        {
            MessageBox.Show("第" + t + "行：" + detail, "出错", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
