using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veolia
{
    [Table("Recommandation")]
    public class Recommandation
    {
        [Key]
        public int recommandationID { get; set; }
       // public  FormDiagnosticANC formulair { get; set; }
        public bool? creerRegaredsRepartitionEtDeBouclage { get; set; }
        public bool? creerVentilationPrimaireEtSecondaire { get; set; }
        public bool? creerFiliereTraitementAvantDispersion { get; set; }
        public bool? creerVentilationSecondaireRemontantDessusFaitageHabitation { get; set; }
        public bool? rehabiliterInstallationSuivantPreconisation { get; set; }
        public bool? remplacerFosseSeptiqueEtBacGraisseParFosseEaux { get; set; }
        public bool? remplacerPuitsPerduParFiliereTraitement { get; set; }
        public bool? rendreAccessibleFilierePretraitement { get; set; }
        public bool? rendreAccessibleFiliaireTraitement { get; set; }
        public bool? rendreAccessibleFosseParInstallationRegard { get; set; }
        public bool? rendreAccessibleRegarsRepartitionEtBouclage { get; set; }
        public bool? rendreAccessibleElementInstallation { get; set; }
        public bool? suprimerArriveeEaxPluvialesDansFiliere { get; set; }
    }
}
