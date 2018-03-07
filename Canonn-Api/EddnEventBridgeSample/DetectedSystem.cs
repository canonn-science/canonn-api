namespace EddnEventBridgeSample
{
	public class DetectedSystem
	{
		public string SystemName { get; private set; }
		public StarSystemCoordinates SystemCoordinates { get; private set; }

		public DetectedSystem(string systemName, float[] coordinates)
		{
			SystemName = systemName;
			SystemCoordinates = new StarSystemCoordinates(coordinates);
		}
	}
}
