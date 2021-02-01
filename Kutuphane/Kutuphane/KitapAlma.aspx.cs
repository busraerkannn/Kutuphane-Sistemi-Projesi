using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Kutuphane
{
    public partial class KitapAlma : System.Web.UI.Page
    {
        SQLBaglanti bgl = new SQLBaglanti();
        DateTime gun;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select * from Tbl_KitapBilgileri where Tbl_KitapBilgileri.TeslimEdilmeDurumu=1", bgl.baglanti());
            SqlDataReader dr = komut1.ExecuteReader();
            DropDownList1.DataTextField = "KitapAd";
            DropDownList1.DataValueField = "KitapID";
            DropDownList1.DataSource = dr;
            DropDownList1.DataBind();
            Label3.Visible = false;
            bgl.baglanti().Close();
            

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label3.Visible = true;
            if (Session["Gun"] != null)
            {
                int sayi = Convert.ToInt32(Session["Gun"].ToString());
                gun = System.DateTime.Now.AddDays(sayi);
            }
            else
            {
                gun = System.DateTime.Now;
            }
            SqlCommand komut2 = new SqlCommand("select count( Tbl_Kitap.KullaniciID) from Tbl_Kitap,Tbl_KitapBilgileri where Tbl_Kitap.KitapID=Tbl_KitapBilgileri.KitapID and Tbl_Kitap.KullaniciID=@p1 and Tbl_KitapBilgileri.TeslimEdilmeDurumu=0", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", Session["ID"].ToString());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                if (Convert.ToUInt32(dr2[0]) > 3)
                {
                    Label3.Text = "Elinizdeki kitap sayısı 3(üç)'ü geçmektedir. Lütfen önce elinizdeki kitapları teslim edin.";
                }
                else
                {
                    SqlCommand komut3 = new SqlCommand("select * from Tbl_Kitap where  Tbl_Kitap.KullaniciID=@p2 and Tbl_Kitap.TeslimEdilmesiGerekenTarih<@p1", bgl.baglanti());
                    komut3.Parameters.AddWithValue("@p1", gun);
                    komut3.Parameters.AddWithValue("@p2", Session["ID"].ToString());
                    
                    SqlDataReader dr3 = komut3.ExecuteReader();
                    if(dr3.Read())
                    {
                        Label3.Text = "Lütfen elinizdeki teslim tarihi geçmiş kitapları teslim edin.";
                    }
                    else
                    {
                        string s=DropDownList1.SelectedValue.ToString();
                        int kitapID = Convert.ToInt32(s);
                        DateTime teslimTarihi = gun.AddDays(7);
                        
                        SqlCommand komut4 = new SqlCommand("insert into Tbl_Kitap (KitapID,KullaniciID,AlinanTarih,TeslimEdilmesiGerekenTarih) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
                        komut4.Parameters.AddWithValue("@p1", kitapID);
                        komut4.Parameters.AddWithValue("@p2", Session["ID"].ToString());
                        komut4.Parameters.AddWithValue("@p3", gun);
                        komut4.Parameters.AddWithValue("@p4", teslimTarihi);
                        komut4.ExecuteNonQuery();

                        SqlCommand komut5 = new SqlCommand("update Tbl_KitapBilgileri Set TeslimEdilmeDurumu=0 where Tbl_KitapBilgileri.KitapID=@a1", bgl.baglanti());
                        komut5.Parameters.AddWithValue("@a1", kitapID);
                        komut5.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        Label3.Text = "Kitap alınmıştır";
                    }

                }
            }


        }
    }
}