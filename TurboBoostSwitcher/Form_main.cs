using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TurboBoostSwitcher;

namespace TurboBoostSwitcher
{
    public partial class Form_main : Form
    {
        PowerManager powerManager;
        bool isBoosting = true;
        public Form_main()
        {
            InitializeComponent();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            try
            {
                powerManager = new PowerManager();
            }
            catch (Exception ex)
            {
                MessageBox.Show("未能获取电源管理的GUID，或许系统语言并非中文?\n详细错误信息已写入日志");
                StreamWriter writer = File.CreateText(Environment.CurrentDirectory + "\\error.log");
                writer.Write(ex.Message + Environment.NewLine + ex.StackTrace);
                writer.Close();
                Application.Exit();
            }

            if (powerManager.value == 100)
            {
                isBoosting = true;
                button_switch.Text = "关闭睿频";
            }     
            else
            {
                isBoosting = false;
                button_switch.Text = "开启睿频";
            }
        }

        private void button_switch_Click(object sender, EventArgs e)
        {
            if(isBoosting)
            {
                powerManager.SetMaxCpu(99);
                button_switch.Text = "开启睿频";
                isBoosting = false;
            }
            else
            {
                powerManager.SetMaxCpu(100);
                button_switch.Text = "关闭睿频";
                isBoosting = true;
            }
        }
    }
}
