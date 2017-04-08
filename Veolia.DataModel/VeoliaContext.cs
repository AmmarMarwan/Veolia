using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Veolia.DataModel
{
    public class VeoliaContext : DbContext
    {
        public VeoliaContext(): base("name=testDB")
        {

        }

        public DbSet <AdressClient> AdressClients { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<FormControlConform> FormControlConforms { get; set; }
        public DbSet<FormDiagnosticANC> FormDiagnosticANCs { get; set; }
        public DbSet<GroupAccess> Groups { get; set; }
        public DbSet<Recommandation> Recommandations { get; set; }
        public DbSet<RelationFormAdress> RelationFormAdresss { get; set; }
        //public DbSet<RelationFormRecommandation> RelationFormRecommandations { get; set; }
        public DbSet<RelationUserGroupAccess> RelationGroupAccesss { get; set; }
        public DbSet<User> Users { get; set; }


    }

    public class vealiamodelchec
    {
        
        public List<Client> getAllClients()
        {
            VeoliaContext dbContext = new VeoliaContext();
            return dbContext.Clients.ToList();
        }
    }


}
