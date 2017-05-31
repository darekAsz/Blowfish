using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace blowfish
{
    class Checker
    {
        public bool Check(string path)
        {
            //load info from xml header to string
            string xmlHeader = "";
            string line;
            using (var source = new StreamReader(path))
            {
                do
                {
                    line = source.ReadLine();
                    xmlHeader += line;
                }
                while (!line.Contains("</ApprovedUsers>") && (!source.EndOfStream));

                xmlHeader += "</EncryptedFileHeader>";


            }
            bool b, c, d, e, f;
            try
            {
                var xml = XDocument.Parse(xmlHeader);
                 b = xml.Descendants("Algorithm").Any();
                 c = xml.Descendants("KeySize").Any();
                 d = xml.Descendants("BlockSize").Any();
                 e = xml.Descendants("CipherMode").Any();
                 f = xml.Descendants("ApprovedUsers").Any();
            }
            catch
            {
                return false;
            }

            if ( b == true && c == true && d == true && e == true && f == true) return true;
            else return false;

        }
    }
}
