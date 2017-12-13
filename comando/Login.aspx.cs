namespace WebApp
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using comando;
    public class Login : Page
    {
        protected HtmlForm form1;
        protected System.Web.UI.WebControls.Login Login1;
        protected Button registrami;

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            using (ComandoEntities2 entities = new ComandoEntities2())
            {
               
                string pwd = Helper.Base64Encode(this.Login1.Password);

                Utente utente = entities.Utente.Where(x => x.Login == this.Login1.UserName && this.Login1.Password == pwd).FirstOrDefault();
                if (utente != null)
                {
                    this.Session["currentUser"] = utente;
                    base.Response.Redirect("Pages/Domicilio.aspx?cat=1");
                }
                else
                {
                    this.Login1.FailureText = "Login o Password Errate";
                }
                this.Login1.FailureTextStyle.CssClass = "alert alert-danger";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Login1.UserNameLabelText = "Nome Utente";
            this.Login1.RememberMeText = "";
        }

        protected void registrami_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("/Comando/Pages/Registrati.aspx");
        }
    }
}

