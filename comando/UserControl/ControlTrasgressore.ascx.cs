namespace Comando.UserControl
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using comando;
    using Comando;

    public class ControlTrasgressore : UserControl
    {
        protected DropDownList ddlSesso;
        protected Panel Panel1;
        public Trasgressore trasgressore = new Trasgressore();
        protected HiddenField TrasgressoreId;
        protected TextBox txtCapNascita;
        protected TextBox txtCAPResidenza;
        protected TextBox txtCF;
        protected TextBox txtCittaDomicilio;
        protected TextBox txtCittaNascita1;
        protected TextBox txtCittaResidenza;
        protected TextBox txtCivicoResidenza;
        protected TextBox txtCognome;
        protected TextBox txtNascita;
        protected TextBox txtNome;
        protected TextBox txtStatoNascita;
        protected TextBox txtViaDomicilio;
        protected TextBox txtViaResidenza;

        public void LoadData(Trasgressore trasgressore)
        {
            this.txtCapNascita.Text = string.IsNullOrEmpty(trasgressore.CapNascita) ? string.Empty : trasgressore.CapNascita;
            this.txtCAPResidenza.Text = string.IsNullOrEmpty(trasgressore.CapResidenza) ? string.Empty : trasgressore.CapResidenza;
            this.txtCF.Text = string.IsNullOrEmpty(trasgressore.CF) ? string.Empty : trasgressore.CF;
            this.txtCittaNascita1.Text = string.IsNullOrEmpty(trasgressore.CittaNascita) ? string.Empty : trasgressore.CittaNascita;
            this.txtCittaResidenza.Text = string.IsNullOrEmpty(trasgressore.CittaResidenza) ? string.Empty : trasgressore.CittaResidenza;
            this.txtCivicoResidenza.Text = string.IsNullOrEmpty(trasgressore.CivicoResidenza) ? string.Empty : trasgressore.CivicoResidenza;
            this.txtCognome.Text = trasgressore.Cognome;
            this.txtNome.Text = trasgressore.Nome;
            this.TrasgressoreId.Value = trasgressore.Id.ToString();
            if (trasgressore.DataNascita.HasValue)
            {
                this.txtNascita.Text = trasgressore.DataNascita.Value.ToShortDateString();
            }
            this.txtStatoNascita.Text = trasgressore.StatoNascita;
            this.txtViaResidenza.Text = trasgressore.ViaResidenza;
            if (trasgressore.Sesso != null)
            {
                this.ddlSesso.ClearSelection();
                this.ddlSesso.Items.FindByValue(trasgressore.Sesso).Selected = true;
            }
            this.txtCittaDomicilio.Text = trasgressore.CIttaDomicilio;
            this.txtViaDomicilio.Text = trasgressore.IndirizzoDomicilio;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.IsPostBack && (((ComandoPage) this.Parent.Page).idverbale.Value != string.Empty))
            {
                this.SaveData((long) int.Parse(((ComandoPage) this.Parent.Page).idverbale.Value));
            }
        }

        public bool save()
        {
            try
            {
                using (ComandoEntities entities = new ComandoEntities())
                {
                    entities.Trasgressore.Add(this.trasgressore);
                    entities.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Trasgressore SaveData(long idverbale)
        {
            using (var entities = new ComandoEntities())
            {
                ParameterExpression expression = null;
                ParameterExpression[] parameters = new ParameterExpression[] { expression };
                Verbale verbale = entities.Verbale.Find(idverbale);
                if (verbale.Trasgressore != null)
                {
                    this.trasgressore = verbale.Trasgressore;
                }
                this.trasgressore.CapNascita = this.txtCapNascita.Text.Trim();
                this.trasgressore.CapResidenza = this.txtCAPResidenza.Text.Trim();
                this.trasgressore.CF = this.txtCF.Text.Trim();
                this.trasgressore.CittaNascita = this.txtCittaNascita1.Text.Trim();
                this.trasgressore.CittaResidenza = this.txtCittaResidenza.Text.Trim();
                this.trasgressore.CivicoResidenza = this.txtCivicoResidenza.Text.Trim();
                this.trasgressore.Nome = this.txtNome.Text.Trim();
                this.trasgressore.Cognome = this.txtCognome.Text.Trim();
                DateTime result = new DateTime();
                this.trasgressore.DataNascita = null;
                if (DateTime.TryParse(this.txtNascita.Text, out result))
                {
                    this.trasgressore.DataNascita = new DateTime?(result);
                }
                this.trasgressore.StatoNascita = this.txtStatoNascita.Text.Trim();
                this.trasgressore.ViaResidenza = this.txtViaResidenza.Text.Trim();
                this.trasgressore.Sesso = this.ddlSesso.SelectedValue;
                this.trasgressore.CIttaDomicilio = this.txtCittaDomicilio.Text;
                this.trasgressore.IndirizzoDomicilio = this.txtViaDomicilio.Text;
                if (this.trasgressore.Id == 0)
                {
                    entities.Trasgressore.Add(this.trasgressore);
                    verbale.Trasgressore = this.trasgressore;
                }
                entities.SaveChanges();
            }
            return this.trasgressore;
        }

        public bool Section1
        {
            get => 
                this.Panel1.Visible;
            set
            {
                this.Panel1.Visible = value;
            }
        }
    }
}

