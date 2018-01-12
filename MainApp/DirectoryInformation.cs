using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
     class DirectoryInformation
    {

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }


        public DirectoryInformation(string path)
        {
            this.Path = path;
        }
       
    }
}
