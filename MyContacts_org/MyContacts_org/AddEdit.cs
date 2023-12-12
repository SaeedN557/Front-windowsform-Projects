using MyContacts_org.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts_org
{
    public partial class AddEdit : Form
    {
        IContacts repository;
        public int contactId = 0;
        public AddEdit()
        {
            repository = new Contacts();
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (validation())
            {
                bool success;
                if (contactId == 0)
                {
                    success = repository.insert(txtName.Text,
                                                   txtFamily.Text,
                                                   txtMobile.Text,
                                                   Convert.ToInt32(txtAge.Text)
                                                  );
                }
                else
                {
                    success = repository.update(txtName.Text,
                                                   txtFamily.Text,
                                                   txtMobile.Text,
                                                   Convert.ToInt32(txtAge.Text)
                                                  ) ;
                }
                
                if (success == true)
                {
                    MessageBox.Show("عملیات موفق", "اعلان", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult= DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات ناموفق","اعلان",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }
        bool validation()
        {
            bool isValid = true;
            if (txtName.Name == "")
            {
                isValid = false;
                MessageBox.Show("لطفا نام را وارد کنید","اخطار",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return isValid;
            }
            if (txtFamily.Text == "")
            {
                isValid = false;
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return isValid;
            }
            if (txtMobile.Text == "")
            {
                isValid = false;
                MessageBox.Show("لطفا سن را وارد کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return isValid;
            }
            if (txtAge.Text == "")
            {
                isValid = false;
                MessageBox.Show("لطفا شماره موبایل را وارد کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return isValid;
            }

            return isValid;
        }
        private void AddEdit_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "افزودن مخاطب جدید";
            }
            else
            {
                this.Text = "ویرایش مخاطب";
                btnSubmit.Text = "ویرایش";
                DataTable dt=repository.Selector(contactId);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtMobile.Text = dt.Rows[0][3].ToString();  
                txtAge.Text = dt.Rows[0][4].ToString();
                
            }
        }
    }
}
