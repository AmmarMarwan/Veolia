using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veolia
{
    [Table("RelationUserGroupAccess")]
    public class RelationUserGroupAccess
    {
        [Key]
        public int relationUserGroupAccessID { get; set; }

        [ForeignKey("userID")]
        public User user { get; set; }
        public int userID { get; set; }

        [ForeignKey("groupAccessID")]
        public GroupAccess group { get; set; }
        public int groupAccessID { get; set; }
    }
}
