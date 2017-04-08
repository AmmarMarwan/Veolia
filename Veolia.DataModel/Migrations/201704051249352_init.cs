namespace Veolia.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recommandation", "creerRegaredsRepartitionEtDeBouclage", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "creerVentilationPrimaireEtSecondaire", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "creerFiliereTraitementAvantDispersion", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "creerVentilationSecondaireRemontantDessusFaitageHabitation", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "rehabiliterInstallationSuivantPreconisation", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "remplacerFosseSeptiqueEtBacGraisseParFosseEaux", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "remplacerPuitsPerduParFiliereTraitement", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "rendreAccessibleFilierePretraitement", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "rendreAccessibleFiliaireTraitement", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "rendreAccessibleFosseParInstallationRegard", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "rendreAccessibleRegarsRepartitionEtBouclage", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "rendreAccessibleElementInstallation", c => c.Boolean());
            AlterColumn("dbo.Recommandation", "suprimerArriveeEaxPluvialesDansFiliere", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recommandation", "suprimerArriveeEaxPluvialesDansFiliere", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "rendreAccessibleElementInstallation", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "rendreAccessibleRegarsRepartitionEtBouclage", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "rendreAccessibleFosseParInstallationRegard", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "rendreAccessibleFiliaireTraitement", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "rendreAccessibleFilierePretraitement", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "remplacerPuitsPerduParFiliereTraitement", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "remplacerFosseSeptiqueEtBacGraisseParFosseEaux", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "rehabiliterInstallationSuivantPreconisation", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "creerVentilationSecondaireRemontantDessusFaitageHabitation", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "creerFiliereTraitementAvantDispersion", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "creerVentilationPrimaireEtSecondaire", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Recommandation", "creerRegaredsRepartitionEtDeBouclage", c => c.Boolean(nullable: false));
        }
    }
}
