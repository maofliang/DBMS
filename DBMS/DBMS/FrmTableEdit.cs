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
    public partial class FrmTableEdit : Form
    {
        FileOp f = new FileOp();

        List<TableMode> tableModeList = new List<TableMode>(); //保存字段信息

        string tableName; //表名

        public FrmTableEdit(String tableName1)
        {
            InitializeComponent();
            this.tableName = tableName1;
        }

        private void FrmTableEdit_Load(object sender, EventArgs e)
        {
            this.Text = "编辑表-" + tableName;
            //获取字段信息，将字段名作为列名
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tableModeList = f.read_table_field(tableName);
            for (int i = 0; i < tableModeList.Count; i++)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                string columnName = tableModeList[i].getFieldName().ToString();
                column.HeaderText = columnName;
                column.FillWeight = columnName.Length;
                dgvRecords.Columns.Add(column);
            }
            //标记原来的行
            DataGridViewTextBoxColumn columnOldNo = new DataGridViewTextBoxColumn();
            columnOldNo.HeaderText = "oldNo";
            columnOldNo.Name = "oldNo";
            columnOldNo.Visible = false;
            dgvRecords.Columns.Add(columnOldNo);
            //标记是否删除，更改
            DataGridViewTextBoxColumn columnIsEdit = new DataGridViewTextBoxColumn();
            columnIsEdit.HeaderText = "isEdit";
            columnIsEdit.Name = "isEdit";
            columnIsEdit.Visible = false;
            dgvRecords.Columns.Add(columnIsEdit);
            //读取表内容
            List<List<object>> recordList = new List<List<object>>();
            recordList = f.read_all_record(tableName, tableModeList);
            for (int i = 0; i < recordList.Count; i++)
            {
                int index = dgvRecords.Rows.Add();
                List<object> record = new List<object>();
                record = recordList[i];
                for (int j = 0; j < dgvRecords.ColumnCount - 2; j++)
                {
                    dgvRecords.Rows[index].Cells[j].Value = record[j];
                }
                dgvRecords.Rows[index].Cells[dgvRecords.ColumnCount - 2].Value = i + 1;
                dgvRecords.Rows[index].Cells[dgvRecords.ColumnCount - 1].Value = 0;
            }
        }

        //判断行数据是否被改动
        private void dgvRecords_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.ColumnIndex <=dgvRecords.ColumnCount-3)
            {
                dgvRecords.Rows[e.RowIndex].Cells[dgvRecords.ColumnCount - 1].Value = 1;
            }
        }

        //添加记录
        private void tsBtnAddRecord_Click(object sender, EventArgs e)
        {
            dgvRecords.Rows.Add();
            //使新建行第一个单元格处于编辑状态
            dgvRecords.CurrentCell = dgvRecords.Rows[dgvRecords.Rows.Count - 1].Cells[0];
            dgvRecords.CurrentRow.Cells[dgvRecords.ColumnCount - 2].Value = 0;
            dgvRecords.CurrentRow.Cells[dgvRecords.ColumnCount - 1].Value = 0;
        }

        //删除记录
        private void tsBtnDelRecord_Click(object sender, EventArgs e)
        {
            if (dgvRecords.Rows.Count != 0)
            {
                //选中行的行数
                int count = dgvRecords.SelectedRows.Count;
                //如果没有选中行，则删除当前行
                if (count == 0)
                {
                    DialogResult dr = MessageBox.Show("你确定要删除1条记录吗？", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        dgvRecords.EndEdit();
                        dgvRecords.Rows[dgvRecords.CurrentRow.Index].Cells[dgvRecords.ColumnCount - 1].Value = 2;
                        dgvRecords.Rows[dgvRecords.CurrentRow.Index].Visible = false;
                    }
                    else
                    {
                        return;
                    }
                }
                //删除所有选中行
                else
                {
                    DialogResult dr = MessageBox.Show("你确定要删除" + count + "条记录吗？", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {
                        foreach (DataGridViewRow row in dgvRecords.SelectedRows)
                        {
                            dgvRecords.Rows[row.Index].Cells[dgvRecords.ColumnCount - 1].Value = 2;
                            dgvRecords.Rows[row.Index].Visible = false;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                return;
            }
        }

        //保存
        private void tsBtnSaveRecords_Click(object sender, EventArgs e)
        {
            //结束当前单元格的编辑状态
            dgvRecords.EndEdit();
            List<List<object>> recordEditList = new List<List<object>>();
            List<int> recordOldNo = new List<int>();
            List<int> recordIsEdit = new List<int>();
            for (int j=0;j<dgvRecords.Rows.Count;j++)
            {
                //找出新增的、删除的、修改过的记录，记录在recordEditList中
                if ((dgvRecords.Rows[j].Cells[dgvRecords.ColumnCount - 2].Value.Equals(0) && !dgvRecords.Rows[j].Cells[dgvRecords.ColumnCount - 1].Value.Equals(2))
                    || (!dgvRecords.Rows[j].Cells[dgvRecords.ColumnCount - 1].Value.Equals(0) && !dgvRecords.Rows[j].Cells[dgvRecords.ColumnCount - 1].Value.Equals(0)))
                {
                    if (checkCells(j) == 0)
                    {
                        List<object> record = new List<object>();
                        for(int k=0;k<dgvRecords.ColumnCount-2;k++)
                        {
                            string type = tableModeList[k].getFieldType().ToString();
                            if (type.Equals("int"))
                            {
                                try
                                {
                                    int dataInt = Convert.ToInt32(dgvRecords.Rows[j].Cells[k].Value);
                                    record.Add(dataInt);
                                }
                                catch
                                {
                                    error(j + 1, tableModeList[k].getFieldName() + "不能完成到int的转换");
                                    return;
                                }
                            }
                            else if (type.Equals("long"))
                            {
                                try
                                {
                                    long dataLong = Convert.ToInt64(dgvRecords.Rows[j].Cells[k].Value);
                                    record.Add(dataLong);
                                }
                                catch
                                {
                                    error(j + 1, tableModeList[k].getFieldName() + "不能完成到long的转换");
                                    return;
                                }
                            }
                            else if (type.Equals("double"))
                            {
                                try
                                {
                                    double dataDouble = Convert.ToDouble(dgvRecords.Rows[j].Cells[k].Value);
                                    record.Add(dataDouble);
                                }
                                catch
                                {
                                    error(j + 1, tableModeList[k].getFieldName() + "不能完成到double的转换");
                                    return;
                                }
                            }
                            else
                            {
                                record.Add(dgvRecords.Rows[j].Cells[k].Value);
                            }
                        }
                        recordEditList.Add(record);
                        //记录操作标记
                        recordOldNo.Add(Convert.ToInt32(dgvRecords.Rows[j].Cells[dgvRecords.ColumnCount - 2].Value));
                        recordIsEdit.Add(Convert.ToInt32(dgvRecords.Rows[j].Cells[dgvRecords.ColumnCount - 1].Value));
                    }
                    else
                    {
                        return;
                    }
                }
            }
            //将以上的修改写入文件
            for (int t = 0; t < recordEditList.Count; t++)
            {
                if (recordOldNo[t] == 0 && recordIsEdit[t] != 2)
                {
                    int index = f.insert_record(tableName, tableModeList, recordEditList[t]);
                    for (int i = t; i < recordOldNo.Count; i++)
                    {
                        if (recordOldNo[i] >= index)
                        {
                            recordOldNo[i]++;
                        }
                    }
                }
                else if (recordOldNo[t] != 0 && recordIsEdit[t] == 1)
                {
                    f.delete_index(tableName, recordOldNo[t]);
                    for (int i = t; i < recordOldNo.Count; i++)
                    {
                        if (recordOldNo[i] > recordOldNo[t])
                        {
                            recordOldNo[i]--;
                        }
                    }
                    int index = f.insert_record(tableName, tableModeList, recordEditList[t]);
                    for (int i = t; i < recordOldNo.Count; i++)
                    {
                        if (recordOldNo[i] >= index)
                        {
                            recordOldNo[i]++;
                        }
                    }
                }
                else if (recordOldNo[t] != 0 && recordIsEdit[t] == 2)
                {
                    f.delete_index(tableName, recordOldNo[t]);
                    for (int i = t; i < recordOldNo.Count; i++)
                    {
                        if (recordOldNo[i] > recordOldNo[t])
                        {
                            recordOldNo[i]--;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            this.Close();
        }

        //检测当前行的单元格是否符合要求
        private int checkCells(int rowIndex)
        {
            int i;
            for (i = 0; i < dgvRecords.ColumnCount - 2; i++)
            {
                //如果不能为空的字段为空值，则报错
                if (tableModeList[i].getNotNull()[0] == 't')
                {
                    if (dgvRecords.Rows[rowIndex].Cells[i].Value == null)
                    {
                        error(rowIndex + 1, tableModeList[i].getFieldName() + "字段不能为空");
                        return 1;
                    }
                }
                //如果主码重复，则报错
                /*if (tableModeList[i].getIsKey()[0] == 't')
                {
                    string curKey = dgvRecords.Rows[rowIndex].Cells[i].Value.ToString();
                    for (int j = 0; j < dgvRecords.RowCount; j++)
                    {
                        if (j != rowIndex)
                        {
                            if (dgvRecords.Rows[j].Cells[i].Value.ToString().Equals(curKey))
                            {
                                error(rowIndex + 1, tableModeList[i].getFieldName() + "主码重复");
                                return 2;
                            }
                        }
                    }
                }*/
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
