using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace MoodlePrivacy
{
    public partial class FrmInitial : Form
    {
        private bool notBusy;
        private string[] usernameAndPassword = new string[2];
        private string[] moodleLinks = new string[8];
        private string[] moduleCodes = new string[8];
        FrmSettings settings = new FrmSettings();

        public FrmInitial()
        {
            InitializeComponent();
            ReadInfo();
            notBusy = true;
            BtnStop.Hide();
            BtnStart.Show();
        }

        public void ReadInfo()
        {
            try
            {
                usernameAndPassword = System.IO.File.ReadAllLines(@"C:LoginInfo.txt");
                moodleLinks = System.IO.File.ReadAllLines(@"MoodleLinksInfo.txt");
                moduleCodes = System.IO.File.ReadAllLines(@"ModuleCodesInfo.txt");

            }
            catch(FileNotFoundException)
            {
                settings.ShowDialog();
            }
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(7000);
        }

        private async void BtnStop_Click(object sender, EventArgs e)
        {
            notBusy = false;

            BtnStart.Show();
            BtnStop.Hide();

            await PutTaskDelay(); 

            dynamic doc = webBrowser1.Document;
            dynamic button = doc.GetElementsByTagName("input");
            foreach (dynamic element in button)
            {
                if (element.GetAttribute("type").Equals("submit"))
                {
                    element.InvokeMember("click");
                    break;
                }
            }
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            BtnStart.Hide();
            BtnStop.Show();
           
            if (!notBusy)
                notBusy = true;

            if (notBusy)
            {
                webBrowser1.Document.GetElementById("username").SetAttribute("value", usernameAndPassword[0]);
                webBrowser1.Document.GetElementById("password").SetAttribute("value", usernameAndPassword[1]);

                dynamic doc = webBrowser1.Document;
                dynamic button = doc.GetElementsByTagName("button");
                foreach (dynamic element in button)
                {
                    if (element.GetAttribute("type").Equals("submit"))
                    {
                        element.InvokeMember("click");
                        break;
                    }
                }
            }

            await Task.Delay(5000);

            int count = 0;
            for(int j = 0; j < 8; j++)
            {
                if (!moodleLinks[j].Equals(""))
                {
                    count++;
                }
                else break;
            }

            while(notBusy)
            {
                for(int i = 0; i < count; i++)
                {
                    if(notBusy)
                    {
                        this.webBrowser1.Navigate(moodleLinks[i]);
                    }
                    else
                    {
                        this.webBrowser1.Navigate("https://learn.mandela.ac.za/login/index.php");
                        break;
                    }
                    if(notBusy)
                    {
                        await PutTaskDelay();
                    }
                    else
                    {
                        this.webBrowser1.Navigate("https://learn.mandela.ac.za/login/index.php");
                        break;
                    }
                }
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            settings.ShowDialog();
        }
    }
}
