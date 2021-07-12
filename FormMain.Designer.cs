
namespace jgdpsinstaller
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.FolderInput = new System.Windows.Forms.TextBox();
			this.BtnBrowse = new System.Windows.Forms.Button();
			this.FolderSelect = new System.Windows.Forms.FolderBrowserDialog();
			this.DesktopCheck = new System.Windows.Forms.CheckBox();
			this.StartMenuCheck = new System.Windows.Forms.CheckBox();
			this.RunAppCheck = new System.Windows.Forms.CheckBox();
			this.MHDesktopCheck = new System.Windows.Forms.CheckBox();
			this.MHStartMenuCheck = new System.Windows.Forms.CheckBox();
			this.LabelDisclaimer = new System.Windows.Forms.Label();
			this.PanelToolbar = new System.Windows.Forms.Panel();
			this.BtnMinimize = new System.Windows.Forms.Button();
			this.BtnClose = new System.Windows.Forms.Button();
			this.BtnInstall = new System.Windows.Forms.Button();
			this.LabelSource = new System.Windows.Forms.LinkLabel();
			this.PBLogo = new System.Windows.Forms.PictureBox();
			this.InstallProgress = new System.Windows.Forms.ProgressBar();
			this.PanelToolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PBLogo)).BeginInit();
			this.SuspendLayout();
			// 
			// FolderInput
			// 
			this.FolderInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(29)))), ((int)(((byte)(36)))));
			this.FolderInput.ForeColor = System.Drawing.Color.White;
			this.FolderInput.Location = new System.Drawing.Point(124, 400);
			this.FolderInput.MaxLength = 260;
			this.FolderInput.Name = "FolderInput";
			this.FolderInput.Size = new System.Drawing.Size(450, 20);
			this.FolderInput.TabIndex = 8;
			// 
			// BtnBrowse
			// 
			this.BtnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnBrowse.ForeColor = System.Drawing.Color.White;
			this.BtnBrowse.Location = new System.Drawing.Point(580, 400);
			this.BtnBrowse.Name = "BtnBrowse";
			this.BtnBrowse.Size = new System.Drawing.Size(75, 21);
			this.BtnBrowse.TabIndex = 9;
			this.BtnBrowse.Text = "Browse";
			this.BtnBrowse.UseVisualStyleBackColor = true;
			this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
			// 
			// DesktopCheck
			// 
			this.DesktopCheck.AutoSize = true;
			this.DesktopCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(29)))), ((int)(((byte)(36)))));
			this.DesktopCheck.Checked = true;
			this.DesktopCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DesktopCheck.ForeColor = System.Drawing.Color.White;
			this.DesktopCheck.Location = new System.Drawing.Point(125, 425);
			this.DesktopCheck.Name = "DesktopCheck";
			this.DesktopCheck.Size = new System.Drawing.Size(109, 17);
			this.DesktopCheck.TabIndex = 11;
			this.DesktopCheck.Text = "Desktop Shortcut";
			this.DesktopCheck.UseVisualStyleBackColor = false;
			// 
			// StartMenuCheck
			// 
			this.StartMenuCheck.AutoSize = true;
			this.StartMenuCheck.Checked = true;
			this.StartMenuCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.StartMenuCheck.ForeColor = System.Drawing.Color.White;
			this.StartMenuCheck.Location = new System.Drawing.Point(125, 450);
			this.StartMenuCheck.Name = "StartMenuCheck";
			this.StartMenuCheck.Size = new System.Drawing.Size(121, 17);
			this.StartMenuCheck.TabIndex = 12;
			this.StartMenuCheck.Text = "Start Menu Shortcut";
			this.StartMenuCheck.UseVisualStyleBackColor = true;
			// 
			// RunAppCheck
			// 
			this.RunAppCheck.AutoSize = true;
			this.RunAppCheck.Enabled = false;
			this.RunAppCheck.ForeColor = System.Drawing.Color.White;
			this.RunAppCheck.Location = new System.Drawing.Point(125, 436);
			this.RunAppCheck.Name = "RunAppCheck";
			this.RunAppCheck.Size = new System.Drawing.Size(106, 17);
			this.RunAppCheck.TabIndex = 13;
			this.RunAppCheck.Text = "Run JustinGDPS";
			this.RunAppCheck.UseVisualStyleBackColor = true;
			this.RunAppCheck.Visible = false;
			// 
			// MHDesktopCheck
			// 
			this.MHDesktopCheck.AutoSize = true;
			this.MHDesktopCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MHDesktopCheck.Checked = true;
			this.MHDesktopCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MHDesktopCheck.ForeColor = System.Drawing.Color.White;
			this.MHDesktopCheck.Location = new System.Drawing.Point(481, 425);
			this.MHDesktopCheck.Name = "MHDesktopCheck";
			this.MHDesktopCheck.Size = new System.Drawing.Size(174, 17);
			this.MHDesktopCheck.TabIndex = 14;
			this.MHDesktopCheck.Text = "Desktop Shortcut (Mega Hack)";
			this.MHDesktopCheck.UseVisualStyleBackColor = true;
			// 
			// MHStartMenuCheck
			// 
			this.MHStartMenuCheck.AutoSize = true;
			this.MHStartMenuCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MHStartMenuCheck.Checked = true;
			this.MHStartMenuCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MHStartMenuCheck.ForeColor = System.Drawing.Color.White;
			this.MHStartMenuCheck.Location = new System.Drawing.Point(469, 450);
			this.MHStartMenuCheck.Name = "MHStartMenuCheck";
			this.MHStartMenuCheck.Size = new System.Drawing.Size(186, 17);
			this.MHStartMenuCheck.TabIndex = 15;
			this.MHStartMenuCheck.Text = "Start Menu Shortcut (Mega Hack)";
			this.MHStartMenuCheck.UseVisualStyleBackColor = true;
			// 
			// LabelDisclaimer
			// 
			this.LabelDisclaimer.AutoSize = true;
			this.LabelDisclaimer.ForeColor = System.Drawing.Color.White;
			this.LabelDisclaimer.Location = new System.Drawing.Point(12, 485);
			this.LabelDisclaimer.Name = "LabelDisclaimer";
			this.LabelDisclaimer.Size = new System.Drawing.Size(214, 13);
			this.LabelDisclaimer.TabIndex = 20;
			this.LabelDisclaimer.Text = "Required space: 230 MB | Available space: ";
			// 
			// PanelToolbar
			// 
			this.PanelToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
			this.PanelToolbar.Controls.Add(this.BtnMinimize);
			this.PanelToolbar.Controls.Add(this.BtnClose);
			this.PanelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
			this.PanelToolbar.Location = new System.Drawing.Point(0, 0);
			this.PanelToolbar.Name = "PanelToolbar";
			this.PanelToolbar.Size = new System.Drawing.Size(800, 50);
			this.PanelToolbar.TabIndex = 21;
			this.PanelToolbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Item_MouseDown);
			this.PanelToolbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Item_MouseMove);
			this.PanelToolbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Item_MouseUp);
			// 
			// BtnMinimize
			// 
			this.BtnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
			this.BtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnMinimize.ForeColor = System.Drawing.Color.White;
			this.BtnMinimize.Location = new System.Drawing.Point(694, 0);
			this.BtnMinimize.Name = "BtnMinimize";
			this.BtnMinimize.Size = new System.Drawing.Size(50, 50);
			this.BtnMinimize.TabIndex = 24;
			this.BtnMinimize.Text = "-";
			this.BtnMinimize.UseVisualStyleBackColor = false;
			this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
			this.BtnMinimize.MouseEnter += new System.EventHandler(this.BtnMinimize_MouseEnter);
			this.BtnMinimize.MouseLeave += new System.EventHandler(this.BtnMinimize_MouseLeave);
			// 
			// BtnClose
			// 
			this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(19)))), ((int)(((byte)(26)))));
			this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnClose.ForeColor = System.Drawing.Color.LightCoral;
			this.BtnClose.Location = new System.Drawing.Point(750, 0);
			this.BtnClose.Name = "BtnClose";
			this.BtnClose.Size = new System.Drawing.Size(50, 50);
			this.BtnClose.TabIndex = 23;
			this.BtnClose.Text = "X";
			this.BtnClose.UseVisualStyleBackColor = false;
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			this.BtnClose.MouseEnter += new System.EventHandler(this.BtnClose_MouseEnter);
			this.BtnClose.MouseLeave += new System.EventHandler(this.BtnClose_MouseLeave);
			// 
			// BtnInstall
			// 
			this.BtnInstall.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.BtnInstall.Cursor = System.Windows.Forms.Cursors.Hand;
			this.BtnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.BtnInstall.ForeColor = System.Drawing.Color.White;
			this.BtnInstall.Location = new System.Drawing.Point(688, 471);
			this.BtnInstall.Name = "BtnInstall";
			this.BtnInstall.Size = new System.Drawing.Size(100, 30);
			this.BtnInstall.TabIndex = 22;
			this.BtnInstall.Text = "Install";
			this.BtnInstall.UseVisualStyleBackColor = false;
			this.BtnInstall.Click += new System.EventHandler(this.BtnInstall_Click);
			// 
			// LabelSource
			// 
			this.LabelSource.ActiveLinkColor = System.Drawing.Color.Blue;
			this.LabelSource.AutoSize = true;
			this.LabelSource.DisabledLinkColor = System.Drawing.Color.Blue;
			this.LabelSource.LinkColor = System.Drawing.Color.Blue;
			this.LabelSource.Location = new System.Drawing.Point(12, 62);
			this.LabelSource.Name = "LabelSource";
			this.LabelSource.Size = new System.Drawing.Size(69, 13);
			this.LabelSource.TabIndex = 23;
			this.LabelSource.TabStop = true;
			this.LabelSource.Text = "Source Code";
			this.LabelSource.VisitedLinkColor = System.Drawing.Color.Blue;
			this.LabelSource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabelSource_LinkClicked);
			// 
			// PBLogo
			// 
			this.PBLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.PBLogo.Image = global::jgdpsinstaller.Properties.Resources.jgdps_modern;
			this.PBLogo.Location = new System.Drawing.Point(245, 62);
			this.PBLogo.Name = "PBLogo";
			this.PBLogo.Size = new System.Drawing.Size(300, 300);
			this.PBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.PBLogo.TabIndex = 0;
			this.PBLogo.TabStop = false;
			// 
			// InstallProgress
			// 
			this.InstallProgress.Enabled = false;
			this.InstallProgress.Location = new System.Drawing.Point(125, 400);
			this.InstallProgress.MarqueeAnimationSpeed = 1;
			this.InstallProgress.Name = "InstallProgress";
			this.InstallProgress.Size = new System.Drawing.Size(530, 21);
			this.InstallProgress.TabIndex = 24;
			this.InstallProgress.Visible = false;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(29)))), ((int)(((byte)(36)))));
			this.ClientSize = new System.Drawing.Size(800, 510);
			this.Controls.Add(this.InstallProgress);
			this.Controls.Add(this.LabelSource);
			this.Controls.Add(this.BtnInstall);
			this.Controls.Add(this.PanelToolbar);
			this.Controls.Add(this.LabelDisclaimer);
			this.Controls.Add(this.MHStartMenuCheck);
			this.Controls.Add(this.MHDesktopCheck);
			this.Controls.Add(this.RunAppCheck);
			this.Controls.Add(this.StartMenuCheck);
			this.Controls.Add(this.DesktopCheck);
			this.Controls.Add(this.BtnBrowse);
			this.Controls.Add(this.FolderInput);
			this.Controls.Add(this.PBLogo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "JustinGDPS Installer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.PanelToolbar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.PBLogo)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox PBLogo;
		private System.Windows.Forms.TextBox FolderInput;
		private System.Windows.Forms.Button BtnBrowse;
		private System.Windows.Forms.FolderBrowserDialog FolderSelect;
		private System.Windows.Forms.CheckBox DesktopCheck;
		private System.Windows.Forms.CheckBox StartMenuCheck;
		private System.Windows.Forms.CheckBox RunAppCheck;
		private System.Windows.Forms.CheckBox MHDesktopCheck;
		private System.Windows.Forms.CheckBox MHStartMenuCheck;
		private System.Windows.Forms.Label LabelDisclaimer;
		private System.Windows.Forms.Panel PanelToolbar;
		private System.Windows.Forms.Button BtnClose;
		private System.Windows.Forms.Button BtnInstall;
		private System.Windows.Forms.LinkLabel LabelSource;
		private System.Windows.Forms.Button BtnMinimize;
		private System.Windows.Forms.ProgressBar InstallProgress;
	}
}

