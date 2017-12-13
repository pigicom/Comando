namespace WebApp.UserControl
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class Menu : UserControl
    {
        protected ImageButton btnCrea;
        protected ImageButton btnNew;
        protected ImageButton btnSave;
        protected ImageButton btnSearch;
        protected ImageButton ImageButton1;
        protected ImageButton ImageButton2;

        [field: CompilerGenerated]
        public event EventHandler Create;

        [field: CompilerGenerated]
        public event EventHandler New;

        [field: CompilerGenerated]
        public event EventHandler Save;

        [field: CompilerGenerated]
        public event EventHandler Search;

        public void btnCrea_Click(object sender, EventArgs e)
        {
            this.Create(sender, e);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            this.New(sender, e);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Save(sender, e);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search(sender, e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}

