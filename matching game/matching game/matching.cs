using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace matching_game
{
    internal class matching
    {
        public int boyut;       // tablo boyutlarını belirtmek için
        public string mod;      // oyun modunu seçmek için
        private string dosya;   //açılacak skor tablosu için
        public int skorsira;     // açılacak dosyayı belirtmek için (en iyi süreler)
        private int eslesen=0;
        public bool finish {    
            get
            {
                if (eslesen == (boyut * boyut / 2))
                    return true;
                else
                    return false;
            } 
        }  //tüm kartlar eşleştiğinde süreyi durdurmak için

        List<string> harfler = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "X", "V", "Y", "Z", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        private Random rnd = new Random();

        private Button ilksecilen; 
        private Button ikincisecilen;

        private List<string> secilenharfler = new List<string>();   //harfler listesinden random alınan harfleri tutmak için
        private List<string> karisikharfler = new List<string>();   //random bir şekilde harfleri dağıtmak için

        public List<Button> kartlar = new List<Button>();
        private List<int> skor_ = new List<int>(); //en iyi skorlar için kullanıcı süresini karşılaştırmak için

        public matching(int boyut,string mod)
        {
            this.boyut = boyut;
            this.mod = mod;

            if (mod.Equals("Kolay Mod") && boyut == 4)
                skorsira = 0;
            else if (mod.Equals("Normal Mod") && boyut == 4)
                skorsira = 1;
            else if (mod.Equals("Zor Mod") && boyut == 4)
                skorsira = 2;
            else if (mod.Equals("Kolay Mod") && boyut == 6)
                skorsira = 3;
            else if (mod.Equals("Normal Mod") && boyut == 6)
                skorsira = 4;
            else if (mod.Equals("Zor Mod") && boyut == 6)
                skorsira = 5;
            else if (mod.Equals("Kolay Mod") && boyut == 8)
                skorsira = 6;
            else if (mod.Equals("Normal Mod") && boyut == 8)
                skorsira = 7;
            else
                skorsira = 8;

            dosya = "C:\\Users\\CASPER\\source\\repos\\matching game\\skor.txt";
        }   

        public void rastgelesec()
        {
            List<int> secilmis = new List<int>();
            int basla = 0;
            bool kontrol;

            while (basla < (boyut * boyut) / 2)
            {
                kontrol = true;
                int sec = rnd.Next(0, harfler.Count);

                for (int i = 0; i < secilmis.Count; i++)
                {
                    if (secilmis[i] == sec)
                    {
                        kontrol = false;
                        break;
                    }
                }
                if (kontrol)
                {
                    secilenharfler.Add(harfler[sec]);
                    secilenharfler.Add(harfler[sec]);
                    secilmis.Add(sec);
                    basla++;
                }

            }
        }
        public void kartlarikaristir()
        {

            for (int i = 0; i < boyut * boyut; i++)
            {
                int a = rnd.Next(0, secilenharfler.Count);
                karisikharfler.Add(secilenharfler[a]);
                secilenharfler.RemoveAt(a);
            }
        }   
        public void btnkolay_Click(object sender, EventArgs e)
        {
            if (ilksecilen == null)
            {
                ilksecilen = sender as Button;
                ilksecilen.Text = karisikharfler[Convert.ToInt32(ilksecilen.Name.Substring(3))];
            }
            else
            {
                if (kartlar.IndexOf(ilksecilen) == kartlar.IndexOf(sender as Button))
                {
                    MessageBox.Show("aynı kutucuk seçildi.");
                    ilksecilen.Text = "?";
                    ilksecilen = null;
                }
                else
                {
                    ikincisecilen = sender as Button;
                    ikincisecilen.Text = karisikharfler[Convert.ToInt32(ikincisecilen.Name.Substring(3))];
                    ikincisecilen.Refresh();



                    if (karisikharfler[Convert.ToInt32(ilksecilen.Name.Substring(3))] == karisikharfler[Convert.ToInt32(ikincisecilen.Name.Substring(3))])
                    {
                        ilksecilen.Enabled = false;
                        ikincisecilen.Enabled = false;
                        ilksecilen = null;
                        ikincisecilen = null;
                        eslesen++;
                        if (eslesen == (boyut * boyut / 2))
                            MessageBox.Show("oyun tamamlandı.");
                        
                    }
                    
                    else
                    {
                        Thread.Sleep(1000);

                        ilksecilen.Text = "?";
                        ikincisecilen.Text = "?";
                        ilksecilen = null;
                        ikincisecilen = null;
                    }
                }
            }
        }
        public void btnnormal_Click(object sender, EventArgs e)
        {
            if (ilksecilen == null)
            {
                ilksecilen = sender as Button;
                ilksecilen.Text = karisikharfler[Convert.ToInt32(ilksecilen.Name.Substring(3))];
            }
            else
            {
                if (kartlar.IndexOf(ilksecilen) == kartlar.IndexOf(sender as Button))
                {
                    MessageBox.Show("aynı kutucuk seçildi.");
                    ilksecilen.Text = "?";
                    ilksecilen = null;
                }
                else
                {
                    ikincisecilen = sender as Button;
                    ikincisecilen.Text = karisikharfler[Convert.ToInt32(ikincisecilen.Name.Substring(3))];
                    ikincisecilen.Refresh();

                    if (karisikharfler[Convert.ToInt32(ilksecilen.Name.Substring(3))] == karisikharfler[Convert.ToInt32(ikincisecilen.Name.Substring(3))])
                    {
                        ilksecilen.Enabled = false;
                        ikincisecilen.Enabled = false;
                        ilksecilen = null;
                        ikincisecilen = null;
                        eslesen++;
                        if (eslesen == (boyut * boyut / 2))
                        {
                            MessageBox.Show("tamamlandı...");
                        }
                    }

                    else
                    {
                        Thread.Sleep(1000);

                        string tut = karisikharfler[Convert.ToInt32(ilksecilen.Name.Substring(3))];
                        karisikharfler[Convert.ToInt32(ilksecilen.Name.Substring(3))] = karisikharfler[Convert.ToInt32(ikincisecilen.Name.Substring(3))];
                        karisikharfler[Convert.ToInt32(ikincisecilen.Name.Substring(3))] = tut;

                        ilksecilen.Text = "?";
                        ikincisecilen.Text = "?";
                        ilksecilen = null;
                        ikincisecilen = null;
                    }
                }
            }



        }
        public void btnzor_Click(object sender, EventArgs e)
        {
            if (ilksecilen == null)
            {
                ilksecilen = sender as Button;
                ilksecilen.Text = karisikharfler[Convert.ToInt32(ilksecilen.Name.Substring(3))];
            }
            else
            {
                if (kartlar.IndexOf(ilksecilen) == kartlar.IndexOf(sender as Button))
                {
                    MessageBox.Show("aynı kutucuk seçildi.");
                    ilksecilen.Text = "?";
                    ilksecilen = null;
                }
                else
                {
                    ikincisecilen = sender as Button;
                    ikincisecilen.Text = karisikharfler[Convert.ToInt32(ikincisecilen.Name.Substring(3))];
                    ikincisecilen.Refresh();

                    if (karisikharfler[Convert.ToInt32(ilksecilen.Name.Substring(3))] == karisikharfler[Convert.ToInt32(ikincisecilen.Name.Substring(3))])
                    {
                        ilksecilen.Enabled = false;
                        ikincisecilen.Enabled = false;
                        ilksecilen = null;
                        ikincisecilen = null;
                        eslesen++;
                        if (eslesen == (boyut * boyut / 2))
                        {
                            MessageBox.Show("tamamlandı...");
                        }
                    }

                    else
                    {
                        Thread.Sleep(1000);
                        string tut;
                        string tut2;
                        for (int i = (Convert.ToInt32(ilksecilen.Name.Substring(3)) + 1); i <= kartlar.Count; i++)
                        {
                            if (i < kartlar.Count)
                            {
                                if (kartlar[i].Enabled != false)
                                {
                                    tut = karisikharfler[Convert.ToInt32(ilksecilen.Name.Substring(3))];
                                    karisikharfler[Convert.ToInt32(ilksecilen.Name.Substring(3))] = karisikharfler[i];
                                    karisikharfler[i] = tut;
                                    break;
                                }

                            }
                            if (i == kartlar.Count)
                                i = (-1);

                        }
                        for (int i = (Convert.ToInt32(ikincisecilen.Name.Substring(3)) + 1); i <= kartlar.Count; i++)
                        {
                            if (i < kartlar.Count)
                            {
                                if (kartlar[i].Enabled != false)
                                {
                                    tut2 = karisikharfler[Convert.ToInt32(ikincisecilen.Name.Substring(3))];
                                    karisikharfler[Convert.ToInt32(ikincisecilen.Name.Substring(3))] = karisikharfler[i];
                                    karisikharfler[i] = tut2;
                                    break;
                                }

                            }
                            if (i == kartlar.Count)
                                i = (-1);

                        }



                        ilksecilen.Text = "?";
                        ikincisecilen.Text = "?";
                        ilksecilen = null;
                        ikincisecilen = null;
                    }
                }
            }
        }
        public List<int> getskor()
        {
            FileStream fs = new FileStream(dosya, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            var s = sr.ReadLine().Split(",");
            for (int i = 0; i < 9; i++)
            {
                skor_.Add(Convert.ToInt32(s[i]));
            }
            sr.Close();
            fs.Close();

            return skor_;
        } // skor tablosu için 

        public void skorkarsilastir(int saniye)
        {   
            FileStream fs = new FileStream(dosya, FileMode.Truncate,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Flush();
            sw.Close();
            fs.Close();

            fs = new FileStream(dosya, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            var s = sr.ReadLine().Split(",");
            for (int i = 0; i < 9; i++)
            {
                skor_.Add(Convert.ToInt32(s[i]));
            }
            if (skor_[skorsira] < saniye)
                skor_[skorsira] = saniye;

            fs.Close();
            sw.Close();
            string line = "";
            for (int i = 0; i < 9; i++)
                line = line + skor_[skorsira] + ",";
            fs = new FileStream(dosya, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(line);
            fs.Close();
            sw.Close();


        }   //kullanıcı süresini en iyi sürelerle karşılaştırmak için

    }
}
