using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Veolia
{
    [Table("Client")]
    public class Client
    {
        public Client()
        {
            adress = new List<AdressClient>();
            formControlConform = new List<FormControlConform>();
            formDiagnosticANC = new List<FormDiagnosticANC>();
        }

        [Key]
        public int clientID { get; set; }

        [ForeignKey("userId")]
        public User user { get; set; }
        public int userId { get; set; }

        public List<FormControlConform> formControlConform { get; set; }
        public List<FormDiagnosticANC> formDiagnosticANC { get; set; }
        public List<AdressClient> adress { get; set; }

        [MaxLength(20)]
        public string clientName { get; set; }
        [MaxLength(20)]
        public string clientSurame { get; set; }
        [EmailAddress, MaxLength(50)]
        public string clientEmail { get; set; }
        [Required, MaxLength(13)]
        public string clientNumTel { get; set; }
        public DateTime clientDateCreation { get; set; }
        public DateTime? clintDateModification { get; set; }
    }
}
