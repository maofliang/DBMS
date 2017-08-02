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
    public partial class FrmMain : Form
    {
        FileOp f = new FileOp();

        String curTableName = null; //当前选中的表名
        List<RichTextBox> txtSQLList = new List<RichTextBox>(); //保存所有txtSQL

        public FrmMain()
        {
            InitializeComponent();
        }

        //初始化
        private void FrmMain_Load(object sender, EventArgs e)
        {
            refreshTreeView();
            createSQL();
        }

        //新建表
        private void 新建表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createTable();
        }

        //刷新树状列表
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshTreeView();
        }

        //退出系统
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        //新建查询
        private void 新建查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createSQL();
        }

        //点击查看软件信息
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DBMS\n作者：毛方亮、左晏伊、沈子良、陈康明、陈志阳、蔡沛文", "软件信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //刷新树状列表
        private void tsBtnRefreshTvw_Click(object sender, EventArgs e)
        {
            refreshTreeView();
        }

        //新建表
        private void tsBtnCreateTable_Click(object sender, EventArgs e)
        {
            createTable();
        }

        //新建查询
        private void tsBtnCreateSQL_Click(object sender, EventArgs e)
        {
            createSQL();
        }

        //关闭当前查询的选项卡
        private void tsBtnDelCurSQL_Click(object sender, EventArgs e)
        {
            deleteCurSQL();
        }

        //关闭所有查询选项卡
        private void tsBtnDelAllSQL_Click(object sender, EventArgs e)
        {
            deleteAllSQL();
        }

        //执行当前选项卡中的查询语句
        private void tsBtnExeCurSQL_Click(object sender, EventArgs e)
        {
            executeCurSQL();
        }

        //关闭当前的查询结果选项卡
        private void tsBtnDelCurResult_Click(object sender, EventArgs e)
        {
            deleteCurResult();
        }

        //关闭所有的查询结果选项卡
        private void tsBtnDelAllResult_Click(object sender, EventArgs e)
        {
            deleteAllResult();
        }

        //单击树节点
        private void tvwDB_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //不是单击右键
            if (e.Button != MouseButtons.Right || e.Node == null)
                return;
            //根节点单击右键
            if (e.Node.Parent == null)
            {
                tvwDB.SelectedNode = e.Node;
                cmsTreeRoot.Show(tvwDB, e.X, e.Y);
            }
            //子节点单击右键
            else
            {
                //记录当前表名
                curTableName = e.Node.Text;
                tvwDB.SelectedNode = e.Node;
                cmsTreeNode.Show(tvwDB, e.X, e.Y);
            }
        }

        //双击树节点
        private void tvwDB_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //双击右键无效
            if (e.Button == MouseButtons.Right || e.Node == null)
                return;
            //记录当前表名
            curTableName = e.Node.Text;
            //子节点双击左键
            if (e.Node.Parent != null)
            {
                tvwDB.SelectedNode = e.Node;
                editTable();
            }
        }

        //打开当前表
        private void 打开表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editTable();
        }

        //编辑当前表的字段
        private void 设计表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            designTable();
        }

        //新建表
        private void 新建表ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            createTable();
        }

        //删除当前表
        private void 删除表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteTable();
        }

        //清空当前表
        private void 清空表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearTable();
        }

        //重命名当前表
        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renameTable();
        }

        //新建表
        private void 新建表ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            createTable();
        }

        //刷新树状列表
        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            refreshTreeView();
        }

        //改变窗口大小
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            Control form = (Control)sender;
            tvwDB.Height = form.Height - 99;
            tabSQL.Width = form.Width - tabSQL.Left - 18;
            pnlResult.Height = form.Height - pnlResult.Top - 42;
            pnlResult.Width = form.Width - pnlResult.Left - 18;
        }

        //刷新树状列表
        private void refreshTreeView()
        {
            //删除所有节点
            tvwDB.Nodes.Clear();
            //添加根节点
            TreeNode tnDB = new TreeNode();
            //设置数据库名称
            tnDB.Text = "data";
            //添加根节点
            tvwDB.Nodes.Add(tnDB);
            //获取表名列表
            FileOp f = new FileOp();
            List<String> tableNameList = f.get_table_names();
            //添加子节点
            foreach(String tableName in tableNameList)
            {
                TreeNode tnTab = new TreeNode();
                tnTab.Text = tableName;
                tnDB.Nodes.Add(tnTab);
            }
            tvwDB.ExpandAll();
        }

        //新建表
        private void createTable()
        {
            FrmTableDesign frmTableDesign = new FrmTableDesign(true, null);
            frmTableDesign.ShowDialog();
            refreshTreeView();
        }

        //新建查询选项卡
        private void createSQL()
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = "SQL查询";
            RichTextBox txtSQL = new RichTextBox();
            txtSQL.Dock = DockStyle.Fill;
            txtSQL.BorderStyle = BorderStyle.None;
            tabPage.Controls.Add(txtSQL);
            tabSQL.Controls.Add(tabPage);
            txtSQLList.Add(txtSQL);
            tabSQL.SelectedIndex = tabSQL.TabCount - 1;
        }

        //关闭当前查询选项卡
        private void deleteCurSQL()
        {
            int curTabSQLIndex = tabSQL.SelectedIndex;
            tabSQL.Controls.RemoveAt(curTabSQLIndex);
            txtSQLList.RemoveAt(curTabSQLIndex);
            if (tabSQL.Controls.Count == 0)
                createSQL();
            tabSQL.SelectedIndex = tabSQL.TabCount - 1;
        }

        //关闭所有查询选项卡
        private void deleteAllSQL()
        {
            tabSQL.Controls.Clear();
            txtSQLList.Clear();
            if (tabSQL.Controls.Count == 0)
                createSQL();
        }

        //执行当前选项卡中的查询语句
        private void executeCurSQL()
        {
            ParseSQL parseSQL = new ParseSQL();
            //获取当前txtSQL中的所有行
            int curTabSQLIndex = tabSQL.SelectedIndex;
            String[] curSQLLines = txtSQLList[curTabSQLIndex].Lines;
            //将所有的行拼接为一个SQL语句
            String curSQL = "";
            foreach (String str in curSQLLines)
            {
                curSQL = curSQL + str + " ";
            }
            //去除SQL语句前后空格
            curSQL = curSQL.Trim();
            bool b = parseSQL.parse(curSQL);
            if (b)
            {
                //select语句
                if (curSQL.ToLower().StartsWith("select"))
                {
                    //显示结果
                    TabPage tabPage = new TabPage();
                    tabPage.Text = "查询结果";
                    //设置结果显示表
                    DataGridView dgvResult = new DataGridView();
                    dgvResult.AllowUserToAddRows = false;
                    dgvResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    dgvResult.Dock = DockStyle.Fill;
                    dgvResult.ScrollBars = ScrollBars.Both;
                    dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    dgvResult.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
                    dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //显示列名
                    object[] fieldNameList = (object[])parseSQL.selectr[0];
                    int filedCount;
                    filedCount = fieldNameList.Length;
                    for (int i = 0; i < filedCount; i++)
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        string columnName = fieldNameList[i].ToString();
                        column.HeaderText = columnName;
                        column.FillWeight = columnName.Length;
                        dgvResult.Columns.Add(column);
                    }
                    //表示不要显示的列
                    for (int i = 0; i < dgvResult.ColumnCount; i++)
                    {
                        if (dgvResult.Columns[i].HeaderText.Equals("###"))
                        {
                            dgvResult.Columns[i].Visible = false;
                        }
                    }
                    dgvResult.ReadOnly = true;
                    //添加dgvResult到选项卡上
                    tabPage.Controls.Add(dgvResult);
                    tabResult.Controls.Add(tabPage);
                    tabResult.SelectedIndex = tabResult.Controls.Count - 1;
                    //添加各条记录
                    for (int i = 1; i < parseSQL.selectr.Count; i++)
                    {
                        int index = dgvResult.Rows.Add();
                        Object[] arrayFieldValue = (Object[])parseSQL.selectr[i];
                        for (int j = 0; j < filedCount; j++)
                        {
                            if (arrayFieldValue[j].ToString().Equals(0))
                                dgvResult.Rows[index].Cells[j].Value = "";
                            else
                                dgvResult.Rows[index].Cells[j].Value = arrayFieldValue[j].ToString();
                        }
                    }
                }
                //其它语句
                else
                {
                    //显示结果
                    TabPage tabPage = new TabPage();
                    tabPage.Text = "运行结果";
                    Label lblResult = new Label();
                    lblResult.Dock = DockStyle.Fill;
                    lblResult.Padding = new Padding(6, 6, 6, 6);
                    lblResult.Text = "命令成功执行！";
                    tabPage.Controls.Add(lblResult);
                    tabResult.Controls.Add(tabPage);
                    tabResult.SelectedIndex = tabResult.Controls.Count - 1;
                }
            }
            else
            {
                //显示失败结果
                TabPage tabPage = new TabPage();
                tabPage.Text = "运行结果";
                Label lblResult = new Label();
                lblResult.Dock = DockStyle.Fill;
                lblResult.Padding = new Padding(6, 6, 6, 6);
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "命令执行失败！";
                tabPage.Controls.Add(lblResult);
                tabResult.Controls.Add(tabPage);
                tabResult.SelectedIndex = tabResult.Controls.Count - 1;
            }
            refreshTreeView();
        }

        //关闭当前的查询结果选项卡
        private void deleteCurResult()
        {
            if (tabResult.TabCount != 0)
            {
                int curTabResultIndex = tabResult.SelectedIndex;
                tabResult.Controls.RemoveAt(curTabResultIndex);
            }
            tabResult.SelectedIndex = tabResult.TabCount - 1;
        }

        //关闭所有的查询结果选项卡
        private void deleteAllResult()
        {
            tabResult.Controls.Clear();
        }

        //打开当前表
        private void editTable()
        {
            FrmTableEdit frmTableEdit = new FrmTableEdit(curTableName);
            frmTableEdit.ShowDialog();
        }

        //编辑当前表的字段
        private void designTable()
        {
            FrmTableDesign frmTableDesign = new FrmTableDesign(false, curTableName);
            frmTableDesign.ShowDialog();
        }

        //删除当前表
        private void deleteTable()
        {
            //弹出确认删除对话框
            DialogResult dr = MessageBox.Show("你确定要删除表\""+curTableName+"\"吗？", "确认删除", MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            //点击确定
            if (dr == DialogResult.OK)
            {
                f.delete_table_files(curTableName);
                refreshTreeView();
            }
            //点击取消
            else
            {
                return;
            }
        }

        //清空当前表
        private void clearTable()
        {
            //弹出确认删除对话框
            DialogResult dr = MessageBox.Show("你确定要清空表\"" + curTableName + "\"吗？", "确认清空", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            //点击确定
            if (dr == DialogResult.OK)
            {
                f.clear_table(curTableName);
            }
            //点击取消
            else
            {
                return;
            }
        }

        //重命名当前表
        private void renameTable()
        {
            FrmTableName frmTableName = new FrmTableName(false, curTableName);
            frmTableName.ShowDialog();
            refreshTreeView();
        }
    }
}
