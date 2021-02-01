using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kutuphane
{
 
    public partial class ZamanAtlama : System.Web.UI.Page
    {
        public static int gun;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Visible = false;
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            Label3.Visible = true;
            gun = Convert.ToInt32(TextBox1.Text);
            DateTime dt = System.DateTime.Now.AddDays(gun);
            Session.Add("Gun", TextBox1.Text);
            Label3.Text = "Yeni Tarih:" + dt.ToString();





        }
    }
}