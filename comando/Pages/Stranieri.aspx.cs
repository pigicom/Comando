// Decompiled with JetBrains decompiler
// Type: WebApp.Stranieri
// Assembly: WebApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 50353A59-A376-4029-BA41-3E06E7F70B6B
// Assembly location: C:\Users\Sensei\Desktop\WebApp.dll



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

    public class Stranieri : ComandoPage
    {
        private Verbale verbale = new Verbale();
        private Agente agente1 = new Agente();
        private Agente agente2 = new Agente();
        private Trasgressore trasgressore = new Trasgressore();
        private Patente patente = new Patente();
        private Avvocato avvocato = new Avvocato();
        private Violazione violazione = new Violazione();
        private VerbaleElezioneDomicilio verbaledomicilio = new VerbaleElezioneDomicilio();
        private Veicolo veicolo = new Veicolo();
        private string pathPrefix = ConfigurationManager.AppSettings["PathTemplates"] + "\\POLIZIA GIUDIZIARIA\\";
        protected ControlAgente ControlAgente;
        protected ControlTrasgressore ControlTrasgressore;
        protected ControlPatente ControlPatente;
        protected ControlAvvocato ControlAvvocato;
        protected Comando.UserControl.Menu Menu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ViewState["categoriaverbale"] = (object)this.Request.QueryString["cat"].ToString();
                if (this.Request.QueryString["idVerbale"] != null)
                {
                    long IdVerbale = long.Parse(this.Request.QueryString["idVerbale"]);
                    using (ComandoEntities comandoEntities1 = new ComandoEntities())
                        this.Load(comandoEntities1.Verbale.Where<Verbale>((Expression<Func<Verbale, bool>>)(x => x.Id == IdVerbale)).First<Verbale>());
                }
            }
           ((ComandoPage)this).Title = Helper.GetCategoryDescription(int.Parse(this.ViewState["categoriaverbale"].ToString()),null);
            ((Label)(this.Master.FindControl("lblCategory"))).Text = Helper.GetCategoryDescription(int.Parse(this.ViewState["categoriaverbale"].ToString()),null);
            this.BindPossibiliVerbali(3);
            this.Menu.Create += new EventHandler(((ComandoPage)this).Create);
            this.Menu.Save += new EventHandler(this.Save);
            this.Menu.Search += new EventHandler(this.Search);
            this.Menu.New += new EventHandler(this.New);
        }

        public override void Create(object sender, EventArgs e)
        {
            List<string> file = new List<string>();
            IList<string> stringList = this.VerbaliSelezionati();
            BaseVerbale baseVerbale = new BaseVerbale();
            if (this.ViewState["idverbale"] != null && stringList.Count > 0)
            {
                int num = int.Parse(this.ViewState["idverbale"].ToString());
                string empty = string.Empty;
                using (new ComandoEntities())
                {
                    Helper.CloseAllProcess();
                    // ISSUE: variable of a compiler-generated type
                    Application instance = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                    foreach (string path in (IEnumerable<string>)stringList)
                    {
                        string str = Helper.FillDocument(path, this.CreaDettaglio((long)num), instance);
                        file.Add(str);
                    }
                    // ISSUE: variable of a compiler-generated type
                    Application application = instance;
                    object missing1 = Type.Missing;
                    object missing2 = Type.Missing;
                    object missing3 = Type.Missing;
                    // ISSUE: reference to a compiler-generated method
                    application.Quit(ref missing1, ref missing2, ref missing3);
                    Marshal.ReleaseComObject((object)instance);
                    Helper.DownloadFile((ComandoPage)this, file, this.GetType());
                }
            }
            else
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>ShowVerbali()</script>");
        }

        public BaseVerbale CreaDettaglio(long verbaleid)
        {
            VerbaleElezioneDomicilio elezioneDomicilio = new VerbaleElezioneDomicilio();
            long current = verbaleid;
            using (ComandoEntities comandoEntities1 = new ComandoEntities())
            {
                this.verbale = comandoEntities1.Verbale.Where<Verbale>((Expression<Func<Verbale, bool>>)(x => x.Id == current)).First<Verbale>();
                this.violazione = comandoEntities1.Violazione.Where<Violazione>((Expression<Func<Violazione, bool>>)(x => x.Verbale_Id == (long?)this.verbale.Id)).First<Violazione>();
                this.trasgressore = this.verbale.Trasgressore;
                if (this.verbale.Agente != null)
                    this.agente1 = this.verbale.Agente;
                if (this.verbale.Agente1 != null)
                    this.agente2 = this.verbale.Agente1;
                this.avvocato = this.verbale.Avvocato;
                this.patente = this.trasgressore.Patente;
                return (BaseVerbale)Helper.RiempiCampi(this.verbale, this.agente1, this.agente2, this.violazione, this.trasgressore, this.patente, (Documento)null, (Veicolo)null, this.avvocato, (Proprietario)null, (Custode)null);
            }
        }

        public void Load(Verbale v)
        {
            if (v == null)
                return;
            using (ComandoEntities comandoEntities1 = new ComandoEntities())
            {
                Verbale Verbale = comandoEntities1.Verbale.Where<Verbale>((Expression<Func<Verbale, bool>>)(x => x.Id == v.Id)).First<Verbale>();
                this.violazione = comandoEntities1.Violazione.Where<Violazione>((Expression<Func<Violazione, bool>>)(x => x.Verbale_Id == (long?)Verbale.Id)).FirstOrDefault<Violazione>();
                if (Verbale.Agente1 != null)
                    this.ControlAgente.agente1 = Verbale.Agente1;
                if (Verbale.Agente != null)
                    this.ControlAgente.agente2 = Verbale.Agente;
                this.ControlAgente.verbale = Verbale;
                this.ControlAgente.violazione = this.violazione;
                this.ControlAgente.LoadData(this.ControlAgente.agente1, this.ControlAgente.agente2, Verbale, this.ControlAgente.violazione);
                if (Verbale.Trasgressore != null)
                    this.ControlTrasgressore.LoadData(Verbale.Trasgressore);
                this.ViewState["idverbale"] = (object)Verbale.Id;
                this.idverbale.Value = Verbale.Id.ToString();
                if (Verbale.Trasgressore != null && Verbale.Trasgressore.Patente != null)
                    this.ControlPatente.LoadData(Verbale.Trasgressore);
                if (Verbale.Avvocato == null)
                    return;
                this.ControlAvvocato.LoadData(Verbale.Avvocato);
            }
        }

        public void Save(object sender, EventArgs e)
        {

            using (ComandoEntities entities = new ComandoEntities())
            {
                if (this.ViewState["idverbale"] == null)
                    this.ViewState["idverbale"] = (object)this.ControlAgente.AddNew();
                int num = int.Parse(this.ViewState["idverbale"].ToString());
                this.verbale = entities.Verbale.Find((long)num);
                this.ControlAgente.SaveData((long)num);
                this.ControlTrasgressore.SaveData((long)num);
                this.ControlPatente.SaveData((long)num, true);

                if (string.IsNullOrEmpty(((TextBox)this.ControlAvvocato.FindControl("txtNome")).Text) && string.IsNullOrEmpty(((TextBox)this.ControlAvvocato.FindControl("txtCognome")).Text))
                    return;
                this.ControlAvvocato.SaveData((long)num);
            }
        }

        public void Search(object sender, EventArgs e)
        {
        }

        public void New(object sender, EventArgs e)
        {
            this.Response.Redirect("Polizia.aspx?sotto=&cat=3");
        }
    }
}
