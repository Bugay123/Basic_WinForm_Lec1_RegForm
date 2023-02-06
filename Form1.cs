using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSurname.ForeColor = System.Drawing.Color.Gray;
            txtName.ForeColor = System.Drawing.Color.Gray;
            txtLogin.ForeColor = System.Drawing.Color.Gray;
        }

        private bool CheckEmptyTextBox()
        {
            //перевірка прізвища, імені і логіну на пустоту.
            try
            {
                if (txtSurname.Text.Length == 0 || txtName.Text.Length == 0 ||
                txtLogin.Text.Length == 0)
                    throw new Exception("Поля обовʼязкові. Введіть дані");
                //перевірка паролей на пустоту
                if (txtPassword.Text.Length == 0 || txtPassword1.Text.Length == 0)
                    throw new Exception("Поля обовʼязкові. Введіть дані.");
                iDiagnost.Text = "";
                return true;
            }
            catch (Exception e)
            {
                iDiagnost.Text = "* Помилка у вхідних даних. " + e.Message;
                return false;
            }
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            // перевірка прізвища на наявність тільки літер без блокування клавіатури
            this.txtSurname.ForeColor = System.Drawing.Color.Black;
            foreach (char c in txtSurname.Text)
            {
                if (!char.IsLetter(c))
                    iDiagnost.Text = "* В поле можна вводити тільки літери";
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // перевірка імені на наявність тільки літер без блокування клавіатури
            txtName.ForeColor = Color.Black;
            foreach (char c in txtName.Text)
            {
                if (!char.IsLetter(c))
                    iDiagnost.Text = "* В поле можна вводити тільки літери";
            }
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            txtLogin.ForeColor = Color.Black;
        }

        private bool CheckLogin()
        {
            // перевірка логіна. Можна вводити літери, цифри, крапку, знак @
            //застосування регулярного виразу для перевірки пошти.
            Regex myReg1 = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!myReg1.IsMatch(txtLogin.Text))
            {
                iDiagnost.Text = "* Помилка при введенні логіну";
                return false;
            }
            return true; 
        }
        private bool CheckPassword()
        {
            // перевірка співпадіння паролів і довжини
            try
            {
                if (txtPassword.Text != txtPassword1.Text)
                    throw new Exception("Паролі не співпадають");
                if (txtPassword.Text.Length < 6)
                    throw new Exception("Поганий пароль. Введіть не менше 6 символів");
                iDiagnost.Text = "";
                return true;
            }
            catch (Exception e)
            {
                iDiagnost.Text = "* " + e.Message;
                return false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckEmptyTextBox() && CheckPassword() && CheckLogin())
            {
                string buf = txtSurname.Text + Environment.NewLine +
                txtName.Text + Environment.NewLine +
                txtLogin.Text + Environment.NewLine +
                txtPassword.Text;
                txtOutput.Text = buf;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
