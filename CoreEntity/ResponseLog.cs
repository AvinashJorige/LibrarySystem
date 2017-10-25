using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntity
{
    public class ResponseLog
    {
        public bool Status { get { return this.Status; } set { this.Status= true; } }
        public object Result { get { return this.Result; } set { this.Result = null; } }
        public string Error { get; set; }
    }
}
