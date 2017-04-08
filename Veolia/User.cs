using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veolia
{
    [Table("User")]
    public class User
    {
            [Key]
            public int userID { get; set; }
            public List<Client> Client { get; set; }
            public List<FormControlConform> formControlConform { get; set; }
            public List<FormDiagnosticANC> formDiagnosticANC { get; set; }
            public  List<RelationUserGroupAccess> relationUserGroupAccess { get; set; }
            [EmailAddress, Required]
            public string email { get; set; }
            [MaxLength(20)]
            public string userName { get; set; }
            [MaxLength(20)]
            public string userSurname { get; set; }
            [MaxLength(13)]
            public string userTel { get; set; }
            public DateTime dateInscription { get; set; }
            public DateTime? dateModification { get; set; }
    }
}
