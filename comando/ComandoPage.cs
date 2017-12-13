namespace WebApp
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using comando;

    public class ComandoPage : Page
    {
        public HiddenField idverbale = new HiddenField();

        public void BindPossibiliVerbali(int currentid)
        {
            using (var ctx=new ComandoEntities2())
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
              //  (comando.SiteMaster).checklist = child;
                ((ComandoPage)this.Parent).FindControl("Panel1").Visible = true;
                ((ComandoPage)this.Parent).FindControl("Panel2").Visible = ((ComandoPage)this.Parent).FindControl("Panel1").Visible;
                ((ComandoPage)this.Parent).FindControl("Panel1").Controls.Add(child);
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

        //[Serializable, CompilerGenerated]
        //private sealed class <>c
        //{
        //    public static readonly ComandoPage.<>c <>9 = new ComandoPage.<>c();
        //    public static Func<string, bool> <>9__3_0;
        //    public static Func<string, string> <>9__3_1;

        //    internal bool <VerbaliSelezionati>b__3_0(string x) => 
        //        (x.IndexOf("documento_") >= 0);

        //    internal string <VerbaliSelezionati>b__3_1(string x) => 
        //        x;
        //}
    }
}

