using CODE.Framework.Core.Utilities;
using CODE.Framework.Wpf.Mvvm;
using System.Text;

namespace VeiderSoft.AgileTools.Main.Models.Home
{
    public class PasswordGeneratorViewModel : ViewModel
    {
        public static byte[] ENCRYPT_KEY = Encoding.ASCII.GetBytes("&2o#4Mr6$8do!i2r4c-6do/0");

        private string password;
        private string encrypedPassword;
        private int passLen;
        public int PassLen
        {
            get
            {
                return passLen;
            }
            set
            {
                if (passLen == value) return;
                passLen = value;
                NotifyChanged("PassLen");
            }
        }

        public string EncryptedPassword
        {
            get
            {
                return encrypedPassword;
            }
            set
            {
                if (encrypedPassword == value) return;
                encrypedPassword = value;
                NotifyChanged("EncryptedPassword");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password == value) return;
                password = value;
                NotifyChanged("Password");

                this.HashCommand.InvalidateCanExecute();
            }
        }

        public ViewAction HashCommand { get; private set; }
        public ViewAction ClearCommand { get; private set; }

        public PasswordGeneratorViewModel()
        {
            HashCommand = new ViewAction("Encrypt", execute: (a, o) => { ComputeHash(); }, canExecute: (a, o) => { return !string.IsNullOrWhiteSpace(this.Password); }, brushResourceKey: "CODE.Framework-Icon-Collapsed");
            ClearCommand = new ViewAction("Clear", execute: (a, o) => { Clear(); }, brushResourceKey: "CODE.Framework-Icon-No");

            Actions.Add(HashCommand);
            Actions.Add(ClearCommand);
            Actions.Add(new CloseCurrentViewAction(this, beginGroup: true));

            this.EncryptedPassword = string.Empty;
            this.Password = string.Empty;
        }

        private void ComputeHash()
        {
            var encrypted = SecurityHelper.EncryptString(this.Password.Trim(), ENCRYPT_KEY);
            this.EncryptedPassword = encrypted;

            this.PassLen = this.EncryptedPassword.Length;
        }
        private void Clear()
        {
            this.EncryptedPassword = string.Empty;
            this.Password = string.Empty;
        }
    }
}
