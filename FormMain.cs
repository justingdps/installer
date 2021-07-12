using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace jgdpsinstaller
{
	public partial class FormMain : Form
	{
		private bool installState = false;
		private bool finishState = false;
		private bool mouseDown = false;

		private int mouseX = 0;
		private int mouseY = 0;

		public FormMain()
		{
			InitializeComponent();
			FolderInput.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "JustinGDPS");
			FolderSelect.SelectedPath = FolderInput.Text;
			LabelDisclaimer.Text += GetDiskSpace();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			try
			{
				WebClient client = new WebClient();

				if (client.DownloadString("https://bwbjustin.7m.pl/justingdps/Version.txt") != "1.0")
				{
					if (MessageBox.Show("An update is available. Would you like to install it?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
					{
						Process.Start(new ProcessStartInfo
						{
							FileName = "https://bwbjustin.7m.pl/justingdps/download/Setup.exe",
							UseShellExecute = true
						});
						Close();
					}
				}
			}
			catch { }
		}

		private string GetDiskSpace()
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

		private void ErrorReport(Exception err)
		{
			MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			Environment.Exit(1);
		}
	}
}
