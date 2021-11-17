using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Rental_Movie.Azure
{
	public class BlobManager
	{
        private CloudBlobContainer _blobContainer;
        private readonly string _containerName;
        private readonly string _connectionString =
            "DefaultEndpointsProtocol=http;" +
            "AccountName=devstoreaccount1;" +
            "AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;" +
            "BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;" +
            "QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;";

        public BlobManager(string containerName)
        {
            if (string.IsNullOrEmpty(containerName))
                throw new ArgumentNullException("containerName", "Container can't be empty.");

            _containerName = containerName;
        }

        public async Task UploadInputFiles(HttpPostedFileBase FileUpload)
        {

			var blockBlob = _blobContainer.GetBlockBlobReference(FileUpload.FileName);
			await blockBlob.UploadFromStreamAsync(FileUpload.InputStream);
			//         string Url;
			//try
			//{
			//             string FileName = Path.GetFileName(FileUpload.FileName);
			//             CloudBlockBlob blockBlob;
			//             blockBlob = _blobContainer.GetBlockBlobReference(FileName);
			//             blockBlob.Properties.ContentType = FileUpload.ContentType;

			//             blockBlob.UploadFromStream(FileUpload.InputStream);

			//             Url = blockBlob.Uri.AbsoluteUri;

			//}
			//catch (Exception ex)
			//{

			//             //Console.WriteLine(ex.Message);
			//             throw ex;
			//}

			//         return Url;

		}

        public async Task BlobContainerInit() //Storage explorer Container 
        {
            try
            {
                var cloudStorage = CloudStorageAccount.Parse(_connectionString);
                var blobClient = cloudStorage.CreateCloudBlobClient();
                _blobContainer = blobClient.GetContainerReference(_containerName);

                if (await _blobContainer.CreateIfNotExistsAsync())
                {
                    await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions()
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task UploadFile(Dictionary<string, byte[]> files)
        {
            foreach (var file in files)
            {
                var blockBlob = _blobContainer.GetBlockBlobReference(file.Key);
                //var reader = new StreamReader(file.Value);
                //var text = await reader.ReadToEndAsync();
                //await blockBlob.UploadTextAsync(text);
                await blockBlob.UploadFromByteArrayAsync(file.Value, 0,file.Value.Length);
			}

        }

        public async Task DeleteFile(string filename)
        {
            var blockBlob = _blobContainer.GetBlockBlobReference(filename);
            await blockBlob.DeleteAsync();
        }

        public async Task<string> GetJson(string filename)
        {
            var blockBlob = _blobContainer.GetBlockBlobReference(filename);
            try
            {
                var result = await blockBlob.DownloadTextAsync();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public async Task<IEnumerable<string>> GetJsonList()
        {
            try
            {
                var listNames = new List<string>();

                foreach (CloudBlockBlob blobItem in (await _blobContainer.ListBlobsSegmentedAsync(
                    new BlobContinuationToken())).Results)
                {
                    listNames.Add(blobItem.Name);
                }

                var listJsonValues = new List<string>();
                foreach (var name in listNames)
                {
                    listJsonValues.Add(await GetJson(name));
                }

                return listJsonValues;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        //public async Task<FileStreamResult> DownloadFile(string filename)
        //{
        //    var blobBlock = _blobContainer.GetBlockBlobReference(filename);
        //    var stream = new MemoryStream();
        //    await blobBlock.DownloadToStreamAsync(stream);
        //    return new FileStreamResult(stream, "application/octet-stream");
        //}
    }

}
