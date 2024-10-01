using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal unsafe class AddHonor(string caption) : TriggerItem(caption)
	{
		public override void OnExecute()
		{
			var unarmed = GET_HASH_KEY("WEAPON_UNARMED");
			SET_CURRENT_PED_WEAPON(PlayerPed, unarmed, true, WeaponAttachPoint.FirstHand, false, false);
			var model = GET_HASH_KEY("U_M_O_VHTEXOTICSHOPKEEPER_01");
			REQUEST_MODEL(model, false);
			while (!HAS_MODEL_LOADED(model))
			{
				WaitAndDraw(10);
			}
			Vector3 coords = GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS(PlayerPed, 0.0f, 3.0f, -0.3f);
			var ped = CREATE_PED(model, coords.X, coords.Y, coords.Z, 0.0f, false, false, false, false);
			SET_RANDOM_OUTFIT_VARIATION(ped, true);

			DECOR_SET_INT(ped, "honor_override", -9999);

			TASK_COMBAT_PED(ped, PlayerPed, 0, 0);
			SET_MODEL_AS_NO_LONGER_NEEDED(model);
		}
	}
}
