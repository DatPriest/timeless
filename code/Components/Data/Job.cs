using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timeless.Components.Data
{
	public class Job
	{
		public string JobName {  get; set; }
		public string JobVersion {  get; set; }
		public string JobDescription {  get; set; }
		public string JobStatus {  get; set; }

		public static Job BaseJob = new Job
		{
			JobName = "Civilian",
			JobVersion = "1.0",
			JobDescription = "A default Civilian",
			JobStatus = "Active",

		};

		public Job()
		{

		}

		public static Job GetLastJob()
		{
			return BaseJob;
		}
	}
}
