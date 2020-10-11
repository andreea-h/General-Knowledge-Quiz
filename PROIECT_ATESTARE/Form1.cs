using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace PROIECT_ATESTARE
{
    public partial class Form1 : Form
    {
        public static int N; //numarul de intrebari continute in test
        Form2 f2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //la apasarea butonului "Incepe testul" se deschide o fereastra noua
        private void button1_Click(object sender, EventArgs e)
        {
            WMPLib.WindowsMediaPlayer sunet = new WMPLib.WindowsMediaPlayer();
            sunet.URL = "music.mp3";
            sunet.controls.play();

            string sir;
            sir = (textBox1.Text).ToString();
            //se actualizeaza N ca numaru de intrebari din test, preluat din textBox

            Boolean checkNumber = false;

           
            if (Int32.TryParse(textBox1.Text, out N))
            {
                 N = int.Parse(sir);
                 checkNumber = true;
                 f2.ShowDialog();
                return;
            }
            else
            {
                MessageBox.Show("Ai introdus un numar invalid!\n" +
                        "Incearca sa introduci numar de intrebari din intervalul 1-45 :)");
            }
            
           
            
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

       

    }
}
