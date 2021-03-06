﻿namespace Comando.UserControl
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using comando;
    using Comando;

    public class ControlProprietario : UserControl
    {
        public Proprietario proprietario = null;
        protected TextBox txtCittaNascita;
        protected TextBox txtCittaResidenza;
        protected TextBox txtCognome;
        protected TextBox txtDataNascita;
        protected TextBox txtIndirizzoResidenza;
        protected TextBox txtNome;

        public void LoadData(Proprietario proprietario)
        {
            this.txtNome.Text = proprietario.Nome;
            this.txtCognome.Text = proprietario.Cognome;
            this.txtCittaNascita.Text = proprietario.CittaNascita;
            this.txtCittaResidenza.Text = proprietario.CittaResidenza;
            if (proprietario.DataNascita.HasValue)
            {
                this.txtDataNascita.Text = proprietario.DataNascita.Value.ToShortDateString();
            }
            this.txtIndirizzoResidenza.Text = proprietario.IndirizzoResidenza;
            this.txtCittaResidenza.Text = proprietario.CittaResidenza;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((base.IsPostBack && (((ComandoPage) this.Parent.Page).idverbale != null)) && (((ComandoPage) this.Parent.Page).idverbale.Value != ""))
            {
                this.SaveData((long) int.Parse(((ComandoPage) this.Parent.Page).idverbale.Value));
            }
        }

        public Proprietario SaveData(long idverbale)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {
               
                ParameterExpression expression;
                Verbale verbale = entities.Verbale.Find(idverbale);

                if (verbale.Veicolo != null)
                    proprietario = verbale.Veicolo.Proprietario;

                if (proprietario == null)
                    proprietario = new Proprietario();
                
                this.proprietario.Nome = this.txtNome.Text.Trim();
                this.proprietario.CittaNascita = this.txtCittaNascita.Text.Trim();
                this.proprietario.CittaResidenza = this.txtCittaResidenza.Text.Trim();
                this.proprietario.Cognome = this.txtCognome.Text.Trim();
                DateTime result = new DateTime();
                this.proprietario.DataNascita = null;
                if (DateTime.TryParse(this.txtDataNascita.Text, out result))
                {
                    this.proprietario.DataNascita = new DateTime?(result);
                }
                this.proprietario.IndirizzoResidenza = this.txtIndirizzoResidenza.Text.Trim();
                this.proprietario.CittaResidenza = this.txtCittaResidenza.Text.Trim();

                if (proprietario.Veicolo.Count == 0)
                    proprietario.Veicolo.Add(verbale.Veicolo);

                if (verbale.Veicolo.Proprietario==null)
                 verbale.Veicolo.Proprietario = proprietario;


                entities.SaveChanges();
                return this.proprietario;
            }
        }
    }
}

