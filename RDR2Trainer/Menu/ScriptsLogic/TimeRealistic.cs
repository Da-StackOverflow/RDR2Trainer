using System;
using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class TimeRealistic(string caption) : SwitchItem(caption)
	{
		private int _seconds = 0;

		protected override void OnActive()
		{
			var now = DateTime.Now;
			var h = (GET_CLOCK_HOURS() - now.Hour) * 3600;
			var m = (GET_CLOCK_MINUTES() - now.Minute) * 60;
			var s = GET_CLOCK_SECONDS() - now.Second;
			_seconds = h + m + s;
		}

		protected override void OnInactive()
		{

		}

		protected override void OnUpdate()
		{
			var now = DateTime.Now;
			var time = now.AddSeconds(_seconds);
			SET_CLOCK_TIME(time.Hour, time.Minute, time.Second);
		}
	}
}
