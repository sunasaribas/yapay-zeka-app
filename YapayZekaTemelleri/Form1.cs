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
        void colormethod()
        {
            TxtBuyPrice.BackColor = Color.White;
            TxtName.BackColor = Color.White;
            TxtSellPrice.BackColor = Color.White;
            maskedTextBox1.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            TxtMark.BackColor = Color.White;
            TxtStock.BackColor = Color.White;
            textBox6.BackColor = Color.White;


        }
        DbProductArtEntities db = new DbProductArtEntities();
        void enabled()
        {
            TxtBuyPrice.Enabled = false;
            TxtName.Enabled = false;
            TxtSellPrice.Enabled = false;
            TxtMark.Enabled = false;
            TxtStock.Enabled = false;
            textBox6.Enabled = false;
            maskedTextBox1.Enabled = false;
            comboBox1.Enabled = false;
        
        }
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
            enabled();
            colormethod();
        }

        private void BtnProductAdd_Click(object sender, EventArgs e)
        {
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TxtName.BackColor == Color.Yellow && TxtName.Enabled==true)
            {
                TxtName.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (TxtMark.BackColor == Color.Yellow && TxtMark.Enabled == true)
            {
                TxtMark.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (TxtStock.BackColor == Color.Yellow && TxtStock.Enabled == true)
            {
                TxtStock.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (TxtBuyPrice.BackColor == Color.Yellow && TxtBuyPrice.Enabled == true)
            {
                TxtBuyPrice.Text = richTextBox1.Text;
                enabled();
                colormethod();

            }

            if (TxtSellPrice.BackColor==Color.Yellow && TxtSellPrice.Enabled == true)
            {
                TxtSellPrice.Text = richTextBox1.Text;
                enabled();
                colormethod();

            }

   

            if (richTextBox1.Text == "The list of product" || richTextBox1.Text == "Products list" || richTextBox1.Text == "56") 
            {
                ProductList();
            }

            if (richTextBox1.Text=="Products name" || richTextBox1.Text == "Product name")
            {
                TxtName.Focus();
                TxtName.BackColor = Color.Yellow;
                TxtName.Enabled = true;

            }
            if (richTextBox1.Text == "Mark" || richTextBox1.Text == "Brand")
            {
                TxtMark.Focus();
                TxtMark.BackColor = Color.Yellow;
                TxtMark.Enabled = true;
            }
            if (richTextBox1.Text == "Stock" || richTextBox1.Text == "Stocks")
            {
                TxtStock.Focus();
                TxtStock.BackColor = Color.Yellow;
                TxtStock.Enabled = true;
            }
            if (richTextBox1.Text == "By price" || richTextBox1.Text == "Buying price")
            {
                TxtName.Focus();
                TxtBuyPrice.BackColor = Color.Blue;
            }
            if (richTextBox1.Text == "Sell price" || richTextBox1.Text == "52") 
            {
                TxtName.Focus();
                TxtSellPrice.BackColor = Color.Yellow;
                TxtSellPrice.Enabled = true;
            }

            if(richTextBox1.Text=="Exit application" || richTextBox1.Text=="Exits application" || richTextBox1.Text=="Exit app" || richTextBox1.Text=="Exit")
            {
                Application.Exit();
            }

            if (richTextBox1.Text == "Paint" ||richTextBox1.Text=="Paints")
            {
                System.Diagnostics.Process.Start("MsPaint");
            }

            
        }
    }
}
