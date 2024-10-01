using System.Collections.Generic;

using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu
{
	internal partial class MenuController
	{
		private readonly Stack<Menu> _menuStack = [];
		private readonly Dictionary<string, Menu> _menuList = [];
		private string _statusText;
		private long _nextCanInputTime;
		private long _statusTextMaxTicks;

		private static readonly MenuController _instance = new();
		public static MenuController Instance { get => _instance; }

		private MenuController()
		{
			_nextCanInputTime = 0;
			_statusTextMaxTicks = 0;
			_statusText = "";
		}

		public void Update()
		{
			OnDraw();
			OnInput();
			OnExecuteHookFunction();
		}

		public void PushMenu(Menu menu)
		{
			if (menu != null)
			{
				_menuStack.Push(menu);
			}
		}

		public void PopMenu()
		{
			_menuStack.Pop();
		}

		public void Register(Menu menu)
		{
			try
			{
				_menuList.Add(menu.ID, menu);
			}
			catch (System.Exception e) 
			{
				Entry.Log($"{menu.ID},   {e}");
			}
		}

		public Menu GetMenu(string id)
		{
			if (_menuList.TryGetValue(id, out var menu))
			{
				return menu;
			}
			return null;
		}

		public Menu GetActiveMenu()
		{
			return _menuStack.Count > 0 ? _menuStack.Peek() : null;
		}

		public void SetTips(string text, long ms)
		{
			_statusText = text;
			_statusTextMaxTicks = Native.GetTickCount() + ms;
		}

		private void DrawTips()
		{
			if (Native.GetTickCount() < _statusTextMaxTicks)
			{
				DrawText(_statusText, 0.5f, 0.5f, 0.5f, 0.5f, Color.White);
			}
		}

		private void InputWait(long ms)
		{
			if(ms <= 0)
			{
				return;
			}
			_nextCanInputTime = Native.GetTickCount() + ms;
		}

		private bool InputIsOnWait()
		{
			return _nextCanInputTime > Native.GetTickCount();
		}

		private void OnDraw()
		{
			GetActiveMenu()?.OnDraw();
			DrawTips();
		}

		private void OnInput()
		{
			if (InputIsOnWait())
			{
				return;
			}
			var menu = GetActiveMenu();
			if (menu is not null)
			{
				var waitTime = ExcuteInput(menu);
				InputWait(waitTime);
			}
		}

		public int ExcuteInput(Menu menu)
		{
			if (Input.IsAccept())
			{
				menu.OnInput(KeyCode.Return);
				return 150;
			}
			else if (Input.IsBack())
			{
				PopMenu();
				return 200;
			}
			else if (Input.IsUp())
			{
				menu.OnInput(KeyCode.Up);
				return 150;
			}
			else if (Input.IsDown())
			{
				menu.OnInput(KeyCode.Down);
				return 150;
			}
			else if (Input.IsLeft())
			{
				menu.OnInput(KeyCode.Left);
				return 150;
			}
			else if (Input.IsRight())
			{
				menu.OnInput(KeyCode.Right);
				return 150;
			}
			return 0;
		}

		private void OnExecuteHookFunction()
		{
			foreach (var menu in _menuList.Values)
			{
				menu.OnSwitchItemUpdate();
			}
		}

		public void WaitAndDraw(long ms)
		{
			long time = Native.GetTickCount() + ms;
			bool waited = false;
			while (Native.GetTickCount() < time || !waited)
			{
				Native.Sleep(1);
				waited = true;
				OnDraw();
			}
		}
	}
}
