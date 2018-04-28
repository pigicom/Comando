namespace Comando.NewPages
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
            string[] strArray = (from x in Directory.GetFiles(Path.Combine(ConfigurationManager.AppSettings["PathTemplates"], categoria), "*.rtf*", SearchOption.AllDirectories)
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
            JsonSerializerSettings settings = new JsonSerializerSettings {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            return JsonConvert.SerializeObject(strArray, Formatting.None, settings);
        }

        //[WebMethod]
        //public static string GetTrasgressore()
        //{
        //    new JavaScriptSerializer();
        //    using (ComandoEntities entities = new ComandoEntities())
        //    {
        //        ParameterExpression expression;
        //        System.Linq.Expressions.Expression[] arguments = new System.Linq.Expressions.Expression[] { System.Linq.Expressions.Expression.Property(expression = System.Linq.Expressions.Expression.Parameter(typeof(Trasgressore), "x"), (MethodInfo) methodof(Trasgressore.get_Id)), System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Trasgressore.get_Nome)), (MethodInfo) methodof(string.Trim), new System.Linq.Expressions.Expression[0]), System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Trasgressore.get_Cognome)), (MethodInfo) methodof(string.Trim), new System.Linq.Expressions.Expression[0]), System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Trasgressore.get_DataNascita)), System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Trasgressore.get_CittaNascita)), (MethodInfo) methodof(string.Trim), new System.Linq.Expressions.Expression[0]) };
        //        MemberInfo[] members = new MemberInfo[] { (MethodInfo) methodof(<>f__AnonymousType4<long, string, string, DateTime?, string>.get_Id, <>f__AnonymousType4<long, string, string, DateTime?, string>), (MethodInfo) methodof(<>f__AnonymousType4<long, string, string, DateTime?, string>.get_Nome, <>f__AnonymousType4<long, string, string, DateTime?, string>), (MethodInfo) methodof(<>f__AnonymousType4<long, string, string, DateTime?, string>.get_Cognome, <>f__AnonymousType4<long, string, string, DateTime?, string>), (MethodInfo) methodof(<>f__AnonymousType4<long, string, string, DateTime?, string>.get_DataNascita, <>f__AnonymousType4<long, string, string, DateTime?, string>), (MethodInfo) methodof(<>f__AnonymousType4<long, string, string, DateTime?, string>.get_CittaNascita, <>f__AnonymousType4<long, string, string, DateTime?, string>) };
        //        ParameterExpression[] parameters = new ParameterExpression[] { expression };
        //        JsonSerializerSettings settings = new JsonSerializerSettings {
        //            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        //        };
        //        return JsonConvert.SerializeObject(entities.Trasgressore.Select(System.Linq.Expressions.Expression.Lambda(System.Linq.Expressions.Expression.New((ConstructorInfo) methodof(<>f__AnonymousType4<long, string, string, DateTime?, string>..ctor, <>f__AnonymousType4<long, string, string, DateTime?, string>), arguments, members), parameters)).ToList(), Formatting.None, settings);
        //    }
        //}

        [WebMethod]
        public static string GetVerbali(string categoria)
        {
            new JavaScriptSerializer();
            using (ComandoEntities entities = new ComandoEntities())
            {
                var list = from x in entities.Verbale where x.Category_Id.ToString() == categoria select new {
                    Id = x.Id,
                    x.Agente1_Id,
                    x.Agente2_Id,
                    TrasgressoreNome = x.Trasgressore.Nome,
                    TrasgressoreCognome = x.Trasgressore.Cognome,
                    AgenteCognome = x.Agente1.Cognome,
                    AgenteNome = x.Agente1.Nome,
                    x.Indirizzo,
                    x.Nome, x.Veicolo_Id, x.Violazione_Id, x.Data, x.DataOraApertura, x.DataOraChiusura, x.Avvocato_Id, Autore = x.Utente.Descrizione };
               JavaScriptSerializer s = new JavaScriptSerializer();
                return s.Serialize(list);
              //  return JsonConvert.SerializeObject(list, Formatting.None, settings);
            }
        }

        //[WebMethod]
        //public static string InsertAgente(string Nome, string Cognome, string Grado)
        //{
        //    try
        //    {
        //        using (ComandoEntities entities = new ComandoEntities())
        //        {
        //            Agente entity = new Agente {
        //                Nome = Nome,
        //                Cognome = Cognome,
        //                Grado = Grado
        //            };
        //            entities.Agente.Add(entity);
        //            entities.SaveChanges();
        //        }
        //        return "true";
        //    }
        //    catch (Exception)
        //    {
        //        return "false";
        //    }
        //}

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //}

        //[WebMethod]
        //public static bool UpdateAgente(Agente agente)
        //{
        //    try
        //    {
        //        long id = agente.Id;
        //        string nome = agente.Nome;
        //        string cognome = agente.Cognome;
        //        string grado = agente.Grado;
        //        using (ComandoEntities entities = new ComandoEntities())
        //        {
        //            object[] keyValues = new object[] { id };
        //            Agente local1 = entities.Agente.Find(keyValues);
        //            local1.Nome = nome;
        //            local1.Cognome = cognome;
        //            local1.Grado = grado;
        //            entities.SaveChanges();
        //        }
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //[Serializable, CompilerGenerated]
        //private sealed class <>c
        //{
        //    public static readonly Services.<>c <>9 = new Services.<>c();
        //    public static Func<string, bool> <>9__2_0;

        //    internal bool <GetDocFile>b__2_0(string x) => 
        //        (x.ToString().IndexOf("~$") < 0);
        //}
    }
}

