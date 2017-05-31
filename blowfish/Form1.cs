/*
INFO
zapas przed ncipher
blok danych 64 bit
 1.funckja skrótu + zaszyfrować klucz prywatny
 3.pobrac z xmla i zaszyfrowac sesyjny
 4.zapisac sesyjny

 
                //szyfrowanie
                //bufferedread
              //robisz tyle pelnych blokow ile mozesz, a na ostatnim niepelnym robisz dofinal()
              //processbytes - szyfruje blok
              //zaszyfrowane do tmpka 
              //tmpka wczytujemy filereaderem, to robimy cryptostream i robimy tobase64, to do tmpa2 a stąd porcjując do xmla
             


 do zrobienia
 1. jak sie usuwa uzytkownika to usuwane są klucze prywatne i publiczne jego
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities.Encoders;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Engines;


//fileEncCB - file encryption choose button
//fileEncTB - file encryption text box
//fileEnc - file to encrypt
//fileEncSB - file encryption save button
//fileEncryptedTB - text box
//keylengthCB - combo box
//blockLengthCB - combo box
//encModeCB - encryption mode comb box
//subblockLengthCB - combo box
//encryptedPrivatKeyTB - text box
//encryptedPrivatKeyCB - chose button
//recipientLB - list box (odbiorców)
//showCB - check box
//showECB - show encryption (password) check box
namespace blowfish
{
    public partial class MainPanel : Form
    {
        public MainPanel()
        {

            InitializeComponent();

        }
        private void MainPanel_Load(object sender, EventArgs e)
        {
            recipientLB.SelectionMode = SelectionMode.MultiExtended;

            keyLengthCB.Items.Add("128");
            keyLengthCB.Items.Add("256");
            keyLengthCB.Items.Add("448");
            keyLengthCB.SelectedIndex = 0;


            encModeCB.Items.Add("ECB");
            encModeCB.Items.Add("CBC");
            encModeCB.Items.Add("CFB");
            encModeCB.Items.Add("OFB");
            encModeCB.SelectedIndex = 0;

            subblockLengthCB.Items.Add("8");
            subblockLengthCB.Items.Add("16");
            subblockLengthCB.Items.Add("24");
            subblockLengthCB.Items.Add("32");
            subblockLengthCB.Items.Add("64");

            var rlist = new RecipientList();
            var listUsers = rlist.ShowRP();
            foreach (var item in listUsers)
            {
                string sub = item.Substring(0, item.Length - 4);
                recipientLB.Items.Add(sub);
            }

            passwordDes.PasswordChar = '*';
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        OpenFileDialog plik = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (plik.ShowDialog() == DialogResult.OK)
            {recipientLB2.Items.Clear();
                encryptedFileRoot.Text = Path.GetFullPath(plik.FileName);
                StreamReader read = new StreamReader(File.OpenRead(plik.FileName));

                var x = new HeaderXML();
               var listUsers = x.GetFromXML(encryptedFileRoot.Text);
                foreach (var user in listUsers)
                {
                    recipientLB2.Items.Add(user);
                }
                read.Dispose();
            }

        }

        SaveFileDialog save = new SaveFileDialog();
        private void sciezka_Click(object sender, EventArgs e)
        {
            if (save.ShowDialog() == DialogResult.OK)
            {
                DecryptedFileRoot.Text = Path.GetFullPath(save.FileName);
            }
        }

       

        private void cancelButton_Click(object sender, EventArgs e)
        {
            save.FileName = "";
            plik.FileName = "";
            DecryptedFileRoot.Clear();
            encryptedFileRoot.Clear();
            passwordDes.Clear();
        }

        //szyfrowanie//encryption
        OpenFileDialog fileEnc = new OpenFileDialog();
        private void fileEncCB_Click(object sender, EventArgs e)
        {
            if (fileEnc.ShowDialog() == DialogResult.OK)
            {

                fileEncTB.Text = Path.GetFullPath(fileEnc.FileName);
                StreamReader readEnc = new StreamReader(File.OpenRead(fileEnc.FileName));
                readEnc.Dispose();

            }
        }
        SaveFileDialog fileEncrypted = new SaveFileDialog();
        private void FileEncSB_Click(object sender, EventArgs e)
        {
            if (fileEncrypted.ShowDialog() == DialogResult.OK)
            {
                fileEncryptedTB.Text = Path.GetFullPath(fileEncrypted.FileName);
            }
        }

        private void encModeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (encModeCB.Items[encModeCB.SelectedIndex].ToString() == "CFB" ||
                encModeCB.Items[encModeCB.SelectedIndex].ToString() == "OFB")
            {
                subblockLengthCB.Enabled = true;
            }
            else subblockLengthCB.Enabled = false;
        }

        private void startEnc_Click(object sender, EventArgs e)
        {
            //list od selected users
            var listSelected = new List<String>();
            foreach (var selectedItem in recipientLB.SelectedItems)
            {
             listSelected.Add( selectedItem as String);
            }

            //sessionKey length
            var SKLength = keyLengthCB.Items[keyLengthCB.SelectedIndex].ToString();
            //paths
            var pathFrom = fileEncTB.Text.ToString();
            var pathTo = fileEncryptedTB.Text.ToString();
            string subblock;
            string mode = encModeCB.Items[encModeCB.SelectedIndex].ToString();
            if (encModeCB.Items[encModeCB.SelectedIndex].ToString() == "OFB" ||
                encModeCB.Items[encModeCB.SelectedIndex].ToString() == "CFB")
            {
                try
                {
                    subblock = subblockLengthCB.Items[subblockLengthCB.SelectedIndex].ToString();
                }
                catch
                {
                    subblock = "";
                }
            }
            else subblock = "";

            if (pathFrom != "" && pathTo != "" && (mode == "ECB" || mode == "CBC" || (mode == "OFB" && subblock != "")
                || (mode == "CFB" && subblock != "")) && listSelected.Any())
            {
                var encryptClass = new Encrypt(SKLength, listSelected, mode, pathFrom, pathTo, subblock);

                encryptClass.EncryptFile();

                encryptClass = null;
            }
            else
            {
                MessageBox.Show("Niepełne dane", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void deszyfr_Click(object sender, EventArgs e)
        {
            //paths
            var pathFrom = encryptedFileRoot.Text.ToString();
            var pathTo = DecryptedFileRoot.Text.ToString();

            passwordDes.PasswordChar =  '\0';        
            var password = passwordDes.Text.ToString();
            passwordDes.PasswordChar = '*';

            if (pathFrom != "" && pathTo != "" && password != "")
            {
                var check = new Checker();
                bool hasHeader = check.Check(pathFrom);

                if (hasHeader)
                {
                    var selectedUser = "";
                    try
                    {
                        selectedUser = recipientLB2.SelectedItem.ToString();
                    }
                    catch { }
                    if (selectedUser != "")
                    {
                        var decryptClass = new Decrypt(pathFrom, pathTo, password, selectedUser);
                        decryptClass.DecryptFile();
                    }
                    else
                    {
                        MessageBox.Show("Nie wybrano odbiorcy", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Wybrano niewłaściwy plik", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Niepełne dane", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cancelEnc_Click(object sender, EventArgs e)
        {
            fileEncrypted.FileName = "";
            fileEncryptedTB.Clear();
            fileEncTB.Clear();
            fileEnc.FileName = "";

        }



       

        //menu
        private void autorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Dariusz Asztemborski" + Environment.NewLine +
                "Student 3. roku Informatyki" + Environment.NewLine + " Nr indeksu 155021";
            string caption = "Autor implementacji algorytmu BlowFish";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }


        private void opisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Blowfish to szyfr blokowy stworzony przez Bruce'a Schneiera w 1993 roku jako " + Environment.NewLine +
                "szybka i bezpłatna alternatywa dla istniejących ówcześnie algorytmów." + Environment.NewLine +
                "Algorytm operuje na 64 - bitowym bloku wejściowym tekstu jawnego," + Environment.NewLine +
               "który przetwarzamy w 16 - tu rundach";
            string caption = "Opis algorytmu";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
        }

    }
}
