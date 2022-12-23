using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using matching_game;
using System.IO;
namespace matching_game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        matching oyun = new matching(Form1.boyut, Form1.oyunmod);

        int saniye = 0;
        

        public void tabloolustur()
        {
            int btnad = 0;
            for (int i = 0; i < oyun.boyut; i++)
            {
                for (int j = 0; j < oyun.boyut; j++)
                {
                    Button btn = new Button();
                    btn.Text = "?";
                    btn.Name = "btn" + btnad.ToString();
                    btn.Size = new Size(50, 50);
                    btn.BackColor = SystemColors.Window;
                    btn.Location = new Point(50 * (j + 1), 50 * (i + 1));
                    if (oyun.mod.Equals("Kolay Mod"))
                        btn.Click += new EventHandler(oyun.btnkolay_Click);
                    else if (oyun.mod.Equals("Normal Mod"))
                        btn.Click += new EventHandler(oyun.btnnormal_Click);
                    else if (oyun.mod.Equals("Zor Mod"))
                        btn.Click += new EventHandler(oyun.btnzor_Click);
                    Controls.Add(btn);
                    oyun.kartlar.Add(btn);
                    btnad++;

                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {   
            skorBox.Items.Add(oyun.getskor()[oyun.skorsira]);
            
            oyun.rastgelesec();
            oyun.kartlarikaristir();
            tabloolustur();
            timer1.Start();
        }
       

        private void timer1_Tick(object sender, EventArgs e)
        {
            saniye++;
            label1.Text = saniye+" saniye ";

            if (oyun.finish)
            {
                timer1.Stop();
                Form1 new_form = new Form1();
                new_form.Show();
                this.Hide();
            }

        }
    }
}
