namespace Comando
{
    using Microsoft.Office.Interop.Word;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Web.UI.WebControls;
    using Comando.UserControl;
    using comando;
    using System.Configuration;
    using Comando;

    public class Sives : ComandoPage
    {
        private Agente agente1 = new Agente();
        private Agente agente2 = new Agente();
        private Avvocato avvocato = new Avvocato();
        protected ControlAgente ControlAgente;
        protected ControlCustode ControlCustode1;
        protected Comando.UserControl.ControlPatente ControlPatente;
        protected ControlPatente ControlPatenteProprietario;
        protected ControlProprietario ControlProprietario;
        protected ControlTrasgressore ControlTrasgressore;
        protected ControlVeicolo ControlVeicolo;
        private Custode custode = new Custode();
        protected Comando.UserControl.Menu Menu;
        private Patente patente = new Patente();
        private string pathPrefix = (ConfigurationManager.AppSettings["PathTemplates"] + @"\POLIZIA GIUDIZIARIA\");
        public string sotto = string.Empty;
        private Trasgressore trasgressore = new Trasgressore();
        private Veicolo veicolo = new Veicolo();
        private Verbale verbale = new Verbale();
        private VerbaleElezioneDomicilio verbaledomicilio = new VerbaleElezioneDomicilio();
        private Violazione violazione = new Violazione();

        public BaseVerbale CreaDettaglio(long verbaleid)
        {
            VerbaleElezioneDomicilio domicilio = new VerbaleElezioneDomicilio();
            long current = verbaleid;
            using (ComandoEntities entities = new ComandoEntities())
            {
                this.violazione = entities.Violazione.Where(x => x.Verbale_Id == verbaleid).FirstOrDefault();
                this.verbale = this.violazione.Verbale;
                this.trasgressore = this.verbale.Trasgressore;
                if (this.verbale.Agente != null)
                {
                    this.agente1 = this.verbale.Agente;
                }
                if (this.verbale.Agente1 != null)
                {
                    this.agente2 = this.verbale.Agente1;
                }
                this.avvocato = this.verbale.Avvocato;
                this.patente = this.trasgressore.Patente;
                if (this.veicolo.Id_Custode.HasValue)
                {
                    object[] objArray2 = new object[] { this.veicolo.Id_Custode };
                    this.custode = entities.Custode.Find(objArray2);
                }
                return Helper.RiempiCampi(this.verbale, this.agente1, this.agente2, this.violazione, this.trasgressore, this.patente, null, verbale.Veicolo, this.avvocato, this.veicolo.Proprietario, this.custode);
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
                using (new ComandoEntities())
                {
                    using (IEnumerator<string> enumerator = list2.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            item = Helper.FillDocument(enumerator.Current, this.CreaDettaglio((long)num), null);
                            file.Add(item);
                        }
                    }
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
                using (ComandoEntities entities = new ComandoEntities())
                {
                    Verbale Verbale = entities.Verbale.Find(v.Id);
                    this.violazione = Verbale.Violazione.FirstOrDefault();
                    if (Verbale.Agente != null)
                    {
                        this.ControlAgente.agente1 = Verbale.Agente;
                    }
                    if (Verbale.Agente1 != null)
                    {
                        this.ControlAgente.agente2 = Verbale.Agente1;
                    }
                    this.ControlAgente.verbale = Verbale;
                    this.ControlAgente.violazione = this.violazione;
                    this.ControlAgente.LoadData(this.ControlAgente.agente1, this.ControlAgente.agente2, Verbale, this.ControlAgente.violazione);
                    if (Verbale.Trasgressore != null)
                    {
                        this.ControlTrasgressore.LoadData(Verbale.Trasgressore);
                    }
                    this.ViewState["idverbale"] = Verbale.Id;
                    base.idverbale.Value = Verbale.Id.ToString();
                    if ((Verbale.Trasgressore != null) && (Verbale.Trasgressore.Patente != null))
                    {
                        this.ControlPatente.LoadData(Verbale.Trasgressore);
                    }
                    if (((Verbale.Veicolo != null) && (Verbale.Veicolo.Proprietario != null)) && (Verbale.Veicolo.Proprietario.Patente != null))
                    {
                        this.ControlPatenteProprietario.LoadData(Verbale.Veicolo.Proprietario);
                    }
                    if (Verbale.Veicolo != null)
                    {
                        this.ControlVeicolo.LoadData(Verbale.Veicolo);
                        if (Verbale.Veicolo.Proprietario != null)
                        {
                            this.ControlProprietario.LoadData(Verbale.Veicolo.Proprietario);
                        }
                        if (Verbale.Veicolo.Custode != null)
                        {
                            this.ControlCustode1.LoadData(Verbale.Veicolo);
                        }
                    }
                }
            }
        }

        public void New(object sender, EventArgs e)
        {
            base.Response.Redirect("Sives.aspx?sotto=" + base.Request.QueryString["sotto"].Trim() + "&cat=4");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.sotto = base.Request.QueryString["sotto"];
            if (!base.IsPostBack)
            {
                this.ViewState["categoriaverbale"] = base.Request.QueryString["cat"].ToString();
                if (base.Request.QueryString["idVerbale"] != null)
                {
                    long IdVerbale = long.Parse(base.Request.QueryString["idVerbale"]);
                    using (ComandoEntities entities = new ComandoEntities())
                    {

                        Verbale v = entities.Verbale.Find(IdVerbale);
                        this.Load(v);
                    }
                }
            }
            ((ComandoPage)this).Title = Helper.GetCategoryDescription(int.Parse(this.ViewState["categoriaverbale"].ToString()),Int32.Parse(sotto));
            ((Label)(this.Master.FindControl("lblCategory"))).Text = Helper.GetCategoryDescription(int.Parse(this.ViewState["categoriaverbale"].ToString()), Int32.Parse(sotto));
            base.BindPossibiliVerbali(3);
            this.Menu.Create += new EventHandler(this.Create);
            this.Menu.Save += new EventHandler(this.Save);
            this.Menu.Search += new EventHandler(this.Search);
            this.Menu.New += new EventHandler(this.New);
            int num = 2;
            if (base.Request.QueryString["sotto"] != num.ToString())
            {
                num = 4;
                if (base.Request.QueryString["sotto"] != num.ToString())
                {
                    return;
                }
            }
            this.ControlCustode1.Visible = false;
        }

        public void Save(object sender, EventArgs e)
        {
            using (ComandoEntities  entities = new ComandoEntities())
            {
                if (this.ViewState["idverbale"] == null)
                    this.ViewState["idverbale"] = this.ControlAgente.AddNew();
                int num = int.Parse(this.ViewState["idverbale"].ToString());
                object[] keyValues = new object[] { num };
                this.verbale = entities.Verbale.Find(keyValues);
                this.ControlAgente.SaveData((long) num);
                this.ControlTrasgressore.SaveData((long) num);
                this.ControlPatente.SaveData((long) num, true);
                this.ControlVeicolo.SaveData((long) num);
                this.ControlProprietario.SaveData((long) num);
                this.ControlPatenteProprietario.SaveData((long)num, false);
                Veicolo veicolo = verbale.Veicolo;
                if (veicolo != null)
                   this.ControlCustode1.SaveData(veicolo.Id);
                 
                entities.SaveChanges();
            }
            this.Page.ClientScript.RegisterStartupScript(base.GetType(), "save", "<script>alert('Salvataggio Effettuato')</script>");
        }

        public void Search(object sender, EventArgs e)
        {
        }
    }
}

