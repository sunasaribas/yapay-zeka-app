using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;
using System.Speech.Recognition;

namespace YapayZekaTemelleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ProductList()
        {
            var products = db.TBLPRODUCTs.ToList();
            dataGridView1.DataSource = products;

        }
        DbProductArtEntities db = new DbProductArtEntities();

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            try
            {
                btnSpeak.Text = "Please Speak";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();
                richTextBox1.Text = res.Text;
            }
            catch (Exception)
            {

                btnSpeak.Text="Error... Try again!";
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnProductAdd_Click(object sender, EventArgs e)
        {
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "The list of product" || richTextBox1.Text == "Products list" || richTextBox1.Text == "56") 
            {
                ProductList();
            }

            if(richTextBox1.Text=="Products name" || richTextBox1.Text == "Product name")
            {
                TxtName.Focus();
                TxtName.BackColor = Color.Yellow;

            }
            if (richTextBox1.Text == "Sell price")
            {
                TxtName.Focus();
                TxtSellPrice.BackColor = Color.Red;
            }
            if (richTextBox1.Text == "By price" || richTextBox1.Text == "Buying price")
            {
                TxtName.Focus();
                TxtBuyPrice.BackColor = Color.Blue;
            }
        }
    }
}
