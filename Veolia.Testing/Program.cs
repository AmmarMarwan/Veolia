using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veolia.DataModel;

namespace Veolia.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //vealiamodelchec modalClass = new vealiamodelchec();
            //foreach (Client client in modalClass.getAllClients())
            //{
            //    Console.WriteLine(client.clientEmail);

            //}
            /*
            List<AdressClient> addd = CheckAdress(5);
            //Console.WriteLine(addd);
            foreach (AdressClient a in addd)
            {
                Console.WriteLine(a.adressClientID);
                Console.WriteLine(a.adress);
                Console.WriteLine(a.commune);
                Console.WriteLine(a.clientID);
                Console.Write("************************* \n");
            }
            Console.ReadKey();
            */

            int clientID = addClient("Almasri", "Ahmad", "0000000000", 3, "Ahmad@gmail.com");
            int adressID = addAddres(clientID, "1220 rue de Bayrouth", "ALMANAMAA");
            int formID = addFormcontrol(clientID, adressID);
            addRelationAdressForm(formID, adressID);

        }

 

        public static int addClient(string nom, string prenom, string tel, int userId, string mail)
        {
            OperationClient addClient = new OperationClient();
            Client client = new Client();

            client.clientName = nom;
            client.clientSurame = prenom;
            client.clientNumTel = tel;
            client.clientDateCreation = DateTime.Now;
            client.clintDateModification = DateTime.Now;
            client.userId = userId;
            client.clientEmail = mail;

            return addClient.SaveNewClient(client);
        }

        public static int addAddres(int idClient, string adress, string commune)
        {

            OperationAdressClient newTransaction = new OperationAdressClient();
            AdressClient newaddress = new AdressClient();

            newaddress.clientID = idClient;
            newaddress.adress = adress;
            newaddress.commune = commune; 

            return (newTransaction.SaveNewAdress(newaddress));

        }

        public static int addFormcontrol( int ClientID, int userID)
        {
            OperationFormContolConform newTransaction = new OperationFormContolConform();
            FormControlConform newForm = new FormControlConform();

            newForm.clientID = ClientID;
            newForm.userID = 3;
            return newTransaction.SaveNewFormControlConform(newForm);
        }

        public static void addRelationAdressForm(int formID, int adressID)
        {
            OperationRelationAdressForm newTransaction = new OperationRelationAdressForm();
            RelationFormAdress newRelation = new RelationFormAdress();

            newRelation.adressClientID = adressID;
            newRelation.formControlConformID = formID;
            newTransaction.SaveNewRelationFormAdress(newRelation);
        }








        public static List<AdressClient> CheckAdress(int ClientID)
        {
            OperationAdressClient newTransaction = new OperationAdressClient();
            return newTransaction.FindAdressClientUsingClientID(ClientID);

        }




    }
}
