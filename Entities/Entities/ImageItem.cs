using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;


namespace Entities.Entities
{
    public class ImageItem
    {

        public ImageItem()
        {
            IsActive = true;
            IsPublic = true;
            IdWeb = Guid.NewGuid();
            InsertDate = DateTime.Now;

        }

        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImageSource { get; set; }
        public string Category { get; set; }
        public Guid IdWeb { get; set; }
        public DateTime InsertDate { get; private set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; private set; }


    }


}
