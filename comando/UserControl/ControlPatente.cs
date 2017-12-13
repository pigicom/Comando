namespace WebApp.UserControl
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using WebApp;
    using comando;
    public class ControlPatente : UserControl
    {
        protected DropDownList ddlCategoria;
        protected Panel Panel1;
        private Patente patente = new Patente();
        protected TextBox txtDataRilascio;
        protected TextBox txtNumero;
        protected TextBox txtRialsciataDa;

        public void LoadData(Proprietario tra)
        {
            using (ComandoEntities2 entities = new ComandoEntities2())
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
            using (ComandoEntities2 entities = new ComandoEntities2())
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
            using (ComandoEntities2 entities = new ComandoEntities2())
            {
                Trasgressore trasgressore2 = null;
                Proprietario proprietario = null;
                if (trasgressore)
                {
                    object[] keyValues = new object[] { idverbale };
                    trasgressore2 = entities.Verbale.Find(keyValues).Trasgressore;
                    if ((trasgressore2 != null) && (trasgressore2.Patente.Count<Patente>() > 0))
                    {
                        trasgressore2.Patente.Clear();
                    }
                }
                else
                {
                    object[] objArray2 = new object[] { idverbale };
                    proprietario = entities.Verbale.Find(objArray2).Veicolo.Proprietario;
                    if (proprietario.Patente.Count<Patente>() > 0)
                    {
                        proprietario.Patente.Clear();
                    }
                }
                this.patente.Categoria = this.ddlCategoria.SelectedItem.Text;
                DateTime result = new DateTime();
                this.patente.Data = null;
                if (DateTime.TryParse(this.txtDataRilascio.Text, out result))
                {
                    this.patente.Data = new DateTime?(result);
                }
                this.patente.Numero = this.txtNumero.Text;
                this.patente.RilasciataDa = this.txtRialsciataDa.Text;
                this.patente.Trasgressore = trasgressore2;
                entities.Patente.Add(this.patente);
                if (trasgressore && (trasgressore2 != null))
                {
                    if (this.patente.Data.HasValue)
                    {
                        trasgressore2.Patente.Add(this.patente);
                    }
                }
                else if (this.patente.Data.HasValue)
                {
                    proprietario.Patente.Add(this.patente);
                }
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

