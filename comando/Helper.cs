namespace Comando
{
    using Comando;
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
    using comando;
    using System.Text.RegularExpressions;
    using System.Globalization;
    using System.Threading;

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
            //word.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            //Document document = (Document) Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00020906-0000-0000-C000-000000000046")));
            //object fileName = destFileName;
            //document = word.Documents.Open(fileName);
            //document.Activate();
            //var enumerator = document.FormFields.GetEnumerator();
                //  using (enumerator)
                {
                //while (enumerator.MoveNext())
                //{
                //    FormField field = (FormField) enumerator.Current;
                //    Console.WriteLine(field.Name);
                //    if (b.Fields.Any<KeyValuePair<string, string>>(x => x.Key == field.Name))
                //    {
                //        field.Range.Text = (from x in b.Fields
                //            where x.Key == field.Name
                //            select x.Value).FirstOrDefault<string>();
                //    }
                 //}
                }

            string fileName = destFileName;
            var document = File.ReadAllText(fileName);
            var regExPatter = @"(?<=<%)(.*)(?=%>)";
            Regex r = new Regex(regExPatter, RegexOptions.IgnoreCase);
            // Match the regular expression pattern against a text string.
            var newValue = string.Empty;

            foreach (Match ItemMatch in r.Matches(document))
            {
                if (b.Fields.Any<KeyValuePair<string, string>>(x => x.Key == ItemMatch.Value))
                   {
                    newValue = (from x in b.Fields where x.Key == ItemMatch.Value select x.Value).FirstOrDefault<string>();
                   }
                    document = document.Replace("<%"+ ItemMatch.Value+"%>", newValue);
            }
            (ConfigurationManager.AppSettings["PathNuovi"] + "VerbaleNuovo.doc").Replace("VerbaleNuovo", "VerbaleNuovo" + DateTime.Now.Ticks);
            object obj17 = destFileName;
            File.WriteAllText(fileName, document);
            //document.Close();
            return destFileName;
        }

        public static string GetCategoryDescription(int currentid,int? sotto)
        {
            currentid--;
            using (ComandoEntities entities = new ComandoEntities())
            {
               if (sotto.HasValue)
                return entities.CategoriaVerbale.Where(x => x.IDPadre == currentid  && x.Sotto==sotto).Select(y => y.Descrizione).FirstOrDefault();
               else
                return entities.CategoriaVerbale.Where(x => x.IDPadre == currentid).Select(y=>y.Descrizione).FirstOrDefault();
            }
        }

        public static string GetCittaDaCAP(string cap)
        {
            string str = string.Empty;
            using (ComandoEntities entities = new ComandoEntities())
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
                using (ComandoEntities entities = new ComandoEntities())
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
            using (ComandoEntities entities = new ComandoEntities())
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
            using (ComandoEntities entities = new ComandoEntities())
            {
                list = entities.Trasgressore.ToList<Trasgressore>();
            }
            return serializer.Serialize(list);
        }

        public static BaseVerbale RiempiCampi(Verbale verbale, Agente agente1, Agente agente2, Violazione violazione, Trasgressore trasgressore, Patente patente, Documento documento, Veicolo veicolo, Avvocato avvocato, Proprietario proprietario, Custode custode)
        {
            var culture = new CultureInfo("it-IT");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            VerbaleElezioneDomicilio domicilio = new VerbaleElezioneDomicilio();
            using (new ComandoEntities())
            {
                domicilio.Fields.Add("protocollo", verbale.Protocollo);
                domicilio.Fields.Add("annoverbale", verbale.Data.Value.Year.ToString()?.Trim());
                domicilio.Fields.Add("giornoverbale", verbale.Data.Value.Day.ToString()?.Trim());
                char[] separator = new char[] { ' ' };
                domicilio.Fields.Add("meseverbale", verbale.Data.Value.ToLongDateString().Split(separator)[2].ToString());
                domicilio.Fields.Add("oraverbale", verbale.DataOraApertura.Value.ToString(@"hh\:mm"));
                domicilio.Fields.Add("cittaverbale", violazione.Citta.ToString()?.Trim());
                domicilio.Fields.Add("viaverbale", verbale.Indirizzo.ToString()?.Trim());
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
                    string[] textArray2 = new string[] { str, " , ", agente2.Cognome?.Trim(), " ", agente2.Nome?.Trim() };
                    str = string.Concat(textArray2);
                    domicilio.Fields.Add("agente2", agente2.Cognome?.Trim() + " " + agente2.Nome?.Trim());
                }
                domicilio.Fields.Add("agenti", str);
                domicilio.Fields.Add("agente1", agente1.Cognome?.Trim() + " " + agente1.Nome?.Trim());
                if (trasgressore != null)
                {
                    domicilio.Fields.Add("nometrasg", trasgressore.Cognome?.Trim() + " " + trasgressore.Nome?.Trim());
                    domicilio.Fields.Add("solonometrasg", trasgressore.Nome?.Trim());
                    domicilio.Fields.Add("solocognometrasg", trasgressore.Cognome?.Trim());
                    domicilio.Fields.Add("luogonascitatrasg", trasgressore.CittaNascita?.Trim());
                    domicilio.Fields.Add("datanascitatrasg", trasgressore.DataNascita.Value.ToShortDateString().Trim());
                    domicilio.Fields.Add("cittaresidenzatrasg", trasgressore.CittaResidenza?.Trim());
                    domicilio.Fields.Add("viaresidenzatrasg", trasgressore.ViaResidenza?.Trim());
                    domicilio.Fields.Add("viadomiciliotrasg", trasgressore.IndirizzoDomicilio?.Trim());
                    domicilio.Fields.Add("cittadomiciliotrasg", trasgressore.CIttaDomicilio?.Trim());
                    domicilio.Fields.Add("sessotrasgr", trasgressore.Sesso?.Trim());
                    domicilio.Fields.Add("nazionalitatrasgr", trasgressore.StatoNascita?.Trim());
                    if (trasgressore.Patente!=null)
                    {
                        domicilio.Fields.Add("tipopatentetrasg", trasgressore.Patente.Categoria?.Trim());
                        domicilio.Fields.Add("tipopatentetrasgprefissopatente",  trasgressore.Patente.Categoria?.Replace("Patente","").Trim());
                        domicilio.Fields.Add("numeropatentetrasg", trasgressore.Patente.Numero?.Trim());
                        domicilio.Fields.Add("patenterilasciatada", trasgressore.Patente.RilasciataDa?.Trim());
                        if (trasgressore.Patente.Data.HasValue)
                        {
                            domicilio.Fields.Add("datarilasciopatente", trasgressore.Patente.Data.Value.ToShortDateString()?.Trim());
                        }
                    }
                    if ((trasgressore.Patente!=null))
                    {
                        domicilio.Fields.Add("tipodocumento", trasgressore.Patente.Categoria?.Trim());
                        domicilio.Fields.Add("numerodocumento", trasgressore.Patente.Numero?.Trim());
                    }

                }
                if (violazione != null)
                {
                    domicilio.Fields.Add("violazionearticolo", violazione.Articolo?.Trim());
                    domicilio.Fields.Add("violazionecitta", violazione.Citta?.Trim());
                    domicilio.Fields.Add("violazioneanno", violazione.Data.Value.Year.ToString());
                    domicilio.Fields.Add("violazionegiorno", violazione.Data.Value.Day.ToString());
                    domicilio.Fields.Add("violazionemese", violazione.Data.Value.ToString("MMMM"));
                    if (violazione.Data.HasValue)
                    {
                        domicilio.Fields.Add("violazionedata", violazione.Data.Value.ToShortDateString()?.Trim());
                    }
                    domicilio.Fields.Add("violazionedescrizione", violazione.Descrizione?.Trim());
                    domicilio.Fields.Add("violazioneindirizzo", violazione.Indirizzo?.Trim());
                    if (violazione.Data.HasValue)
                    {
                        domicilio.Fields.Add("violazioneora", violazione.Data.Value.ToShortTimeString()?.Trim());
                    }
                }
                if (veicolo != null)
                {
                    domicilio.Fields.Add("marcaveicolo", veicolo.marca?.Trim());
                    domicilio.Fields.Add("modelloveicolo", veicolo.modello?.Trim());
                    domicilio.Fields.Add("veicolo", veicolo.TipoVeicolo.Descrizione?.Trim());
                    domicilio.Fields.Add("tipoemodelloveicolo", veicolo.marca?.Trim() + " " + veicolo.modello?.Trim());
                    domicilio.Fields.Add("targaveicolo", veicolo.targa?.Trim());
                    domicilio.Fields.Add("telaioveicolo", veicolo.telaio?.Trim());
                    domicilio.Fields.Add("coloreveicolo", veicolo.colore?.Trim());
                    if (veicolo.Proprietario != null)
                    {
                        domicilio.Fields.Add("proprietarioveicolo", veicolo.Proprietario.Nome?.Trim() + " " + veicolo.Proprietario.Cognome?.Trim());
                        domicilio.Fields.Add("cittanascitapropr", veicolo.Proprietario.CittaNascita?.Trim());
                        domicilio.Fields.Add("datanascitapropr", veicolo.Proprietario.DataNascita.Value.ToShortDateString()?.Trim());
                        domicilio.Fields.Add("cittaresidenzapropr", veicolo.Proprietario.CittaResidenza?.Trim());
                        domicilio.Fields.Add("viaresidenzapropr", veicolo.Proprietario.IndirizzoResidenza?.Trim());
                        if (veicolo.Proprietario.Patente != null)
                        {
                            domicilio.Fields.Add("tipopatenteprop", veicolo.Proprietario.Patente.Categoria?.Trim());
                            domicilio.Fields.Add("numeropatenteprop", veicolo.Proprietario.Patente.Numero?.Trim());
                            domicilio.Fields.Add("patenteproprilasciatada", veicolo.Proprietario.Patente.RilasciataDa?.Trim());
                            if (veicolo.Proprietario.Patente.Data.HasValue)
                            {
                                domicilio.Fields.Add("datarilasciopatenteprop", veicolo.Proprietario.Patente.Data.Value.ToShortDateString()?.Trim());
                            }
                        }
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
                        domicilio.Fields.Add("avvocatoufficiostudiocitta", avvocato.CittaStudio?.Trim());
                        domicilio.Fields.Add("avvocatoufficiostudiovia", avvocato.IndirizzoStudio?.Trim());
                        domicilio.Fields.Add("avvocatoufficiostudiotel", avvocato.TelefonoStudio?.Trim());
                        domicilio.Fields.Add("avvocatoufficiostudiofax", avvocato.FaxStudio?.Trim());
                        domicilio.Fields.Add("avvocatoufficiocellulare", avvocato.Cellulare?.Trim());
                        domicilio.Fields.Add("avvocatoufficioforo", avvocato.Foro?.Trim());
                        domicilio.Fields.Add("avvocatoufficioemail", avvocato.Email?.Trim());
                    }
                }
                if (custode != null)
                {
                    domicilio.Fields.Add("custodeditta", custode.Ditta?.Trim());
                    domicilio.Fields.Add("custodecomune", custode.Comune?.Trim());
                    domicilio.Fields.Add("custodeindirizzo", custode.Indirizzo?.Trim());
                }
            }
            return domicilio;
        }
       
    }
}

