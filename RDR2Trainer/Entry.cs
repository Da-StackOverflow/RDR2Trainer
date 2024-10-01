using System;
using System.IO;
using RDR2Trainer;
using RDR2Trainer.Menu;

public class Entry
{
	private static StreamWriter _logWriter;

	public static void Log(string message)
	{
		_logWriter.WriteLine($"{message}");
	}

	public void OnStart()
	{
		_logWriter = new("RDR2Trainer.log")
		{
			AutoFlush = true
		};
		Log("加载脚本");
		MenuController.Instance.CreateMainMenu();
	}

	public void OnClose()
	{
		Log("卸载脚本");
		_logWriter.Flush();
		_logWriter.Close();
		_logWriter = null;
		Native.Release();
	}

	public static void OnGameFrame()
	{
		try
		{
			if (MenuController.Instance.GetActiveMenu() == null && Input.MenuSwitchPressed())
			{
				MenuController.Instance.PushMenu(MenuController.Instance.CreateMainMenu());
			}
			MenuController.Instance.Update();
		}
		catch(Exception e)
		{
			Log($"{e.Message}\n{e.StackTrace}");
		}
	}

	public static void OnReceiveInputMessage(uint key, bool isUpNow)
	{
		Input.OnKeyboardMessage(key, isUpNow);
	}
}
