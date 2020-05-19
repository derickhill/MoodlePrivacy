using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodlePrivacy
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs x)
        {
            string[] usernameAndPassword = new string[2];
            string[] moodleLinks = new string[8];
            string [] moduleCodes = new string[8];

            usernameAndPassword[0] = TxtUsername.Text;
            usernameAndPassword[1] = TxtPassword.Text;

            moodleLinks[0] = TxtMoodleLink1.Text;
            moodleLinks[1] = TxtMoodleLink2.Text;
            moodleLinks[2] = TxtMoodleLink3.Text;
            moodleLinks[3] = TxtMoodleLink4.Text;
            moodleLinks[4] = TxtMoodleLink5.Text;
            moodleLinks[5] = TxtMoodleLink6.Text;
            moodleLinks[6] = TxtMoodleLink7.Text;
            moodleLinks[7] = TxtMoodleLink8.Text;

            moduleCodes[0] = TxtModuleCode1.Text;
            moduleCodes[1] = TxtModuleCode2.Text;
            moduleCodes[2] = TxtModuleCode3.Text;
            moduleCodes[3] = TxtModuleCode4.Text;
            moduleCodes[4] = TxtModuleCode5.Text;
            moduleCodes[5] = TxtModuleCode6.Text;
            moduleCodes[6] = TxtModuleCode7.Text;
            moduleCodes[7] = TxtModuleCode8.Text;

            System.IO.File.WriteAllLines(@"LoginInfo.txt", usernameAndPassword);
            System.IO.File.WriteAllLines(@"ModuleCodesInfo.txt", moduleCodes);
            System.IO.File.WriteAllLines(@"MoodleLinksInfo.txt", moodleLinks);

        }

        private void BtnSaveLoginInfo_Click(object sender, EventArgs e)
        {
            string[] usernameAndPassword = new string[2];

            usernameAndPassword[0] = TxtUsername.Text;
            usernameAndPassword[1] = TxtPassword.Text;

            System.IO.File.WriteAllLines(@"LoginInfo.txt", usernameAndPassword);
        }

        private void BtnSaveCodes_Click(object sender, EventArgs e)
        {
            string[] moduleCodes = new string[8];

            moduleCodes[0] = TxtModuleCode1.Text;
            moduleCodes[1] = TxtModuleCode2.Text;
            moduleCodes[2] = TxtModuleCode3.Text;
            moduleCodes[3] = TxtModuleCode4.Text;
            moduleCodes[4] = TxtModuleCode5.Text;
            moduleCodes[5] = TxtModuleCode6.Text;
            moduleCodes[6] = TxtModuleCode7.Text;
            moduleCodes[7] = TxtModuleCode8.Text;

            System.IO.File.WriteAllLines(@"ModuleCodesInfo.txt", moduleCodes);
        }

        private void BtnSaveLinks_Click(object sender, EventArgs e)
        {
            string[] moodleLinks = new string[8];

            moodleLinks[0] = TxtMoodleLink1.Text;
            moodleLinks[1] = TxtMoodleLink2.Text;
            moodleLinks[2] = TxtMoodleLink3.Text;
            moodleLinks[3] = TxtMoodleLink4.Text;
            moodleLinks[4] = TxtMoodleLink5.Text;
            moodleLinks[5] = TxtMoodleLink6.Text;
            moodleLinks[6] = TxtMoodleLink7.Text;
            moodleLinks[7] = TxtMoodleLink8.Text;

            System.IO.File.WriteAllLines(@"MoodleLinksInfo.txt", moodleLinks);
        }
    }
}
