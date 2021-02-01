using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Kutuphane
{
    public partial class KullaniciListeleme : System.Web.UI.Page
    {
        SQLBaglanti bgl = new SQLBaglanti();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("select KullaniciAd,KitapAd from Tbl_Kullanici, Tbl_Kitap, Tbl_KitapBilgileri where Tbl_Kullanici.KullaniciID = Tbl_Kitap.KullaniciID and Tbl_Kitap.KitapID = Tbl_KitapBilgileri.KitapID and Tbl_Kitap.TeslimTarihi is null", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            DataList1.DataSource = dr;
            DataList1.DataBind();

            SqlCommand komut2 = new SqlCommand("select Tbl_Kullanici.KullaniciAd from Tbl_Kullanici where Tbl_Kullanici.KullaniciID not in (select Tbl_Kitap.KullaniciID from Tbl_Kitap where Tbl_Kitap.TeslimTarihi is null)", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            DataList2.DataSource = dr2;
            DataList2.DataBind();

            bgl.baglanti().Close();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {
            
        }
    }
}