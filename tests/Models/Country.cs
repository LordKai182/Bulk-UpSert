using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlBulkMerge.Test.Models
{
    public class PromocaoUneg
    {
        public Int32 prm_id { get; set; }
        public Int32 uneg_id { get; set; }


        public PromocaoUneg(int prm_id, int uneg_id)
        {
            this.prm_id = prm_id;
            this.uneg_id = uneg_id;
           
        }
    }
}
