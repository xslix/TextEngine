using System;
using System.Collections.Generic;
using System.Text;
using Artemis;
using Artemis.System;
using Artemis.Attributes;
using TextEngine.Components;

namespace TextEngine.Systems
{
	[ArtemisEntitySystem]
	public class LifeTimeReductionSystem : EntityProcessingSystem
	{
		public LifeTimeReductionSystem() : base(Aspect.One(typeof(LifeTimeComponent)))
		{

		}
		public override void Process(Entity entity)
		{
			var lifeTimeComponent = entity.GetComponent<LifeTimeComponent>();
			
			if (lifeTimeComponent != null)
			{
				float ms = TimeSpan.FromTicks(this.EntityWorld.Delta).Milliseconds;
				lifeTimeComponent.ReduceLifeTime(ms);

				if (lifeTimeComponent.IsExpired)
				{
					entity.Delete();
				}
			}
		}
	}
}
