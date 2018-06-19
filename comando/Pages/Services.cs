namespace Comando.Pages

{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Web.Script.Serialization;
    using System.Web.Services;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using Comando;
    using Comando.NewPages;
    using comando;
    using comando.NewPages;

    public class Services : Page
    {
        protected HtmlForm form1;

        [WebMethod]
        public static void CaricaVerbale(string id)
        {
            int index = Convert.ToInt32(id);
            using (ComandoEntities entities = new ComandoEntities())
            {
                Verbale v = entities.Verbale.Find(id);
                if (v.CategoriaVerbale.ID == 1L)
                {
                    new Domicilio().Load(v);
                }
                else if (v.CategoriaVerbale.ID == 2L)
                {
                    new Ebbrezza().Load(v);
                }
                else if (v.CategoriaVerbale.ID == 3L)
                {
                    new Polizia().Load(v);
                }
            }
        }

        [WebMethod]
        public static void DeleteAgente(long id)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {
                object[] keyValues = new object[] { id };
                Agente entity = entities.Agente.Find(keyValues);
                entities.Agente.Remove(entity);
                entities.SaveChanges();
            }
        }

        [WebMethod]
        public static string GetAgenti()
        {
            new JavaScriptSerializer();
            using (ComandoEntities entities = new ComandoEntities())
            {
                entities.Configuration.LazyLoadingEnabled = false;
                return JsonConvert.SerializeObject(entities.Agente);
            }
        }

        [WebMethod]
        public static string GetDocFile(string categoria)
        {
            string[] strArray = (from x in Directory.GetFiles(Path.Combine(ConfigurationManager.AppSettings["PathTemplates"], categoria), "*.doc*", SearchOption.AllDirectories)
                                 where x.ToString().IndexOf("~$") < 0
                                 select x).ToArray<string>();
            int index = 0;
            string[] strArray2 = strArray;
            for (int i = 0; i < strArray2.Length; i++)
            {
                string text1 = strArray2[i];
                FileInfo info = new FileInfo(strArray[index]);
                strArray[index++] = info.Name;
            }
            new JavaScriptSerializer().Serialize(strArray).Replace("\"", "'");
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            return JsonConvert.SerializeObject(strArray, Formatting.None, settings);
        }

        [WebMethod]
        public static string GetComuni(string startWith)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {
                return JsonConvert.SerializeObject(entities.Comuni.Where(x => x.Comune.StartsWith(startWith)).ToList());
            }
        }
    }
}

