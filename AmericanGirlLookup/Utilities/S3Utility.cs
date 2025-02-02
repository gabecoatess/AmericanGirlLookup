using Amazon.S3;
using Amazon.S3.Model;

namespace AmericanGirlLookup.Utilities
{
    public class S3Utility
    {
        public async Task<byte[]> GetImageAsync(string bucketName, string key)
        {
            using (var client = new AmazonS3Client())
            {
                var request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                };

                using (var response = await client.GetObjectAsync(request))
                using (var memoryStream = new MemoryStream())
                {
                    // Load raw bytes from the response (doll image) into memory via memory stream
                    await response.ResponseStream.CopyToAsync(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}
