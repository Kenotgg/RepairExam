using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairExam
{
    internal class PageController
    {

        private static AddRequest _addRequest;
        public static AddRequest AddRequest 
        {
            get
            {
                if(_addRequest == null) 
                {
                    _addRequest = new AddRequest();
                }
                return _addRequest;
            }
        }
    }
}
