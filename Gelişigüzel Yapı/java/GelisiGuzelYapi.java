/// <summary>
    /// Bu Sınıf Dizilerden Gelişi Güzel Elemanı almak için oluşturulmuştur.
    /// </summary>
package VeriYapilari;

import java.util.Arrays;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.Random;

/**
 *
 * @author uzayli
 * @param <Tur>
 */
 public class GelisiGuzelYapi<Tur>
    {
     LinkedList Veriler;
        /*Verilerin tutulduğu Değişken
         */
       public int Sayi()
       {
           return Veriler.size();
       }
        //Kaç tane değer olduğunu döndürmeye yarayan değişken 
       
       //<editor-fold defaultstate="collapsed" desc="Kurucu Metodlar">
       //Boş kurucu Metod
       public GelisiGuzelYapi()
       {
           Veriler= new LinkedList<Tur>();
       }
       //Bir dizi veriyi alıp değişkenlere atan kurucu metod
       public GelisiGuzelYapi(Tur[] Degerler)
       {
           Veriler= new LinkedList<Tur>();
           Veriler.addAll(Arrays.asList(Degerler));
       }
//</editor-fold>
       
       //<editor-fold defaultstate="collapsed" desc="Veri Ekleme Metodları">
       //Verileri Eklemeye Yarayan Fonksiyonlar
       public void Ekle(Tur Deger)
       {
           Veriler.add(Deger);
       }
       
       public void Ekle(Tur[] Degerler)
       {
           Veriler.addAll(Arrays.asList(Degerler));
       }
//</editor-fold>


       //<editor-fold defaultstate="collapsed" desc="Silerek Bir değer Getirme Metodu">
       
       //Gelişi güzel bir elemanı silerek onu gönderen fonksiyon
       public Tur Getir()
       {
           Random ran = new Random();
           //Gelişi güzel sayı almak için random sınıfını kullanıyoruz
            int gonderilecek=0;
               if(Veriler.size()!=1)
                 gonderilecek = ran.nextInt(Veriler.size());
           //Verilerden birini almak istediğimizden Verileri tamamını alabileceğimiz şekilde
           //gelişi güzel bir sayı aldık
           Tur veri=(Tur) Veriler.get(gonderilecek);
           Veriler.remove(gonderilecek);
           return veri;
       }
//</editor-fold>

       //<editor-fold defaultstate="collapsed" desc="Toplu Silmeden Getirme">
       //Önceki sırayı korumadan Karışık bir şekilde değerleri gönderen fonksiyon
       public Tur[] KarisikGetir()
       {
           /*Getir fonksiyonuna sadece Veriler'in değeri
           KadarDÖngüye oluşturulmasıyla tüm değerleri silmeden gönderen
           fonksiyon
           */
           Random ran = new Random();
           Tur[] Karisik;
           Karisik = (Tur[])new Object[Veriler.size()];
           LinkedList<Tur> yeni=new LinkedList<>();
           for (int i = 0; i < Karisik.length; i++)
           {
               int gonderilecek=0;
               if(Veriler.size()!=1)
                 gonderilecek = ran.nextInt(Veriler.size());
               Karisik[i]=(Tur) Veriler.get(gonderilecek);
               yeni.add(Karisik[i]);
            /*Değerleri kaybetmemek için
                * Önceki tüm değerleri yeniden Ekliyoruz
            */
               Veriler.remove(gonderilecek);
           }
           Veriler=yeni;
           return Karisik;
       }
       
       //Elemanın içindeki verileri sırayla getiren fonksiyon
       public Tur[] SiraylaGetir()
       {
           Tur[] sirali = (Tur[])new Object[Veriler.size()];
           Iterator eVeriler = Veriler.iterator();
           for (int i = 0; i < Veriler.size(); i++)
           {
               sirali[i] = (Tur) eVeriler.next();
           }
           return sirali;
       }
       
       //Elemanların önceki yerlerini değiştirmeden dağıtılmış şekilde verileri gönderen fonksiyon
       public Tur[] KarisikGetirOncekiSiralamayiKoru()
       {
            /*Getir fonksiyonuna sadece Veriler'in değeri
           KadarDÖngüye oluşturulmasıyla tüm değerleri silmeden gönderen
           fonksiyon
           */
           Random ran = new Random();
           Tur[] Karisik;
           Karisik = (Tur[])new Object[Veriler.size()];
           for (int i = 0; i < Karisik.length; i++)
           {
               int gonderilecek=0;
               if(Veriler.size()!=1)
                 gonderilecek = ran.nextInt(Veriler.size());
               Karisik[i]=(Tur) Veriler.get(gonderilecek);
           }
           return Karisik;
       }
//</editor-fold>

//<editor-fold defaultstate="collapsed" desc="Yararlı Metodlar">
       public void Temizle()//Verilerde ki tüm elemanları silmeye yarayan fonksiyon
       {
           this.Veriler.removeAll(Veriler);
       }
//</editor-fold>
    }