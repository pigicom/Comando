// Decompiled with JetBrains decompiler
// Type: WebApp.Veicoli
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

    public class Veicoli : ComandoPage
  {
    private Verbale verbale = new Verbale();
    private Agente agente1 = new Agente();
    private Agente agente2 = new Agente();
    private Veicolo veicolo = new Veicolo();
    private Violazione violazione = new Violazione();
    private VerbaleElezioneDomicilio verbaledomicilio = new VerbaleElezioneDomicilio();
    private Custode custode = new Custode();
    private string pathPrefix = ConfigurationManager.AppSettings["PathTemplates"] + "\\VEICOLI DI PROVENIENZA FURTIVA\\";
    protected ControlAgente ControlAgente;
    protected ControlVeicolo ControlVeicolo;
    protected ControlProprietario ControlProprietario;
    protected ControlPatente ControlPatente;
    protected ControlCustode ControlCustode;
    protected Comando.UserControl.Menu Menu;

        protected void Page_Load(object sender, EventArgs e)
    {
      if (!this.IsPostBack)
      {
        this.ViewState["categoriaverbale"] = (object) this.Request.QueryString["cat"].ToString();
        if (this.Request.QueryString["idVerbale"] != null)
        {
          long IdVerbale = long.Parse(this.Request.QueryString["idVerbale"]);
          using (ComandoEntities ComandoEntities = new ComandoEntities())
            this.Load(ComandoEntities.Verbale.Where<Verbale>((Expression<Func<Verbale, bool>>) (x => x.Id == IdVerbale)).First<Verbale>());
        }
      }
      ((ComandoPage)this).Title = Helper.GetCategoryDescription(int.Parse(this.ViewState["categoriaverbale"].ToString()),null);
      ((Label)(this.Master.FindControl("lblCategory"))).Text = Helper.GetCategoryDescription(int.Parse(this.ViewState["categoriaverbale"].ToString()),null);
      this.BindPossibiliVerbali(2);
      this.Menu.Create += new EventHandler(((ComandoPage) this).Create);
      this.Menu.Save += new EventHandler(this.Save);
      this.Menu.Search += new EventHandler(this.Search);
      this.Menu.New += new EventHandler(this.New);
    }

    public void Load(Verbale v)
    {
      if (v == null)
        return;
      using (ComandoEntities entities = new ComandoEntities())
      {
        Verbale Verbale = entities.Verbale.Where<Verbale>((Expression<Func<Verbale, bool>>) (x => x.Id == v.Id)).First<Verbale>();
        if (Verbale.Agente!=null)
          this.ControlAgente.agente1 = Verbale.Agente;
        if (Verbale.Agente1!=null)
          this.ControlAgente.agente2 = Verbale.Agente1;
        this.ControlAgente.verbale = Verbale;
        this.violazione = entities.Violazione.Where<Violazione>((Expression<Func<Violazione, bool>>) (x => x.Verbale_Id == (long?) Verbale.Id)).FirstOrDefault<Violazione>();
        this.ControlAgente.LoadData(this.ControlAgente.agente1, this.ControlAgente.agente2, Verbale, this.violazione);
        if (Verbale.Veicolo != null)
        {
          this.ControlVeicolo.LoadData(Verbale.Veicolo);
          if (Verbale.Veicolo.Proprietario != null)
            this.ControlProprietario.LoadData(Verbale.Veicolo.Proprietario);
        }
        if (Verbale.Veicolo.Proprietario != null)
          this.ControlPatente.LoadData(Verbale.Veicolo.Proprietario);
        if (Verbale.Veicolo.Custode != null)
          this.ControlCustode.LoadData(Verbale.Veicolo);
        this.ViewState["idverbale"] = (object) Verbale.Id;
        this.idverbale.Value = Verbale.Id.ToString();
      }
    }

    public void Save(object sender, EventArgs e)
    {
      using (ComandoEntities ComandoEntities = new ComandoEntities())
      {
        if (this.ViewState["idverbale"] == null)
          this.ViewState["idverbale"] = (object) this.ControlAgente.AddNew();
        int num = int.Parse(this.ViewState["idverbale"].ToString());
        this.verbale = ComandoEntities.Verbale.Find((object) num);
        this.ControlAgente.SaveData((long) num);
        Veicolo veicolo = this.ControlVeicolo.SaveData((long) num);
        Proprietario proprietario = this.ControlProprietario.SaveData((long) num);
        veicolo.Proprietario = proprietario;
        this.ControlPatente.SaveData((long) num, false);
        this.ControlCustode.SaveData(veicolo.Id);
        int cat = int.Parse(this.Request.QueryString["cat"].ToString());
        this.verbale.CategoriaVerbale = ComandoEntities.CategoriaVerbale.Where<CategoriaVerbale>((Expression<Func<CategoriaVerbale, bool>>) (x => x.ID == (long) cat)).FirstOrDefault<CategoriaVerbale>();
        this.verbale.Timestamp =(DateTime.Now);
        ComandoEntities.SaveChanges();
      }
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
          Application instance = (Application) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("000209FF-0000-0000-C000-000000000046")));
          foreach (string path in (IEnumerable<string>) stringList)
          {
            string str = Helper.FillDocument(path, (BaseVerbale) this.CreaDettaglio((long) num), instance);
            file.Add(str);
          }
          // ISSUE: variable of a compiler-generated type
          Application application = instance;
          object missing1 = Type.Missing;
          object missing2 = Type.Missing;
          object missing3 = Type.Missing;
          // ISSUE: reference to a compiler-generated method
          application.Quit(ref missing1, ref missing2, ref missing3);
          Marshal.ReleaseComObject((object) instance);
          Helper.DownloadFile((ComandoPage) this, file, this.GetType());
        }
      }
      else
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>ShowVerbali()</script>");
    }

    public void Search(object sender, EventArgs e)
    {
    }

    public void New(object sender, EventArgs e)
    {
      this.Response.Redirect("Ebbrezza.aspx?sotto=&cat=6");
    }

    public VerbaleElezioneDomicilio CreaDettaglio(long verbaleid)
    {
      VerbaleElezioneDomicilio elezioneDomicilio = new VerbaleElezioneDomicilio();
      long current = verbaleid;
      using (ComandoEntities entities = new ComandoEntities())
      {
        this.verbale = entities.Verbale.Where<Verbale>((Expression<Func<Verbale, bool>>) (x => x.Id == current)).First<Verbale>();
        this.violazione = entities.Violazione.Where<Violazione>((Expression<Func<Violazione, bool>>) (x => x.Verbale_Id == (long?) this.verbale.Id)).First<Violazione>();
        this.veicolo = this.verbale.Veicolo;
        if (this.verbale.Agente!=null)
          this.agente1 = this.verbale.Agente;
                if (this.verbale.Agente1 != null)
                    this.agente2 = this.verbale.Agente1;
                return (VerbaleElezioneDomicilio)Helper.RiempiCampi(this.verbale, this.agente1, this.agente2, this.violazione, null, null,  null,  null, null,  null,  null);
            }
    }
  }
}
