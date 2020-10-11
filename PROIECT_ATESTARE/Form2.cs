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
        int nr_curent = 0; //indicele intrebarii curente in vectorul de intrebari
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

        //alege random o intrebare din vectorul de intrebari si printeaza in label textul intrebarii
        //iar in textul aferent pt radioButton-uri cele 4 variante de raspuns
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
            //afiseaza in label enuntul intreabarii
            label1.Text = indicele.ToString() + ". " + v[c].enunt;

            radioButton1.Text = v[c].varianta1;
            radioButton2.Text = v[c].varianta2;
            radioButton3.Text = v[c].varianta3;
            radioButton4.Text = v[c].varianta4;
            nr_curent = c;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           n = int.Parse(f.ReadLine()); //citeste numarul de intrebari care se gasesc in fisier
           v = new intrebare[300];
           a = new int[n+1];
           progressBar1.Maximum =(Form1.N) + 1;
           progressBar1.Minimum = 1;
           progressBar1.Step= 1;
           CitireDate(); //memoreaza intreabarile din fisier intr-un vector
           Afisari(); //afiseaza textul si variantele de raspuns
           button2.Visible = false;
           button3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //se verifica raspunsul ales (prin verificarea butoanelor radio) pentru a contoriza punctajul
            if (radioButton1.Checked == true)
            {
                //se verifica daca raspunsul 1 este cel corect
                if (v[nr_curent].rc == 1)
                {
                    checkAnswer = true;
                    punctaj++;
                }
                else
                {
                    checkAnswer = false;
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (v[nr_curent].rc == 2)
                {
                    checkAnswer = true;
                    punctaj++;
                }
                else
                {
                    checkAnswer = false;
                }
            }
            else if (radioButton3.Checked == true)
            {
                if (v[nr_curent].rc == 3)
                {
                    checkAnswer = true;
                    punctaj++;
                }
                else
                {
                    checkAnswer = false;
                }
            }
            else if (radioButton4.Checked == true)
            {
                if (v[nr_curent].rc == 4)
                {
                    checkAnswer = true;
                    punctaj++;
                }
                else
                {
                    checkAnswer = false;
                }
            }

            //valideaza prin mesaj sonor raspunsul dat
            if (checkAnswer == true)
            {
                WMPLib.WindowsMediaPlayer raspunsCorect = new WMPLib.WindowsMediaPlayer();
                raspunsCorect.URL = "Correct-answer.mp3";
                raspunsCorect.controls.play();
            }
            else if (checkAnswer == false)
            {
                WMPLib.WindowsMediaPlayer raspunsGresit = new WMPLib.WindowsMediaPlayer();
                raspunsGresit.URL = "Wrong-answer-sound-effect.mp3";
                raspunsGresit.controls.play();
            }

            if (indicele < Form1.N)
            {
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

                if(punctaj != 0 && punctaj >= indicele/2)
                {
                    string message_congrats = " Testul s-a incheiat! Felicitari! Ai obtinut " + punctaj + " puncte :)";
                    string title = "Final Test";
                    MessageBox.Show(message_congrats, title);
                }
                else if(punctaj != 0 && punctaj < indicele/2)
                {
                    MessageBox.Show("Testul s-a incheiat! Ai obtinut " + punctaj + " puncte \n" +
                        "Cu siguranta poti mai mult! Incearca o noua runda!");
                }
                else if (punctaj == 0)
                {
                    MessageBox.Show("Testul s-a incheiat! Din pacate, nu ai raspuns corect la nicio intrebare :( \n " +
                        "Incearca o noua runda!", "Final Test");
                }

                button2.Visible = true;
                button3.Visible = true;
                progressBar1.Visible = false;
                label2.Text = " ";
            }
        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
      
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
   
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
