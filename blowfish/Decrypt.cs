using Org.BouncyCastle.Crypto;
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
using System.Xml.Linq;

namespace blowfish
{


    class Decrypt
    {
        public string selectedUser { get; set; }
        string pathLoad;
        string pathSave;
        string password;
        string mode;
        int keySize;
        int subblockSize;
        byte[] vectorIV;
        byte[] encryptedSessionKey;
        byte[] decryptedSessionKey;
        byte[] hashedPassword;
        private bool IsPasswordOK { get; set; } = true;
        public Decrypt(string from, string to, string pass, string user)//konstruktor
        {
            this.pathLoad = from;
            this.pathSave = to;
            this.selectedUser = user;
            this.password = pass;
        }



        public void DecryptFile()
        {
            //load info from xml header to string
            string xmlHeader = "";
            string line;
            using (var source = new StreamReader(pathLoad))
            {
                do
                {
                    line = source.ReadLine();
                    xmlHeader += line;
                }
                while (!line.Contains("</ApprovedUsers>") && (!source.EndOfStream));
            
            xmlHeader += "</EncryptedFileHeader>";
            }
            GetInfo(xmlHeader); //get info about encryption
            //hashing password given by user
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes2 = Encoding.UTF8.GetBytes(password);
             hashedPassword = sha256.ComputeHash(bytes2);


            DecryptionSessionKey(encryptedSessionKey);
            GetOnlyCiphertext();


            //setting all parameters of decoding
            BufferedBlockCipher Blowfish = new BufferedBlockCipher(new BlowfishEngine());

            using (var input = File.Open("ciphertext.temp", FileMode.Open))
            using (var fs = File.Open(pathSave, FileMode.Create))
            {

                

                if (IsPasswordOK)
                {

                    switch (mode)
                    {
                        case "ECB":
                            {
                                Blowfish = new PaddedBufferedBlockCipher(new BlowfishEngine());
                                KeyParameter e = new KeyParameter(decryptedSessionKey);
                                Blowfish.Init(false, e);
                                break;
                            }
                        case "CBC":
                            {
                                CbcBlockCipher cipher = new CbcBlockCipher(new BlowfishEngine());
                                Blowfish = new PaddedBufferedBlockCipher(cipher);
                                break;
                            }

                        case "OFB":
                            {
                                OfbBlockCipher cipher = new OfbBlockCipher(new BlowfishEngine(), subblockSize);
                                Blowfish = new PaddedBufferedBlockCipher(cipher);
                                break;
                            }
                        case "CFB":
                            {
                                CfbBlockCipher cipher = new CfbBlockCipher(new BlowfishEngine(), subblockSize);
                                Blowfish = new PaddedBufferedBlockCipher(cipher);
                                break;
                            }
                    }
                    //ofb,cfb,cbc have initial vector
                    if (mode != "ECB")
                    {
                        var parameters = new ParametersWithIV(new KeyParameter(decryptedSessionKey), vectorIV);
                        Blowfish.Init(false, parameters);
                    }

                }
                else
                {
                    Blowfish = new BufferedBlockCipher(new BlowfishEngine());
                    Blowfish.Init(false, new KeyParameter(decryptedSessionKey));
                }


                //tmp buffers
                var buffer = new byte[Blowfish.GetBlockSize()];
                var outBuffer = new byte[Blowfish.GetBlockSize() + Blowfish.GetOutputSize(buffer.Length)];

                int inCount = 0;
                int outCount = 0;


                while ((inCount = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outCount = Blowfish.ProcessBytes(buffer, 0, inCount, outBuffer, 0);
                    fs.Write(outBuffer, 0, outCount);

                }
                try
                {
                    outCount = Blowfish.DoFinal(outBuffer, 0);
                    fs.Write(outBuffer, 0, outCount);
                }
                catch (DataLengthException) { }


            
            input.Close();
                fs.Close();
                //end of decryption

            }
        }

        public void GetInfo(string xmlValue)
        {

            var xml = XDocument.Parse(xmlValue);
            var header = xml.Element("EncryptedFileHeader");

            keySize = Int32.Parse(header.Element("KeySize").Value);
            mode = header.Element("CipherMode").Value;

            if (header.Descendants("SubblockSize").Any())
                subblockSize = Int32.Parse(header.Element("SubblockSize").Value);

            if (header.Descendants("IV").Any())
                vectorIV = Convert.FromBase64String(header.Element("IV").Value);

            var usr = header.Element("ApprovedUsers").Descendants("User").First(u => u.Element("Name").Value == selectedUser);

            var us = usr.Element("Name").Value;
            encryptedSessionKey = Convert.FromBase64String(usr.Element("SessionKey").Value);
        }

        public void DecryptionSessionKey(byte[] encrypted)
        {
            var blowfish_temp = new BufferedBlockCipher(new BlowfishEngine());
            KeyParameter e = new KeyParameter(hashedPassword);
            blowfish_temp.Init(false, e);

            var privateEncrypted = File.ReadAllBytes("private//" + selectedUser + ".key");

            var privateKey = new byte[blowfish_temp.GetOutputSize(privateEncrypted.Length)];
            var len = blowfish_temp.ProcessBytes(privateEncrypted, 0, privateEncrypted.Length, privateKey, 0);
            blowfish_temp.DoFinal(privateKey, len);

            var privateAsString = Encoding.ASCII.GetString(privateKey);


            using (var rsa = new RSACryptoServiceProvider(2048))
            {

                rsa.PersistKeyInCsp = false;
                try
                {
                    rsa.FromXmlString(privateAsString);
                    decryptedSessionKey = rsa.Decrypt(encryptedSessionKey, false);
                }
                catch (Exception)
                {
                    IsPasswordOK = false;
                    decryptedSessionKey = hashedPassword.Take(keySize / 8).ToArray();
                }

            }
        }

        public void GetOnlyCiphertext()
        {

           
            byte[] buffer = new byte[1024];
            int bytesRead;

            using (var fs = File.Open("ciphertext.temp", FileMode.Create))
            using (var fis = File.Open(pathLoad, FileMode.Open))
            using (var br = new BinaryReader(fis))
            {
                string str = "";
                char c;
                while (true)
                {
                    c = br.ReadChar();
                    if (c == '\n')
                    {
                        if (str.Contains("</EncryptedFileHeader>")) break;
                        else
                            str = "";
                    }
                    else
                    {
                        str += c;
                    }
                }

                while ((bytesRead = br.Read(buffer, 0, buffer.Length)) > 0)
                {
                    
                    fs.Write(buffer, 0, bytesRead);
                }
            }

        
    }
    }
}