namespace Comando.Pages
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using Comando;
    using comando;
    public class Regitstrati : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected Label lblError;
        protected TextBox password1;
        protected TextBox password2;
        protected Button salva;
        protected TextBox username;

        public static string Base64Decode(string base64EncodedData)
        {
            byte[] bytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string Base64Encode(string plainText) => 
            Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("/Comando/Login.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void salva_Click(object sender, EventArgs e)
        {
            try
            {
                using (ComandoEntities entities = new ComandoEntities())
                {
                    Utente u = new Utente {
                        Login = this.username.Text,
                        Pwd = Base64Encode(this.password1.Text)
                    };
                    if (this.password1.Text == this.password2.Text)
                    {
                        if (!(entities.Utente.Any(x=>x.Login== this.username.Text)))
                        {
                            entities.Utente.Add(u);
                            try
                            {
                                entities.SaveChanges();
                                this.lblError.Text = "Utente creato correttamente";
                            }
                            catch (Exception exception)
                            {
                                this.lblError.Text = "Si \x00e8 verificato un errore" + exception.Message;
                            }
                        }
                        else
                        {
                            this.lblError.Text = "Utente gi\x00e0 registrato!";
                        }
                    }
                    else
                    {
                        this.lblError.Text = "Le Password non coincidono! Riprovare";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

