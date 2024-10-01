using System;
using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class TimeSystemSynced(string caption) : SwitchItem(caption)
	{
		protected override void OnUpdate()
		{
			var now = DateTime.Now;
			SET_CLOCK_TIME(now.Hour, now.Minute, now.Second);
		}
	}
}
