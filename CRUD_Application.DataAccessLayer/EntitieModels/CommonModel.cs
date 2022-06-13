using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Application.DataAccessLayer.EntitieModels
{
    public class CommonModel
    {
        public string? CreatedBy { get; set; }
        public string? ModifyedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? Status { get; set; }
    }
}
