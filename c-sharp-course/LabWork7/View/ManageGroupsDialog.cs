using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabWork7.View
{
    public partial class ManageGroupsDialog : Form
    {
        private readonly AddGroupDialog _addGroupDialog;
        private readonly RenameGroupDialog _renameGroupDialog;

        public ManageGroupsDialog()
        {
            InitializeComponent();
            _addGroupDialog = new AddGroupDialog {Owner = this};
            _renameGroupDialog = new RenameGroupDialog {Owner = this};
        }

        private void ManageGroupsDialog_Load(object sender, EventArgs e) => ResetGroupsGrid();

        private void ResetGroupsGrid()
        {
            using (var data = new SqlDataAdapter("Select * From Groups", ((MainWindow) Owner).Conn))
            {
                var table = new DataTable();
                data.Fill(table);
                GroupsGrid.DataSource = table;
                GroupsGrid.ResetBindings();
            }

            foreach (DataGridViewColumn groupsGridColumn in GroupsGrid.Columns)
            {
                groupsGridColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void AddBtn_Click(object sender, EventArgs e) => _addGroupDialog.ShowDialog();

        public bool AddNewGroup(string group)
        {
            try
            {
                new SqlCommand($"Insert into Groups (Name) Values ('{group}')", ((MainWindow) Owner).Conn)
                    .ExecuteNonQuery();
                ResetGroupsGrid();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (GroupsGrid.SelectedRows.Count == 0)
            {
                return;
            }

            var groupsToDelete = (from DataGridViewRow selectedRow in GroupsGrid.SelectedRows
                select (string) selectedRow.Cells[1].Value).ToList();

            var stringBuilder = new StringBuilder();
            for (var index = 0; index < groupsToDelete.Count; index++)
            {
                stringBuilder.Append("'").Append(groupsToDelete[index]).Append("'");
                if (index < groupsToDelete.Count - 1)
                {
                    stringBuilder.Append(", ");
                }
            }

            var cmd = new SqlCommand($"Delete From Groups where Name IN ({stringBuilder})", ((MainWindow) Owner).Conn);
            try
            {
                cmd.ExecuteNonQuery();
                ResetGroupsGrid();
            }
            catch
            {
                // ignored
            }
        }


        private void RenameBtn_Click(object sender, EventArgs e)
        {
            if (GroupsGrid.SelectedRows.Count != 1)
            {
                return;
            }

            _renameGroupDialog.GroupName = (string) GroupsGrid.SelectedRows[0].Cells[1].Value;
            _renameGroupDialog.Id = (int) GroupsGrid.SelectedRows[0].Cells[0].Value;
            _renameGroupDialog.ShowDialog();
        }

        public bool RenameGroup(int id, string name)
        {
            try
            {
                var cmd = new SqlCommand($"Update Groups Set Name = '{name}' where Id = '{id}'",
                    ((MainWindow) Owner).Conn);
                cmd.ExecuteNonQuery();
                ResetGroupsGrid();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}