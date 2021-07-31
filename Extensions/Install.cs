using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jgdpsinstaller
{
	public partial class FormMain : Form
	{
		private void CreateShortcut(bool startMenu = false)
		{
			IWshShortcut shortcut = (IWshShortcut)new WshShell().CreateShortcut(Path.Combine(Environment.GetFolderPath(startMenu ? Environment.SpecialFolder.Programs : Environment.SpecialFolder.Desktop), "JustinGDPS.lnk"));
			shortcut.TargetPath = Path.Combine(FolderSelect.SelectedPath, "0JustinGDPS0.exe");
			shortcut.WorkingDirectory = FolderSelect.SelectedPath;

			shortcut.Save();
		}

		private async void StartInstall()
		{
			try
			{
				if (Directory.Exists(FolderSelect.SelectedPath))
				{
					if (Directory.EnumerateFileSystemEntries(FolderSelect.SelectedPath).Any())
						Directory.Delete(FolderSelect.SelectedPath, true);
				}

				if (!Directory.Exists(FolderSelect.SelectedPath))
					Directory.CreateDirectory(FolderSelect.SelectedPath);

				Directory.CreateDirectory(Path.Combine(FolderSelect.SelectedPath, "Resources"));

				await Task.Run(DownloadGDPS);
				FinishInstall();
			}
			catch (Exception err)
			{
				ErrorReport(err);
			}
		}

		private void DownloadGDPS()
		{
			try
			{
				BeginInvoke((MethodInvoker)(() => {
					TimerTime.Start();
					LabelTime.Text = "00:00:00";
					LabelProgress.Text = "Downloading...";
				}));

				Stream stream = new WebClient().OpenRead("https://www.dropbox.com/s/zh89c4g1qugkndt/JustinGDPS.zip?dl=1");

				InstallGDPS(stream);

				stream.Close();
			}
			catch (Exception err)
			{
				ErrorReport(err);
			}
		}

		private void InstallGDPS(Stream ZIP)
		{
			BeginInvoke((MethodInvoker)(() => LabelProgress.Text = "Reading..."));

			try
			{
				ZipArchive GDPS = new ZipArchive(ZIP);

				int count = 0;
				foreach (ZipArchiveEntry entry in GDPS.Entries)
				{
					count++;

					string fileName = Path.Combine(FolderSelect.SelectedPath, entry.FullName).Replace(char.Parse("/"), char.Parse("\\"));

					if (!fileName.EndsWith("Resources\\"))
					{
						BeginInvoke((MethodInvoker)(() => {
							LabelProgress.Text = "Installing... " + fileName;
							InstallProgress.Value = 100 * count / GDPS.Entries.Count;
						}));

						entry.ExtractToFile(fileName);
					}
				}

				RegisterGDPS();
			}
			catch (Exception err)
			{
				ErrorReport(err);
			}
		}

		private void RegisterGDPS()
		{
			string localPath = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\JustinGDPS\\";
			RegistryKey local = Registry.LocalMachine.OpenSubKey(localPath);

			if (local != null)
				Registry.LocalMachine.DeleteSubKey(localPath);

			local = Registry.LocalMachine.CreateSubKey(localPath);

			local.SetValue("DisplayIcon", Path.Combine(FolderSelect.SelectedPath, "0JustinGDPS0.exe"));
			local.SetValue("DisplayName", "JustinGDPS");
			local.SetValue("DisplayVersion", "1.1");
			local.SetValue("InstallLocation", FolderSelect.SelectedPath);
			local.SetValue("NoModify", 1, RegistryValueKind.DWord);
			local.SetValue("NoRepair", 1, RegistryValueKind.DWord);
			local.SetValue("Publisher", "BWBJustin");
			local.SetValue("UninstallString", Assembly.GetExecutingAssembly().Location);
		}

		private void FinishInstall()
		{
			installState = false;
			finishState = true;
			LabelProgress.Text = "";

			if (DesktopCheck.Checked)
				CreateShortcut();

			if (StartMenuCheck.Checked)
				CreateShortcut(true);

			RunAppCheck.Enabled = true;
			RunAppCheck.Visible = true;
			TimerTime.Stop();
		}

		private void RunGDPS()
		{
			Process.Start(new ProcessStartInfo
			{
				FileName = Path.Combine(FolderSelect.SelectedPath, "0JustinGDPS0.exe"),
				WorkingDirectory = FolderSelect.SelectedPath
			});
		}

		private async void StartUninstall()
		{
			LabelTime.Text = "00:00:00";
			TimerTime.Start();

			await Task.Run(UninstallGDPS);
			FinishUninstall();
		}

		private void UninstallGDPS()
		{
			try
			{
				string localPath = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\JustinGDPS\\";
				RegistryKey local = Registry.LocalMachine.OpenSubKey(localPath);
				string path = (string)local.GetValue("InstallLocation");

				if (Directory.Exists(path) && Directory.EnumerateFileSystemEntries(path).Any())
					Directory.Delete(path, true);

				Registry.LocalMachine.DeleteSubKey(localPath);
			}
			catch (Exception err)
			{
				ErrorReport(err);
			}
		}

		private void FinishUninstall()
		{
			uninstallState = false;
			finishState = true;
			InstallProgress.Value = 100;
			TimerTime.Stop();
		}
	}
}
