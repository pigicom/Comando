using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Web.Services;
using Comando.UserControl;
using Comando;
using System.Configuration;

namespace Comando.NewPages
{
    public partial class Domicilio : Comando.ComandoPage
    {
        private Agente agente1 = new Agente();
        private Agente agente2 = new Agente();
        private Avvocato avvocato = new Avvocato();
        protected Comando.UserControl.ControlAgente ControlAgente;
        protected Comando.UserControl.ControlAvvocato ControlAvvocato;
        protected Comando.UserControl.ControlTrasgressore ControlTrasgressore;
        protected Comando.UserControl.Menu Menu;
        private string pathPrefix = (ConfigurationManager.AppSettings["PathTemplates"] + @"\ELEZIONI DI DOMICILIO STRANIERI\");
        private Trasgressore trasgressore = new Trasgressore();
        private Verbale verbale = new Verbale();
        private VerbaleElezioneDomicilio verbaledomicilio = new VerbaleElezioneDomicilio();
        private Violazione violazione = new Violazione();

        public BaseVerbale CreaDettaglio(long verbaleid)
        {
            BaseVerbale verbale = new BaseVerbale();
            long current = verbaleid;
            using (ComandoEntities entities = new ComandoEntities())
            {
                this.violazione = entities.Violazione.Where(x => x.Verbale_Id == verbaleid).Select(x => x).FirstOrDefault();
                this.trasgressore = this.verbale.Trasgressore;
                this.avvocato = this.verbale.Avvocato;
                if (this.verbale.Agente != null)
                {
                    this.agente1 = this.verbale.Agente2.ElementAt<Agente>(1);
                }
                if (this.verbale.Agente2 != null)
                {
                    this.agente2 = this.verbale.Agente2.ElementAt<Agente>(2);
                }
                return Helper.RiempiCampi(this.verbale, this.agente1, this.agente2, this.violazione, this.trasgressore, null, null, null, this.avvocato, null, null);
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
                    Helper.CloseAllProcess();
                    Application word = (Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
                    using (IEnumerator<string> enumerator = list2.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            item = Helper.FillDocument(enumerator.Current, this.CreaDettaglio((long)num), word);
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

        [WebMethod]
        public static string GetCittaDaCAP(string cap) =>
            Helper.GetCittaDaCAP(cap);

        [WebMethod]
        public static string GetCittaList(string testo) =>
            Helper.GetCittaList(testo);

        [WebMethod]
        public static string[] GetStatiList() =>
            Helper.GetStatiList();

        public void Load(Verbale v)
        {
            if (v != null)
            {
                using (ComandoEntities entities = new ComandoEntities())
                {

                    this.violazione = entities.Violazione.Where(x => x.Verbale_Id == v.Id).FirstOrDefault();
                    if (v.Agente2.Count() > 0)
                    {
                        this.ControlAgente.agente1 = v.Agente2.ElementAt<Agente>(0);
                    }
                    if (v.Agente2.Count() > 1)
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
                    if (v.Avvocato != null)
                    {
                        this.ControlAvvocato.LoadData(v.Avvocato);
                    }
                    this.ViewState["idverbale"] = v.Id;
                    base.idverbale.Value = v.Id.ToString();
                }
            }
        }

        public void New(object sender, EventArgs e)
        {
            base.Response.Redirect("Domicilio.aspx?sotto=&cat=1");
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

                        ;
                        Verbale v = entities.Verbale.Where(x => x.Id == IdVerbale).FirstOrDefault();
                        this.Load(v);
                    }
                }
            }
            ((ComandoPage)this).Title = Helper.GetCategoryDescription(int.Parse(this.ViewState["categoriaverbale"].ToString()));
            base.BindPossibiliVerbali(1);
            this.Menu.New += new EventHandler(this.New);
            this.Menu.Create += new EventHandler(this.Create);
            this.Menu.Save += new EventHandler(this.Save);
            this.Menu.Search += new EventHandler(this.Search);
        }

        public void Save(object sender, EventArgs e)
        {
            using (var context = new ComandoEntities())
            {
                if (this.ViewState["idverbale"] == null)
                {
                    this.ViewState["idverbale"] = this.ControlAgente.AddNew(context,1);
                }
                int num = int.Parse(this.ViewState["idverbale"].ToString());
                this.verbale = context.Verbale.Find((long)num);
                this.ControlAgente.SaveData(verbale);
                this.ControlAvvocato.SaveData((long)num);
                this.ControlTrasgressore.SaveData((long)num);
            }
        }

        public void Search(object sender, EventArgs e)
        {
        }
    }
}
