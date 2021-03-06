﻿namespace Comando.UserControl
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using comando;
    using Comando;
    using System.Globalization;

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
            Agente item2 = new Agente();
            using (var entities = new  ComandoEntities())
            {
                verbale.Utente_Id = ((Utente)this.Context.Session["currentUser"]).Id;
                verbale.Category_Id = Int64.Parse(Request.QueryString["cat"].ToString());
                item = entities.Agente.Find(this.agente1.Id);
                item2 = entities.Agente.Find(this.agente2.Id);
                verbale.Agente=item;
                verbale.Agente1=item2;
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

                this.txtOraApertura.Text=this.txtOraApertura.Text.Replace("__", "00");
                this.txtOraChiusura.Text = this.txtOraChiusura.Text.Replace("__", "00");
                char[] separator = new char[] { ':' };
                int hours = short.Parse(this.txtOraApertura.Text.Split(separator)[0].ToString());
                char[] chArray2 = new char[] { ':' };
                int minutes = (this.txtOraApertura.Text.Split(chArray2).Length > 1) ? short.Parse(this.txtOraApertura.Text.Split(new char[] { ':' })[1].ToString()) : 0;
                DateTime span = new DateTime(verbale.DataOraApertura.Value.Year, 
                                             verbale.DataOraApertura.Value.Month, 
                                             verbale.DataOraApertura.Value.Day, 
                                             hours, 
                                             minutes, 
                                             0);
                char[] chArray4 = new char[] { ':' };
                int num3 = short.Parse(this.txtOraChiusura.Text.Split(chArray4)[0].ToString());
                char[] chArray5 = new char[] { ':' };
                int num4 = (this.txtOraChiusura.Text.Split(chArray5).Length > 1) ? short.Parse(this.txtOraChiusura.Text.Split(new char[] { ':' })[1].ToString()) : 0;
                DateTime span2 = new DateTime(verbale.DataOraChiusura.Value.Year,
                                             verbale.DataOraChiusura.Value.Month,
                                             verbale.DataOraChiusura.Value.Day, 
                                             num3, 
                                             num4, 
                                             0);
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
                try
                {
                    entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

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
                    dictionary.Add(Int32.Parse(e.Id.ToString()), e.Cognome);
                }
                this.ddlA1.DataTextField = "Value";
                this.ddlA1.DataValueField = "Key";
                this.ddlA1.DataSource = dictionary;
                this.ddlA1.DataBind();
                this.ddlA2.DataTextField = "Value";
                this.ddlA2.DataValueField = "Key";
                this.ddlA2.DataSource = dictionary;
                this.ddlA2.DataBind();
                this.ddlA2.Items.Insert(0, new ListItem("", "0"));
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
                    this.txtOraApertura.Text = !verbale.DataOraApertura.HasValue ? string.Empty : verbale.DataOraApertura.Value.ToString("hh:mm");
                }
                if (verbale.DataOraChiusura.HasValue)
                {
                    this.txtDataChiusura.Text = verbale.DataOraChiusura.Value.ToShortDateString();
                    this.txtOraChiusura.Text = !verbale.DataOraChiusura.HasValue ? string.Empty : verbale.DataOraChiusura.Value.ToString("hh:mm");
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
                if (verbale.Id == 0)
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
            }
            else
            {
                this.SaveData(this.verbale.Id);
            }
        }

        public void SaveData(long verbaleId)
        {
            using (var entities = new ComandoEntities())
            {
                verbale = entities.Verbale.Find(verbaleId);
                agente1.Id = string.IsNullOrEmpty(this.ddlA1.SelectedValue) ? ((long) 0) : ((long) int.Parse(this.ddlA1.SelectedValue));
                agente2.Id = string.IsNullOrEmpty(this.ddlA2.SelectedValue) ? ((long) 0) : ((long) int.Parse(this.ddlA2.SelectedValue));
                if (this.verbale != null)
                {
                    this.verbale.Utente.Id = ((Utente)base.Session["currentUser"]).Id;
                    long idv = this.verbale.Id;
                    DateTime result = new DateTime();
                    verbale.Agente1_Id = this.agente1.Id;
                    if (this.agente2.Id != 0)
                        verbale.Agente2_Id = this.agente2.Id;
                    verbale.Data = new DateTime?(DateTime.TryParse(this.txtDataVerbale.Text, out result) ? result : DateTime.MinValue);
                    verbale.Data = new DateTime(verbale.Data.Value.Year,
                                                verbale.Data.Value.Month,
                                                verbale.Data.Value.Day,
                                                Int32.Parse(this.txtOraApertura.Text.Split(':')[0]),
                                                Int32.Parse(this.txtOraApertura.Text.Split(':')[1]),
                                                0);
                    verbale.Indirizzo = this.txtVerbaleIndirizzo.Text;
                    entities.SaveChanges();
                }
            }

            using (var entities = new ComandoEntities())
            {
                if (this.verbale != null)
                {
                    Violazione violazione = entities.Violazione.Where(x => x.Verbale_Id == verbaleId).FirstOrDefault();


                    if (this.violazione != null)
                    {
                        if (String.IsNullOrWhiteSpace(txtOra.Text))
                            txtOra.Text = "00:00";
                        violazione.Data = DateTime.ParseExact(txtViolazioneData.Text + " " + txtOra.Text, "dd/MM/yyyy hh:mm", CultureInfo.CurrentCulture);
                        violazione.Indirizzo = txtVerbaleIndirizzo.Text;
                        entities.SaveChanges();
                    }
                }
            }
        }
    }
}

