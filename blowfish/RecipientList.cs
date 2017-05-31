using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace blowfish
{
    class RecipientList
    {
        public List<string> ShowRP()
        {
            var path = Path.GetFullPath("public");

            var listUsers = new List<string>();
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] Files = info.GetFiles("*.pub");

            foreach (FileInfo file in Files)
            {
                
                listUsers.Add(file.Name);
            }


            return listUsers;
        }
    }
}
