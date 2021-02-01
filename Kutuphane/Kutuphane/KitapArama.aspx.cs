using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Kutuphane
{
    public partial class KitapArama : System.Web.UI.Page
    {
        SQLBaglanti bgl = new SQLBaglanti();
        bool kontrol;
        bool kontrol2;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            TextBox1.Visible = false;
            btn_ara.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (((CheckBox)sender).Checked && (!((CheckBox)sender).ID.ToString().Equals("CheckBox2")))
            {
                CheckBox2.Checked = false;
                kontrol = true;
                Label1.Text = "Kitap Adı : ";
                Label1.Visible = true;
                TextBox1.Visible = true;
                btn_ara.Visible = true;

                Label3.Text = ((CheckBox)sender).ID.ToString();
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (((CheckBox)sender).Checked && (!((CheckBox)sender).ID.ToString().Equals("CheckBox1")))
            {
                CheckBox1.Checked = false;
                kontrol = false;
                Label1.Text = "ISBN Numarası : ";
                Label1.Visible = true;
                TextBox1.Visible = true;
                btn_ara.Visible = true;
                
                Label3.Text = ((CheckBox)sender).ID.ToString();
            }
        }

        protected void btn_ara_Click(object sender, EventArgs e)
        {
            Label2.Visible = true;
            Label1.Visible = true;
            TextBox1.Visible = true;
            btn_ara.Visible = true;

            if (Label3.Text.Equals("CheckBox1"))
            {
                SqlCommand komut = new SqlCommand("select * from Tbl_KitapBilgileri where TeslimEdilmeDurumu=1 and KitapAd=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TextBox1.Text);
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    //Label3.Text= kontrol.ToString();
                    Label2.Text = "İstediğiniz kitap bulunmaktadır.";
                }
                else
                {
                    Label2.Text = "İstediğiniz kitap bulunmamaktadır.";
                }
            }

            else if (Label3.Text.Equals("CheckBox2"))
            {
                SqlCommand komut2 = new SqlCommand("select * from Tbl_KitapBilgileri where TeslimEdilmeDurumu=1 and KitapISBN=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TextBox1.Text);
                SqlDataReader dr2 = komut2.ExecuteReader();
                if (dr2.Read())
                {
                    Label2.Text = "İstediğiniz kitap bulunmaktadır.";
                }
                else
                {
                    Label2.Text = "İstediğiniz kitap bulunmamaktadır.";
                }
            }

            bgl.baglanti().Close();

        }
    }
}