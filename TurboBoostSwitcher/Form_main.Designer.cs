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
            this.button_switch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_switch
            // 
            this.button_switch.Location = new System.Drawing.Point(54, 28);
            this.button_switch.Name = "button_switch";
            this.button_switch.Size = new System.Drawing.Size(265, 81);
            this.button_switch.TabIndex = 0;
            this.button_switch.Text = "关闭睿频";
            this.button_switch.UseVisualStyleBackColor = true;
            this.button_switch.Click += new System.EventHandler(this.button_switch_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 149);
            this.Controls.Add(this.button_switch);
            this.MaximizeBox = false;
            this.Name = "Form_main";
            this.ShowIcon = false;
            this.Text = "TurboBoostSwitcher";
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_switch;
    }
}

