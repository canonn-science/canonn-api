using System;
using Newtonsoft.Json;

namespace EddnEventBridgeSample
{
	public class EddnMessageContainer
	{
		[JsonProperty("$schemaRef")]
		public string Schema { get; set; }

		public EddnMessageHeader Header { get; set; }
		public dynamic Message { get; set; }
	}

	public class EddnMessageHeader
	{
		public DateTime GatewayTimestamp { get; set; }
		public string SoftwareName { get; set; }
		public string SoftwareVersion { get; set; }
		public string UploaderId { get; set; }
	}
}
