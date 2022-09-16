using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cupertino_bot
{
    public partial class Form1 : Form
    {
        libreriaHolk.Nave nave = new libreriaHolk.Nave();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            nave.OpenUrl("https://volveralaesencia.com/wp-login.php");
            

            string cadena;
            int cont = 0;

            try
            {
                string[] lineas = File.ReadAllLines("dato1.txt");

                foreach (string linea in lineas)
                {
                    while (nave.IsVisible("//*[@id='user_login']") == false) { nave.tiempoE(2); }
                    Thread.Sleep(500);
                    nave.EscribirText("//*[@id='user_login']", linea);
                    nave.EscribirText("//*[@id='user_pass']", linea);
                    nave.ClickXP("//*[@id='wp-submit']");
                    cont++;

                }

            }
            catch (Exception)
            {
                Console.WriteLine("Exception: ");
            }







            //*[@id="mount_0_0_So"]/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div/div[3]/button[2]

            //*[@id='mount_0_0_ri']/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div/div[3]/button[2]
            //while (nave.IsVisible("//*[@id='mount_0_0_ri']/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div/div[3]/button[2]") == false) { nave.tiempoE(2); }
            //nave.ClickXP("//*[@id='mount_0_0_ri']/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div/div[3]/button[2]");

            //*[@id="mount_0_0_hg"]/div/div[1]/div/div[2]/div/div/div[1]/div/div[2]/div/div/div/div/div/div/div/div[3]/button[2]
            //while (nave.IsVisible("//*[@id='mount_0_0_ri']/div/div[1]/div/div[1]/div/div/div[1]/div[1]/section/nav/div[2]/div/div/div[3]/div/div[2]/a/svg") == false) { nave.tiempoE(2); }
            //nave.ClickXP("//*[@id='mount_0_0_ri']/div/div[1]/div/div[1]/div/div/div[1]/div[1]/section/nav/div[2]/div/div/div[3]/div/div[2]/a/svg");
        }
    }
}
