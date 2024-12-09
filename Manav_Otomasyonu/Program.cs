using Manav_Otomasyonu;
using System.Xml;

namespace Manav_Otomasyonu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(" 1 -Hal");
                Console.WriteLine(" 2-Manav");
                string secim = Console.ReadLine();
                if (secim == "1")
                { MerhabaHal(); }
                else if (secim == "2")
                {
                    MerhabaManav();
                }
                else { Console.WriteLine("Hata lı Tuşlama Yaptınız!"); }
            }
            static void MerhabaHal()
            {
                Console.WriteLine("Sebze Meyve Haline Hoş Geldiniz");
                while (true)
                {
                    Console.WriteLine("Sebze Mi Almak İstersiniz Meyve Mi? S  / M ?");
                    string manavSecim = Console.ReadLine();
                    if (manavSecim.ToUpper() == "S")
                    {
                        SebzeListele();
                        try
                        {
                            int sebzeSecim = Convert.ToInt32(Console.ReadLine());
                            if (sebzeSecim > 0 && sebzeSecim <= SebzeListeHal.sebzeListeHal.Count)
                            {
                                Console.WriteLine("Kaç Kilo Almak İstersiniz?");
                                double kiloSecimSebze = Convert.ToDouble(Console.ReadLine());
                                string secilenSebze = SebzeListeHal.sebzeListeHal[sebzeSecim - 1].ToString();
                                string alinanSebze = $"{secilenSebze}-";
                                bool urun = false;
                                foreach (string sebze in ManavUrunlerListe.manavAlinanlarSebze)
                                {
                                    if (sebze.StartsWith(alinanSebze))
                                    {
                                        var urunBilgileri = sebze.Split("-");
                                        double mevcutKilo = Convert.ToDouble(urunBilgileri[1].Replace(" kg", "").Trim());// Trim metodu istenmeyen boşlukları siler
                                        mevcutKilo += kiloSecimSebze;
                                        ManavUrunlerListe.manavAlinanlarSebze[ManavUrunlerListe.manavAlinanlarSebze.IndexOf(sebze)] = $"{secilenSebze}-{mevcutKilo} kg"; // Güncelle
                                        urun = true;
                                        break;
                                    }
                                }
                                if (!urun)
                                {
                                    ManavUrunlerListe.manavAlinanlarSebze.Add($"{secilenSebze}-{kiloSecimSebze} kg");
                                }

                                Console.WriteLine("Seçilen Ürün Listeye Başarıyla Eklendi");
                                Console.WriteLine("Başka Ürün Eklemek İçin 1 'e Çıkış Yapmak İçin 9 a Basınız.");
                                int urunsecenek = Convert.ToInt32(Console.ReadLine());
                                if (urunsecenek == 1)
                                { continue; }

                                else if (urunsecenek == 9)
                                {
                                    Console.WriteLine(" Aldığınız Ürünlerin Odeme Kasada Yapabilirsiniz.Manav Bölümüne Geçiliyor...");
                                    Thread.Sleep(2000);
                                    MerhabaManav();
                                }
                                else
                                { Console.WriteLine("Hatalı Tuşlama Yaptınız."); }

                            }
                            else
                            {
                                Console.WriteLine("Hatalı Seçim Yaptınız!");
                            }

                        }
                        catch (FormatException)
                        { Console.WriteLine("Lütfen Rakam Tuşlayınız"); }
                    }
                    else if (manavSecim.ToUpper() == "M")
                    {
                        MeyveListele();
                        try
                        {
                            int meyveSecim = Convert.ToInt32(Console.ReadLine());
                            if (meyveSecim > 0 && meyveSecim <= MeyveListeHal.manavAlinanlarMeyvel.Count)
                            {
                                Console.WriteLine("    Kaç Kilo Almak İstersiniz?");
                                double kiloSecimMeyve = Convert.ToDouble(Console.ReadLine());
                                string secilenMeyve = MeyveListeHal.manavAlinanlarMeyvel[meyveSecim - 1].ToString();
                                string alinanMeyve = $"{secilenMeyve}-";
                                bool urunBulundu = false;
                                foreach (string meyve in ManavUrunlerListe.manavAlinanlarMeyve)
                                {
                                    if (meyve.StartsWith(alinanMeyve))
                                    {
                                        var urunBilgileri = meyve.Split("-");
                                        double mevcutKilo = Convert.ToDouble(urunBilgileri[1].Replace(" kg", "").Trim());// trım sılıcek 
                                        mevcutKilo += kiloSecimMeyve;
                                        ManavUrunlerListe.manavAlinanlarMeyve[ManavUrunlerListe.manavAlinanlarMeyve.IndexOf(meyve)] = $"{secilenMeyve}-{mevcutKilo} kg"; 
                                        urunBulundu = true;
                                        break;
                                    }
                                }
                                if (!urunBulundu)
                                {
                                    ManavUrunlerListe.manavAlinanlarMeyve.Add($"{secilenMeyve}-{kiloSecimMeyve} kg");
                                }

                                Console.WriteLine(" Seçilen Ürün Listeye Başarıyla Eklendi");
                                Console.WriteLine("Başka Ürün Eklemek İçin 1 'e Çıkış  Yapmak  İçin  9 'a Basınız.");
                                int urunEkleme = Convert.ToInt32(Console.ReadLine());
                                if (urunEkleme == 1)
                                { continue; }

                                else if (urunEkleme == 9)
                                {
                                    Console.WriteLine("Aldığınız Ürünlerin Ödemesini Kasada Yapabilirsiniz.Manav Bölümüne Geçiliyor...");
                                    Thread.Sleep(2000);
                                    MerhabaManav();
                                }
                                else
                                { Console.WriteLine("Hatalı Tuşlama Yaptınız."); }

                            }
                            else
                            {
                                Console.WriteLine("Hatalı Seçim Yaptınız!");
                            }

                        }
                        catch (FormatException)
                        { Console.WriteLine("Lütfen Rakam Tuşlayınız"); }
                    }
                    else
                    {
                        Console.WriteLine("Hat alı Tuşlama Yaptınız. S veya M Seçimi Yapınız.");
                    }
                }
            }
            static void SebzeListele()
            {

                Console.WriteLine("Almak İstediğiniz Sebzeyi Seçin");
                for (int i = 0; i < SebzeListeHal.sebzeListeHal.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{SebzeListeHal.sebzeListeHal[i]}");
                }

            }
            static void MeyveListele()
            {

                Console.WriteLine("Almak İstediğiniz Meyveyi Seçin");
                for (int i = 0; i < MeyveListeHal.manavAlinanlarMeyvel.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{MeyveListeHal.manavAlinanlarMeyvel[i]}");
                }
            }
            static void MerhabaManav()
            {
                Console.WriteLine("Hoş Geldiniz");
                while (true)
                {
                    Console.WriteLine("Sebze Mi Almak İstersiniz Meyve Mi? S/M ?");
                    string manavSecim = Console.ReadLine();
                    if (manavSecim.ToUpper() == "S")
                    {
                        ManavUrunleriSebzeListele();
                        try
                        {
                            int sebzeSecim = Convert.ToInt32(Console.ReadLine());
                            if (sebzeSecim > 0 && sebzeSecim <= ManavUrunlerListe.manavAlinanlarSebze.Count)
                            {
                                Console.WriteLine("Kaç Kilo Almak İsters iniz?");
                                double kiloSecimSebze = Convert.ToDouble(Console.ReadLine());
                                var secilenUrun = ManavUrunlerListe.manavAlinanlarSebze[sebzeSecim - 1].ToString();
                                var urunBilgileri = secilenUrun.Split('-');
                                string urunAdi = urunBilgileri[0];
                                double mevcutKiloSebze = Convert.ToDouble(urunBilgileri[1].Replace(" kg", ""));
                                if (kiloSecimSebze <= mevcutKiloSebze)
                                {
                                    mevcutKiloSebze -= kiloSecimSebze;
                                    if (mevcutKiloSebze > 0)
                                    {
                                        ManavUrunlerListe.manavAlinanlarSebze[sebzeSecim - 1] = $"{urunAdi}-{mevcutKiloSebze} kg"; 
                                    }
                                    else
                                    {
                                        ManavUrunlerListe.manavAlinanlarSebze.RemoveAt(sebzeSecim - 1);     
                                    }
                                    Console.WriteLine($"{kiloSecimSebze} kg {urunAdi} alındı.");
                                }
                                else
                                {
                                    Console.WriteLine($"Şuan Elimizde Ürün {mevcutKiloSebze} Kilo Var. Lütfen İstediğiniz Kiloyu Düşürünüz.");

                                }
                            }
                            else
                            { Console.WriteLine("Hatalı Tuşla a Yaptınız"); }
                        }
                        catch (FormatException) { Console.WriteLine("Lütfen Rakam Tuşlayınız!"); }
                    }

                    else if (manavSecim.ToUpper() == "M")
                    {
                        ManavUrunleriMeyveListele();
                        try
                        {
                            int meyveSecim = Convert.ToInt32(Console.ReadLine());
                            if (meyveSecim > 0 && meyveSecim <= ManavUrunlerListe.manavAlinanlarMeyve.Count)
                            {
                                Console.WriteLine("Kaç Kilo Almak İstersiniz?");
                                double kiloSecimMeyve = Convert.ToDouble(Console.ReadLine());
                                var secilenUrun = ManavUrunlerListe.manavAlinanlarMeyve[meyveSecim - 1].ToString();
                                var urunlerbılgısı = secilenUrun.Split('-');
                                string urunAdi = urunlerbılgısı[0];
                                double mevcutKiloMeyve = Convert.ToDouble(urunlerbılgısı[1].Replace(" kg", ""));
                                if (kiloSecimMeyve <= mevcutKiloMeyve)
                                {
                                    mevcutKiloMeyve -= kiloSecimMeyve;
                                    if (mevcutKiloMeyve > 0)
                                    {
                                        ManavUrunlerListe.manavAlinanlarSebze[meyveSecim - 1] = $"{urunAdi}-{mevcutKiloMeyve} kg"; 
                                    }
                                    else
                                    {
                                        ManavUrunlerListe.manavAlinanlarMeyve.RemoveAt(meyveSecim - 1); 
                                    }
                                    Console.WriteLine($"{kiloSecimMeyve} kg {urunAdi} alındı.");
                                }
                                else
                                {
                                    Console.WriteLine($"Şuan Elimiz e Ürün {mevcutKiloMeyve} Kilo Var.");

                                }
                            }
                            else
                            { Console.WriteLine("Hatalı Tuşlama Yaptınız"); }
                        }
                        catch (FormatException) { Console.WriteLine("Lütfen Rakam Tuşlayınız!"); }
                    }

                    else
                    {  
                        Console.WriteLine("Hatalı Tuşlama Ya tınız. S veya M Seçimi Yapınız.");
                    }

                }
            }

            static void ManavUrunleriSebzeListele()
            {

                Console.WriteLine("Almak İstediği niz Sebzeyi Seçin");
                for (int i = 0; i < ManavUrunlerListe.manavAlinanlarSebze.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{ManavUrunlerListe.manavAlinanlarSebze[i]}");

                }

            }
            static void ManavUrunleriMeyveListele()
            {
                Console.WriteLine("Almak İstediğiniz Meyveyi Seçin");
                for (int i = 0; i < ManavUrunlerListe.manavAlinanlarMeyve.Count; i++)
                {
                    Console.WriteLine($"{i + 1}-{ManavUrunlerListe.manavAlinanlarMeyve[i]}");

                }
            }














        }
















    }
}




