using System.IO;

namespace RDR2Trainer.Menu
{
	internal abstract class MenuItem(int width, int height, Color bgColor, Color textColor, string text)
	{
		protected readonly static int PlayerPed;
		protected readonly static int PlayerID;

		public float Width { get; set; } = width / 1000.0f;
		public float Height { get; set; } = height / 1000.0f;

		public Color _bgColor = bgColor;
		public ref Color BgColor => ref _bgColor;

		public Color _textColor = textColor;
		public ref Color TextColor => ref _textColor;

		public virtual string Text { get; set; } = text;

		protected Vector2 _position;
		public ref Vector2 Position => ref _position;

		protected Vector2 _textPosition;
		public ref Vector2 TextPosition => ref _textPosition;

		protected Vector2 _scale = new() { X = 0, Y = height / 1000.0f * 8.0f };
		public ref Vector2 Scale => ref _scale;

		public Menu Menu { get; set; }

		static MenuItem()
		{
			PlayerPed = Function.PLAYER_PED_ID();
			PlayerID = Function.PLAYER_ID();
		}

		public void WaitAndDraw(long ms)
		{
			MenuController.Instance.WaitAndDraw(ms);
		}

		public void SetTips(string text, int ms = 2500)
		{
			MenuController.Instance.SetTips(text, ms);
		}

		public virtual void OnDraw(bool active = false)
		{
			Function.DrawText(Text, TextPosition, Scale, TextColor);
			Function.DrawBackground(Position, Width, Height, BgColor);
		}

		public abstract void OnExecute();
	}
}
