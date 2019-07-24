using System;
using System.Collections.Generic;
using System.Text;
using Artemis.Interface;

namespace TextEngine.Components
{
	public class LifeTimeComponent : SerializableComponent
	{
		public LifeTimeComponent()
			: this(0.0f)
		{
		}
		public LifeTimeComponent(float lifeTime)
		{
			this.LifeTime = lifeTime;
		}
		public bool IsExpired
		{
			get
			{
				return this.LifeTime <= 0;
			}
		}
		public float LifeTime { get; set; }
		public void ReduceLifeTime(float lifeTimeDelta)
		{
			this.LifeTime -= lifeTimeDelta;
			if (this.LifeTime < 0)
			{
				this.LifeTime = 0;
			}
		}
	}
}
