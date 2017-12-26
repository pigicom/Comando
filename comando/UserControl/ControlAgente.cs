namespace Comando.UserControl
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Comando;

    public class ControlAgente : UserControl
    {
        public Agente agente1 = new Agente();
        protected HiddenField Agente1ID;
        public Agente agente2 = new Agente();
        protected HiddenField Agente2ID;
        protected DropDownList ddlA1;
        protected DropDownList ddlA2;
        protected Panel Panel1;
        protected TextBox txtArticolo;
        protected TextBox txtCittaViolazione;
        protected TextBox txtDataApertura;
        protected TextBox txtDataChiusura;
        protected TextBox txtDataVerbale;
        protected TextBox txtIndirizzoViolazione;
        protected TextBox txtOra;
        protected TextBox txtOraApertura;
        protected TextBox txtOraChiusura;
        protected TextBox txtVerbaleIndirizzo;
        protected TextBox txtViolazioneData;
        public Verbale verbale = new Verbale();
        protected HiddenField VerbaleDomicilioId;
        public Violazione violazione = new Violazione();
        protected HiddenField ViolazioneId;

        public long AddNew()
        {
            Violazione entity = new Violazione();
            Verbale verbale = new Verbale();
            Agente item = new Agente();
            Agente agente2 = new Agente();
            using (var entities = new  ComandoEntities())
            {

                item = entities.Agente.Find(this.agente1.Id);
                agente2 = entities.Agente.Find(this.agente2.Id);
                verbale.Agente1=item;
                verbale.Agente2.Add(agente2);
                new DateTime();
                DateTime result = new DateTime();
                DateTime? nullable = null;
                verbale.Data = nullable;
                if (DateTime.TryParse(this.txtDataVerbale.Text, out result))
                {
                    verbale.Data = new DateTime?(result);
                }
                else
                {
                    verbale.Data = new DateTime?(DateTime.Now);
                }
                DateTime time2 = new DateTime();
                nullable = null;
                verbale.DataOraApertura = nullable;
                if (DateTime.TryParse(this.txtDataApertura.Text, out time2))
                {
                    verbale.DataOraApertura = new DateTime?(time2);
                }
                DateTime time3 = new DateTime();
                nullable = null;
                verbale.DataOraChiusura = nullable;
                if (DateTime.TryParse(this.txtDataChiusura.Text, out time3))
                {
                    verbale.DataOraChiusura = new DateTime?(time3);
                }
                this.txtOraApertura.Text = string.IsNullOrEmpty(this.txtOraApertura.Text) ? "00:00" : this.txtOraApertura.Text;
                this.txtOraChiusura.Text = string.IsNullOrEmpty(this.txtOraChiusura.Text) ? "00:00" : this.txtOraChiusura.Text;
                char[] separator = new char[] { ':' };
                int hours = short.Parse(this.txtOraApertura.Text.Split(separator)[0].ToString());
                char[] chArray2 = new char[] { ':' };
                int minutes = (this.txtOraApertura.Text.Split(chArray2).Length > 1) ? short.Parse(this.txtOraApertura.Text.Split(new char[] { ':' })[1].ToString()) : 0;
                DateTime span = new DateTime(hours, minutes, 0);
                char[] chArray4 = new char[] { ':' };
                int num3 = short.Parse(this.txtOraChiusura.Text.Split(chArray4)[0].ToString());
                char[] chArray5 = new char[] { ':' };
                int num4 = (this.txtOraChiusura.Text.Split(chArray5).Length > 1) ? short.Parse(this.txtOraChiusura.Text.Split(new char[] { ':' })[1].ToString()) : 0;
                DateTime span2 = new DateTime(num3, num4, 0);
                verbale.DataOraApertura = new DateTime?(span);
                verbale.DataOraChiusura = new DateTime?(span2);
                verbale.Indirizzo = this.txtVerbaleIndirizzo.Text;
                entity.Verbale = verbale;
                entities.Entry<Verbale>(verbale).State = EntityState.Added;
                DateTime time4 = new DateTime();
                entity.Data = null;
                if (DateTime.TryParse(this.txtViolazioneData.Text, out time4))
                {
                    entity.Data = new DateTime?(time4);
                }
                entity.Articolo = this.txtArticolo.Text;
                entity.Indirizzo = this.txtIndirizzoViolazione.Text;
                entity.Citta = this.txtCittaViolazione.Text;
                entity.Verbale = verbale;
                entities.Entry<Violazione>(entity).State = EntityState.Added;
                entities.SaveChanges();
                return verbale.Id;
            }
        }

        private void BindDDL()
        {
            using (ComandoEntities entities = new ComandoEntities())
            {
               
                Dictionary<int, string> dictionary = new Dictionary<int, string>();
                foreach (var e in  entities.Agente)
                {
                    dictionary.Add(Int32.Parse(e.Id.ToString()), e.Nome);
                }
                this.ddlA1.DataTextField = "Value";
                this.ddlA1.DataValueField = "Key";
                this.ddlA1.DataSource = dictionary;
                this.ddlA1.DataBind();
                this.ddlA2.DataTextField = "Value";
                this.ddlA2.DataValueField = "Key";
                this.ddlA2.DataSource = dictionary;
                this.ddlA2.DataBind();
            }
        }

        public void LoadData(Agente agente1, Agente agente2, Verbale verbale, Violazione violazione)
        {
            if (agente1.Id != 0)
            {
                if (this.ddlA1.Items.Count == 0)
                {
                    this.BindDDL();
                }
                this.Agente1ID.Value = agente1.Id.ToString();
                this.ddlA1.ClearSelection();
                this.ddlA1.Items.FindByValue(agente1.Id.ToString()).Selected = true;
            }
            if (agente2.Id != 0)
            {
                this.Agente2ID.Value = agente2.Id.ToString();
                this.ddlA2.ClearSelection();
                this.ddlA2.Items.FindByValue(agente2.Id.ToString()).Selected = true;
            }
            if (verbale != null)
            {
                DateTime? data = verbale.Data;
                DateTime minValue = DateTime.MinValue;
                if (data.HasValue ? (data.HasValue ? (data.GetValueOrDefault() != minValue) : false) : true)
                {
                    this.txtDataVerbale.Text = verbale.Data.Value.ToShortDateString();
                }
                if (verbale.DataOraApertura.HasValue)
                {
                    this.txtDataApertura.Text = verbale.DataOraApertura.Value.ToShortDateString();
                    this.txtOraApertura.Text = !verbale.DataOraApertura.HasValue ? string.Empty : verbale.DataOraApertura.Value.ToString();
                }
                if (verbale.DataOraChiusura.HasValue)
                {
                    this.txtDataChiusura.Text = verbale.DataOraChiusura.Value.ToShortDateString();
                    this.txtOraChiusura.Text = !verbale.DataOraChiusura.HasValue ? string.Empty : verbale.DataOraChiusura.Value.ToString();
                }
                if (verbale.Indirizzo != null)
                {
                    this.txtVerbaleIndirizzo.Text = verbale.Indirizzo.ToString();
                }
            }
            if (violazione != null)
            {
                if (verbale.Violazione.Count > 0)
                {
                    this.ViolazioneId.Value = verbale.Violazione.First<Violazione>().Id.ToString();
                }
                this.txtArticolo.Text = violazione.Articolo;
                if (violazione.Data.HasValue)
                {
                    this.txtViolazioneData.Text = violazione.Data.Value.ToShortDateString();
                }
                if (violazione.Data.HasValue)
                {
                    this.txtOra.Text = violazione.Data.Value.ToShortTimeString();
                }
                this.txtIndirizzoViolazione.Text = violazione.Indirizzo;
                this.txtCittaViolazione.Text = violazione.Citta;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                DateTime now = DateTime.Now;
                this.txtDataVerbale.Text = now.ToShortDateString();
                this.txtDataApertura.Text = now.ToShortDateString();
                this.txtDataChiusura.Text = now.ToShortDateString();
                this.txtOraApertura.Text = now.Hour.ToString();
                this.txtOraChiusura.Text = now.Hour.ToString();
                if (this.ddlA1.Items.Count == 0)
                {
                    this.BindDDL();
                }
            }
            else
            {
                this.SaveData(this.verbale.Id);
            }
        }

        public void SaveData(long verbaleId)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {
                this.verbale = entities.Verbale.Find(verbaleId);
                this.agente1.Id = string.IsNullOrEmpty(this.ddlA1.SelectedValue) ? ((long) 0) : ((long) int.Parse(this.ddlA1.SelectedValue));
                this.agente2.Id = string.IsNullOrEmpty(this.ddlA2.SelectedValue) ? ((long) 0) : ((long) int.Parse(this.ddlA2.SelectedValue));
                if (this.verbale != null)
                {
                    this.verbale.Utente = (Utente) base.Session["currentUser"];
                    this.violazione = entities.Violazione.Where(x => x.Verbale_Id == verbaleId).FirstOrDefault();
                    long idv = this.verbale.Id;
                    this.agente1 = entities.Agente.Find(this.agente1.Id);
                    this.agente2 = entities.Agente.Find(this.agente2.Id);

                    this.verbale.CategoriaVerbale = entities.CategoriaVerbale.Where(x => x.ID == verbale.Category_Id).FirstOrDefault();
                    if (this.verbale.Agente2.Count > 0)
                    {
                        this.verbale.Agente2.Clear();
                    }
                    this.verbale.Agente2.Add(this.agente1);
                    this.verbale.Agente2.Add(this.agente2);
                    DateTime result = new DateTime();
                    this.verbale.Data = new DateTime?(DateTime.TryParse(this.txtDataVerbale.Text, out result) ? result : DateTime.MinValue);
                    DateTime time2 = result;
                    DateTime time3 = result;
                    this.txtOraApertura.Text = string.IsNullOrEmpty(this.txtOraApertura.Text) ? "00:00" : this.txtOraApertura.Text;
                    this.txtOraChiusura.Text = string.IsNullOrEmpty(this.txtOraChiusura.Text) ? "00:00" : this.txtOraChiusura.Text;
                    this.verbale.DataOraApertura = new DateTime?(DateTime.TryParse(this.txtDataApertura.Text, out time2) ? time2 : result);
                    this.verbale.DataOraChiusura = new DateTime?(DateTime.TryParse(this.txtDataChiusura.Text, out time3) ? time3 : result);
                    char[] separator = new char[] { ':' };
                    int hours = short.Parse(this.txtOraApertura.Text.Split(separator)[0].ToString());
                    char[] chArray2 = new char[] { ':' };
                    int minutes = (this.txtOraApertura.Text.Split(chArray2).Length > 1) ? short.Parse(this.txtOraApertura.Text.Split(new char[] { ':' })[1].ToString()) : 0;
                    DateTime span = new DateTime(hours, minutes, 0);
                    char[] chArray4 = new char[] { ':' };
                    int num3 = short.Parse(this.txtOraChiusura.Text.Split(chArray4)[0].ToString());
                    char[] chArray5 = new char[] { ':' };
                    int num4 = (this.txtOraChiusura.Text.Split(chArray5).Length > 1) ? short.Parse(this.txtOraChiusura.Text.Split(new char[] { ':' })[1].ToString()) : 0;
                    DateTime span2 = new DateTime(num3, num4, 0);
                    this.verbale.DataOraApertura = new DateTime?(span);
                    this.verbale.DataOraChiusura = new DateTime?(span2);
                    this.verbale.Indirizzo = this.txtVerbaleIndirizzo.Text;
                    if (this.violazione != null)
                    {
                        this.violazione.Verbale = this.verbale;
                    }
               
                    if (!entities.Verbale.Any(x => x.Id == verbaleId))
                    {
                        entities.Entry<Verbale>(this.verbale).State = (this.verbale.Id == 0) ? EntityState.Added : EntityState.Modified;
                    }
                    DateTime time4 = new DateTime();
                    this.violazione.Articolo = this.txtArticolo.Text;
                    this.violazione.Data = new DateTime?(DateTime.TryParse(this.txtViolazioneData.Text, out time4) ? time4 : DateTime.MinValue);
                    if (this.txtOra.Text == "")
                    {
                        this.txtOra.Text = "00:00";
                    }
                    char[] chArray7 = new char[] { ':' };
                    char[] chArray8 = new char[] { ':' };
                    DateTime time5 = new DateTime(this.violazione.Data.Value.Year, this.violazione.Data.Value.Month, this.violazione.Data.Value.Day, int.Parse(this.txtOra.Text.Split(chArray7)[0]), int.Parse(this.txtOra.Text.Split(chArray8)[1]), 0);
                    this.violazione.Data = new DateTime?(time5);
                    this.violazione.Indirizzo = this.txtIndirizzoViolazione.Text;
                    this.violazione.Citta = this.txtCittaViolazione.Text;
                    int cat = int.Parse(base.Request.QueryString["cat"].ToString());
                    this.verbale.CategoriaVerbale = entities.CategoriaVerbale.Where(x => x.ID == verbale.Category_Id).FirstOrDefault();
                    this.verbale.Timestamp = new DateTime?(DateTime.Now);
                    entities.SaveChanges();
                }
            }
        }
    }
}

