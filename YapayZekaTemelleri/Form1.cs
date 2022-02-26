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
            TxtCategory.BackColor = Color.White;


        }
        void enabled()
        {
            TxtBuyPrice.Enabled = false;
            TxtName.Enabled = false;
            TxtSellPrice.Enabled = false;
            TxtMark.Enabled = false;
            TxtStock.Enabled = false;
            TxtCategory.Enabled = false;
            maskedTextBox1.Enabled = false;
            comboBox1.Enabled = false;

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
            //timer1.Start();
            enabled();
            colormethod();
        }

        private void BtnProductAdd_Click(object sender, EventArgs e)
        {
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TxtName.BackColor == Color.Yellow && TxtName.Enabled == true)
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

            if (TxtSellPrice.BackColor == Color.Yellow && TxtSellPrice.Enabled == true)
            {
                TxtSellPrice.Text = richTextBox1.Text;
                enabled();
                colormethod();

            }

            if (TxtCategory.BackColor == Color.Yellow && TxtCategory.Enabled == true)
            {
                TxtCategory.Text = richTextBox1.Text;
                enabled();
                colormethod();
            }

            if (maskedTextBox1.BackColor == Color.Yellow && maskedTextBox1.Enabled == true)
            {
                enabled();
                colormethod();
            }

            if (comboBox1.BackColor == Color.Yellow && comboBox1.Enabled == true)
            {
                comboBox1.Text = "Active";
                enabled();
                colormethod();
            }

            if (richTextBox1.Text == "The list of product" || richTextBox1.Text == "Products list")
            {
                ProductList();
            }
            if (richTextBox1.Text == "Add" || richTextBox1.Text == "Add to" || richTextBox1.Text == "Add the")
            {
                TBLPRODUCT t = new TBLPRODUCT();
                t.NAME = TxtName.Text;
                t.BRAND = TxtMark.Text;
                t.SELLPRICE = decimal.Parse(TxtSellPrice.Text);
                t.BUYPRICE = decimal.Parse(TxtBuyPrice.Text);
                t.STOCK = short.Parse(TxtStock.Text);
                t.PRODUCTCASE = true;
                t.DATEADDPRO = DateTime.Parse(maskedTextBox1.Text);
                t.CATEGORY = TxtCategory.Text;
                db.TBLPRODUCTs.Add(t);
                db.SaveChanges();
                label10.Text = "Products saved in Database";


            }

            if (richTextBox1.Text == "Products name" || richTextBox1.Text == "Product name" || richTextBox1.Text == "56" || richTextBox1.Text == "Product" || richTextBox1.Text == "Products" || richTextBox1.Text == "Main" || richTextBox1.Text == "The name")
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

            if (richTextBox1.Text == "By price" || richTextBox1.Text == "Buying price" ||richTextBox1.Text=="By" ||richTextBox1.Text=="Buy" ||richTextBox1.Text== "Take" ||richTextBox1.Text=="Reception" )
            {
                TxtName.Focus();
                TxtBuyPrice.BackColor = Color.Yellow;
                TxtBuyPrice.Enabled = true;
            }

            if (richTextBox1.Text == "Sell price" || richTextBox1.Text == "52" || richTextBox1.Text == "Sales" || richTextBox1.Text == "Sale" || richTextBox1.Text == "Sell" || richTextBox1.Text == "Sale")
            {
                TxtName.Focus();
                TxtSellPrice.BackColor = Color.Yellow;
                TxtSellPrice.Enabled = true;
            }

            if (richTextBox1.Text == "Category" || richTextBox1.Text == "Set" || richTextBox1.Text=="Group" ||richTextBox1.Text=="Cluster" || richTextBox1.Text == "Cents")
            {
                TxtCategory.Focus();
                TxtCategory.BackColor = Color.Yellow;
                TxtCategory.Enabled = true;
            }
            if (richTextBox1.Text == "Date" ||richTextBox1.Text=="Dates")
            {
                maskedTextBox1.Focus();
                maskedTextBox1.BackColor = Color.Yellow;
                maskedTextBox1.Enabled = true;
            }
            if (richTextBox1.Text == "State" || richTextBox1.Text == "Chase" || richTextBox1.Text == "States")
            {
                comboBox1.Focus();
                comboBox1.BackColor = Color.Yellow;
                comboBox1.Enabled = true;
            }

            if (richTextBox1.Text=="Exit application" || richTextBox1.Text=="Exits application" || richTextBox1.Text=="Exit app" || richTextBox1.Text=="Exit")
            {
                timer1.Stop();
                Application.Exit();
            }

            if (richTextBox1.Text == "Paint" ||richTextBox1.Text=="Paints")
            {
                System.Diagnostics.Process.Start("MsPaint");
            }

        }

        private void maskedTextBox1_BackColorChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.BackColor == Color.Yellow)
            {
                maskedTextBox1.Text = DateTime.Now.ToString("dd.MM.yyyy");
            }
        }

        private void comboBox1_BackColorChanged(object sender, EventArgs e)
        {
            if (comboBox1.BackColor == Color.Yellow)
            {
                comboBox1.Text = "Active";
            }

        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(label10.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
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

                btnSpeak.Text = "Error... Try again!";
            }
        }
    }
}
