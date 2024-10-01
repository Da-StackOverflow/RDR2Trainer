using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class TimeAdjust(string caption, int difHours) : TriggerItem(caption)
	{
		private readonly int m_difHours = difHours;
		public override void OnExecute()
		{
			ADD_TO_CLOCK_TIME(m_difHours, 0, 0);
		}
	}
}
