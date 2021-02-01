using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OpenCvSharp;
using OpenCvSharp.MachineLearning;
using OpenCvSharp.Blob;
using OpenCvSharp.UserInterface;
using OpenCvSharp.CPlusPlus;
using System.Drawing;
using Tesseract;
using System.Data.SqlClient;

namespace Kutuphane
{
    public partial class KitapVerme : System.Web.UI.Page
    {
        List<string> kontrol1 = new List<string>();
        String ekleISBN;
        SQLBaglanti bgl = new SQLBaglanti();
        DateTime gun;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Image2.Visible = false;
            btn_teslimEt.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;

        }

        protected string Donusum(String dosyaYolu)
        {
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchyIndexes;
            OpenCvSharp.Mat s = Cv2.ImRead(@"C:\Users\FURKAN\Desktop\kitap\" + dosyaYolu);
            OpenCvSharp.Mat gray = new OpenCvSharp.Mat();
            OpenCvSharp.Mat thresh = new OpenCvSharp.Mat();
            OpenCvSharp.Mat rectKernel = new OpenCvSharp.Mat();
            OpenCvSharp.Mat dilation = new OpenCvSharp.Mat();
            Cv2.CvtColor(s, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.ImWrite(@"C:\Users\FURKAN\source\repos\Kutuphane\Kutuphane\kitap3.jpg", gray);
            Cv2.Threshold(gray, thresh, 0, 255, ThresholdTypes.Otsu | ThresholdTypes.BinaryInv);
            Cv2.ImWrite(@"C:\Users\FURKAN\source\repos\Kutuphane\Kutuphane\kitap4.jpg", thresh);
            rectKernel = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(33, 33));
            Cv2.Dilate(thresh, dilation, rectKernel);
            Cv2.ImWrite(@"C:\Users\FURKAN\source\repos\Kutuphane\Kutuphane\kitap5.jpg", dilation);
            Cv2.FindContours(dilation, out contours, out hierarchyIndexes, RetrievalModes.CComp, ContourApproximationModes.ApproxSimple);

            var contourIndex = 0;
            while ((contourIndex >= 0))
            {
                var contour = contours[contourIndex];

                var boundingRect = Cv2.BoundingRect(contour);

                Cv2.Rectangle(s,
                    new OpenCvSharp.Point(boundingRect.X, boundingRect.Y),
                    new OpenCvSharp.Point(boundingRect.X + boundingRect.Width, boundingRect.Y + boundingRect.Height),
                    new Scalar(0, 0, 255),
                    2);
                var roi = new OpenCvSharp.Mat(s, boundingRect);
                contourIndex = hierarchyIndexes[contourIndex].Next;

            }

            Cv2.ImWrite(@"C:\Users\FURKAN\source\repos\Kutuphane\Kutuphane\kitap6.jpg", s);
            var img = s;
            //var img = new OpenCvSharp.Mat("C:\\Users\\FURKAN\\source\\repos\\Kutuphane\\kitap6.jpg");
            var ocr = new TesseractEngine("C:\\Users\\FURKAN\\source\\repos\\Kutuphane\\packages\\Tesseract.3.3.0.\\tessdata", "eng", EngineMode.TesseractAndCube);
            var page = ocr.Process(OpenCvSharp.Extensions.BitmapConverter.ToBitmap(img));

            return page.GetText();
        }

        protected string ISBN_Kontrol()
        {
            string dosya_yolu2 = @"C:\Users\FURKAN\Desktop\kontrol.txt";
            FileStream fs2 = new FileStream(dosya_yolu2, FileMode.Open, FileAccess.Read);
            StreamReader sw2 = new StreamReader(fs2);

            string kitapISBNKontrol = sw2.ReadLine();
            while (kitapISBNKontrol != null)
            {
                kontrol1.Add(kitapISBNKontrol);
                kitapISBNKontrol = sw2.ReadLine();
            }



            string dosya_yolu = @"C:\Users\FURKAN\Desktop\Yaz2.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            Char[] s;
            string ISBN = null;
            string yazi = sw.ReadLine();
            while (yazi != null)
            {
                foreach (string test in kontrol1)
                {
                    if (yazi.Equals(test))
                    {

                        char c = yazi[0];
                        while (yazi != null)
                        {
                            yazi = sw.ReadLine();

                            if (String.IsNullOrWhiteSpace(yazi))
                            {
                                continue;
                            }
                            else
                            {
                                s = yazi.ToCharArray();
                                if (char.IsNumber(s[0]))
                                {
                                    for (int i = 0; i < s.Length; i++)
                                    {
                                        if (!char.IsWhiteSpace(s[i]))
                                        {
                                            if (s[i].Equals('S') || s[i].Equals('r'))
                                            {
                                                s[i] = '5';

                                            }
                                            else if (s[i].Equals('O') || s[i].Equals('o'))
                                            {
                                                s[i] = '0';

                                            }
                                            else if (s[i].Equals('ı') || s[i].Equals('l') || s[i].Equals('I'))
                                            {
                                                s[i] = '1';

                                            }
                                            else if (s[i].Equals('B'))
                                            {
                                                s[i] = '8';

                                            }
                                            ISBN = ISBN + s[i];
                                        }

                                    }

                                    break;

                                }

                            }

                        }

                    }
                    else if (yazi.Contains(test))
                    {
                        int index = 0;

                        String[] kelimeler = yazi.Split(' ');
                        for (int i = 0; i < kelimeler.Length; i++)
                        {
                            if (kelimeler[i].Equals(test))
                            {
                                index = index + kelimeler[i].Length + (i - 1);
                                //                   Label3.Text = index.ToString();
                                break;
                            }
                            index = index + kelimeler[i].Length;
                        }
                        s = yazi.ToCharArray();
                        for (int i = index + 1; i < s.Length; i++)
                        {
                            if (!char.IsWhiteSpace(s[i]))
                            {
                                if (s[i].Equals('S') || s[i].Equals('r'))
                                {
                                    s[i] = '5';

                                }
                                else if (s[i].Equals('O') || s[i].Equals('o'))
                                {
                                    s[i] = '0';

                                }
                                else if (s[i].Equals('ı') || s[i].Equals('l') || s[i].Equals('I'))
                                {
                                    s[i] = '1';

                                }
                                else if (s[i].Equals('B'))
                                {
                                    s[i] = '8';

                                }
                                ISBN = ISBN + s[i];
                            }

                        }




                    }
                }
                yazi = sw.ReadLine();
            }

            sw.Close();
            fs.Close();
            sw2.Close();
            fs2.Close();

            return ISBN;
        }

        protected void btn_teslimEt_Click(object sender, EventArgs e)
        {
            if (Session["Gun"] != null)
            {
                int sayi = Convert.ToInt32(Session["Gun"].ToString());
                gun = System.DateTime.Now.AddDays(sayi);
            }
            else
            {
                gun = System.DateTime.Now;
            }
            Label4.Visible = true;
            ekleISBN = ISBN_Kontrol();
            Label5.Visible = false;
            Label5.Text = ekleISBN;
            SqlCommand komut = new SqlCommand("select * from Tbl_Kitap,Tbl_KitapBilgileri,Tbl_Kullanici where Tbl_Kitap.KitapID=Tbl_KitapBilgileri.KitapID and Tbl_Kullanici.KullaniciID=@p1 and Tbl_KitapBilgileri.KitapISBN =@p2 and Tbl_KitapBilgileri.TeslimEdilmeDurumu=0", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Session["ID"].ToString());
            komut.Parameters.AddWithValue("@p2", Label5.Text.ToString());
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                SqlCommand komut2 = new SqlCommand("update Tbl_KitapBilgileri set TeslimEdilmeDurumu=1", bgl.baglanti());
                komut2.ExecuteNonQuery();
                SqlCommand komut3 = new SqlCommand("update Tbl_Kitap set TeslimTarihi=@u1", bgl.baglanti());
                komut3.Parameters.AddWithValue("@u1", gun);
                komut3.ExecuteNonQuery();
                Label4.Text = "Kitap teslim edilmiştir.";
            }
            else
            {
                Label4.Text = "Eklediğiniz ISBN ile üzerinizdeki kitap bilgileri uyuşmamaktadır.";
            }

            bgl.baglanti().Close();
        }

        protected void btn_yukle_Click(object sender, EventArgs e)
        {
            Label3.Visible = true;
            Image2.Visible = true;
            btn_teslimEt.Visible = true;
            FileUpload1.SaveAs(Server.MapPath(FileUpload1.FileName));
            Image2.ImageUrl = FileUpload1.FileName;
            StreamWriter Yaz = new StreamWriter("C:\\Users\\FURKAN\\Desktop\\Yaz2.txt");
            Yaz.WriteLine(Donusum(FileUpload1.FileName));
            try
            {
                Thread.Sleep(1000);
            }
            catch (Exception i)
            {
                // TODO: handle exception
            }
            Yaz.Close();
            ekleISBN = ISBN_Kontrol();
            Label3.Text = "ISBN:" + ekleISBN;
        }
    }
}