using System;
using System.Collections.Generic;
using System.Text;
using Artemis.Interface;

namespace TextEngine.Components
{
	public class LifeTimeComponent : IComponent
	{
		public LifeTimeComponent()
			: this(0.0f)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="ExpiresComponent" /> class.</summary>
		/// <param name="lifeTime">The life time.</param>
		public LifeTimeComponent(float lifeTime)
		{
			this.LifeTime = lifeTime;
		}

		/// <summary>Gets a value indicating whether is expired.</summary>
		/// <value><see langword="true" /> if this instance is expired; otherwise, <see langword="false" />.</value>
		public bool IsExpired
		{
			get
			{
				return this.LifeTime <= 0;
			}
		}

		/// <summary>Gets or sets the life time.</summary>
		/// <value>The life time.</value>
		public float LifeTime { get; set; }

		/// <summary>The reduce life time.</summary>
		/// <param name="lifeTimeDelta">The life time.</param>
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
