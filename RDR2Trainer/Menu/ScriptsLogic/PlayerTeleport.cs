using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class PlayerTeleport(string caption, Vector3 pos) : TriggerItem(caption)
	{
		private readonly Vector3 _pos = pos;
		public override void OnExecute()
		{
			var e = PlayerPed;
			if (IS_PED_ON_MOUNT(e))
			{
				e = GET_MOUNT(e);
			}
			else if (IS_PED_IN_ANY_VEHICLE(e, false))
			{
				e = GET_VEHICLE_PED_IS_USING(e);
			}

			SET_ENTITY_COORDS(e, _pos.X, _pos.Y, _pos.Z, false, false, false, false);
		}
	}
}
