using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Kutuphane
{
    public partial class AdminGiris : System.Web.UI.MasterPage
    {
        SQLBaglanti bgl = new SQLBaglanti();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Admin where AdminAd=@p1 and AdminSifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txt_kullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txt_sifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Response.Redirect("Admin.aspx");
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert('Hatalı Kullanıcı Adı veya Şifre');</script>");
                //Response.Redirect("AdminGiris.aspx");
                txt_kullaniciAd.Text = "";
                txt_sifre.Text = "";
                txt_kullaniciAd.Focus();
            }
            bgl.baglanti().Close();

        }
    }
}