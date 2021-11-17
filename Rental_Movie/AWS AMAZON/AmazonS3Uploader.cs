using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rental_Movie.AWS_AMAZON
{
	public class AmazonS3Uploader
	{
		private string bucketName = "testriinvest";
		private string keyName = "Test";
		private string filePath = "C:\\Users\\Lenovo\\OneDrive\\Desktop\\Images\\GiantBook.png";

		public void UploadFile()
		{
			var client = new AmazonS3Client(Amazon.RegionEndpoint.EUCentral1);

			try
			{

				PutObjectRequest putRequest = new PutObjectRequest
				{
					BucketName = bucketName,
					Key = keyName,
					FilePath = filePath,
					ContentType = "text/plain"
					
				};
				PutObjectResponse response = client.PutObject(putRequest);


			}
			catch (AmazonS3Exception e)
			{
				if(e.ErrorCode != null && (e.ErrorCode.Equals("InvalidKeyAccessId")
					|| e.ErrorCode.Equals("InvalidSecurity")))

				{
					throw new Exception("Check the provided AWS credentials");
				}
				else
				{
					throw new Exception("Error occurred: " +e.Message);
				}
				
			}

		}

	}
}