using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projERPMercearia.Model;
using projERPMercearia.Controller;

namespace projERPMercearia.View
{
    public partial class FrmSection : Form
    {
        public FrmSection()
        {
            InitializeComponent();
            PopulateListView();
        }

        private void OnListBoxItemIndexChanged(object sender, EventArgs e)
        {
            if (lbxSections.SelectedItems.Count > 0) SetRename(true);
            else btnRename.Enabled = false;
        }

        private void SetRename(bool canRename)
        {
            txtName.Enabled = canRename;
            btnRename.Enabled = canRename;
        }

        private void OnButtonAddClicked(object sender, EventArgs e)
        {
            Section section = new Section()
            {
                ID = lbxSections.Items.Count + 1,
                Name = $"Setor {lbxSections.Items.Count + 1}"
            };

            lbxSections.Items.Add(section.Name);
            DatabaseController.Add("SECTION", "ID, NAME", $"{section.ID}, '{section.Name}'");
            DatabaseController.Add
            (
                "SECTION_CHANGES",
                "ID, ID_SECTION, CHANGE, CHANGE_DATE",
                $"'{CommonQuery.Select("COUNT(*)", "SECTION_CHANGES")}', '{section.ID}', 'Criou o setor.', {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}"
            );
        }

        private void OnButtonRenameClicked(object sender, EventArgs e)
        {
            int id = lbxSections.SelectedIndex + 1;
            string name = lbxSections.GetItemText(lbxSections.SelectedItem);

            if (txtName.Text == string.Empty) MessageBox.Show
            (
                "Digite um nome antes de renomear.", 
                "Erro",                   
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error
            );
            else
            {
                DatabaseController.Add
                (
                    "SECTION_CHANGES",
                    "ID, ID_SECTION, CHANGE, CHANGE_DATE",
                    $"'{CommonQuery.Select("COUNT(*)", "SECTION_CHANGES")}', '{id}', 'Editou o nome do setor de {name} para {txtName.Text}.', {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}"
                );
                DatabaseController.Update("SECTION", $"NAME = '{txtName.Text}'", $"ID = {id}");
                SetRename(false);
                PopulateListView();
            }
        }

        private void PopulateListView()
        {
            lbxSections.Items.Clear();
            var itens = DatabaseController.SelectInArray("NAME", "SECTION");
            foreach (string item in itens)
            {
                lbxSections.Items.Add(item);
            }
        }
    }
}
