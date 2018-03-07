using System;

namespace EddnEventBridgeSample
{
	public class StarSystemCoordinates
	{
		public float X { get; private set; }
		public float Y { get; private set; }
		public float Z { get; private set; }

		public StarSystemCoordinates(float[] coordinates)
		{
			if (coordinates.Length != 3)
				throw new ArgumentException("Star system coordinates need to be an array of three floatting point numbers", nameof(coordinates));

			X = coordinates[0];
			Y = coordinates[1];
			Z = coordinates[2];
		}
	}
}
