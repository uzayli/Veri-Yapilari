namespace VeriYapilari
{
    /// <summary>
    /// Bu Sınıf Dizilerden Gelişi Güzel Elemanı almak için oluşturulmuştur.
    /// </summary>
    /// <typeparam name="Tur"></typeparam>
    public class GelisiGuzelYapi<Tur>
    {
        #region Degişkenler
        System.Collections.Generic.HashSet<Tur> Veriler = new System.Collections.Generic.HashSet<Tur>();/*
        Verilerin tutulduğu Değişken
         */

        public int Sayi { get {return Veriler.Count; ; } private set {; } }
        //Kaç tane değer olduğunu döndürmeye yarayan değişken
        #endregion

        #region Kurucu Metodlar
        //Boş kurucu Metod
        public GelisiGuzelYapi()
        {
        }
        //Bir dizi veriyi alıp değişkenlere atan kurucu metod
        public GelisiGuzelYapi(Tur[] Degerler)
        {
            for (int i = 0; i < Degerler.Length; i++)
            {
                Veriler.Add(Degerler[i]);
            }
        }
        #endregion

        #region Veri Ekleme Metodları
        //Verileri Eklemeye Yarayan Fonksiyonlar
        public void Ekle(Tur Deger)
        {
            Veriler.Add(Deger);
        }

        public void Ekle(Tur[] Degerler)
        {
            for (int i = 0; i < Degerler.Length; i++)
            {
                Veriler.Add(Degerler[i]);
            }
        }

        #endregion

        #region Silerek Bir değer Getirme Metodu
        //Gelişi güzel bir elemanı silerek onu gönderen fonksiyon
        public Tur Getir()
        {
            System.Random ran = new System.Random();
            //Gelişi güzel sayı almak için random sınıfını kullanıyoruz
            int gonderilecek = ran.Next(0,Veriler.Count-1);
            //Verilerden birini almak istediğimizden Verileri tamamını alabileceğimiz şekilde
            //gelişi güzel bir sayı aldık 
            System.Collections.Generic.HashSet<Tur>.Enumerator eVeriler = Veriler.GetEnumerator();
            //Verileri sırayla kullanabilmek için enumerator'e aktardık
            eVeriler.MoveNext();//eVeriler değişkenin sonraki değerine gittik(0.eleman)
            for (int i = 0; i <= gonderilecek; i++) /*Gonderilecek sayı kadar sırayla gidiyoruz çünkü dizi olmadığı için 
                doğrudan gidemiyoruz*/
            {
                if(i==gonderilecek) /*Eğer gönderilecek sayı i'ye eşitse istediğimiz yere 
                    Gelmişiz demektir. buradan veriyi silip geri göndereceğiz*/
                {
                    Veriler.Remove(eVeriler.Current);//eVeriler'in şuandaki elemanı veriler'den siliyoruz
                    return eVeriler.Current;//Sildiğimiz değeri gönderiyoruz
                }
                eVeriler.MoveNext();//eVeriler'in sonraki değerine gitmesini sağlıyoruz
            }
            return default(Tur);
        }

        #endregion

        #region Toplu Silmeden Getirme
        //Önceki sırayı korumadan Karışık bir şekilde değerleri gönderen fonksiyon
        public Tur[] KarisikGetir()
        {
            /*Getir fonksiyonuna sadece Veriler'in değeri
            KadarDÖngüye oluşturulmasıyla tüm değerleri silmeden gönderen
            fonksiyon  
            */
            System.Random ran = new System.Random();
            Tur[] Karisik = new Tur[Veriler.Count];
            for (int i = 0; i < Karisik.Length; i++)
            {
                int gonderilecek = ran.Next(0, Veriler.Count - 1);
                System.Collections.Generic.HashSet<Tur>.Enumerator eVeriler = Veriler.GetEnumerator();
                eVeriler.MoveNext();
                for (int j = 0; j <= gonderilecek; j++)
                {
                    if (j == gonderilecek)
                    {
                        Veriler.Remove(eVeriler.Current);
                        Karisik[i] = eVeriler.Current;
                    }
                    else
                        eVeriler.MoveNext();
                }
            }
            /*Değerleri kaybetmemek için
             * Önceki tüm değerleri yeniden Ekliyoruz
             */
            Ekle(Karisik);
            return Karisik;
        }

        //Elemanın içindeki verileri sırayla getiren fonksiyon
        public Tur[] SiraylaGetir()
        {
            Tur[] sirali = new Tur[Veriler.Count];
            System.Collections.Generic.HashSet<Tur>.Enumerator eVeriler = Veriler.GetEnumerator();
            eVeriler.MoveNext();
            for (int i = 0; i < Veriler.Count; i++)
            {
                sirali[i] = eVeriler.Current;
                eVeriler.MoveNext();
            }
            return sirali;
        }

        //Elemanların önceki yerlerini değiştirmeden dağıtılmış şekilde verileri gönderen fonksiyon
        public Tur[] KarisikGetirOncekiSiralamayiKoru()
        {
            Tur[] sirali = SiraylaGetir();
            Tur[] Karisik = KarisikGetir();

            //Karisik fonksiyonun oluşturduğu yeni verileri temizleyerek 
            //Önceki değerleri sirali bir şekilde Veriler'e yeniden ekliyoruz 
            Temizle();
            Ekle(sirali);
            return Karisik;
        }
        #endregion

        #region Diğer Yararlı Metodlar
        public void Temizle()//Verilerde ki tüm elemanları silmeye yarayan fonksiyon
        {
            this.Veriler.Clear();
        }
        #endregion
    }
}
