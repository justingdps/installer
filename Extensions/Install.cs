using IWshRuntimeLibrary;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jgdpsinstaller
{
	public partial class FormMain : Form
	{
		private void CreateShortcut(string type, string pathType)
		{
			WshShell shell = new WshShell();
			dynamic rawShortcut = null;

			if (type == "DESKTOP")
				rawShortcut = shell.CreateShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), pathType == "GDPS" ? "JustinGDPS.lnk" : "Mega Hack JustinGDPS.lnk"));

			else if (type == "STARTMENU")
				rawShortcut = shell.CreateShortcut(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs), pathType == "GDPS" ? "JustinGDPS.lnk" : "Mega Hack JustinGDPS.lnk"));

			IWshShortcut shortcut = (IWshShortcut)rawShortcut;
			shortcut.TargetPath = pathType == "GDPS" ? Path.Combine(FolderSelect.SelectedPath, "0JustinGDPS0.exe") : Path.Combine(FolderSelect.SelectedPath, "MegaHack", "MegaHack.exe");

			shortcut.Save();
		}

		private async void StartInstall()
		{
			if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
			{
				MessageBox.Show("Administrator permission is disabled.", "Administrator Permission", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(0);
			}

			try
			{
				if (Directory.Exists(FolderSelect.SelectedPath))
				{
					if (Directory.EnumerateFileSystemEntries(FolderSelect.SelectedPath).Any())
						Directory.Delete(FolderSelect.SelectedPath, true);
				}

				if (!Directory.Exists(FolderSelect.SelectedPath))
					Directory.CreateDirectory(FolderSelect.SelectedPath);

				InstallProgress.Style = ProgressBarStyle.Marquee;
				InstallProgress.Enabled = true;

				await Task.Run(InstallGDPS);
				FinishInstall();
			}
			catch (Exception err)
			{
				ErrorReport(err);
			}
		}

		private void InstallGDPS()
		{
			try
			{
				new ZipArchive(Assembly.GetExecutingAssembly().GetManifestResourceStream("jgdpsinstaller.JustinGDPS.zip")).ExtractToDirectory(FolderSelect.SelectedPath);
			}
			catch (Exception err)
			{
				ErrorReport(err);
			}
		}

		private void FinishInstall()
		{
			InstallProgress.Style = ProgressBarStyle.Blocks;
			InstallProgress.Value = 100;
			installState = false;
			finishState = true;

			if (DesktopCheck.Checked)
				CreateShortcut("DESKTOP", "GDPS");

			if (StartMenuCheck.Checked)
				CreateShortcut("STARTMENU", "GDPS");

			if (MHDesktopCheck.Checked)
				CreateShortcut("DESKTOP", "MEGAHACK");

			if (MHStartMenuCheck.Checked)
				CreateShortcut("STARTMENU", "MEGAHACK");

			RunAppCheck.Enabled = true;
			RunAppCheck.Visible = true;
		}

		private void RunGDPS()
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = Path.Combine(FolderSelect.SelectedPath, "0JustinGDPS0.exe"),
				WorkingDirectory = FolderSelect.SelectedPath
			});
		}
	}
}
