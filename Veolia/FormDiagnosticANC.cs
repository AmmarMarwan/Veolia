using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veolia
{
    [Table("FormDiagnosticANC")]
    public class FormDiagnosticANC
    {
        [Key]
        public int formDiagnosticANCID { get; set; }

        [ForeignKey("clientID")]
        public Client client { get; set; }
        public int clientID { get; set; }

        [ForeignKey("userID")]
        public User user { get; set; }
        public int? userID { get; set; }

        
        [ForeignKey("recommandationID")]
        public Recommandation recommandation { get; set; }
        public int recommandationID { get; set; }

        //public RelationFormRecommandation relationFormRecommandation { get; set; }

        public int nombrePiecesPrincipales { get; set; }
        public int nombreResidents { get; set; }
        public DateTime anneeConstruction { get; set; }
        public DateTime anneeRealisationFiliereANC { get; set; }
        public bool terrainDesserviReseauPub { get; set; }
        public bool captageEauProximiteOuvrage { get; set; }
        public bool destineConsommationHumaine { get; set; }
        public string penteTerrain { get; set; }
        public bool separationEpEvEm { get; set; }
        public string destinationEauPluie { get; set; }
        public bool regardCollecte { get; set; }
        public bool regardCollecteAccessible { get; set; }
        public bool signesAlteration { get; set; }
        public bool presenceOdeurRegardCollecte { get; set; }
        public bool sepEauVannesEauMenageresPreTraitement { get; set; }
        public bool presenceBacGraisse { get; set; }
        public decimal volumeBacGraisse { get; set; }
        public bool signesAlterationBacGraisse { get; set; }
        public bool presenceFosse { get; set; }
        public decimal volumeFosse { get; set; }
        public bool signesAlterationFosse { get; set; }
        public string fonctionnementPreTraitement { get; set; }
        public string frequenceEntretien { get; set; }
        public DateTime dateDerniereVidange { get; set; }
        public bool documentJustifFourni { get; set; }
        public string niveauVoileBoues { get; set; }
        public bool sepEauVannesEauMenageresTraitement { get; set; }
        public string natureFiliereTraitement { get; set; }
        public string surfaceAllouee { get; set; }
        public string longueurTotale { get; set; }
        public int nombreDrains { get; set; }
        public string fonctionnementTraitement { get; set; }
        public bool filiere5mHabitation { get; set; }
        public bool filiere3mVegetation { get; set; }
        public bool filiere3mLimitesParcelle { get; set; }
        public bool filiere35mCaptageDestineConsommationHumaine { get; set; }
        public bool presenceVentilationSecondaire { get; set; }
        public bool odeurVentilation { get; set; }
        public bool presenceRegardRepartition { get; set; }
        public bool regardRepartitionAccessible { get; set; }
        public bool signesAlertationRegardRepartition { get; set; }
        public bool presenceOdeurRegardRepartition { get; set; }
        public bool ecoulementRegardRepartition { get; set; }
        public bool presenceRegardBouclage { get; set; }
        public bool regardBouclageAccessible { get; set; }
        public bool signesAlertationRegardBouclage { get; set; }
        public bool presenceOdeurRegardBouclage { get; set; }
        public bool ecoulementRegardBouclage { get; set; }
        public string fonctionnementRejet { get; set; }
        public bool autorisationDeversement { get; set; }
        public bool conformiteFiliere { get; set; }
        public string etatGeneralFonctionnement { get; set; }
        public string avisEnqueteur { get; set; }
    }
}
