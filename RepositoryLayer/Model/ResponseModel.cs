using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Model
{
    public class ResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Messsage { get; set; }
        public string Role { get; set; }
        public string Id { get; set; }
        public int StatusCode { get; set; }
        public ICollection<RolesModel> RolesModels { get; set; }
        public ICollection<PagesModel> PagesModels { get; set; }
    }
    public class RolesModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class PagesModel
    {
        public int PageId { get; set; }
        public string PageMenu { get; set; }
    }
}
