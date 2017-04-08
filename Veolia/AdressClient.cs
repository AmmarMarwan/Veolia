
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Veolia
{

    [Table("AdressClient")]
    public class AdressClient 
    {
        public AdressClient()
        {
            relationFormAdress = new List<RelationFormAdress>(); 
        }

        [Key] 
        public int adressClientID { get; set; }

        [ForeignKey("clientID")]
        public Client client { get; set; }
        public int clientID { get; set; }

        public List<RelationFormAdress> relationFormAdress { get; set; }

        public string adress { get; set; }
        public string commune { get; set; }
    }
}
