namespace WebApp.UserControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using WebApp;
    using comando;

    public class Ricerca : UserControl
    {
        protected GridView GridView1;

        private void BindGrid()
        {
            using (ComandoEntities2 entities = new ComandoEntities2())
            {
                int currid = int.Parse(this.ViewState["categoriaverbale"].ToString());
                var list = entities.Verbale.Where(x=>x.Category_Id== currid). ToList();
                this.GridView1.DataSource = list;
                this.GridView1.DataBind();
            }
        }

        protected void OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                using (ComandoEntities2 entities = new ComandoEntities2())
                {
                     
                    ParameterExpression expression;
                    ParameterExpression[] parameters = new ParameterExpression[] {   };
                    Verbale v = entities.Verbale.Find(index);
                    if (v.CategoriaVerbale.ID == 1L)
                    {
                        ((Domicilio) this.Parent.Page).Load(v);
                    }
                    else if (v.CategoriaVerbale.ID == 2L)
                    {
                        ((Ebbrezza) this.Parent.Page).Load(v);
                    }
                    else if (v.CategoriaVerbale.ID == 3L)
                    {
                        ((Polizia) this.Parent.Page).Load(v);
                    }
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.ViewState["categoriaverbale"] = base.Request.QueryString["cat"].ToString();
                this.BindGrid();
            }
        }
    }
}

