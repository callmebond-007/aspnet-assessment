using aspnet_assessment.ADO;
using aspnet_assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aspnet_assessment
{
    public partial class AddToy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                ResetForm();
            }
        }

        protected void btnAddToy_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                Toy toy = new Toy();
                toy.Name = txtToyName.Text;
                toy.Description = txtDescription.Text;
                toy.Amount = Convert.ToInt32(txtAmount.Text);
                toy.Category = ddlCategories.SelectedValue;
                ToyRepository toyRepository = new ToyRepository();
                toyRepository.AddToy(toy);
                ResetForm();
                Server.Transfer("ViewToys.aspx");
                
            }
        }

        private void ResetForm()
        {
            txtToyName.Text = string.Empty;
           
            txtDescription.Text = string.Empty;
            txtAmount.Text = string.Empty;
            

        }

        private void LoadCategories()
        {
            ToyRepository toyRepository = new ToyRepository();
            var toyList = toyRepository.GetToys();
            ddlCategories.DataSource = toyList;
            ddlCategories.DataTextField = "Category";
            
            ddlCategories.DataBind();
        }


    }
}
