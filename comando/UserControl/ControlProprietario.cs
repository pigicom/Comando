namespace Comando.UserControl
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    using Comando;

    public class ControlProprietario : UserControl
    {
        public Proprietario proprietario = new Proprietario();
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
             
                if (verbale.Veicolo.Proprietario != null)
                {
                    this.proprietario = verbale.Veicolo.Proprietario;
                }
                else
                {
                    verbale.Veicolo.Proprietario = this.proprietario;
                }
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
                entities.SaveChanges();
                return this.proprietario;
            }
        }
    }
}

