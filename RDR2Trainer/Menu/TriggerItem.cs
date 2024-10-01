namespace RDR2Trainer.Menu
{
	internal abstract class TriggerItem(string text) : MenuItem(200, 40, Color.White, Color.Blue, text)
	{
		private Color _bgActiveColor = Color.Green;
		public ref Color BgActiveColor => ref _bgActiveColor;

		private Color _textActiveColor = Color.Red;
		public ref Color TextActiveColor => ref _textActiveColor;

		public override void OnDraw(bool active = false)
		{
			Function.DrawText(Text, TextPosition, Scale, active ? TextActiveColor : TextColor);
			Function.DrawBackground(Position, Width, Height, active ? BgActiveColor : BgColor);
		}
	}
}
