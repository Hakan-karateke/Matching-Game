namespace matching_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static public int boyut;
        static public string oyunmod;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnoyna_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("l�tfen oyunun modunu ve tablo boyutunu se�in!");
            }

            else
            {   
                string smod = comboBox2.Text;
                boyut = Convert.ToInt32(comboBox1.Text);
                oyunmod = smod;

                Form2 yeni_form = new Form2();
                yeni_form.Show();
                this.Hide();
            }
            
            
        }

        private void btnnasil_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Oyunda boyut ad� alt�nda kare �eklindeki tablonun bir kenar�n�  belirlersiniz.\r\n\r\nDaha sonra se�ece�iniz oyunun moduna g�re oyunu ba�lat�rs�n�z.\r\n\r\nKolay Mod:\r\n\tOyunun en basit oynan�� �eklidir. �lk a�t���n�z kart ile sonraki kart�n e�le�me durumuna bak�l�r\r\n\tve e�le�ti�i zaman di�er kartlar e�le�tirilmeye devam edilir. E�le�me olmad��� durumda ise kartlar\r\n\ts�ras�na g�re tekrar kapan�r.\r\nNormal Mod:\r\n\tBurada oyunun oynan��� ve kartlar�n yerle�imi her e�le�meden sonra de�i�ebilir.E�er kartlar e�it de�il\r\n\tise kartlar birbiriyle de�i�ir. Ve oyun b�yle devam eder.\r\nZor Mod:\r\n\tBu modda kartlar�n da��l�m� her e�le�me durumundan sonra e�lik durumu olmad��� zaman normal mod i�lemi\r\n\tve daha sonra kartlar soldan kontrol edilerek bir yan�ndaki e�le�memi� kartla de�i�ir. E�le�mi� kart \r\n\tolmas� halinde bir a�a��s�nda bulunan s�ra ile devam edilir. Dolay�s�yla bu b�l�m oynan��� en zor b�l�md�r.\r\n\r\n\r\n\t\t\t\t\t�yi Oyunlar :)))))\r\n");
        }
    }
}