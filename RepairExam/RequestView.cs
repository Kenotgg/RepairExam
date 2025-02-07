using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairExam
{
    internal class RequestView
    {
        public int id;
        public string client;
        public string[] masters;
        public string[] comments;
        public RequestView(int id, string client, string[] masters, string[] comments) 
        {
            this.id = id;
            this.client = client;
            this.masters = masters;
            this.comments = comments;
        }

        public RequestView(string client, string[] masters, string[] comments) 
        {
            this.client = client;
            this.masters = masters;
            this.comments = comments;
        }
    }
}
