namespace Comando.UserControl
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Comando;
    using comando;

    public class ControlAvvocato : UserControl
    {
        public Avvocato avvocato = new Avvocato();
        protected HiddenField AvvocatoId;
        protected DropDownList ddlAssegnato;
        protected Panel Panel1;
        protected TextBox txtCellulare;
        protected TextBox txtCittaStudio;
        protected TextBox txtCognome;
        protected TextBox txtEmail;
        protected TextBox txtFaxStudio;
        protected TextBox txtForo;
        protected TextBox txtIndirizzoStudio;
        protected TextBox txtNome;
        protected TextBox txtTelefonoStudio;

        public void LoadData(Avvocato avvocato)
        {
            int num2;
            this.txtCellulare.Text = avvocato.Cellulare;
            this.txtCognome.Text = avvocato.Cognome;
            this.txtEmail.Text = avvocato.Email;
            this.txtForo.Text = avvocato.Foro;
            this.txtIndirizzoStudio.Text = avvocato.IndirizzoStudio;
            this.txtNome.Text = avvocato.Nome;
            this.txtTelefonoStudio.Text = avvocato.TelefonoStudio;
            this.txtFaxStudio.Text = avvocato.FaxStudio;
            this.txtCittaStudio.Text = avvocato.CittaStudio;
            this.AvvocatoId.Value = avvocato.Id.ToString();
            bool? assegnato =  avvocato.Assegnato;
            bool flag = true;
            if ((assegnato.GetValueOrDefault() == flag) ? assegnato.HasValue : false)
            {
                num2 = 1;
                this.ddlAssegnato.ClearSelection();
                this.ddlAssegnato.Items.FindByValue(num2.ToString()).Selected = true;
            }
            else
            {
                num2 = 0;
                this.ddlAssegnato.ClearSelection();
                this.ddlAssegnato.Items.FindByValue(num2.ToString()).Selected = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (base.IsPostBack && (((ComandoPage) this.Parent.Page).idverbale.Value != string.Empty))
            {
                this.SaveData((long) int.Parse(((ComandoPage) this.Parent.Page).idverbale.Value));
            }
        }

        public void SaveData(long idverbale)
        {
             using (var entities = new ComandoEntities())
            {
                ParameterExpression expression;
                ParameterExpression[] parameters = new ParameterExpression[] { };
                Verbale verbale = entities.Verbale.Find(idverbale);
                if (verbale.Avvocato != null)
                {
                    this.avvocato = entities.Avvocato.Where(x => x.Id == verbale.Avvocato_Id).FirstOrDefault();
                }
                this.avvocato.Cellulare = this.txtCellulare.Text;
                this.avvocato.Cognome = this.txtCognome.Text;
                this.avvocato.Email = this.txtEmail.Text;
                this.avvocato.Foro = this.txtForo.Text;
                this.avvocato.CittaStudio = this.txtCittaStudio.Text;
                this.avvocato.IndirizzoStudio = this.txtIndirizzoStudio.Text;
                this.avvocato.Nome = this.txtNome.Text;
                this.avvocato.TelefonoStudio = this.txtTelefonoStudio.Text;
                this.avvocato.FaxStudio = this.txtFaxStudio.Text;
                int num = 1;
                if (this.ddlAssegnato.SelectedValue.ToString() == num.ToString())
                {
                    this.avvocato.Assegnato = true;
                }
                else
                {
                    this.avvocato.Assegnato = false;
                }
                verbale.Avvocato = this.avvocato;
                entities.Entry<Avvocato>(this.avvocato).State = (this.avvocato.Id == 0) ? EntityState.Added : EntityState.Modified;
                entities.SaveChanges();
            }
        }
    }
}

