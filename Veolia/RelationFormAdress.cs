using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veolia
{
    [Table("RelationFormAdress")]
    public class RelationFormAdress
    {
        [Key]
        public int relationFormAdressID { get; set; }

        [ForeignKey("formControlConformID")]
        public FormControlConform formulaire { get; set; }
        public int formControlConformID { get; set; }

        [ForeignKey("adressClientID")]
        public AdressClient adress { get; set; }
        public int adressClientID { get; set; }

        [Required]public bool adressFacture { get; set; }

        
    }
}
