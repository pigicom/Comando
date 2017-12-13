﻿namespace WebApp
{
    using Microsoft.Office.Interop.Word;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using WebApp.UserControl;
    using comando;
    using System.Configuration;

    public class Ebbrezza : ComandoPage
    {
        private Agente agente1 = new Agente();
        private Agente agente2 = new Agente();
        private Avvocato avvocato = new Avvocato();
        protected WebApp.UserControl.ControlAgente ControlAgente;
        protected WebApp.UserControl.ControlPatente ControlPatente;
        protected WebApp.UserControl.ControlProprietario ControlProprietario;
        protected WebApp.UserControl.ControlTrasgressore ControlTrasgressore;
        protected ControlVeicolo ControlVeicolo1;
        protected WebApp.UserControl.Menu Menu;
        private string pathPrefix = (ConfigurationManager.AppSettings["PathTemplates"] + @"\GUIDA IN STATO DI EBBREZZA\");
        private Trasgressore trasgressore = new Trasgressore();
        private Veicolo veicolo = new Veicolo();
        private Verbale verbale = new Verbale();
        private VerbaleElezioneDomicilio verbaledomicilio = new VerbaleElezioneDomicilio();
        private Violazione violazione = new Violazione();

        public BaseVerbale CreaDettaglio(long verbaleid)
        {
            VerbaleElezioneDomicilio domicilio = new VerbaleElezioneDomicilio();
            long current = verbaleid;
            using (ComandoEntities2 entities = new ComandoEntities2())
            {
                this.violazione = entities.Violazione.Where(x => x.Verbale_Id == verbaleid).FirstOrDefault();
                this.trasgressore = this.verbale.Trasgressore;
                this.veicolo = this.verbale.Veicolo;
                if (this.verbale.Agente2.Count > 0)
                {
                    this.agente1 = this.verbale.Agente2.ElementAt<Agente>(0);
                }
                if (this.verbale.Agente2.Count > 1)
                {
                    this.agente2 = this.verbale.Agente2.ElementAt<Agente>(1);
                }
                return Helper.RiempiCampi(this.verbale, this.agente1, this.agente2, this.violazione, this.trasgressore, null, null, this.veicolo, this.avvocato, this.veicolo.Proprietario, null);
            }
        }

        public override void Create(object sender, EventArgs e)
        {
            List<string> file = new List<string>();
            IList<string> list2 = base.VerbaliSelezionati();
            BaseVerbale verbale = new BaseVerbale();
            if ((this.ViewState["idverbale"] != null) && (list2.Count > 0))
            {
                int num = int.Parse(this.ViewState["idverbale"].ToString());
                string item = string.Empty;
                using (new ComandoEntities2())
                {
                    Helper.CloseAllProcess();
                    Application word = (Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                    using (IEnumerator<string> enumerator = list2.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            item = Helper.FillDocument(enumerator.Current, this.CreaDettaglio((long) num), word);
                            file.Add(item);
                        }
                    }
                    word.Quit(true);
                    Marshal.ReleaseComObject(word);
                    Helper.DownloadFile(this, file, base.GetType());
                    return;
                }
            }
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "key", "<script>ShowVerbali()</script>");
        }

        public void Load(Verbale v)
        {
            if (v != null)
            {
                using (ComandoEntities2 entities = new ComandoEntities2())
                {
                    this.violazione = entities.Violazione.Where(x => x.Verbale_Id == v.Id).FirstOrDefault();
                    if (v.Agente2.Count > 0)
                    {
                        this.ControlAgente.agente1 = v.Agente2.ElementAt<Agente>(0);
                    }
                    if (v.Agente2.Count > 1)
                    {
                        this.ControlAgente.agente2 = v.Agente2.ElementAt<Agente>(1);
                    }
                    this.ControlAgente.verbale = v;
                    this.ControlAgente.violazione = this.violazione;
                    this.ControlAgente.LoadData(this.ControlAgente.agente1, this.ControlAgente.agente2, v, this.ControlAgente.violazione);
                    if (v.Trasgressore != null)
                    {
                        this.ControlTrasgressore.LoadData(v.Trasgressore);
                    }
                    if (v.Veicolo != null)
                    {
                        this.ControlVeicolo1.LoadData(v.Veicolo);
                        if (v.Veicolo.Proprietario != null)
                        {
                            this.ControlProprietario.LoadData(v.Veicolo.Proprietario);
                        }
                    }
                    if (v.Trasgressore != null)
                    {
                        this.ControlPatente.LoadData(v.Trasgressore);
                    }
                    this.ViewState["idverbale"] = v.Id;
                    base.idverbale.Value = v.Id.ToString();
                }
            }
        }

        public void New(object sender, EventArgs e)
        {
            base.Response.Redirect("Ebbrezza.aspx?sotto=&cat=2");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ViewState["categoriaverbale"] = base.Request.QueryString["cat"].ToString();
                if (base.Request.QueryString["idVerbale"] != null)
                {
                    long IdVerbale = long.Parse(base.Request.QueryString["idVerbale"]);
                    using (ComandoEntities2 entities = new ComandoEntities2())
                    {
                        Verbale v = entities.Verbale.Find(IdVerbale);
                        this.Load(v);
                    }
                }
            }
            ((ComandoPage)this.Parent).Title = Helper.GetCategoryDescription(int.Parse(this.ViewState["categoriaverbale"].ToString()));
            base.BindPossibiliVerbali(2);
            this.Menu.Create += new EventHandler(this.Create);
            this.Menu.Save += new EventHandler(this.Save);
            this.Menu.Search += new EventHandler(this.Search);
            this.Menu.New += new EventHandler(this.New);
        }

        public void Save(object sender, EventArgs e)
        {
            using (ComandoEntities2 entities = new ComandoEntities2())
            {
                if (this.ViewState["idverbale"] == null)
                {
                    this.ViewState["idverbale"] = this.ControlAgente.AddNew();
                }
                int num = int.Parse(this.ViewState["idverbale"].ToString());
                object[] keyValues = new object[] { num };
                this.verbale = entities.Verbale.Find(keyValues);
                this.ControlAgente.SaveData((long) num);
                this.ControlTrasgressore.SaveData((long) num);
                this.ControlPatente.SaveData((long) num, true);
                this.ControlVeicolo1.SaveData((long) num);
                this.ControlProprietario.SaveData((long) num);
                entities.SaveChanges();
            }
        }

        public void Search(object sender, EventArgs e)
        {
        }
    }
}
