using System;
using System.IO;
using System.Windows.Forms;

namespace CopyTool
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			if (File.Exists("dirSave"))
			{
				DirInput.Text = File.ReadAllText("dirSave");
			}
            else
            {
				DirInput.Text = DesPath;
			}
			DirInput.Select(DirInput.Text.Length, 0);

		}

		private const string DesPath = "D:/SteamLibrary/steamapps/common/RedDeadRedemption2";
		private const string AsiPath = "Bridge.asi";
		private const string DllPath = "RDR2Trainer.dll";


		private void Save()
		{
			var dir = DirInput.Text;
			if (!string.IsNullOrWhiteSpace(dir))
			{
				File.WriteAllText("dirSave", dir);
			}
		}

		private void CopyAll_Click(object sender, EventArgs e)
		{
			try
			{
				Save();
				var dir = DirInput.Text;
				File.Copy(AsiPath, $"{dir}/RDR2Asi.asi", true);
				File.Copy(DllPath, $"{dir}/RDR2Script.dll", true);
				MessageBox.Show("复制成功");
			}
			catch(Exception ex) {
				MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
			}
		}

		private void CopyDll_Click(object sender, EventArgs e)
		{
			try
			{
				Save();
				var dir = DirInput.Text;
				File.Copy(DllPath, $"{dir}/RDR2Script.dll", true);
				MessageBox.Show("复制成功");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex.Message}\n{ex.StackTrace}");
			}
		}
	}
}
