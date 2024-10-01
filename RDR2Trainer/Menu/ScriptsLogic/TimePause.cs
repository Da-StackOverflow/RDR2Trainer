using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class TimePause(string caption) : SwitchItem(caption)
	{
		protected override void OnActive()
		{
			PAUSE_CLOCK(true, 0);
		}

		protected override void OnInactive()
		{
			PAUSE_CLOCK(false, 0);
		}

		protected override void OnUpdate()
		{
			
		}
	}
}
