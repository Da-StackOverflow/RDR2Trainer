using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal unsafe class SpawnVehicle(string tittle, ItemInfo info, Vector3 pos, float heading, bool resetHeading) : TriggerItem(tittle)
	{
		private readonly ItemInfo _info = info;
		private readonly Vector3 _pos = pos;
		private readonly float _heading = heading;
		private readonly bool _resetHeading = resetHeading;

		public override void OnExecute()
		{
			var model = GET_HASH_KEY(_info.ModelID);
			if (IS_MODEL_IN_CDIMAGE(model) && IS_MODEL_VALID(model))
			{
				REQUEST_MODEL(model, false);
				while (!HAS_MODEL_LOADED(model))
				{
					WaitAndDraw(10);
				}

				float playerHeading = GET_ENTITY_HEADING(PlayerPed) + 5.0f;
				float heading = playerHeading + _heading;
				Vector3 coords = GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS(PlayerPed, _pos.X, _pos.Y, _pos.Z);
				var veh = CREATE_VEHICLE(model, coords.X, coords.Y, coords.Z, heading, false, false, false, false);
				DECOR_SET_BOOL(veh, "wagon_block_honor", true);

				if (_resetHeading)
				{
					SET_ENTITY_HEADING(veh, heading);
				}
				SET_VEHICLE_AS_NO_LONGER_NEEDED(&veh);
				SET_MODEL_AS_NO_LONGER_NEEDED(model);
			}
		}
	}
}
