using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassandraDataLayer.QueryEntities
{
    public class Section
    {
        public string schoolID { get; set; }
        public string teacherID { get; set; }
        public int num_stud { get; set; }
        public string name { get; set; }
        public SortedDictionary<string, string> opinions { get; set; }

        public string opinion { get; set; }
    }
}
