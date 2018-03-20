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
    public class ControlPatente : UserControl
    {
        protected DropDownList ddlCategoria;
        protected Panel Panel1;
        private Patente patente = null;
        protected TextBox txtDataRilascio;
        protected TextBox txtNumero;
        protected TextBox txtRialsciataDa;

        public void LoadData(Proprietario tra)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {

                this.patente = entities.Patente.Where(x => x.Trasgressore == tra).FirstOrDefault();
            }
            if (this.patente != null)
            {
                this.ddlCategoria.Text = this.patente.Categoria;
                if (this.patente.Data.HasValue)
                {
                    this.txtDataRilascio.Text = this.patente.Data.Value.ToShortDateString();
                }
                this.txtNumero.Text = this.patente.Numero.Trim();
                this.txtRialsciataDa.Text = this.patente.RilasciataDa.Trim();
            }
        }

        public void LoadData(Trasgressore tra)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {

                this.patente = entities.Patente.Where(x => x.Trasgressore.Id == tra.Id).FirstOrDefault();
            }
            if (this.patente != null)
            {
                this.ddlCategoria.Text = this.patente.Categoria;
                if (this.patente.Data.HasValue)
                {
                    this.txtDataRilascio.Text = this.patente.Data.Value.ToShortDateString();
                }
                this.txtNumero.Text = this.patente.Numero.Trim();
                this.txtRialsciataDa.Text = this.patente.RilasciataDa.Trim();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((base.IsPostBack && (((ComandoPage) this.Parent.Page).idverbale != null)) && (((ComandoPage) this.Parent.Page).idverbale.Value != ""))
            {
                int.Parse(((ComandoPage) this.Parent.Page).idverbale.Value);
                this.SaveData((long) int.Parse(((ComandoPage) this.Parent.Page).idverbale.Value), true);
            }
        }

        public void SaveData(long idverbale, bool trasgressore)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {
                Trasgressore trasgressore2 = null;
                Proprietario proprietario = null;
                Trasgressore PropietarioTrasgressore = null;

                if (trasgressore)
                {
                    object[] keyValues = new object[] { idverbale };
                    PropietarioTrasgressore = entities.Verbale.Find(keyValues).Trasgressore;
                }
                else
                {
                    object[] objArray2 = new object[] { idverbale };
                    PropietarioTrasgressore = entities.Verbale.Find(objArray2).Veicolo.Proprietario;
                }

                this.patente = PropietarioTrasgressore.Patente.FirstOrDefault();
                if (this.patente == null)
                    this.patente = new Patente();

                patente.Categoria = this.ddlCategoria.SelectedItem.Text;
                DateTime result = new DateTime();
                patente.Data = null;
                if (DateTime.TryParse(this.txtDataRilascio.Text, out result))
                {
                    this.patente.Data = new DateTime?(result);
                }
                this.patente.Numero = this.txtNumero.Text;
                this.patente.RilasciataDa = this.txtRialsciataDa.Text;
                try
                {
                    entities.SaveChanges();
                }
                catch (Exception exception1)
                {
                    Console.Write(exception1.Message);
                }
            }
        }
    }
}

