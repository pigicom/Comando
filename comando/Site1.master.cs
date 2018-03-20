using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Comando
{
    public class Site1 :  MasterPage
    {
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
            Session.Abandon();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambioPassword.aspx");
        }

        protected void btnCrea_Click(object sender, EventArgs e)
        {
            ((ComandoPage)this.Page).Create(null, null);
        }
    }
}