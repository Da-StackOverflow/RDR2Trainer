namespace RDR2Trainer.Menu
{
	internal class SubMenu : MenuItem
	{
		private Color _bgActiveColor;
		public ref Color BgActiveColor => ref _bgActiveColor;

		private Color _textActiveColor;
		public ref Color TextActiveColor => ref _textActiveColor;

		public SubMenu(string text, Menu menu) : base(200, 40, Color.White, Color.Blue, text)
		{
			Menu = menu;
			_bgActiveColor = Color.Green;
			_textActiveColor = Color.Red;
		}

		public override void OnDraw(bool active = false)
		{
			Function.DrawText(Text, TextPosition, Scale, active ? TextActiveColor : TextColor);
			Function.DrawBackground(Position, Width, Height, active ? BgActiveColor : BgColor);
		}

		public override void OnExecute()
		{
			MenuController.Instance.PushMenu(Menu);
		}
	}
}
