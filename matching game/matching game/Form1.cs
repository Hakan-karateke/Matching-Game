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
                MessageBox.Show("lütfen oyunun modunu ve tablo boyutunu seçin!");
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
            MessageBox.Show("Oyunda boyut adý altýnda kare þeklindeki tablonun bir kenarýný  belirlersiniz.\r\n\r\nDaha sonra seçeceðiniz oyunun moduna göre oyunu baþlatýrsýnýz.\r\n\r\nKolay Mod:\r\n\tOyunun en basit oynanýþ þeklidir. Ýlk açtýðýnýz kart ile sonraki kartýn eþleþme durumuna bakýlýr\r\n\tve eþleþtiði zaman diðer kartlar eþleþtirilmeye devam edilir. Eþleþme olmadýðý durumda ise kartlar\r\n\tsýrasýna göre tekrar kapanýr.\r\nNormal Mod:\r\n\tBurada oyunun oynanýþý ve kartlarýn yerleþimi her eþleþmeden sonra deðiþebilir.Eðer kartlar eþit deðil\r\n\tise kartlar birbiriyle deðiþir. Ve oyun böyle devam eder.\r\nZor Mod:\r\n\tBu modda kartlarýn daðýlýmý her eþleþme durumundan sonra eþlik durumu olmadýðý zaman normal mod iþlemi\r\n\tve daha sonra kartlar soldan kontrol edilerek bir yanýndaki eþleþmemiþ kartla deðiþir. Eþleþmiþ kart \r\n\tolmasý halinde bir aþaðýsýnda bulunan sýra ile devam edilir. Dolayýsýyla bu bölüm oynanýþý en zor bölümdür.\r\n\r\n\r\n\t\t\t\t\tÝyi Oyunlar :)))))\r\n");
        }
    }
}