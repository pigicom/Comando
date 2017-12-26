namespace Comando
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using Comando;

    public class ComandoPage : Page
    {
        public HiddenField idverbale = new HiddenField();

        public void BindPossibiliVerbali(int currentid)
        {
            using (var ctx=new ComandoEntities())
            {
                string path = ConfigurationManager.AppSettings["PathTemplates"];
                string[] directories = Directory.GetDirectories(path);
                CheckBoxList child = new CheckBoxList();
                child.Style.Add("font-family", "Verdana");
                child.Style.Add("font-size", "11px");
                int index = 0;
                foreach (string str2 in directories)
                {
                    child.Items.Add(new ListItem(str2.Replace(path, ""), str2.Replace(path, "")));
                    Directory.GetFiles(directories[index]);
                    child.Items[index].Attributes.Add("id", "Categoria" + index);
                    object[] objArray1 = new object[] { "VisualizzaVerbali('", directories[index].Replace(path, ""), "','", index, "')" };
                    child.Items[index].Attributes.Add("onchange", string.Concat(objArray1));
                    index++;
                }
                //  (Comando.SiteMaster).checklist = child;
                this.Controls[0].FindControl("Panel1").Visible = true;
                this.Controls[0].FindControl("Panel2").Visible = this.Controls[0].FindControl("Panel1").Visible;
                this.Controls[0].FindControl("Panel1").Controls.Add(child);
            }
        }

        public virtual void Create(object sender, EventArgs e)
        {
        }

        public IList<string> VerbaliSelezionati()
        {
            List<string> source = new List<string>();
            foreach (string str in from x in base.Request.Form.AllKeys
                where x.IndexOf("documento_") >= 0
                select x)
            {
                source.Add(base.Request.Form[str]);
            }
            return source.ToList<string>();
        }
             
    }
}

