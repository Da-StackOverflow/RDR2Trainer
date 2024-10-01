using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal unsafe class SpawnPed(string caption, PedInfo info = default) : TriggerItem(caption)
	{
		protected virtual PedInfo Info { get { return _info; } }
		private readonly PedInfo _info = info;

		public override void OnExecute()
		{
			uint model = GET_HASH_KEY(Info.ModelID);
			if (IS_MODEL_IN_CDIMAGE(model) && IS_MODEL_VALID(model))
			{
				REQUEST_MODEL(model, false);
				while (!HAS_MODEL_LOADED(model))
				{
					WaitAndDraw(10);
				}
				Vector3 coords = GET_OFFSET_FROM_ENTITY_IN_WORLD_COORDS(PlayerPed, 0.0f, 3.0f, -0.3f);
				var ped = CREATE_PED(model, coords.X, coords.Y, coords.Z, Random(0.0f, 360.0f), false, false, false, false);
				SET_RANDOM_OUTFIT_VARIATION(ped, true);
				SET_PED_AS_NO_LONGER_NEEDED(&ped);
				SET_MODEL_AS_NO_LONGER_NEEDED(model);
			}
		}
	}
}
