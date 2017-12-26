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

        //[WebMethod]
        //public static string GetAgenti()
        //{
        //    new JavaScriptSerializer();
        //    //using (ComandoEntities entities = new ComandoEntities())
        //    //{
        //    //    ParameterExpression expression;
        //    //    entities.Configuration.LazyLoadingEnabled = false;
        //    //    System.Linq.Expressions.Expression[] arguments = new System.Linq.Expressions.Expression[] { System.Linq.Expressions.Expression.Property(expression = System.Linq.Expressions.Expression.Parameter(typeof(Agente), "x"), (MethodInfo) methodof(Agente.get_Nome)) };
        //    //    ParameterExpression[] parameters = new ParameterExpression[] { expression };
        //    //    ParameterExpression[] expressionArray3 = new ParameterExpression[] { expression };
        //    //    JsonSerializerSettings settings = new JsonSerializerSettings {
        //    //        PreserveReferencesHandling = PreserveReferencesHandling.Objects
        //    //    };
        //    //    return JsonConvert.SerializeObject(entities.Agente.Where<Agente>(System.Linq.Expressions.Expression.Lambda<Func<Agente, bool>>(System.Linq.Expressions.Expression.Equal(System.Linq.Expressions.Expression.Call(null, (MethodInfo) methodof(string.IsNullOrEmpty), arguments), System.Linq.Expressions.Expression.Constant(false, typeof(bool))), parameters)).Select<Agente, Agente>(System.Linq.Expressions.Expression.Lambda<Func<Agente, Agente>>(expression = System.Linq.Expressions.Expression.Parameter(typeof(Agente), "x"), expressionArray3)).ToList<Agente>(), Formatting.None, settings);
        //    //}
        //}

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

        //[WebMethod]
        //public static string GetVerbali(string categoria)
        //{
        //    new JavaScriptSerializer();
        //    using (ComandoEntities entities = new ComandoEntities())
        //    {
        //        <>c__DisplayClass3_0 class_;
        //        ParameterExpression expression;
        //        int currid = int.Parse(categoria);
        //        ParameterExpression[] parameters = new ParameterExpression[] { expression };
        //        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
        //        System.Linq.Expressions.Expression[] arguments = new System.Linq.Expressions.Expression[7];
        //        arguments[0] = System.Linq.Expressions.Expression.Property(expression = System.Linq.Expressions.Expression.Parameter(typeof(Verbale), "x"), (MethodInfo) methodof(Verbale.get_Id));
        //        arguments[1] = System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Data));
        //        arguments[2] = System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Protocollo));
        //        arguments[3] = System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Trasgressore)), (MethodInfo) methodof(Trasgressore.get_Nome)), (MethodInfo) methodof(string.Trim), new System.Linq.Expressions.Expression[0]);
        //        arguments[4] = System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Trasgressore)), (MethodInfo) methodof(Trasgressore.get_Cognome)), (MethodInfo) methodof(string.Trim), new System.Linq.Expressions.Expression[0]);
        //        System.Linq.Expressions.Expression[] expressionArray4 = new System.Linq.Expressions.Expression[] { System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Agente)) };
        //        arguments[5] = System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Call(null, (MethodInfo) methodof(Enumerable.FirstOrDefault), expressionArray4), (MethodInfo) methodof(Agente.get_Cognome)), (MethodInfo) methodof(string.Trim), new System.Linq.Expressions.Expression[0]);
        //        arguments[6] = System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Timestamp));
        //        MemberInfo[] members = new MemberInfo[] { (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Id, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Data, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Protocollo, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Nome, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Cognome, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Agente, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Timestamp, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>) };
        //        ParameterExpression[] expressionArray5 = new ParameterExpression[] { expression };
        //        var list = entities.Verbale.Where<Verbale>(System.Linq.Expressions.Expression.Lambda<Func<Verbale, bool>>(System.Linq.Expressions.Expression.Equal(System.Linq.Expressions.Expression.Property(expression = System.Linq.Expressions.Expression.Parameter(typeof(Verbale), "x"), (MethodInfo) methodof(Verbale.get_CategoriaVerbale_Id)), System.Linq.Expressions.Expression.Convert(System.Linq.Expressions.Expression.Convert(System.Linq.Expressions.Expression.Field(System.Linq.Expressions.Expression.Constant(class_, typeof(<>c__DisplayClass3_0)), fieldof(<>c__DisplayClass3_0.currid)), typeof(long)), typeof(long?))), parameters)).OrderByDescending<Verbale, long>(System.Linq.Expressions.Expression.Lambda<Func<Verbale, long>>(System.Linq.Expressions.Expression.Property(expression = System.Linq.Expressions.Expression.Parameter(typeof(Verbale), "x"), (MethodInfo) methodof(Verbale.get_Id)), expressionArray2)).Select(System.Linq.Expressions.Expression.Lambda(System.Linq.Expressions.Expression.New((ConstructorInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>..ctor, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), arguments, members), expressionArray5)).ToList();
        //        if (currid == 6)
        //        {
        //            ParameterExpression[] expressionArray6 = new ParameterExpression[] { expression };
        //            ParameterExpression[] expressionArray7 = new ParameterExpression[] { expression };
        //            System.Linq.Expressions.Expression[] expressionArray8 = new System.Linq.Expressions.Expression[7];
        //            expressionArray8[0] = System.Linq.Expressions.Expression.Property(expression = System.Linq.Expressions.Expression.Parameter(typeof(Verbale), "x"), (MethodInfo) methodof(Verbale.get_Id));
        //            expressionArray8[1] = System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Data));
        //            expressionArray8[2] = System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Protocollo));
        //            expressionArray8[3] = System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Veicolo)), (MethodInfo) methodof(Veicolo.get_Proprietario)), (MethodInfo) methodof(Proprietario.get_Nome)), (MethodInfo) methodof(string.Trim), new System.Linq.Expressions.Expression[0]);
        //            expressionArray8[4] = System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Veicolo)), (MethodInfo) methodof(Veicolo.get_Proprietario)), (MethodInfo) methodof(Proprietario.get_Cognome)), (MethodInfo) methodof(string.Trim), new System.Linq.Expressions.Expression[0]);
        //            System.Linq.Expressions.Expression[] expressionArray9 = new System.Linq.Expressions.Expression[] { System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Agente)) };
        //            expressionArray8[5] = System.Linq.Expressions.Expression.Call(System.Linq.Expressions.Expression.Property(System.Linq.Expressions.Expression.Call(null, (MethodInfo) methodof(Enumerable.FirstOrDefault), expressionArray9), (MethodInfo) methodof(Agente.get_Cognome)), (MethodInfo) methodof(string.Trim), new System.Linq.Expressions.Expression[0]);
        //            expressionArray8[6] = System.Linq.Expressions.Expression.Property(expression, (MethodInfo) methodof(Verbale.get_Timestamp));
        //            MemberInfo[] infoArray2 = new MemberInfo[] { (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Id, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Data, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Protocollo, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Nome, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Cognome, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Agente, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), (MethodInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>.get_Timestamp, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>) };
        //            ParameterExpression[] expressionArray10 = new ParameterExpression[] { expression };
        //            list = entities.Verbale.Where<Verbale>(System.Linq.Expressions.Expression.Lambda<Func<Verbale, bool>>(System.Linq.Expressions.Expression.Equal(System.Linq.Expressions.Expression.Property(expression = System.Linq.Expressions.Expression.Parameter(typeof(Verbale), "x"), (MethodInfo) methodof(Verbale.get_CategoriaVerbale_Id)), System.Linq.Expressions.Expression.Convert(System.Linq.Expressions.Expression.Convert(System.Linq.Expressions.Expression.Field(System.Linq.Expressions.Expression.Constant(class_, typeof(<>c__DisplayClass3_0)), fieldof(<>c__DisplayClass3_0.currid)), typeof(long)), typeof(long?))), expressionArray6)).OrderByDescending<Verbale, long>(System.Linq.Expressions.Expression.Lambda<Func<Verbale, long>>(System.Linq.Expressions.Expression.Property(expression = System.Linq.Expressions.Expression.Parameter(typeof(Verbale), "x"), (MethodInfo) methodof(Verbale.get_Id)), expressionArray7)).Select(System.Linq.Expressions.Expression.Lambda(System.Linq.Expressions.Expression.New((ConstructorInfo) methodof(<>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>..ctor, <>f__AnonymousType5<long, DateTime?, string, string, string, string, DateTime?>), expressionArray8, infoArray2), expressionArray10)).ToList();
        //        }
        //        JsonSerializerSettings settings = new JsonSerializerSettings {
        //            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        //        };
        //        return JsonConvert.SerializeObject(list, Formatting.None, settings);
        //    }
        //}

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

