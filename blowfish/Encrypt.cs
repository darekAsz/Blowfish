using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace blowfish
{


    class Encrypt
    {
          string SessionLength = "" ;
        public List<string> selectedUsers { get; set; }
        string EncMode;
        string pathLoad;
        string pathSave;
        int subblockSize;
        byte[] IV;
        
        public Encrypt(string SKLen,List<string> selUsr, string mode,string from, string to, string subblock ) //konstruktor
        {   
            this.SessionLength = SKLen;
            this.EncMode = mode;
            this.pathLoad = from;
            this.pathSave = to;
            selectedUsers = selUsr;
            
            if (mode == "OFB" || mode == "CFB") this.subblockSize =Convert.ToInt32(subblock);

        }



        public void EncryptFile()
        {
            //sk generate
            UInt32 keyLength = Convert.ToUInt32(SessionLength);
            var generator = new SessionKeyGenerator();
            string sessionKey = generator.GenerateSK(keyLength);
            var byteSessionKey = Encoding.ASCII.GetBytes(sessionKey);

            //make iv vector if mode != ecb
            if (EncMode != "ECB")
            {
                Random rnd = new Random();
                var engine = new BlowfishEngine();
                IV = new byte[engine.GetBlockSize()];
                rnd.NextBytes(IV);
            }


            //make xml with encryption info
            MakeXML(byteSessionKey);

            //engine blowfish
            PaddedBufferedBlockCipher Blowfish = new PaddedBufferedBlockCipher(new BlowfishEngine(), new Pkcs7Padding());
            //IO files
            File.AppendAllText(pathSave, Environment.NewLine);
            var input = File.Open(pathLoad, FileMode.Open);
            var writeFileStream = File.Open(pathSave, FileMode.Append);

       
            //assignment mode engine 
            switch (EncMode)
            {
                case "ECB":
                    { 
                    Blowfish = new PaddedBufferedBlockCipher(new BlowfishEngine(), new Pkcs7Padding());
                    KeyParameter e = new KeyParameter(byteSessionKey);
                    Blowfish.Init(true, e);
                    break;
                    }
                case "CBC":
                    {
                        CbcBlockCipher cipher = new CbcBlockCipher(new BlowfishEngine());
                        Blowfish = new PaddedBufferedBlockCipher(cipher, new Pkcs7Padding());
                        break;
                    }
                    
                case "OFB":
                    {
                        OfbBlockCipher cipher = new OfbBlockCipher(new BlowfishEngine(),subblockSize);
                        Blowfish = new PaddedBufferedBlockCipher(cipher, new Pkcs7Padding());
                        break;
                    }
                case "CFB":
                    {
                        CfbBlockCipher cipher = new CfbBlockCipher(new BlowfishEngine(), subblockSize);
                        Blowfish = new PaddedBufferedBlockCipher(cipher, new Pkcs7Padding());
                        break;
                    }
            }
            //ofb,cfb,cbc have initial vector
        if(EncMode != "ECB") {
                var parameters = new ParametersWithIV(new KeyParameter(byteSessionKey), IV);
                Blowfish.Init(true, parameters);
            }

            

            //tmp buffers
            var buffer = new byte[Blowfish.GetBlockSize()];
            var outBuffer = new byte[Blowfish.GetBlockSize() + Blowfish.GetOutputSize(buffer.Length)];

            int inCount = 0;
            int outCount = 0;


            while ((inCount = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                outCount = Blowfish.ProcessBytes(buffer, 0, inCount, outBuffer, 0);
                writeFileStream.Write(outBuffer, 0, outCount);
              
            }

            outCount = Blowfish.DoFinal(outBuffer, 0);
            writeFileStream.Write(outBuffer, 0, outCount);

            input.Close();
            writeFileStream.Close();
            //end of ecryption


           
        }

        public void MakeXML(byte [] session)
        {
            //save to xml
            XDocument xml = new XDocument(
                new XElement("EncryptedFileHeader",
                    new XElement("Algorithm", "Blowfish"),
                    new XElement("KeySize", SessionLength),
                    new XElement("BlockSize", "64"),
                    new XElement("CipherMode", EncMode)));

            if (EncMode == "CFB" || EncMode == "OFB")
            {
                xml.Root.Add(new XElement("SubblockSize", subblockSize.ToString()));
            }

            if (EncMode != "ECB")
            {
                xml.Root.Add(new XElement("IV", Convert.ToBase64String(IV)));
            }


            xml.Root.Add(new XElement("ApprovedUsers"));

            var usr = xml.Root.Element("ApprovedUsers");

            //add users from list of selected users, encrypt session key with rsa and public key
            foreach (var u in selectedUsers)
            {
                var rsa = new RSACryptoServiceProvider(2048);
                
                    rsa.PersistKeyInCsp = false;
                    
                        var publicKey = File.ReadAllText(@"public//" + u + ".pub");
                        rsa.FromXmlString(publicKey);

                        byte[] encryptedSessionKey= rsa.Encrypt(session, false);
   

                usr.Add(new XElement("User",
                    new XElement("Name", u),
                    new XElement("SessionKey", Convert.ToBase64String(encryptedSessionKey))
                    ));
                xml.Save(pathSave);
            }

        }


    }
}
