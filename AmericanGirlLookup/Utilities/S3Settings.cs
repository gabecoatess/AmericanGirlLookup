namespace AmericanGirlLookup.Utilities
{
    public class S3Settings
    {
        public required string BucketName { get; set; }
        public required string DefaultImageKey { get; set; }
        public required string CloudFrontUrl { get; set; }
    }
}
