using System.Reflection.Emit;
using System.Runtime.Serialization;

namespace ÖdevHakanBozurt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Kaç Öğrenci Kaydetmek İstiyorsunuz:");
            int ogrenciSayisi ;
            do
            {
                try
                {
                    ogrenciSayisi = int.Parse(Console.ReadLine());
                    if (ogrenciSayisi <= 0)
                    {
                        Console.WriteLine("Hatalı Giriş Yaptınız. Lütfen 0'dan Büyük Sayı Giriniz.");
                        ogrenciSayisi = 0;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hatalı Giriş Yaptınız. Lütfen Sayı Giriniz.");
                    ogrenciSayisi = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hatalı Giriş Yaptınız.Bir Sayı Giriniz.");
                    ogrenciSayisi = 0;
                }
            } while (ogrenciSayisi == 0);

            string [,] ogrenciler = new string [ogrenciSayisi,7];


            for (int i = 0; i < ogrenciSayisi; i++)
            {
                do
                {
                    try
                    {
                        Console.Write("Öğrenci Numarası: ");
                        ogrenciler[i, 0] = Console.ReadLine();
                        ogrenciler[i, 0] = int.Parse(ogrenciler[i, 0]).ToString();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hatalı Giriş Yaptınız. Lütfen Sayı Giriniz.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hatalı Giriş Yaptınız.Bir Sayı Giriniz.");
                    }
                } while (int.TryParse(ogrenciler[i, 0], out _) == false);
                
                Console.Write("ADINIZ:");
                ogrenciler[i, 1] = Console.ReadLine().ToUpper().Trim();
                Console.Write("SOYADINIZ:");
                ogrenciler[i, 2] = Console.ReadLine().ToUpper().Trim();
                do
                {
                    try
                    {
                        Console.Write("VİZE NOTUNUZ:");
                        ogrenciler[i, 3] = Console.ReadLine();
                        ogrenciler[i, 3] = double.Parse(ogrenciler[i, 3]).ToString();
                        if (double.Parse(ogrenciler[i, 3]) < 0 || double.Parse(ogrenciler[i, 3]) > 100)
                        {
                            Console.WriteLine("Hatalı Giriş Yaptınız. Lütfen 0-100 Arasında Bir Sayı Giriniz.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hatalı Giriş Yaptınız. Lütfen Sayı Giriniz.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hatalı Giriş Yaptınız.Bir Sayı Giriniz.");
                    }
                } while (double.TryParse(ogrenciler[i, 3], out _) == false);
                do
                {
                    try
                    {
                        Console.Write("FİNAL NOTUNUZ:");
                        ogrenciler[i, 4] = Console.ReadLine();
                        ogrenciler[i, 4] = double.Parse(ogrenciler[i, 4]).ToString();
                        if (double.Parse(ogrenciler[i, 4]) < 0 || double.Parse(ogrenciler[i, 4]) > 100)
                        {
                            Console.WriteLine("Hatalı Giriş Yaptınız. Lütfen 0-100 Arasında Bir Sayı Giriniz.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Hatalı Giriş Yaptınız. Lütfen Sayı Giriniz.");
                    }
                    
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hatalı Giriş Yaptınız.Bir Sayı Giriniz.");
                    }
                } while (double.TryParse(ogrenciler[i, 4], out _) == false );


                ogrenciler[i, 5] = (double.Parse(ogrenciler[i, 3]) * 0.4 + double.Parse(ogrenciler[i, 4]) * 0.6).ToString("F2");
                double ortalama = double.Parse(ogrenciler[i, 5]);
                switch (ortalama)
                {
                    case double n when (n >= 85):
                        ogrenciler[i, 6] = ("AA");
                        break;
                    case double n when (n >= 75):
                        ogrenciler[i, 6]= ("BA");
                        break;
                    case double n when (n >= 60):
                        ogrenciler[i, 6] = ("BB");
                        break;
                    case double n when (n >= 50):
                        ogrenciler[i, 6] = ("CB");
                        break;
                    case double n when (n >= 40):
                        ogrenciler[i, 6] = ("CC");
                        break;
                    case double n when (n >= 30):
                        ogrenciler[i, 6] = ("DC");
                        break;
                    case double n when (n >= 20):
                        ogrenciler[i, 6] = ("DD");
                        break;
                    case double n when (n >= 10):
                        ogrenciler[i, 6] = ("FD");
                        break;
                    default:
                        ogrenciler[i, 6] = ("FF");
                        break;
                }
            


            }
            Console.Write("{0,-11} {1,-10} {2,-10} {3,-5} {4,-6} {5,-9} {6,-9}", "Numara", "Ad", "Soyad", "Vize", "Final", "Ortalama", "Harf Notu");
            Console.WriteLine();
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                Console.WriteLine("{0,-11} {1,-10} {2,-10} {3,-5} {4,-6} {5,-9} {6,-9}", ogrenciler[i, 0], ogrenciler[i, 1], ogrenciler[i, 2], ogrenciler[i, 3], ogrenciler[i, 4], ogrenciler[i, 5], ogrenciler[i, 6]);
            }
            double toplamOrtalama = 0;
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                toplamOrtalama += double.Parse(ogrenciler[i, 5]);
            }
            double sinifOrtalamasi = toplamOrtalama / ogrenciSayisi;
            Console.WriteLine("Sınıf Ortalaması: " + sinifOrtalamasi.ToString("F2"));
            double enbuyuk = 0;
            for (int i = 0;i < ogrenciSayisi; i++)
            {
                if (double.Parse(ogrenciler[i, 5]) > enbuyuk)
                    enbuyuk = double.Parse(ogrenciler[i, 5]);
            }
            Console.WriteLine("En Yüksek Not: " + enbuyuk);
            double enkucuk = 100;
            for (int i = 0; i < ogrenciSayisi; i++)
            {
                if (double.Parse(ogrenciler[i, 5]) < enkucuk)
                    enkucuk = double.Parse(ogrenciler[i, 5]);
            }
            Console.WriteLine("En Düşük Not: " + enkucuk);

            Console.ReadKey();
        }   
    }
}
