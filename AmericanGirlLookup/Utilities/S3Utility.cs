using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace AmericanGirlLookup.Utilities
{
    public class S3Utility : IDisposable
    {
        private readonly IAmazonS3 _s3Client;

        public S3Utility()
        {
            _s3Client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1);
        }

        public async Task<string> UploadImageAsync(string bucketName, string objectKey, Stream fileStream, string contentType)
        {
            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = fileStream,
                BucketName = bucketName,
                Key = objectKey,
                ContentType = contentType
            };

            var transferUtility = new TransferUtility(_s3Client);

            try
            {
                await transferUtility.UploadAsync(uploadRequest);

                return $"https://{bucketName}.s3.amazonaws.com/{objectKey}";
            }
            catch (Exception e)
            {
                throw new Exception($"Error uploading file to S3: {e.Message}", e);
            }
        }

        public async Task<byte[]> GetImageAsync(string bucketName, string objectKey)
        {
            var request = new GetObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey
            };

            try
            {
                using (var response = await _s3Client.GetObjectAsync(request))
                using (var memoryStream = new MemoryStream())
                {
                    await response.ResponseStream.CopyToAsync(memoryStream);

                    return memoryStream.ToArray();
                }
            }
            catch (AmazonS3Exception e)
            {
                throw new Exception($"Error getting file from S3: {e.Message}", e);
            }
        }

        public void Dispose()
        {
            _s3Client.Dispose();
        }
    }
}
