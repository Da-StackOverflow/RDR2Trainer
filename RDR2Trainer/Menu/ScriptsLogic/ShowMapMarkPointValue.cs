using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class ShowMapMarkPointValue(string caption) : TriggerItem(caption)
	{
		public unsafe override void OnExecute()
		{
			if (!IS_WAYPOINT_ACTIVE())
			{
				SetTips("地图没有标记点!");
				return;
			}

			Vector3 coords = GET_WAYPOINT_COORDS();
			SetTips(coords.ToString(), 5000);
		}
	}
}
