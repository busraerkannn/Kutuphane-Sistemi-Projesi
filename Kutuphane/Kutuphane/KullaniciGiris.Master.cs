using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Kutuphane
{
    public partial class KullaniciGiris : System.Web.UI.MasterPage
    {
        SQLBaglanti bgl = new SQLBaglanti(); 

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Kullanici where KullaniciAd=@p1 and KullaniciSifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txt_kullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", txt_sifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                SqlCommand komut2 = new SqlCommand("select KullaniciID from Tbl_Kullanici where KullaniciAd=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", txt_kullaniciAd.Text);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    Session.Add("ID", dr2[0].ToString());
                }
                Response.Redirect("Kullanici.aspx");

                
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert('Hatalı Kullanıcı Adı veya Şifre');</script>");
                txt_kullaniciAd.Text = "";
                txt_sifre.Text = "";
                txt_kullaniciAd.Focus();
            }
            bgl.baglanti().Close();

        }
    }
}