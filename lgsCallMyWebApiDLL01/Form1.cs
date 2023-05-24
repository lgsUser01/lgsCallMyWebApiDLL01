using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lgsCallMyWebApiDLL01
{
    public partial class Form1 : Form
    {
        ClgsCallMyWebApi01.ClgsWebKiroTeiKyori01 ClgsWebKiroTei = new ClgsCallMyWebApi01.ClgsWebKiroTeiKyori01();

        public Form1()
        {
           
            InitializeComponent();
            this.textBoxWebApiUrl.Text = "http://localhost/lgsWebKiroTeiKyori01/api/K/";    // 【1】　WebApi URL

            ClgsWebKiroTei.WebApiUrl = this.textBoxWebApiUrl.Text;
            // 【2】プロキシ認証の指定
            ClgsWebKiroTei.ProxyServer = "";
            ClgsWebKiroTei.ProxyUserName = "";
            ClgsWebKiroTei.ProxyPassword = "";

            this.textBox起点.Text = "13102";
            this.textBox終点.Text = "27127";
        }

        private async void dLL呼び出しToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClgsWebKiroTei.Kiten = this.textBox起点.Text;
            ClgsWebKiroTei.Shuuten = this.textBox終点.Text;

         
            await ClgsWebKiroTei.lgsKyoriKmKeisan();
            int IppanKm = ClgsWebKiroTei.SaitanKyoriKm;
            int ShuyouKm = ClgsWebKiroTei.ShuyouKyoriKm;
            string Error = ClgsWebKiroTei.Error;

            this.textBox主要距離Km.Text = ShuyouKm.ToString();
            this.textBox最短距離Km.Text = IppanKm.ToString();
            this.textBoxError.Text = Error;
        }

    }
}
