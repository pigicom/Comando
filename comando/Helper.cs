namespace WebApp
{
    using comando;
    using Microsoft.Office.Interop.Word;
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Web.Script.Serialization;

    public class Helper
    {
        private const string processo = "WINWORD";

        public static string Base64Decode(string base64EncodedData)
        {
            byte[] bytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string Base64Encode(string plainText) => 
            Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

        public static VerbaleElezioneDomicilio Blank(VerbaleElezioneDomicilio verb, int cont) => 
            verb;

        public static void CloseAllProcess()
        {
            foreach (Process process in Process.GetProcessesByName("WINWORD"))
            {
                if (!string.IsNullOrEmpty(process.ProcessName))
                {
                    try
                    {
                        process.Kill();
                    }
                    catch
                    {
                    }
                }
            }
        }

        public static void DownloadFile(ComandoPage Page, List<string> file, Type t)
        {
            string str = "";
            string str2 = "";
            foreach (string str3 in file)
            {
                str = ConfigurationManager.AppSettings["URLNuovi"] + "//" + str3.Replace(ConfigurationManager.AppSettings["PathNuovi"], "");
                string[] textArray1 = new string[] { str2, "<a href=\"", str, "\">", Path.GetFileName(str3), "</a>" };
                str2 = string.Concat(textArray1);
            }
            str2 = "'" + str2 + "'";
            Page.ClientScript.RegisterStartupScript(t, "key", "<script>$('#fileDownloader').append(" + str2 + "); $('#fileDownloader').dialog({modal: false,width:400,height:200,buttons: {Ok: function() {$(this).dialog('close')}}});</script>");
        }

        public static string FillDocument(string path, BaseVerbale b, Application word)
        {
            string str = "Verbale_" + DateTime.Now.Ticks.ToString();
            b.directory = DateTime.Now.ToString("dd-MM-yyyy") + "//";
            string destFileName = ConfigurationManager.AppSettings["PathNuovi"] + b.directory + str + ".doc";
            if (!Directory.Exists(ConfigurationManager.AppSettings["PathNuovi"] + b.directory))
            {
                Directory.CreateDirectory(ConfigurationManager.AppSettings["PathNuovi"] + b.directory);
            }
            File.Copy(Directory.GetFiles(ConfigurationManager.AppSettings["PathTemplates"], path, SearchOption.AllDirectories).FirstOrDefault<string>(), destFileName, true);
            word.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            Document document = (Document) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00020906-0000-0000-C000-000000000046")));
            object fileName = destFileName;
            document = word.Documents.Open(fileName);
            document.Activate();
            var enumerator = document.FormFields.GetEnumerator();
            
          //  using (enumerator)
            {
                while (enumerator.MoveNext())
                {
                    FormField field = (FormField) enumerator.Current;
                    Console.WriteLine(field.Name);
                    if (b.Fields.Any<KeyValuePair<string, string>>(x => x.Key == field.Name))
                    {
                        field.Range.Text = (from x in b.Fields
                            where x.Key == field.Name
                            select x.Value).FirstOrDefault<string>();
                    }
                }
            }
            (ConfigurationManager.AppSettings["PathNuovi"] + "VerbaleNuovo.doc").Replace("VerbaleNuovo", "VerbaleNuovo" + DateTime.Now.Ticks);
            object obj17 = destFileName;
            document.SaveAs2(fileName);
            document.Close();
            return destFileName;
        }

        public static string GetCategoryDescription(int currentid)
        {
            using (ComandoEntities2 entities = new ComandoEntities2())
            {
                return entities.CategoriaVerbale.Find(currentid).Descrizione;
            }
        }

        public static string GetCittaDaCAP(string cap)
        {
            string str = string.Empty;
            using (ComandoEntities2 entities = new ComandoEntities2())
            {

                var source = entities.ListaComuni.Where(x => x.CAP == cap).Select(x => x);
                if (source.Count() > 0)
                {
                    str = JsonConvert.SerializeObject(source.First());
                }
            }
            return str;
        }

        public static string GetCittaList(string testo)
        {
            string str = string.Empty;
            if (testo.Length > 2)
            {
                using (ComandoEntities2 entities = new ComandoEntities2())
                {
                    str = JsonConvert.SerializeObject(entities.ListaComuni.Where(x => x.Nome.Contains(testo)).ToList());
                }
            }
            return str;
        }

        public static string[] GetStatiList()
        {
            char[] chArray3;
            string str = string.Empty;
            using (ComandoEntities2 entities = new ComandoEntities2())
            {

                str = JsonConvert.SerializeObject(entities.Stati.ToList());
            }
            char[] separator = new char[] { ',' };
            string[] strArray = new string[str.Split(separator).Length];
            int index = 0;
            chArray3 = new char[] { ',' };
            if (index < str.Split(chArray3).Length)
            {
                char[] chArray2 = new char[] { ',' };
                strArray[index] = str.Split(chArray2)[index].Replace("\"", "");
                index++;
            }
            return strArray;
        }

        public static string GetTrasgressori()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            List<Trasgressore> list = new List<Trasgressore>();
            using (ComandoEntities2 entities = new ComandoEntities2())
            {
                list = entities.Trasgressore.ToList<Trasgressore>();
            }
            return serializer.Serialize(list);
        }

        public static BaseVerbale RiempiCampi(Verbale verbale, Agente agente1, Agente agente2, Violazione violazione, Trasgressore trasgressore, Patente patente, Documento documento, Veicolo veicolo, Avvocato avvocato, Proprietario proprietario, Custode custode)
        {
            VerbaleElezioneDomicilio domicilio = new VerbaleElezioneDomicilio();
            using (new ComandoEntities2())
            {
                domicilio.Fields.Add("protocollo", verbale.Protocollo);
                domicilio.Fields.Add("annoverbale", verbale.Data.Value.Year.ToString());
                domicilio.Fields.Add("giornoverbale", verbale.Data.Value.Day.ToString());
                char[] separator = new char[] { ' ' };
                domicilio.Fields.Add("meseverbale", verbale.Data.Value.ToLongDateString().Split(separator)[2].ToString());
                domicilio.Fields.Add("oraverbale", verbale.DataOraApertura.Value.ToString(@"hh\:mm"));
                domicilio.Fields.Add("cittaverbale", violazione.Citta.ToString());
                domicilio.Fields.Add("viaverbale", verbale.Indirizzo.ToString());
                string[] textArray1 = new string[5];
                textArray1[0] = verbale.Data.Value.Day.ToString();
                textArray1[1] = " ";
                char[] chArray2 = new char[] { ' ' };
                textArray1[2] = verbale.Data.Value.ToLongDateString().Split(chArray2)[2].ToString();
                textArray1[3] = " ";
                textArray1[4] = verbale.Data.Value.Year.ToString();
                domicilio.Fields.Add("dataverbale", string.Concat(textArray1));
                if (verbale.DataOraChiusura.HasValue)
                {
                    domicilio.Fields.Add("datachiusuraverbale", verbale.DataOraChiusura.Value.ToShortDateString());
                }
                if (verbale.DataOraChiusura.HasValue)
                {
                    domicilio.Fields.Add("orachiusuraverbale", verbale.DataOraChiusura.Value.ToString(@"hh\:mm"));
                }
                string str = string.Empty;
                str = agente1.Cognome.Trim() + " " + agente1.Nome.Trim();
                if ((agente2 != null) && (agente2.Id != 0))
                {
                    string[] textArray2 = new string[] { str, " , ", agente2.Cognome.Trim(), " ", agente2.Nome.Trim() };
                    str = string.Concat(textArray2);
                    domicilio.Fields.Add("agente2", agente2.Cognome.Trim() + " " + agente2.Nome.Trim());
                }
                domicilio.Fields.Add("agenti", str);
                domicilio.Fields.Add("agente1", agente1.Cognome.Trim() + " " + agente1.Nome.Trim());
                if (trasgressore != null)
                {
                    domicilio.Fields.Add("nometrasg", trasgressore.Cognome.Trim() + " " + trasgressore.Nome.Trim());
                    domicilio.Fields.Add("solonometrasg", trasgressore.Nome.Trim());
                    domicilio.Fields.Add("solocognometrasg", trasgressore.Cognome.Trim());
                    domicilio.Fields.Add("luogonascitatrasg", trasgressore.CittaNascita);
                    domicilio.Fields.Add("datanascitatrasg", trasgressore.DataNascita.Value.ToShortDateString());
                    domicilio.Fields.Add("cittaresidenzatrasg", trasgressore.CittaResidenza);
                    domicilio.Fields.Add("viaresidenzatrasg", trasgressore.ViaResidenza);
                    domicilio.Fields.Add("viadomiciliotrasg", trasgressore.IndirizzoDomicilio);
                    domicilio.Fields.Add("cittadomiciliotrasg", trasgressore.CIttaDomicilio);
                    domicilio.Fields.Add("sessotrasgr", trasgressore.Sesso);
                    domicilio.Fields.Add("nazionalitatrasgr", trasgressore.StatoNascita);
                    if (trasgressore.Patente.Count > 0)
                    {
                        domicilio.Fields.Add("tipopatentetrasg", trasgressore.Patente.First<Patente>().Categoria);
                        domicilio.Fields.Add("numeropatentetrasg", trasgressore.Patente.First<Patente>().Numero);
                        domicilio.Fields.Add("patenterilasciatada", trasgressore.Patente.First<Patente>().RilasciataDa);
                        if (trasgressore.Patente.First<Patente>().Data.HasValue)
                        {
                            domicilio.Fields.Add("datarilasciopatente", trasgressore.Patente.First<Patente>().Data.Value.ToShortDateString());
                        }
                    }
                    if (!string.IsNullOrEmpty(trasgressore.DocumentoTipo))
                    {
                        domicilio.Fields.Add("tipodocumento", trasgressore.DocumentoTipo);
                        domicilio.Fields.Add("numerodocumento", trasgressore.DocumentoNumero);
                    }
                }
                if (violazione != null)
                {
                    domicilio.Fields.Add("violazionearticolo", violazione.Articolo);
                    domicilio.Fields.Add("violazionecitta", violazione.Citta);
                    if (violazione.Data.HasValue)
                    {
                        domicilio.Fields.Add("violazionedata", violazione.Data.Value.ToShortDateString());
                    }
                    domicilio.Fields.Add("violazionedescrizione", violazione.Descrizione);
                    domicilio.Fields.Add("violazioneindirizzo", violazione.Indirizzo);
                    if (violazione.Data.HasValue)
                    {
                        domicilio.Fields.Add("violazioneora", violazione.Data.Value.ToShortTimeString());
                    }
                }
                if (veicolo != null)
                {
                    domicilio.Fields.Add("marcaveicolo", veicolo.marca);
                    domicilio.Fields.Add("modelloveicolo", veicolo.modello);
                    domicilio.Fields.Add("veicolo", veicolo.TipoVeicolo.Descrizione);
                    domicilio.Fields.Add("tipoemodelloveicolo", veicolo.marca + " " + veicolo.modello);
                    domicilio.Fields.Add("targaveicolo", veicolo.targa);
                    domicilio.Fields.Add("telaioveicolo", veicolo.telaio);
                    domicilio.Fields.Add("coloreveicolo", veicolo.colore);
                    if (veicolo.Proprietario != null)
                    {
                        domicilio.Fields.Add("proprietarioveicolo", veicolo.Proprietario.Nome.Trim() + " " + veicolo.Proprietario.Cognome.Trim());
                        domicilio.Fields.Add("cittanascitapropr", veicolo.Proprietario.CittaNascita);
                        domicilio.Fields.Add("datanascitapropr", veicolo.Proprietario.DataNascita.Value.ToShortDateString());
                        domicilio.Fields.Add("cittaresidenzapropr", veicolo.Proprietario.CittaResidenza);
                        domicilio.Fields.Add("viaresidenzapropr", veicolo.Proprietario.IndirizzoResidenza);
                    }
                }
                if (avvocato != null)
                {
                    bool? assegnato = avvocato.Assegnato;
                    bool flag = true;
                    if ((assegnato.GetValueOrDefault() == flag) ? !assegnato.HasValue : true)
                    {
                        domicilio.Fields.Add("avvocatonome", avvocato.Cognome + " " + avvocato.Nome);
                        domicilio.Fields.Add("avvocatostudiocitta", avvocato.CittaStudio);
                        domicilio.Fields.Add("avvocatostudiovia", avvocato.IndirizzoStudio);
                        domicilio.Fields.Add("avvocatostudiotel", avvocato.TelefonoStudio);
                        domicilio.Fields.Add("avvocatostudiofax", avvocato.TelefonoStudio);
                        domicilio.Fields.Add("avvocatocellulare", avvocato.Cellulare);
                        domicilio.Fields.Add("avvocatoforo", avvocato.Foro);
                        domicilio.Fields.Add("avvocatoemail", avvocato.Email);
                    }
                    else
                    {
                        domicilio.Fields.Add("avvocatoufficionome", avvocato.Cognome + " " + avvocato.Nome);
                        domicilio.Fields.Add("avvocatoufficiostudiocitta", avvocato.CittaStudio);
                        domicilio.Fields.Add("avvocatoufficiostudiovia", avvocato.IndirizzoStudio);
                        domicilio.Fields.Add("avvocatoufficiostudiotel", avvocato.TelefonoStudio);
                        domicilio.Fields.Add("avvocatoufficiostudiofax", avvocato.TelefonoStudio);
                        domicilio.Fields.Add("avvocatoufficiocellulare", avvocato.Cellulare);
                        domicilio.Fields.Add("avvocatoufficioforo", avvocato.Foro);
                        domicilio.Fields.Add("avvocatoufficioemail", avvocato.Email);
                    }
                }
                if (custode != null)
                {
                    domicilio.Fields.Add("custodeditta", custode.Ditta);
                    domicilio.Fields.Add("custodecomune", custode.Comune);
                    domicilio.Fields.Add("custodeindirizzo", custode.Indirizzo);
                }
            }
            return domicilio;
        }

        //[Serializable, CompilerGenerated]
        //private sealed class <>c
        //{
        //    public static readonly Helper.<>c <>9 = new Helper.<>c();
        //    public static Func<KeyValuePair<string, string>, string> <>9__1_2;

        //    internal string <FillDocument>b__1_2(KeyValuePair<string, string> x) => 
        //        x.Value;
        //}
    }
}

