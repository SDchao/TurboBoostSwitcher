using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurboBoostSwitcher;

namespace TurboBoostSwitcher
{
    public partial class Form_main : Form
    {
        PowerManager powerManager;
        public Form_main()
        {
            InitializeComponent();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            powerManager = new PowerManager();     
        }
    }
}
