using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace jgdpsinstaller
{
	public partial class FormMain : Form
	{
		private bool installState = false;
		private bool uninstallState = false;
		private bool finishState = false;
		private bool mouseDown = false;
		private readonly bool installed = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\JustinGDPS") != null;

		private int mouseX = 0;
		private int mouseY = 0;
		private int tick = 0;

		public FormMain()
		{
			InitializeComponent();
			if (installed)
			{
				BtnBrowse.Enabled = false;
				FolderInput.Enabled = false;
				DesktopCheck.Enabled = false;
				StartMenuCheck.Enabled = false;
				LabelDisclaimer.Enabled = false;
				BtnBrowse.Visible = false;
				FolderInput.Visible = false;
				DesktopCheck.Visible = false;
				StartMenuCheck.Visible = false;
				LabelDisclaimer.Visible = false;

				BtnInstall.Text = "Uninstall";
				BtnInstall.BackColor = Color.LightCoral;
			}
			else
			{
				FolderInput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "JustinGDPS");
				FolderSelect.SelectedPath = FolderInput.Text;
				LabelDisclaimer.Text += GetDiskSpace();
			}
		}

		private string GetDiskSpace()
		{
			try
			{
				string diskName = FolderSelect.SelectedPath.Split(char.Parse("\\"))[0];
				DriveInfo disk = Array.Find(DriveInfo.GetDrives(), (DriveInfo x) => x.Name.StartsWith(diskName));

				decimal bytes = disk.AvailableFreeSpace;
				decimal kilobytes = Math.Floor(bytes / 1024);
				decimal megabytes = Math.Floor(kilobytes / 1024);
				decimal gigabytes = Math.Floor(megabytes / 1024);
				decimal terabytes = Math.Floor(gigabytes / 1024);

				string byteValues_bytes = bytes + " B";
				string byteValues_kilobytes = "";
				string byteValues_megabytes = "";
				string byteValues_gigabytes = "";
				string byteValues_terabytes = "";

				if (kilobytes >= 1) byteValues_kilobytes = kilobytes + " KB";
				if (megabytes >= 1) byteValues_megabytes = megabytes + " MB";
				if (gigabytes >= 1) byteValues_gigabytes = gigabytes + " GB";
				if (terabytes >= 1) byteValues_terabytes = terabytes + " TB";

				if (byteValues_terabytes != "") return byteValues_terabytes;
				else
				{
					if (byteValues_gigabytes != "") return byteValues_gigabytes;
					else
					{
						if (byteValues_megabytes != "") return byteValues_megabytes;
						else
						{
							if (byteValues_kilobytes != "") return byteValues_kilobytes;
							else return byteValues_bytes;
						}
					}
				}
			}
			catch
			{
				return "Unknown";
			}
		}

		private void ErrorReport(Exception err)
		{
			MessageBox.Show(err.ToString() + "\n\nPlease use Ctrl+C and report error to https://github.com/justingdps/installer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			Environment.Exit(1);
		}
	}
}
