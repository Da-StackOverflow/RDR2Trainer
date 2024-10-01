using static RDR2Trainer.Function;


namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class RevealMap(string caption) : TriggerItem(caption)
	{
		public override void OnExecute()
		{
			SET_MINIMAP_HIDE_FOW(true);
			REVEAL_MINIMAP_FOW(0);
		}
	}
}
