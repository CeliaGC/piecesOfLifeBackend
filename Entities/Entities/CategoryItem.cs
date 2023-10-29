using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class CategoryItem
    {
        public CategoryItem()
        {
            IsActive = true;
            IsPublic = true;
            InsertDate = DateTime.Now;

        }
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public DateTime InsertDate { get; private set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; private set; }
        //[JsonIgnore]
        public ICollection<ImageItem> Images { get; } = new List<ImageItem>();
    }
}
