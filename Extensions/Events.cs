using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;

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
				LabelDisclaimer.Text = "Required space: 230 MB | Available space: " + GetDiskSpace();
			}
		}

		private void BtnInstall_Click(object sender, EventArgs e)
		{
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
			MHDesktopCheck.Visible = false;
			MHStartMenuCheck.Visible = false;
			InstallProgress.Enabled = true;
			InstallProgress.Visible = true;

			StartInstall();
		}

		private void GDPS_ExtractProgress(object sender, ExtractProgressEventArgs e)
		{
			if (e.CurrentEntry != null)
				LabelProgress.Invoke((MethodInvoker)(() => LabelProgress.Text = e.CurrentEntry.FileName));

			if (e.EventType == ZipProgressEventType.Extracting_BeforeExtractEntry)
			{
				filesExtracted++;
				InstallProgress.Invoke((MethodInvoker)(() => InstallProgress.Value = 100 * filesExtracted / totalFiles));
			}
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (installState)
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
	}
}
