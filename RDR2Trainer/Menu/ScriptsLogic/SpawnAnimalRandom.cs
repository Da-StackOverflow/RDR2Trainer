using static RDR2Trainer.ResourcesConfig;
using static RDR2Trainer.Function;

namespace RDR2Trainer.Menu.ScriptsLogic
{
	internal class SpawnAnimalRandom(string caption) : SpawnPed(caption)
	{
		protected override PedInfo Info
		{
			get
			{
				while (true)
				{
					var index = Random(0, PedInfos.Length);
					if (PedInfos[index].IsOtherAnimal)
					{
						SetTips(PedInfos[index].Name);
						return PedInfos[index];
					}
				}
			}
		}
	}
}
