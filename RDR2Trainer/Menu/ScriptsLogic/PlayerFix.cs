using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerFix(string caption) : TriggerItem(caption)
	{
		public override void OnExecute()
		{
			SET_ENTITY_HEALTH(PlayerPed, GET_ENTITY_MAX_HEALTH(PlayerPed, false), 0);
			CLEAR_PED_WETNESS(PlayerPed);
			RESTORE_PLAYER_STAMINA(PlayerID, 100.0f);
			SPECIAL_ABILITY_START_RESTORE(PlayerID, -1, false);

			if (IS_PED_ON_MOUNT(PlayerPed))
			{
				var horse = GET_MOUNT(PlayerPed);
				SET_ENTITY_HEALTH(horse, GET_ENTITY_MAX_HEALTH(horse, false), 0);
				RESTORE_PED_STAMINA(horse, 100.0f);
			}
			else if (IS_PED_IN_ANY_VEHICLE(PlayerPed, false))
			{
				var veh = GET_VEHICLE_PED_IS_USING(PlayerPed);
				SET_ENTITY_HEALTH(veh, GET_ENTITY_MAX_HEALTH(veh, false), 0);
			}
		}
	}
}
