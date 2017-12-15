namespace alimenterBaseDeDonnees
{
    partial class Traitement
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRepertoireFichiers = new System.Windows.Forms.Label();
            this.lblFichierCsv = new System.Windows.Forms.Label();
            this.lblClasse = new System.Windows.Forms.Label();
            this.cbSuppression = new System.Windows.Forms.CheckBox();
            this.clbFichierCsv = new System.Windows.Forms.CheckedListBox();
            this.cbClasse = new System.Windows.Forms.ComboBox();
            this.btIntegration = new System.Windows.Forms.Button();
            this.tbRepertoireFichiers = new System.Windows.Forms.TextBox();
            this.btParcourir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRepertoireFichiers
            // 
            this.lblRepertoireFichiers.AutoSize = true;
            this.lblRepertoireFichiers.Location = new System.Drawing.Point(12, 25);
            this.lblRepertoireFichiers.Name = "lblRepertoireFichiers";
            this.lblRepertoireFichiers.Size = new System.Drawing.Size(121, 13);
            this.lblRepertoireFichiers.TabIndex = 0;
            this.lblRepertoireFichiers.Text = "Répertoire des fichiers : ";
            // 
            // lblFichierCsv
            // 
            this.lblFichierCsv.AutoSize = true;
            this.lblFichierCsv.Location = new System.Drawing.Point(12, 86);
            this.lblFichierCsv.Name = "lblFichierCsv";
            this.lblFichierCsv.Size = new System.Drawing.Size(115, 13);
            this.lblFichierCsv.TabIndex = 1;
            this.lblFichierCsv.Text = "Fichier CSV à intégrer :";
            // 
            // lblClasse
            // 
            this.lblClasse.AutoSize = true;
            this.lblClasse.Location = new System.Drawing.Point(12, 182);
            this.lblClasse.Name = "lblClasse";
            this.lblClasse.Size = new System.Drawing.Size(98, 13);
            this.lblClasse.TabIndex = 2;
            this.lblClasse.Text = "Choisir une classe :";
            // 
            // cbSuppression
            // 
            this.cbSuppression.AutoSize = true;
            this.cbSuppression.Location = new System.Drawing.Point(15, 245);
            this.cbSuppression.Name = "cbSuppression";
            this.cbSuppression.Size = new System.Drawing.Size(313, 17);
            this.cbSuppression.TabIndex = 3;
            this.cbSuppression.Text = "Suppression de tous les élèves de la classe avant intégration";
            this.cbSuppression.UseVisualStyleBackColor = true;
            // 
            // clbFichierCsv
            // 
            this.clbFichierCsv.FormattingEnabled = true;
            this.clbFichierCsv.Location = new System.Drawing.Point(134, 86);
            this.clbFichierCsv.Name = "clbFichierCsv";
            this.clbFichierCsv.Size = new System.Drawing.Size(277, 64);
            this.clbFichierCsv.TabIndex = 5;
            // 
            // cbClasse
            // 
            this.cbClasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasse.FormattingEnabled = true;
            this.cbClasse.Location = new System.Drawing.Point(134, 179);
            this.cbClasse.Name = "cbClasse";
            this.cbClasse.Size = new System.Drawing.Size(91, 21);
            this.cbClasse.TabIndex = 6;
            // 
            // btIntegration
            // 
            this.btIntegration.Location = new System.Drawing.Point(140, 289);
            this.btIntegration.Name = "btIntegration";
            this.btIntegration.Size = new System.Drawing.Size(121, 23);
            this.btIntegration.TabIndex = 7;
            this.btIntegration.Text = "Lancer l\'intégration";
            this.btIntegration.UseVisualStyleBackColor = true;
            this.btIntegration.Click += new System.EventHandler(this.btIntegration_Click);
            // 
            // tbRepertoireFichiers
            // 
            this.tbRepertoireFichiers.Location = new System.Drawing.Point(134, 22);
            this.tbRepertoireFichiers.Name = "tbRepertoireFichiers";
            this.tbRepertoireFichiers.ReadOnly = true;
            this.tbRepertoireFichiers.Size = new System.Drawing.Size(208, 20);
            this.tbRepertoireFichiers.TabIndex = 8;
            // 
            // btParcourir
            // 
            this.btParcourir.Location = new System.Drawing.Point(348, 22);
            this.btParcourir.Name = "btParcourir";
            this.btParcourir.Size = new System.Drawing.Size(75, 23);
            this.btParcourir.TabIndex = 9;
            this.btParcourir.Text = "Parcourir";
            this.btParcourir.UseVisualStyleBackColor = true;
            this.btParcourir.Click += new System.EventHandler(this.btParcourir_Click);
            // 
            // Traitement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 324);
            this.Controls.Add(this.btParcourir);
            this.Controls.Add(this.tbRepertoireFichiers);
            this.Controls.Add(this.btIntegration);
            this.Controls.Add(this.cbClasse);
            this.Controls.Add(this.clbFichierCsv);
            this.Controls.Add(this.cbSuppression);
            this.Controls.Add(this.lblClasse);
            this.Controls.Add(this.lblFichierCsv);
            this.Controls.Add(this.lblRepertoireFichiers);
            this.Name = "Traitement";
            this.Text = "Alimentation de la base de données : Nouvelle classe";
            this.Load += new System.EventHandler(this.Traitement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRepertoireFichiers;
        private System.Windows.Forms.Label lblFichierCsv;
        private System.Windows.Forms.Label lblClasse;
        private System.Windows.Forms.CheckBox cbSuppression;
        private System.Windows.Forms.CheckedListBox clbFichierCsv;
        private System.Windows.Forms.ComboBox cbClasse;
        private System.Windows.Forms.Button btIntegration;
        private System.Windows.Forms.TextBox tbRepertoireFichiers;
        private System.Windows.Forms.Button btParcourir;
    }
}

