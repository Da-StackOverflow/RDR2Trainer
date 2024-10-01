namespace RDR2Trainer.Menu
{
	internal abstract class SwitchItem(string text) : MenuItem(200, 40, Color.White, Color.Blue, text)
	{
		private Color _bgActiveColor = Color.Green;
		public ref Color BgActiveColor => ref _bgActiveColor;

		private Color _textActiveColor = Color.Red;
		public ref Color TextActiveColor => ref _textActiveColor;
		public bool State { get; set; }

		private Color _stateActiveColor;
		public ref Color StateActiveColor => ref _stateActiveColor;

		private Color _stateInactiveColor;
		public ref Color StateInactiveColor => ref _stateInactiveColor;

		private static readonly string ActiveString = "[已开启]";
		private static readonly string InactiveString = "[已关闭]";

		private Vector2 _activeTextPosition;
		public ref Vector2 ActiveTextPosition => ref _activeTextPosition;

		public override void OnDraw(bool active = false)
		{
			Function.DrawText(Text, TextPosition, Scale, active ? TextActiveColor : TextColor);
			Function.DrawBackground(Position, Width, Height, active ? BgActiveColor : BgColor);
			Function.DrawText(State ? ActiveString : InactiveString, _activeTextPosition, Scale, active ? TextActiveColor : (State ? StateActiveColor : StateInactiveColor));
		}

		public override void OnExecute()
		{
			State = !State;
			if (State)
			{
				OnActive();
				OnUpdate();
			}
			else
			{
				OnInactive();
			}
		}
		protected virtual void OnActive() { }
		protected virtual void OnInactive() { }

		public void Update()
		{
			if (State)
			{
				OnUpdate();
			}
		}

		protected abstract void OnUpdate();
	}
}
