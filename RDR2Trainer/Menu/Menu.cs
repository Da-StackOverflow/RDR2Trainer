using System;
using System.Collections.Generic;

namespace RDR2Trainer.Menu
{
	internal class Menu(string tittle)
	{
		public readonly string ID = tittle;
		public TitleItem Tittle = new(tittle);
		private readonly List<MenuItem> _items = [];
		private readonly List<SwitchItem> _switchItems = [];
		private int _activeItemInActivePage = 0;
		private int _activePage = 0;
		private int _itemCount = 0;
		private int _switchItemCount = 0;

		private const int ItemsMaxCountPerPage = 15;

		public void AddItem(TriggerItem item)
		{
			int index = _items.Count % ItemsMaxCountPerPage;
			item.Position = new(item.Width / 2.0f, item.Height * index + 0.08f);
			item.TextPosition = new Vector2(0.01f, item.Position.Y - item.Height / 4.0f);
			item.BgColor = (_items.Count & 1) == 0 ? Color.White : Color.Yellow;
			_items.Add(item);
			_itemCount++;
		}

		public void AddItem(SubMenu item)
		{
			int index = _items.Count % ItemsMaxCountPerPage;
			item.Position = new(item.Width / 2.0f, item.Height * index + 0.08f);
			item.TextPosition = new Vector2(0.01f, item.Position.Y - item.Height / 4.0f);
			item.BgColor = (_items.Count & 1) == 0 ? Color.White : Color.Yellow;
			_items.Add(item);
			_itemCount++;
		}

		public void AddItem(SwitchItem item)
		{
			int index = _items.Count % ItemsMaxCountPerPage;
			item.Position = new(item.Width / 2.0f, item.Height * index + 0.08f);
			item.TextPosition = new Vector2(0.01f, item.Position.Y - item.Height / 4.0f);
			item.BgColor = (_items.Count & 1) == 0 ? Color.White : Color.Yellow;
			item.ActiveTextPosition = new Vector2 { X = 0.15f, Y = item.TextPosition.Y };
			_items.Add(item);
			_switchItems.Add(item);
			_itemCount++;
			_switchItemCount++;
		}

		public int ActiveItemIndex { get { return _activePage * ItemsMaxCountPerPage + _activeItemInActivePage; } }

		public void OnDraw()
		{
			Tittle.OnDraw();
			int end = Math.Min(_items.Count, (_activePage + 1) * ItemsMaxCountPerPage);
			int index = 0;
			for (int i = _activePage * ItemsMaxCountPerPage; i < end; i++)
			{
				_items[i].OnDraw(_activeItemInActivePage == index);
				index++;
			}
		}

		public void OnSwitchItemUpdate()
		{
			for (int i = 0; i < _switchItemCount; i++)
			{
				_switchItems[i].Update();
			}
		}

		public void OnInput(KeyCode key)
		{
			int itemsLeft = _itemCount % ItemsMaxCountPerPage;
			int pageCount = _itemCount / ItemsMaxCountPerPage + (itemsLeft != 0 ? 1 : 0);
			int lineCountLastPage = itemsLeft > 0 ? itemsLeft : ItemsMaxCountPerPage;

			switch (key)
			{
				case KeyCode.Return:
					_items[ActiveItemIndex].OnExecute();
					break;
				case KeyCode.Up:
					if (_activePage != pageCount - 1)
					{
						_activeItemInActivePage = (_activeItemInActivePage + ItemsMaxCountPerPage - 1) % ItemsMaxCountPerPage;
					}
					else
					{
						_activeItemInActivePage = (_activeItemInActivePage + lineCountLastPage - 1) % lineCountLastPage;
					}
					break;
				case KeyCode.Down:
					if (_activePage != pageCount - 1)
					{
						_activeItemInActivePage = (_activeItemInActivePage + 1) % ItemsMaxCountPerPage;
					}
					else
					{
						_activeItemInActivePage = (_activeItemInActivePage + 1) % lineCountLastPage;
					}
					break;
				case KeyCode.Left:
					_activePage = (_activePage + pageCount - 1) % pageCount;
					_activeItemInActivePage = 0;
					break;
				case KeyCode.Right:
					_activePage = (_activePage + 1) % pageCount;
					_activeItemInActivePage = 0;
					break;
				case KeyCode.Back:
					break;
			}
		}
	}
}
