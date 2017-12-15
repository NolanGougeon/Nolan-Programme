using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace alimenterBaseDeDonnees
{
    public partial class Traitement : Form
    {
        static string sConnexion = "user=admin;password=siojjr;database=rallyelecture;host=localhost";
        public Traitement()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Cet méthode est activé lors de l'activation du bouton "Parcourir".
        /// Elle affiche une fenètre qui va permettre a l'utilisateur de séléctionner le fichier csv contenant les informations a inserer dans la base de donnée en récupérant son path.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btParcourir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog parcourir = new FolderBrowserDialog();
            parcourir.ShowDialog();
            tbRepertoireFichiers.Text = parcourir.SelectedPath;
            string[] filepaths = Directory.GetFiles(parcourir.SelectedPath, "*.csv", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < filepaths.Length; i++)
            {
                clbFichierCsv.Items.Add(filepaths[i].Replace(parcourir.SelectedPath + "\\", ""));
            }
        }
        /// <summary>
        /// Cet méthode est activé lors du chargement de la fenètre mère.
        /// Elle permet de charger les classes dans la liste déroulante.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Traitement_Load(object sender, EventArgs e)
        {
            MySqlConnection connexion;
            connexion = new MySqlConnection(sConnexion);
            connexion.Open();
            string sSelectClasse = "select classe.id,niveauScolaire,anneeScolaire from niveau inner join classe on niveau.id=classe.idNiveau;";
            MySqlCommand SelectClasse = new MySqlCommand(sSelectClasse, connexion);
            MySqlDataReader reader = SelectClasse.ExecuteReader();
            while (reader.Read())
            {
                cbClasse.Items.Add(reader["id"]+" "+reader["niveauScolaire"]+" "+reader["anneeScolaire"]);
            }
            reader.Close();
            connexion.Close();
            
        }
        /// <summary>
        /// Cet méthode s'active lorsque le bouton "lancer l'intégration" est activé.
        /// Elle permet l'intégration des fichiers csv des élèves séléctionnés dans la base de données.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btIntegration_Click(object sender, EventArgs e)
        {
            string classeNiveau = Convert.ToString(cbClasse.SelectedItem);
            string[] test = classeNiveau.Split(' ');
            MySqlConnection connexion;
            connexion = new MySqlConnection(sConnexion);
            connexion.Open();
            //Lorsque que la case suppression est coché on supprime tout les éléves de la base appartenant a la classe.
            if (cbSuppression.Checked == true)
            {
                try
                {
                    
                    MySqlCommand DeleteAauthUsersInGroups = new MySqlCommand("delete from aauth_user_to_group where user_id in(select idAuth from eleve where idClasse=@classe)",connexion);
                    DeleteAauthUsersInGroups.Parameters.AddWithValue("@classe", test[0]);
                    DeleteAauthUsersInGroups.ExecuteNonQuery();
                    MySqlCommand DeleteAauthUsers = new MySqlCommand("delete from aauth_users where id in (select idauth from eleve where idclasse=@classe)",connexion);
                    DeleteAauthUsers.Parameters.AddWithValue("@classe",test[0]);
                    DeleteAauthUsers.ExecuteNonQuery();
                    string sSupprimerEleve = "delete from eleve where idClasse in(select classe.id from Classe inner join niveau on niveau.id=classe.idNiveau where anneeScolaire=@annee and niveauScolaire=@niveau);";
                    MySqlCommand supprimerEleve = new MySqlCommand(sSupprimerEleve, connexion);
                    supprimerEleve.Parameters.AddWithValue("@annee", test[2]);
                    supprimerEleve.Parameters.AddWithValue("@niveau",test[1]);
                    supprimerEleve.ExecuteNonQuery();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                
            }

            //On récupère toutes les lignes du fichier CSV et on insert dans la base les données récupérés.
            String[] lines = System.IO.File.ReadAllLines(tbRepertoireFichiers.Text+"\\"+clbFichierCsv.SelectedItem.ToString());
            foreach (string  line in lines)
            {
                string[] csvlecture = line.Split(';');
                string nom = csvlecture[1];
                string prenom = csvlecture[2];
                string mail = csvlecture[3];
                //On insert le nouvel utilisateur dans la table aauth.user.
                MySqlCommand InsertUsers = new MySqlCommand("Insert into aauth_users(email,pass) values (@email,@pass)", connexion);
                InsertUsers.Parameters.AddWithValue("@email", mail);
                InsertUsers.Parameters.AddWithValue("@pass",GetSha256FromString("siojjr"));
                InsertUsers.ExecuteNonQuery();
                //On récupère l'Id de l'utilisateur
                MySqlCommand selectUsers = new MySqlCommand("select id from aauth_users where email=@email",connexion);
                selectUsers.Parameters.AddWithValue("@email", mail);
                MySqlDataReader rdr= selectUsers.ExecuteReader();
                rdr.Read();
                int idAuth = Convert.ToInt32(rdr["id"]);
                rdr.Close();
                //On insert l'élève dans la table élève
                MySqlCommand InsertEleves = new MySqlCommand("insert into eleve(nom,prenom,login,idClasse,idAuth) values (@nom,@prenom,@login,@idClasse,@idAuth)",connexion);
                InsertEleves.Parameters.AddWithValue("@nom", nom);
                InsertEleves.Parameters.AddWithValue("idClasse", test[0]);
                InsertEleves.Parameters.AddWithValue("@login", mail);
                InsertEleves.Parameters.AddWithValue("@prenom", prenom);
                InsertEleves.Parameters.AddWithValue("@idAuth",idAuth);
                InsertEleves.ExecuteNonQuery();
                //On insert le nouvel utilisateur dans le group qui correspond au eleve dans la table aauth_user_to_group.
                MySqlCommand InsertUserGroup = new MySqlCommand("insert into aauth_user_to_group(user_id,group_id) values(@user_id,@group_id)",connexion);
                InsertUserGroup.Parameters.AddWithValue("@user_id", idAuth);
                InsertUserGroup.Parameters.AddWithValue("@group_id",4);
                InsertUserGroup.ExecuteNonQuery();
            }
            connexion.Close();
        }
        /// <summary>
        /// Lors de la création d'un élève dans la base de donnée on hache son code utilisateur.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetSha256FromString(string data)
        {
            var message = Encoding.ASCII.GetBytes(data);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";
            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }

    }
}
