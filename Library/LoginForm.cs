using System;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Library
{
    public partial class LoginForm : MaterialForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = richTextBox1.Text;
            string password = richTextBox2.Text;

            // 示例：简单的用户名和密码验证
            if (username == "liuqiukai" && password == "123456")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误.", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}