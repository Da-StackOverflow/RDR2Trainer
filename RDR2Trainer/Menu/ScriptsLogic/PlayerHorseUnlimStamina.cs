using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerHorseUnlimStamina(string caption) : SwitchItem(caption)
	{
		protected override void OnUpdate()
		{
			if (IS_PED_ON_MOUNT(PlayerPed))
			{
				var horse = GET_MOUNT(PlayerPed);
				RESTORE_PED_STAMINA(horse, 100.0f);
			}
		}
	}
}
