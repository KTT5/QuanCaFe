using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dynamic_Controls;
namespace QLQuanCaFe
{
    public partial class TaiBan : Form
    {

        private Ban buttonCreator;
        public TaiBan()
        {
            InitializeComponent();
            buttonCreator = new Ban();
        }

        private void TaiBan_Load(object sender, EventArgs e)
        {
            int buttonSpace = 30;
          
           for (int i = 0; i <= 5; i++)
            {
                Button dynamicButton = buttonCreator.CreateButton("DynamicButton{i + 1}", "Phòng:" + i, 50, 50 + i * (30 + buttonSpace), Button_Click);
              
                this.Controls.Add(dynamicButton);
            }

        }
         private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            MessageBox.Show("đã được click!");
        }

         private void ban1_Click(object sender, EventArgs e)
         {

         }
    }
}
