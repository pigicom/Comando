using comando;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace Comando
{
  [WebService(Namespace = "http://tempuri.org/")]
  [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
  [ToolboxItem(false)]
  [ScriptService]
  public class Agenti : WebService
  {
    private ComandoEntities db = new ComandoEntities();

    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public bool InsertAgente(string Nome, string Cognome, string Grado)
    {
      try
      {
        this.db.Agente.Add(new Agente()
        {
          Nome = Nome,
          Cognome = Cognome,
          Grado = Grado
        });
        this.db.SaveChanges();
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public bool EditAgente(long Id, string Nome, string Cognome, string Grado)
    {
      Agente entity = this.db.Agente.Find((object) Id);
      entity.Nome = Nome;
      entity.Cognome = Cognome;
      entity.Grado = Grado;
      this.db.Entry<Agente>(entity).State = EntityState.Modified;
      try
      {
        this.db.SaveChanges();
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    [WebMethod]
    [ScriptMethod(UseHttpGet = true)]
    public bool DeleteAgente(long id)
    {
      this.db.Agente.Remove(this.db.Agente.Find((object) id));
      try
      {
        this.db.SaveChanges();
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void UploadFile()
    {
      JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
      try
      {
        HttpPostedFile file = this.Context.Request.Files[0];
        string fileName = Path.GetFileName(file.FileName);
        this.Context.Response.ContentType = "application/json";
        file.SaveAs(Path.Combine(ConfigurationManager.AppSettings["PathTemplates"] + this.Context.Request.Form["cartella"], fileName));
        scriptSerializer.Serialize((object) "{'Response':'Ok'}");
        this.Context.Response.Write(new JavaScriptSerializer().Serialize((object) "{Response:Success}"));
      }
      catch (Exception ex)
      {
      }
    }
  }
}