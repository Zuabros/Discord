namespace Discord
{
 partial class Form1
 {
	/// <summary>
	/// Variável de designer necessária.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Limpar os recursos que estão sendo usados.
	/// </summary>
	/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
	protected override void Dispose(bool disposing)
	{
	 if (disposing && (components != null))
	 {
		components.Dispose();
	 }
	 base.Dispose(disposing);
	}

	#region Código gerado pelo Windows Form Designer

	/// <summary>
	/// Método necessário para suporte ao Designer - não modifique 
	/// o conteúdo deste método com o editor de código.
	/// </summary>
	private void InitializeComponent()
	{
	 this.tabControl1 = new System.Windows.Forms.TabControl();
	 this.tabPage1 = new System.Windows.Forms.TabPage();
	 this.tabPage2 = new System.Windows.Forms.TabPage();
	 this.tb_hp = new System.Windows.Forms.TextBox();
	 this.tb_mana = new System.Windows.Forms.TextBox();
	 this.tb_y = new System.Windows.Forms.TextBox();
	 this.tb_x = new System.Windows.Forms.TextBox();
	 this.tb_spd = new System.Windows.Forms.TextBox();
	 this.tb_yaw = new System.Windows.Forms.TextBox();
	 this.bt_getstats = new System.Windows.Forms.Button();
	 this.bt_debug1 = new System.Windows.Forms.Button();
	 this.tb_debug1 = new System.Windows.Forms.TextBox();
	 this.tb_debug2 = new System.Windows.Forms.TextBox();
	 this.cb_12801024 = new System.Windows.Forms.CheckBox();
	 this.tb_debug3 = new System.Windows.Forms.TextBox();
	 this.bt_debug2 = new System.Windows.Forms.Button();
	 this.tb_debug4 = new System.Windows.Forms.TextBox();
	 this.cb_1366768 = new System.Windows.Forms.CheckBox();
	 this.bt_debug3 = new System.Windows.Forms.Button();
	 this.tabControl1.SuspendLayout();
	 this.SuspendLayout();
	 // 
	 // tabControl1
	 // 
	 this.tabControl1.Controls.Add(this.tabPage1);
	 this.tabControl1.Controls.Add(this.tabPage2);
	 this.tabControl1.Location = new System.Drawing.Point(115, 4);
	 this.tabControl1.Name = "tabControl1";
	 this.tabControl1.SelectedIndex = 0;
	 this.tabControl1.Size = new System.Drawing.Size(682, 438);
	 this.tabControl1.TabIndex = 0;
	 // 
	 // tabPage1
	 // 
	 this.tabPage1.Location = new System.Drawing.Point(4, 22);
	 this.tabPage1.Name = "tabPage1";
	 this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
	 this.tabPage1.Size = new System.Drawing.Size(674, 412);
	 this.tabPage1.TabIndex = 0;
	 this.tabPage1.Text = "tabPage1";
	 this.tabPage1.UseVisualStyleBackColor = true;
	 // 
	 // tabPage2
	 // 
	 this.tabPage2.Location = new System.Drawing.Point(4, 22);
	 this.tabPage2.Name = "tabPage2";
	 this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
	 this.tabPage2.Size = new System.Drawing.Size(674, 412);
	 this.tabPage2.TabIndex = 1;
	 this.tabPage2.Text = "tabPage2";
	 this.tabPage2.UseVisualStyleBackColor = true;
	 // 
	 // tb_hp
	 // 
	 this.tb_hp.Location = new System.Drawing.Point(9, 45);
	 this.tb_hp.Name = "tb_hp";
	 this.tb_hp.Size = new System.Drawing.Size(31, 20);
	 this.tb_hp.TabIndex = 1;
	 // 
	 // tb_mana
	 // 
	 this.tb_mana.Location = new System.Drawing.Point(46, 45);
	 this.tb_mana.Name = "tb_mana";
	 this.tb_mana.Size = new System.Drawing.Size(31, 20);
	 this.tb_mana.TabIndex = 2;
	 this.tb_mana.TextChanged += new System.EventHandler(this.tb_mana_TextChanged);
	 // 
	 // tb_y
	 // 
	 this.tb_y.Location = new System.Drawing.Point(9, 97);
	 this.tb_y.Name = "tb_y";
	 this.tb_y.Size = new System.Drawing.Size(90, 20);
	 this.tb_y.TabIndex = 4;
	 // 
	 // tb_x
	 // 
	 this.tb_x.Location = new System.Drawing.Point(9, 71);
	 this.tb_x.Name = "tb_x";
	 this.tb_x.Size = new System.Drawing.Size(90, 20);
	 this.tb_x.TabIndex = 3;
	 // 
	 // tb_spd
	 // 
	 this.tb_spd.Location = new System.Drawing.Point(46, 121);
	 this.tb_spd.Name = "tb_spd";
	 this.tb_spd.Size = new System.Drawing.Size(31, 20);
	 this.tb_spd.TabIndex = 6;
	 // 
	 // tb_yaw
	 // 
	 this.tb_yaw.Location = new System.Drawing.Point(9, 121);
	 this.tb_yaw.Name = "tb_yaw";
	 this.tb_yaw.Size = new System.Drawing.Size(31, 20);
	 this.tb_yaw.TabIndex = 7;
	 // 
	 // bt_getstats
	 // 
	 this.bt_getstats.Location = new System.Drawing.Point(2, 147);
	 this.bt_getstats.Name = "bt_getstats";
	 this.bt_getstats.Size = new System.Drawing.Size(75, 23);
	 this.bt_getstats.TabIndex = 8;
	 this.bt_getstats.Text = "Get Stats";
	 this.bt_getstats.UseVisualStyleBackColor = true;
	 this.bt_getstats.Click += new System.EventHandler(this.bt_getstats_Click);
	 // 
	 // bt_debug1
	 // 
	 this.bt_debug1.Location = new System.Drawing.Point(2, 348);
	 this.bt_debug1.Name = "bt_debug1";
	 this.bt_debug1.Size = new System.Drawing.Size(75, 23);
	 this.bt_debug1.TabIndex = 9;
	 this.bt_debug1.Text = "Move to";
	 this.bt_debug1.UseVisualStyleBackColor = true;
	 this.bt_debug1.Click += new System.EventHandler(this.bt_debug1_Click);
	 // 
	 // tb_debug1
	 // 
	 this.tb_debug1.Location = new System.Drawing.Point(2, 377);
	 this.tb_debug1.Name = "tb_debug1";
	 this.tb_debug1.Size = new System.Drawing.Size(50, 20);
	 this.tb_debug1.TabIndex = 11;
	 this.tb_debug1.Text = "4815";
	 // 
	 // tb_debug2
	 // 
	 this.tb_debug2.Location = new System.Drawing.Point(58, 377);
	 this.tb_debug2.Name = "tb_debug2";
	 this.tb_debug2.Size = new System.Drawing.Size(41, 20);
	 this.tb_debug2.TabIndex = 10;
	 this.tb_debug2.Text = "4294";
	 // 
	 // cb_12801024
	 // 
	 this.cb_12801024.AutoSize = true;
	 this.cb_12801024.Checked = true;
	 this.cb_12801024.CheckState = System.Windows.Forms.CheckState.Checked;
	 this.cb_12801024.Location = new System.Drawing.Point(9, 176);
	 this.cb_12801024.Name = "cb_12801024";
	 this.cb_12801024.Size = new System.Drawing.Size(79, 17);
	 this.cb_12801024.TabIndex = 12;
	 this.cb_12801024.Text = "1280x1024";
	 this.cb_12801024.UseVisualStyleBackColor = true;
	 // 
	 // tb_debug3
	 // 
	 this.tb_debug3.Location = new System.Drawing.Point(2, 403);
	 this.tb_debug3.Name = "tb_debug3";
	 this.tb_debug3.Size = new System.Drawing.Size(31, 20);
	 this.tb_debug3.TabIndex = 13;
	 this.tb_debug3.Text = "0";
	 // 
	 // bt_debug2
	 // 
	 this.bt_debug2.Location = new System.Drawing.Point(2, 319);
	 this.bt_debug2.Name = "bt_debug2";
	 this.bt_debug2.Size = new System.Drawing.Size(75, 23);
	 this.bt_debug2.TabIndex = 14;
	 this.bt_debug2.Text = "Get Position";
	 this.bt_debug2.UseVisualStyleBackColor = true;
	 this.bt_debug2.Click += new System.EventHandler(this.bt_debug2_Click);
	 // 
	 // tb_debug4
	 // 
	 this.tb_debug4.Location = new System.Drawing.Point(39, 403);
	 this.tb_debug4.Name = "tb_debug4";
	 this.tb_debug4.Size = new System.Drawing.Size(31, 20);
	 this.tb_debug4.TabIndex = 15;
	 this.tb_debug4.Text = "0";
	 // 
	 // cb_1366768
	 // 
	 this.cb_1366768.AutoSize = true;
	 this.cb_1366768.Checked = true;
	 this.cb_1366768.CheckState = System.Windows.Forms.CheckState.Checked;
	 this.cb_1366768.Location = new System.Drawing.Point(9, 199);
	 this.cb_1366768.Name = "cb_1366768";
	 this.cb_1366768.Size = new System.Drawing.Size(71, 17);
	 this.cb_1366768.TabIndex = 16;
	 this.cb_1366768.Text = "1366.768";
	 this.cb_1366768.UseVisualStyleBackColor = true;
	 // 
	 // bt_debug3
	 // 
	 this.bt_debug3.Location = new System.Drawing.Point(5, 290);
	 this.bt_debug3.Name = "bt_debug3";
	 this.bt_debug3.Size = new System.Drawing.Size(75, 23);
	 this.bt_debug3.TabIndex = 17;
	 this.bt_debug3.Text = "Gira Para:";
	 this.bt_debug3.UseVisualStyleBackColor = true;
	 this.bt_debug3.Click += new System.EventHandler(this.bt_debug3_Click);
	 // 
	 // Form1
	 // 
	 this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
	 this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	 this.ClientSize = new System.Drawing.Size(800, 450);
	 this.Controls.Add(this.bt_debug3);
	 this.Controls.Add(this.cb_1366768);
	 this.Controls.Add(this.tb_debug4);
	 this.Controls.Add(this.bt_debug2);
	 this.Controls.Add(this.tb_debug3);
	 this.Controls.Add(this.cb_12801024);
	 this.Controls.Add(this.tb_debug1);
	 this.Controls.Add(this.tb_debug2);
	 this.Controls.Add(this.bt_debug1);
	 this.Controls.Add(this.bt_getstats);
	 this.Controls.Add(this.tb_yaw);
	 this.Controls.Add(this.tb_spd);
	 this.Controls.Add(this.tb_y);
	 this.Controls.Add(this.tb_x);
	 this.Controls.Add(this.tb_mana);
	 this.Controls.Add(this.tb_hp);
	 this.Controls.Add(this.tabControl1);
	 this.Name = "Form1";
	 this.Text = "Form1";
	 this.tabControl1.ResumeLayout(false);
	 this.ResumeLayout(false);
	 this.PerformLayout();

	}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox tb_hp;
		private System.Windows.Forms.TextBox tb_mana;
		private System.Windows.Forms.TextBox tb_y;
		private System.Windows.Forms.TextBox tb_x;
		private System.Windows.Forms.TextBox tb_spd;
		private System.Windows.Forms.TextBox tb_yaw;
	private System.Windows.Forms.Button bt_getstats;
	private System.Windows.Forms.Button bt_debug1;
	private System.Windows.Forms.TextBox tb_debug1;
	private System.Windows.Forms.TextBox tb_debug2;
	private System.Windows.Forms.CheckBox cb_12801024;
	private System.Windows.Forms.TextBox tb_debug3;
	private System.Windows.Forms.Button bt_debug2;
	private System.Windows.Forms.TextBox tb_debug4;
        private System.Windows.Forms.CheckBox cb_1366768;
	private System.Windows.Forms.Button bt_debug3;
 }
}

