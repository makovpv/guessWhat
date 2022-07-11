namespace DataStorage
{
	public interface IPlaneRepository
	{
		public string[] GetRandomData(long compulsaryPlaneTypeId);

		public void SaveUserAnswerAsync(long imageId, string answer);

		public long GetPlaneByImageId(long imageId);

		public PlaneImage GetRandomPlaneImage();

		public Task<long> AddPlaneTypeAsync(string name, string imagePath);

		public string GetImagePath(long imageId);
	}
}
