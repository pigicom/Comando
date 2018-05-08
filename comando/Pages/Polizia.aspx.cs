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

    public class Polizia : ComandoPage
    {
        private Agente agente1 = new Agente();
        private Agente agente2 = new Agente();
        private Avvocato avvocato = new Avvocato();
        protected Comando.UserControl.ControlAgente ControlAgente;
        protected Comando.UserControl.ControlAvvocato ControlAvvocato;
        protected Comando.UserControl.ControlPatente ControlPatente;
        protected Comando.UserControl.ControlTrasgressore ControlTrasgressore;
        protected Comando.UserControl.Menu Menu;
        private Patente patente = new Patente();
        private string pathPrefix = (ConfigurationManager.AppSettings["PathTemplates"] + @"\POLIZIA GIUDIZIARIA\");
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
               
                ParameterExpression expression=null;
                ParameterExpression[] parameters = new ParameterExpression[] { expression };
                this.violazione = entities.Violazione.Where(x => x.Verbale_Id == verbaleid).FirstOrDefault();
                this.verbale = this.violazione.Verbale;
                this.trasgressore = this.verbale.Trasgressore;
                if (this.verbale.Agente!=null )
                {
                    this.agente1 = this.verbale.Agente;
                }
                if (this.verbale.Agente1!=null)
                {
                    this.agente2 = this.verbale.Agente1;
                }
                this.avvocato = this.verbale.Avvocato;
                this.patente = this.trasgressore.Patente;
                return Helper.RiempiCampi(this.verbale, this.agente1, this.agente2, this.violazione, this.trasgressore, this.patente, null, null, this.avvocato, null, null);
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
                    if (Verbale.Agente!=null)
                    {
                        this.ControlAgente.agente1 = Verbale.Agente;
                    }
                    if (Verbale.Agente1!=null)
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
                    if (Verbale.Avvocato != null)
                    {
                        this.ControlAvvocato.LoadData(Verbale.Avvocato);
                    }
                }
            }
        }

        public void New(object sender, EventArgs e)
        {
            base.Response.Redirect("Polizia.aspx?sotto=&cat=3");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            ((ComandoPage)this) .Title = Helper.GetCategoryDescription(int.Parse(this.ViewState["categoriaverbale"].ToString()),null);
            ((Label)(this.Master.FindControl("lblCategory"))).Text = Helper.GetCategoryDescription(int.Parse(this.ViewState["categoriaverbale"].ToString()),null);
            base.BindPossibiliVerbali(3);
            this.Menu.Create += new EventHandler(this.Create);
            this.Menu.Save += new EventHandler(this.Save);
            this.Menu.Search += new EventHandler(this.Search);
            this.Menu.New += new EventHandler(this.New);
        }

        public void Save(object sender, EventArgs e)
        {
                if (this.ViewState["idverbale"] == null)
                 this.ViewState["idverbale"] = this.ControlAgente.AddNew();

                int num = int.Parse(this.ViewState["idverbale"].ToString());
                this.ControlAgente.SaveData((long)num);
                this.ControlTrasgressore.SaveData((long)num);
                this.ControlPatente.SaveData((long)num, true);
                if (!string.IsNullOrEmpty(((TextBox)this.ControlAvvocato.FindControl("txtNome")).Text) || !string.IsNullOrEmpty(((TextBox)this.ControlAvvocato.FindControl("txtCognome")).Text))
                {
                    this.ControlAvvocato.SaveData((long)num);
                }
             
        }

        public void Search(object sender, EventArgs e)
        {
        }
    }
}

