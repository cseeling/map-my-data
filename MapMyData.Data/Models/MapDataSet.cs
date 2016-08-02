using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMyData.Data.Models
{
    public class MapDataSet : BaseModel
    {
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public AppUser Owner { get; set; }
        public bool IsPublic { get; set; }
        public ICollection<DataPoint> Data { get; set; }
    }
}
