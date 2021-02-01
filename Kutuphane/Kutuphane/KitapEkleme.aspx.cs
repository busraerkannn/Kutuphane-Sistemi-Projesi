using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Threading;
using System.Data.SqlClient;
namespace Kutuphane
{
    public partial class KitapEkleme : System.Web.UI.Page
    {
        List<string> kontrol1 = new List<string>();
        public int gun;
        string ekleISBN;
        protected string Donusum(String dosyaYolu)
        {
            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchyIndexes;
            OpenCvSharp.Mat s = Cv2.ImRead(@"C:\Users\FURKAN\Desktop\kitap\"+dosyaYolu);
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
            while(kitapISBNKontrol!=null)
            {
                kontrol1.Add(kitapISBNKontrol);
                kitapISBNKontrol = sw2.ReadLine();
            }

           

            string dosya_yolu = @"C:\Users\FURKAN\Desktop\Yaz.txt";
            FileStream fs = new FileStream(dosya_yolu, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);
            Char[] s;
            string ISBN=null;
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
                                index = index + kelimeler[i].Length+(i-1);
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


        protected void Page_Load(object sender, EventArgs e)
        {
            Image2.Visible = false;
            btn_kaydet.Visible = false;
            Label1.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            Image2.Visible = true;
            btn_kaydet.Visible = true;
            FileUpload1.SaveAs(Server.MapPath( FileUpload1.FileName));
            
            Image2.ImageUrl = FileUpload1.FileName;
            
            StreamWriter Yaz = new StreamWriter("C:\\Users\\FURKAN\\Desktop\\Yaz.txt");
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
            Label1.Text ="ISBN:"+ ekleISBN;

            if (Session["Gun"]!=null)
            {
                Label1.Text = Session["Gun"].ToString();
            }

        }

        protected void btn_kaydet_Click(object sender, EventArgs e)
        {
            btn_kaydet.Visible = true;
            ekleISBN = ISBN_Kontrol();
            Label1.Visible = true;
            
            SQLBaglanti bgl = new SQLBaglanti();
            SqlCommand komut = new SqlCommand("insert into Tbl_KitapBilgileri (KitapAd,KitapISBN) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txt_kitapAdi.Text);
            komut.Parameters.AddWithValue("@p2",ekleISBN);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
    }
}