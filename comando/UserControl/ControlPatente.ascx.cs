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

                this.patente = entities.Patente.Where(x => x.Id == tra.PatenteId).FirstOrDefault();
            }
            if (this.patente != null)
            {
                this.ddlCategoria.Text = this.patente.Categoria.Trim();
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

                this.patente = entities.Patente.Where(x => x.Id == tra.PatenteId).FirstOrDefault();
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

        public Patente SaveData(long idverbale, bool tra)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {
                Attore PropietarioTrasgressore = null;

                if (tra)
                {
                    object[] keyValues = new object[] { idverbale };
                    PropietarioTrasgressore = (Trasgressore)entities.Verbale.Find(keyValues).Trasgressore;
                }
                else
                {
                    object[] objArray2 = new object[] { idverbale };
                    PropietarioTrasgressore = (Proprietario)entities.Verbale.Find(idverbale).Veicolo.Proprietario;
                }

                if (tra)
                    this.patente = entities.Verbale.Find(idverbale).Trasgressore.Patente;
                else
                    this.patente = entities.Verbale.Find(idverbale).Veicolo.Proprietario.Patente;
                if (this.patente == null)
                    this.patente = new Patente();

                patente.Categoria = this.ddlCategoria.SelectedItem.Text.Trim();
                DateTime result = new DateTime();
                patente.Data = null;
                if (DateTime.TryParse(this.txtDataRilascio.Text, out result))
                {
                    this.patente.Data = new DateTime?(result);
                }
                this.patente.Numero = this.txtNumero.Text;
                this.patente.RilasciataDa = this.txtRialsciataDa.Text;
                if (this.patente.Id == 0)
                    entities.Patente.Add(this.patente);

                if (tra)
                    ((Trasgressore)PropietarioTrasgressore).Patente = patente;
                else
                    ((Proprietario)PropietarioTrasgressore).Patente = patente;
                try
                {
                    entities.SaveChanges();
                }
                catch (Exception exception1)
                {
                    Console.Write(exception1.Message);
                }
            }
            return this.patente;
        }
    }
}

