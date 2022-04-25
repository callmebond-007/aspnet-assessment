using aspnet_assessment.ADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnet_assessment
{
    public partial class ViewToys : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadToys();
            }

        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            string commandArgument = (sender as LinkButton).CommandArgument;
            int selectedId = Convert.ToInt32(commandArgument);
            ToyRepository toyRepository = new ToyRepository();
            toyRepository.RemoveToy(selectedId);
            LoadToys();

        }

        private void LoadToys()
        {
            ToyRepository toyRepository = new ToyRepository();
            var toys = toyRepository.GetToys();
            gridToys.DataSource = toys;
            gridToys.DataBind();
        }


    }
}
