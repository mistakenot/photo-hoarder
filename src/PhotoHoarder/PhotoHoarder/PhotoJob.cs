using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

namespace PhotoHoarder
{
	public class PhotoJob
	{
		private readonly IEnumerable<Photo> source;
		private readonly ICollection<Photo> destination;

		public PhotoJob (IEnumerable<Photo> source, ICollection<Photo> destination)
		{
			this.source = source;
			this.destination = destination;
		}

		public Task Run()
		{
			var sourceSub = source
				.ToObservable (ThreadPoolScheduler)
				.Where (p => !destination.Contains (p))
				.Subscribe (p => destination.Add (p));
		}
	}
}

