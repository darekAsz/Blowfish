using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace blowfish
{
    class HeaderXML
    {

        public List <string> GetFromXML(string pathLoad) {
            List<string> users = new List<string>();
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


            try
            {
                var xml = XDocument.Parse(xmlHeader);
                var header = xml.Element("EncryptedFileHeader");

                var accounts = xml.Root.Elements("ApprovedUsers").Elements("User");
                foreach (XElement elem in accounts)
                {
                    users.Add(elem.Element("Name").Value.ToString());

                }
            }
            catch
            {
                
            }
            return users;
            


        } }
}
