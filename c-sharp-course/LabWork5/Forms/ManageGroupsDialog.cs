using System;
using System.Linq;
using System.Windows.Forms;

namespace LabWork5.Forms
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
            GroupsGrid.DataSource = ((MainWindow) Owner).Groups.ConvertAll(x => new {Value = x});
            GroupsGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GroupsGrid.Columns[0].HeaderText = "Group name";
            GroupsGrid.ResetBindings();
        }

        private void AddBtn_Click(object sender, EventArgs e) => _addGroupDialog.ShowDialog();

        public bool AddNewGroup(string group)
        {
            if (((MainWindow) Owner).Groups.Contains(group))
            {
                return false;
            }

            ((MainWindow) Owner).Groups.Add(group);
            ((MainWindow) Owner).OnGroupAdded(group);
            ResetGroupsGrid();
            return true;
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (GroupsGrid.SelectedRows.Count == 0)
            {
                return;
            }

            var groupsToDelete = (from DataGridViewRow selectedRow in GroupsGrid.SelectedRows
                select (string) selectedRow.Cells[0].Value).ToList();
            ((MainWindow) Owner).Groups.RemoveAll(g => groupsToDelete.Contains(g));
            ((MainWindow) Owner).OnGroupsDeleted(groupsToDelete);
            ResetGroupsGrid();
        }

        private void RenameBtn_Click(object sender, EventArgs e)
        {
            if (GroupsGrid.SelectedRows.Count == 0)
            {
                return;
            }

            _renameGroupDialog.GroupName = (string) GroupsGrid.SelectedRows[0].Cells[0].Value;
            _renameGroupDialog.ShowDialog();
        }

        public bool RenameGroup(string newName, string oldName)
        {
            var groups = ((MainWindow) Owner).Groups;
            if (groups.Contains(newName))
            {
                return false;
            }

            groups[groups.IndexOf(oldName)] = newName;
            ((MainWindow) Owner).OnGroupsRenamed(newName, oldName);
            ResetGroupsGrid();
            return true;
        }
    }
}