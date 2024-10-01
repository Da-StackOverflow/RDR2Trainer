using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal unsafe class GiveWeapon(string caption, ItemInfo model) : TriggerItem(caption)
	{
		private readonly ItemInfo _info = model;

		public override void OnExecute()
		{
			var hash = GET_HASH_KEY(_info.ModelID);
			GIVE_DELAYED_WEAPON_TO_PED(PlayerPed, hash, 100, true, 0x2cd419dc);
			SET_PED_AMMO(PlayerPed, hash, 100);
			SET_CURRENT_PED_WEAPON(PlayerPed, hash, true, WeaponAttachPoint.FirstHand, false, false);
		}
	}
}
