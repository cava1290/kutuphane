using System;
using System.Collections.Generic;

class Kitap
{
    public string Ad { get; set; }
    public string Yazar { get; set; }
    public string ISBN { get; set; }
    public int YayınYılı { get; set; }

    public Kitap(string ad, string yazar, string isbn, int yayınYılı)
    {
        Ad = ad;
        Yazar = yazar;
        ISBN = isbn;
        YayınYılı = yayınYılı;
    }

    public override string ToString()
    {
        return $"Kitap Adı: {Ad}, Yazar: {Yazar}, ISBN: {ISBN}, Yayın Yılı: {YayınYılı}";
    }
}

class Kütüphane
{
    private List<Kitap> kitaplar = new List<Kitap>();

    public void KitapEkle(Kitap kitap)
    {
        kitaplar.Add(kitap);
        Console.WriteLine("Kitap başarıyla eklendi!");
    }

    public void KitaplarıListele()
    {
        if (kitaplar.Count == 0)
        {
            Console.WriteLine("Kütüphanede hiç kitap yok.");
        }
        else
        {
            foreach (var kitap in kitaplar)
            {
                Console.WriteLine(kitap);
            }
        }
    }

    public void KitapAra(string kitapAdi)
    {
        var bulunanKitap = kitaplar.Find(k => k.Ad.ToLower() == kitapAdi.ToLower());
        if (bulunanKitap != null)
        {
            Console.WriteLine(bulunanKitap);
        }
        else
        {
            Console.WriteLine("Aradığınız kitap bulunamadı.");
        }
    }

    public void KitapSil(string isbn)
    {
        var kitap = kitaplar.Find(k => k.ISBN == isbn);
        if (kitap != null)
        {
            kitaplar.Remove(kitap);
            Console.WriteLine("Kitap başarıyla silindi.");
        }
        else
        {
            Console.WriteLine("Silinecek kitap bulunamadı.");
        }
    }
}

class Program
{
    static void Main()
    {
        Kütüphane kütüphane = new Kütüphane();
        while (true)
        {
            Console.WriteLine("\n--- Kütüphane Yönetim Sistemi ---");
            Console.WriteLine("1. Kitap Ekle");
            Console.WriteLine("2. Kitapları Listele");
            Console.WriteLine("3. Kitap Ara");
            Console.WriteLine("4. Kitap Sil");
            Console.WriteLine("5. Çıkış");
            Console.Write("Seçiminizi yapın: ");
            string seçim = Console.ReadLine();

            switch (seçim)
            {
                case "1":
                    Console.Write("Kitap Adı: ");
                    string ad = Console.ReadLine();
                    Console.Write("Yazar Adı: ");
                    string yazar = Console.ReadLine();
                    Console.Write("ISBN: ");
                    string isbn = Console.ReadLine();
                    Console.Write("Yayın Yılı: ");
                    int yayınYılı = int.Parse(Console.ReadLine());
                    Kitap yeniKitap = new Kitap(ad, yazar, isbn, yayınYılı);
                    kütüphane.KitapEkle(yeniKitap);
                    break;
                case "2":
                    kütüphane.KitaplarıListele();
                    break;
                case "3":
                    Console.Write("Aramak istediğiniz kitap adını girin: ");
                    string arananKitap = Console.ReadLine();
                    kütüphane.KitapAra(arananKitap);
                    break;
                case "4":
                    Console.Write("Silmek istediğiniz kitabın ISBN numarasını girin: ");
                    string silinecekISBN = Console.ReadLine();
                    kütüphane.KitapSil(silinecekISBN);
                    break;
                case "5":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim! Tekrar deneyin.");
                    break;
            }
        }
    }
}
