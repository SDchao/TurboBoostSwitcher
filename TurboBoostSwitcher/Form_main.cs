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
using Microsoft.Win32;

namespace TurboBoostSwitcher
{
    public partial class Form_main : Form
    {
        PowerManager powerManager;
        ConfigManager configManager;
        bool isBoosting = true;
        public Form_main()
        {
            InitializeComponent();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;

            try
            {
                powerManager = new PowerManager();
                configManager = new ConfigManager();
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化错误\n详细错误信息已写入日志");
                StreamWriter writer = File.CreateText(Environment.CurrentDirectory + "\\error.log");
                writer.Write(ex.Message + Environment.NewLine + ex.StackTrace);
                writer.Close();
                Application.Exit();
            }

            checkBox_minOnLoad.Checked = configManager.minimizedOnLoad;
            checkBox_runOnStart.Checked = configManager.runOnStart;

            if (powerManager.value == 100)
            {
                isBoosting = true;
            }     
            else
            {
                isBoosting = false;
            }
            RefreshSetting();

            if(configManager.minimizedOnLoad)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void button_switch_Click(object sender, EventArgs e)
        {
            isBoosting = !isBoosting;
            RefreshSetting();
        }

        private void RefreshSetting()
        {
            if (isBoosting)
            {
                powerManager.SetMaxCpu(100);
                button_switch.Text = "关闭睿频";
                notifyIcon.Text = "关闭睿频";
                notifyIcon.Icon = Resource.icon;
            }
            else
            {
                powerManager.SetMaxCpu(99);
                button_switch.Text = "开启睿频";
                notifyIcon.Text = "开启睿频";
                notifyIcon.Icon = Resource.icon_off;
            }
        }

        private void Form_main_Resized(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            { 
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(3);
                this.ShowInTaskbar = false;
                this.Visible = false;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isBoosting = !isBoosting;
                RefreshSetting();
            }
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip_icon.Show();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maxsize_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void checkBox_runOnStart_CheckedChanged(object sender, EventArgs e)
        {
            configManager.runOnStart = checkBox_runOnStart.Checked;
            configManager.SaveCfg();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            if (configManager.runOnStart)
            {
                key.SetValue("TurboBoostSwitcher", Application.ExecutablePath.Replace('/', '\\'));
            }
            else
            {
                key.DeleteValue("TurboBoostSwitcher");
            }
            key.Close();
        }

        private void checkBox_minOnLoad_CheckedChanged(object sender, EventArgs e)
        {
            configManager.minimizedOnLoad = checkBox_minOnLoad.Checked;
            configManager.SaveCfg();
        }
    }
}
