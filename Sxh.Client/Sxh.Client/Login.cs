using Shared.Util;
using Sxh.Client.Business;
using Sxh.Client.Business.Logs;
using Sxh.Client.Business.Repository;
using Sxh.Client.Business.ViewModel;
using Sxh.Client.Util;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Sxh.Client
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        #region Event

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadAccountXml();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            this.UiFreeze(false);

            var repo = new LoginRepository();
            var taskLogin = repo.LoginAsync(new VmLogin()
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                PasswordTran = txtPasswordTran.Text
            });

            var msg = await taskLogin;
            if (string.IsNullOrEmpty(msg))
            {
                var mainForm = new frmMain();
                mainForm.OnWindowClosed -= MainForm_OnWindowClosed;
                mainForm.Show();
                mainForm.OnWindowClosed += MainForm_OnWindowClosed;

                Hide();
            }
            else
            {
                LogManager.Instance.Message($"login faild: {msg}");
                MessageBox.Show(msg, string.Empty, MessageBoxButtons.OK);
            }

            this.UiFreeze(true);
        }

        private void MainForm_OnWindowClosed(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Private Method

        private void LoadAccountXml()
        {
            const string FILE_ACCOUNT = "account.xml";
            if (File.Exists(FILE_ACCOUNT))
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(FILE_ACCOUNT);

                var selectSingleNode = xmlDoc.SelectSingleNode("root");
                if (selectSingleNode != null)
                {
                    foreach (XmlElement childNode in selectSingleNode.ChildNodes)
                    {
                        var id = TypeParser.GetStringValue(childNode.GetAttribute("id"));
                        var psw = TypeParser.GetStringValue(childNode.GetAttribute("psw"));
                        var tsw = TypeParser.GetStringValue(childNode.GetAttribute("tsw"));

                        txtUserName.Text = id;
                        txtPassword.Text = psw;
                        txtPasswordTran.Text = tsw;
                    }
                }
            }
        }

        #endregion
    }
}
