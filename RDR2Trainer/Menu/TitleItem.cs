namespace RDR2Trainer.Menu
{
	internal class TitleItem : MenuItem
	{
		public TitleItem(string text) : base(200, 60, Color.Cyan, Color.Blue, text)
		{
			Position = new Vector2(Width / 2.0f, Height / 2.0f);
			_textPosition = new Vector2(0.01f, Position.Y - Height / 4.0f);
		}

		public override void OnExecute()
		{
			
		}
	}
}
