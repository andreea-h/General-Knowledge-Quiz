using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace PROIECT_ATESTARE
{
    public partial class Form2 : Form
    {
        static Boolean checkAnswer = false;
        public Form2()
        {
            InitializeComponent();
        }
        public struct intrebare
        {
            public string enunt;
            public string varianta1;
            public string varianta2;
            public string varianta3;
            public string varianta4;
            public int rc;//raspunsul corect (1,2,3 sau 4)
        };

        StreamReader f = File.OpenText("test.txt");

        intrebare[] v;///vectorul de intrebari    
        int[] a;///vectorul de frecventa (se vor verifica intrebarile generate deja)
        int n;///numarul de intrebari din fisierul cu datele
        int punctaj = 0;
        int indicele = 0;
        Random r;

        void CitireDate()
        {
            for (int i = 0; i <= n-1; i++)
            {
                v[i].enunt = f.ReadLine();
                v[i].varianta1 = f.ReadLine();
                v[i].varianta2 = f.ReadLine();
                v[i].varianta3 = f.ReadLine();
                v[i].varianta4 = f.ReadLine();
                v[i].rc = int.Parse(f.ReadLine());
            }
            f.Close();
        }

        void Afisari()
        {
            indicele++; //indicele intrebarii curente din test
            label2.Text = indicele.ToString() + "/" + Form1.N.ToString();

            progressBar1.PerformStep();
            r = new Random();
            int c;
            do
            {
                c = r.Next(n - 1);
            } while (a[c] == 1);

            a[c] = 1;
            label1.Text = indicele.ToString() + "." + v[c].enunt;

            radioButton1.Text = v[c].varianta1;
            radioButton2.Text = v[c].varianta2;
            radioButton3.Text = v[c].varianta3;
            radioButton4.Text = v[c].varianta4;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           n = int.Parse(f.ReadLine());
           v = new intrebare[300];
           a = new int[n+1];
           progressBar1.Maximum =(Form1.N)+1;
           progressBar1.Minimum = 1;
           progressBar1.Step= 1;
           CitireDate();
           Afisari();
           button2.Visible = false;
           button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (indicele < Form1.N)
            {
                if (checkAnswer == false)
                {
                    WMPLib.WindowsMediaPlayer raspunsCorect = new WMPLib.WindowsMediaPlayer();
                    raspunsCorect.URL = "Correct-answer.mp3";
                    raspunsCorect.controls.play();
                }
                else if (checkAnswer == true)
                {
                    WMPLib.WindowsMediaPlayer raspunsGresit = new WMPLib.WindowsMediaPlayer();
                    raspunsGresit.URL = "Wrong-answer-sound-effect.mp3";
                    raspunsGresit.controls.play();
                }
                Afisari();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
            else
            {
                label1.Text = " ";
                radioButton1.Text = " ";
                radioButton2.Text = " ";
                radioButton3.Text = " ";
                radioButton4.Text = " ";
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                button1.Visible = false;

                string message = " Testul s-a incheiat!  Ai obtinut  " + punctaj + " puncte ";
                string title = "Final_test";
                MessageBox.Show(message, title);
                button2.Visible = true;
                button3.Visible = true;
                progressBar1.Visible = false;
                label2.Text = " ";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (v[indicele].rc == 1)
            {
                punctaj++;
                checkAnswer = true;
                Console.WriteLine("Raspuns corect 1\n");
            }
            else
            {
                checkAnswer = false;
            }
               
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (v[indicele].rc == 2)
            {
                punctaj++;
                checkAnswer = true;
                Console.WriteLine("Raspuns corect 2\n");
            }
            else
            {
                checkAnswer = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (v[indicele].rc == 3)
            {
                punctaj++;
                checkAnswer = true;
                Console.WriteLine("Raspuns corect 3\n");
            }
            else
            {
                checkAnswer = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
             if(v[indicele].rc == 4)
             {
                punctaj++;
                checkAnswer = true;
                Console.WriteLine("Raspuns corect 4\n");
             }
             else
             {
                checkAnswer = false;
             }
        }

        private void button2_Click(object sender, EventArgs e)///generare test nou
        {
            label2.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            progressBar1.Visible = true;
            progressBar1.Value = 1;
            punctaj = 0;
            indicele = 0;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            button1.Visible = true;
            button1.Text = "Urmatoarea intrebare";
            
            Afisari();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        


    }
}
