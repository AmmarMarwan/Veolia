using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veolia
{
    [Table("FormControlConform")]
    public class FormControlConform
    {
        [Key]
        public int formControlConformID { get; set; }

        [ForeignKey("clientID")]
        public virtual Client client { get; set; }
        public int clientID { get; set; }

        [ForeignKey("userID")]
        public virtual User user { get; set; }
        public int? userID { get; set; }

        public List<RelationFormAdress> relationFormAdress { get; set; }

        public bool presenceRegardEU { get; set; }
        public string regardEUAccessible { get; set; }
        public bool presenceRegardEP { get; set; }
        public string regardEPAccessible { get; set; }
        public string natureEffluent { get; set; }
        public string typeBranchement { get; set; }
        public bool dispositifAntiReflux { get; set; }
        public int wc { get; set; }
        public int salleDeBain { get; set; }
        public int evier { get; set; }
        public int laveLinge { get; set; }
        public int laveVaisselle { get; set; }
        public int systemeRelevage { get; set; }
        public int fosseSeptique { get; set; }
        public int nombreGouttieres { get; set; }
        public string regardPiedGouttiere { get; set; }
        public string evacuationEauPluies { get; set; }
        public DateTime dateControle { get; set; }
        public bool constatEnquete { get; set; }
        public DateTime anomaliesConstatees { get; set; }
        public string recommendationTraveauxMiseConformite { get; set; }

    }
}
