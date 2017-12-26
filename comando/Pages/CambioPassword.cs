namespace Comando.Pages
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using Comando;
    public class CambioPassword : Page
    {
        protected TextBox confermapassword;
        protected Panel divError;
        protected HtmlForm form1;
        protected Label lblError;
        protected TextBox nuovapassword;
        protected Button salva;
        protected TextBox vecchiapassword;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void salva_Click(object sender, EventArgs e)
        {
            using (ComandoEntities entities = new ComandoEntities())
            {
                Utente u = (Utente) this.Session["currentUser"];
                string encodedPassword = Helper.Base64Encode(this.vecchiapassword.Text);
                if (u != null)
                {
                    var vecchiaPwd = Helper.Base64Encode(entities.Utente.Where(x => x.Id == u.Id).Select(x => x.Pwd).FirstOrDefault());
                    if (vecchiaPwd!= encodedPassword)
                    {
                        this.divError.Visible = true;
                        this.lblError.Visible = true;
                        this.divError.CssClass = "alert-danger";
                        this.lblError.CssClass = "alert-danger";
                        this.lblError.Text = "Vecchia password errata";
                    }
                    else
                    {
                        this.divError.Visible = true;
                        this.lblError.Visible = true;
                        entities.Utente.Find(u.Id).Pwd = Helper.Base64Decode(nuovapassword.Text);
                        entities.SaveChanges();
                        this.divError.CssClass = "alert-success";
                        this.lblError.CssClass = "alert-success";
                        this.lblError.Text = "Salvataggio effettuato";
                        base.Response.Redirect("Domicilio.aspx?cat=1");
                    }
                }
                else
                {
                    this.divError.Visible = true;
                    this.lblError.Visible = true;
                    this.divError.CssClass = "alert-danger";
                    this.lblError.CssClass = "alert-danger";
                    this.lblError.Text = "Prima occorre effettuare il login";
                }
            }
        }
    }
}

