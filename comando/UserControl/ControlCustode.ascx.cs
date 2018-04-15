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

    public class ControlCustode : UserControl
    {
        private Custode custode = new Custode();
        protected Panel Panel1;
        protected TextBox txtComune;
        protected TextBox txtDitta;
        protected TextBox txtIndirizzo;

        public void LoadData(Veicolo veicolo)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {


                this.custode = entities.Veicolo.Where(x => x.Id_Custode == veicolo.Id_Custode).Select(x => x.Custode).FirstOrDefault();
            }
            if (this.custode != null)
            {
                this.txtDitta.Text = this.custode.Ditta;
                this.txtIndirizzo.Text = this.custode.Indirizzo;
                this.txtComune.Text = this.custode.Comune;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((base.IsPostBack && (((ComandoPage) this.Parent.Page).idverbale != null)) && (((ComandoPage) this.Parent.Page).idverbale.Value != ""))
            {
                int.Parse(((ComandoPage) this.Parent.Page).idverbale.Value);
                this.SaveData((long) int.Parse(((ComandoPage) this.Parent.Page).idverbale.Value));
            }
        }

        public void SaveData(long idveicolo)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {
                Veicolo veicolo = entities.Veicolo.Find(idveicolo);
                this.custode = veicolo.Custode;
                if (custode == null)
                    custode = new Custode();

                this.custode.Ditta = this.txtDitta.Text;
                this.custode.Indirizzo = this.txtIndirizzo.Text;
                this.custode.Comune = this.txtComune.Text;

                if (custode.Id == 0)
                {
                    entities.Custode.Add(custode);
                    veicolo.Custode = custode;
                }
                entities.SaveChanges();
            }
        }
    }
}

