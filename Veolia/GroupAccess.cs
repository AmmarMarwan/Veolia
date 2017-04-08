using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veolia
{
    [Table("GroupAccess")]
    public class GroupAccess
    {
        [Key]
        public int groupAccessID { get; set; }
        public List<RelationUserGroupAccess> relationUserGroupAccess { get; set; }
        [MaxLength(50)]
        public string groupName { get; set; }
        public string groupDescription { get; set; }
    }
}
