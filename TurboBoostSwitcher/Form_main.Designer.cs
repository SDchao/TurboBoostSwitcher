namespace TurboBoostSwitcher
{
    partial class Form_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.button_switch = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip_icon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.maxsize = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBox_runOnStart = new System.Windows.Forms.CheckBox();
            this.checkBox_minOnLoad = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip_icon.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_switch
            // 
            this.button_switch.Location = new System.Drawing.Point(63, 28);
            this.button_switch.Name = "button_switch";
            this.button_switch.Size = new System.Drawing.Size(265, 81);
            this.button_switch.TabIndex = 0;
            this.button_switch.Text = "关闭睿频";
            this.button_switch.UseVisualStyleBackColor = true;
            this.button_switch.Click += new System.EventHandler(this.button_switch_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "左键单击图标切换睿频开关\r\n右键单击图标弹出菜单";
            this.notifyIcon.BalloonTipTitle = "TurboBoostSwitcher已隐藏";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip_icon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "切换睿频";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // contextMenuStrip_icon
            // 
            this.contextMenuStrip_icon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maxsize,
            this.exit});
            this.contextMenuStrip_icon.Name = "contextMenuStrip_icon";
            this.contextMenuStrip_icon.Size = new System.Drawing.Size(125, 48);
            // 
            // maxsize
            // 
            this.maxsize.Name = "maxsize";
            this.maxsize.Size = new System.Drawing.Size(124, 22);
            this.maxsize.Text = "显示窗口";
            this.maxsize.Click += new System.EventHandler(this.maxsize_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(124, 22);
            this.exit.Text = "退出";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // checkBox_runOnStart
            // 
            this.checkBox_runOnStart.AutoSize = true;
            this.checkBox_runOnStart.Location = new System.Drawing.Point(14, 128);
            this.checkBox_runOnStart.Name = "checkBox_runOnStart";
            this.checkBox_runOnStart.Size = new System.Drawing.Size(72, 16);
            this.checkBox_runOnStart.TabIndex = 2;
            this.checkBox_runOnStart.Text = "开机启动";
            this.checkBox_runOnStart.UseVisualStyleBackColor = true;
            this.checkBox_runOnStart.CheckedChanged += new System.EventHandler(this.checkBox_runOnStart_CheckedChanged);
            // 
            // checkBox_minOnLoad
            // 
            this.checkBox_minOnLoad.AutoSize = true;
            this.checkBox_minOnLoad.Location = new System.Drawing.Point(92, 128);
            this.checkBox_minOnLoad.Name = "checkBox_minOnLoad";
            this.checkBox_minOnLoad.Size = new System.Drawing.Size(96, 16);
            this.checkBox_minOnLoad.TabIndex = 3;
            this.checkBox_minOnLoad.Text = "启动时最小化";
            this.checkBox_minOnLoad.UseVisualStyleBackColor = true;
            this.checkBox_minOnLoad.CheckedChanged += new System.EventHandler(this.checkBox_minOnLoad_CheckedChanged);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 149);
            this.Controls.Add(this.checkBox_minOnLoad);
            this.Controls.Add(this.checkBox_runOnStart);
            this.Controls.Add(this.button_switch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_main";
            this.Text = "TurboBoostSwitcher";
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.SizeChanged += new System.EventHandler(this.Form_main_Resized);
            this.contextMenuStrip_icon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_switch;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem maxsize;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_icon;
        private System.Windows.Forms.CheckBox checkBox_runOnStart;
        private System.Windows.Forms.CheckBox checkBox_minOnLoad;
    }
}

