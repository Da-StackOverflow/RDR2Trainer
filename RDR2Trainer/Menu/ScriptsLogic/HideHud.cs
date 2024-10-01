using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class HideHud(string caption) : SwitchItem(caption)
	{
		protected override void OnUpdate()
		{
			HIDE_HUD_AND_RADAR_THIS_FRAME();
		}
	}
}
