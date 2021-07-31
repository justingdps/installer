using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Principal;
using System.Windows.Forms;

namespace jgdpsinstaller
{
	public partial class FormMain : Form
	{
		private void Item_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				mouseDown = false;
			}
		}

		private void Item_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				mouseX = Cursor.Position.X - Left;
				mouseY = Cursor.Position.Y - Top;
				mouseDown = true;
			}
		}

		private void Item_MouseMove(object sender, MouseEventArgs e)
		{
			if (mouseDown)
				Location = new Point(Cursor.Position.X - mouseX, Cursor.Position.Y - mouseY);
		}

		private void FolderInput_TextChanged(object sender, EventArgs e)
		{
			if (FolderSelect.SelectedPath != FolderInput.Text)
				FolderSelect.SelectedPath = FolderInput.Text;
		}

		private void BtnBrowse_Click(object sender, EventArgs e)
		{
			if (FolderSelect.ShowDialog() == DialogResult.OK)
			{
				FolderInput.Text = FolderSelect.SelectedPath;
				LabelDisclaimer.Text = "Required space: 178 MB | Available space: " + GetDiskSpace();
			}
		}

		private void BtnInstall_Click(object sender, EventArgs e)
		{
			if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
				MessageBox.Show("Administrator permission is disabled.", "Administrator Permission Disabled", MessageBoxButtons.OK, MessageBoxIcon.Error);
			
			if (installed)
			{
				uninstallState = true;
				BtnInstall.Enabled = false;
				BtnInstall.Visible = false;
				InstallProgress.Enabled = true;
				InstallProgress.Visible = true;

				StartUninstall();
			}
			else
			{
				try
				{
					if (int.Parse(GetDiskSpace().Split(char.Parse(" MB"))[0].Split(char.Parse(" KB"))[0].Split(char.Parse(" B"))[0]) < 178)
						MessageBox.Show("There is not enough disk space.", "Not Enough Disk Space", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch { }

				installState = true;
				BtnInstall.Enabled = false;
				BtnBrowse.Enabled = false;
				FolderInput.Enabled = false;
				DesktopCheck.Enabled = false;
				StartMenuCheck.Enabled = false;
				BtnInstall.Visible = false;
				BtnBrowse.Visible = false;
				FolderInput.Visible = false;
				DesktopCheck.Visible = false;
				StartMenuCheck.Visible = false;
				InstallProgress.Enabled = true;
				InstallProgress.Visible = true;

				StartInstall();
			}
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (installState || uninstallState)
			{
				DialogResult confirm = MessageBox.Show("Are you sure you want to abort the installation?", "Abort Installation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

				if (confirm == DialogResult.Yes)
					Environment.Exit(0);
				if (confirm == DialogResult.No)
					e.Cancel = true;
			}
			if (finishState)
			{
				if (RunAppCheck.Checked)
					RunGDPS();

				Environment.Exit(0);
			}
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BtnClose_MouseEnter(object sender, EventArgs e)
		{
			BtnClose.BackColor = Color.LightCoral;
			BtnClose.ForeColor = Color.FromArgb(1, 19, 26);
		}

		private void BtnClose_MouseLeave(object sender, EventArgs e)
		{
			BtnClose.ForeColor = Color.LightCoral;
			BtnClose.BackColor = Color.FromArgb(1, 19, 26);
		}

		private void BtnMinimize_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}

		private void BtnMinimize_MouseEnter(object sender, EventArgs e)
		{
			BtnMinimize.BackColor = Color.White;
			BtnMinimize.ForeColor = Color.FromArgb(1, 19, 26);
		}

		private void BtnMinimize_MouseLeave(object sender, EventArgs e)
		{
			BtnMinimize.ForeColor = Color.White;
			BtnMinimize.BackColor = Color.FromArgb(1, 19, 26);
		}

		private void LabelSource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = "https://github.com/justingdps/installer",
				UseShellExecute = true
			});
		}

		private void TimerTime_Tick(object sender, EventArgs e)
		{
			tick++;

			LabelTime.Text = TimeSpan.FromSeconds(tick).ToString("hh':'mm':'ss");
		}
	}
}
