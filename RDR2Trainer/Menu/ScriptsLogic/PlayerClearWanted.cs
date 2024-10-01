using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerClearWanted(string caption, bool ClearBounty = true, bool ClearBountyHunterPursuit = true) : TriggerItem(caption)
	{
		private readonly bool clearBounty = ClearBounty;
		private readonly bool clearBountyHunterPursuit = ClearBountyHunterPursuit;
		public override void OnExecute()
		{
			if (clearBounty)
			{
				SET_BOUNTY(PlayerID, 0);
			}

			if (clearBountyHunterPursuit)
			{
				SET_BOUNTY_HUNTER_PURSUIT_CLEARED();
				SET_WANTED_SCORE(PlayerID, 0);
			}
			SetTips($"Player has to be in pursuit\n\nhead price: {GET_BOUNTY(PlayerID) / 100}\nwanted intensity: {GET_WANTED_SCORE(PlayerID)}");
		}
	}
}
