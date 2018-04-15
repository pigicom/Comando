namespace Comando.UserControl
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using comando;
    using Comando;

    public class ControlVeicolo : UserControl
    {
        protected DropDownList ddlTipoVeicolo;
        protected Panel Panel1;
        protected SqlDataSource SqlDataSource1;
        protected TextBox txtColore;
        protected TextBox txtMarca;
        protected TextBox txtModello;
        protected TextBox txtTarga;
        protected TextBox txtTelaio;
        private Veicolo veicolo = null;

        public void LoadData(Veicolo veicolo)
        {
            this.txtColore.Text = veicolo.colore;
            this.txtMarca.Text = veicolo.marca;
            this.txtModello.Text = veicolo.modello;
            this.txtTarga.Text = veicolo.targa;
            this.txtTelaio.Text = veicolo.telaio;
            this.ddlTipoVeicolo.ClearSelection();
            if (this.ddlTipoVeicolo.Items.Count == 0)
            {
                this.ddlTipoVeicolo.DataBind();
            }
            this.ddlTipoVeicolo.Items.FindByValue(veicolo.TipoVeicolo_Id.ToString()).Selected = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((base.IsPostBack && (((ComandoPage) this.Parent.Page).idverbale != null)) && (((ComandoPage) this.Parent.Page).idverbale.Value != ""))
            {
                long idverbale = int.Parse(((ComandoPage) this.Parent.Page).idverbale.Value);
                this.SaveData(idverbale);
            }
        }

        public Veicolo SaveData(long idverbale)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {
                ParameterExpression[] parameters = new ParameterExpression[] {   };
                ParameterExpression[] expressionArray2 = new ParameterExpression[] {   };
                Verbale item = entities.Verbale.Find(idverbale);
                this.veicolo = item.Veicolo;
                if (veicolo == null)
                    veicolo = new Veicolo();
                this.veicolo.colore = this.txtColore.Text;
                this.veicolo.marca = this.txtMarca.Text;
                this.veicolo.modello = this.txtModello.Text;
                this.veicolo.targa = this.txtTarga.Text;
                this.veicolo.telaio = this.txtTelaio.Text;
                this.veicolo.TipoVeicolo_Id = int.Parse(this.ddlTipoVeicolo.SelectedValue);
                
                if (veicolo.Id == 0)
                    entities.Veicolo.Add(veicolo);
                if (item.Veicolo==null)
                    item.Veicolo = veicolo;
                entities.SaveChanges();
                return this.veicolo;
            }
        }
    }
}

