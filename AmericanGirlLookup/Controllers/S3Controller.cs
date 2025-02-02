using AmericanGirlLookup.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace AmericanGirlLookup.Controllers
{
    public class S3Controller : Controller
    {
        private S3Utility s3Utility = new S3Utility();

        public async Task<ActionResult> GetImage(string bucketName, string key)
        {
            var rawImageData = await s3Utility.GetImageAsync(bucketName, key);

            return File(rawImageData, "image/jpeg");
        }
    }
}
