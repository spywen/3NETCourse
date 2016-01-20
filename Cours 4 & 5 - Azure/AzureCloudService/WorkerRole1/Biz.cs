using System;
using System.Diagnostics;
using System.IO;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace WorkerRole1
{
    public static class Biz
    {
        public static CloudBlobClient GetCloudBlobClient()
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString"));
            return storageAccount.CreateCloudBlobClient();
        }

        #region Upload Download / Create Delete
        public static void CreateDeleteFile()
        {
            CloudBlobContainer container = GetCloudBlobClient().GetContainerReference("mycontainer");

            CloudBlockBlob txt = container.GetBlockBlobReference("file.txt");
            if (txt.Exists())
            {
                //File exist on Azure Storage
                Trace.TraceInformation("{0} Exists !", txt.Uri);

                //Download locally
                using (var fileStream = File.OpenWrite(@"./data/file.txt"))
                {
                    txt.DownloadToStream(fileStream);
                }

                //Delete on Azure Storage
                txt.Delete();

                //Status 
                Trace.TraceInformation("STATUS : File.txt, AZURE : NO EXISTS, LOCAL : EXISTS");
            }
            else
            {
                //File doesn't exist on Azure Storage
                Trace.TraceInformation("File doesn't exist !");

                //Upload on Azure Storage
                using (var fileStream = File.OpenRead(@"./data/file.txt"))
                {
                    txt.UploadFromStream(fileStream);
                }

                //Delete locally
                File.Delete(@"./data/file.txt");

                //Status 
                Trace.TraceInformation("STATUS : File.txt, AZURE : EXISTS, LOCAL : NO EXISTS");
            }
        }
        #endregion

        #region List all blobs of the container
        public static void ListAllBlobs()
        {
            CloudBlobContainer container = GetCloudBlobClient().GetContainerReference("mycontainer");
            var listOfObjects = container.ListBlobs();
            foreach (var obj in listOfObjects)
            {
                var type = obj.GetType();
                if (type == typeof(CloudBlockBlob))
                {
                    Trace.TraceInformation(obj.Uri.ToString());
                }
                else if (type == typeof(CloudBlobDirectory))
                {
                    ListBlobsOfDirectory((CloudBlobDirectory)obj);
                }
            }
        }

        private static void ListBlobsOfDirectory(CloudBlobDirectory directory)
        {
            var listOfObjects = directory.ListBlobs();
            foreach (var obj in listOfObjects)
            {
                var type = obj.GetType();
                if (type == typeof(CloudBlockBlob))
                {
                    Trace.TraceInformation(obj.Uri.ToString());
                }
                else if (type == typeof(CloudBlobDirectory))
                {
                    ListBlobsOfDirectory((CloudBlobDirectory)obj);
                }
            }
        }
        #endregion

        #region Create folder, Copy

        public static void ArchiveBlob()
        {
            CloudBlobContainer container = GetCloudBlobClient().GetContainerReference("mycontainer");

            var archivePath = string.Format("Archive/{0}/", DateTime.Now.ToString("yyyyMMdd_HHmmss"));

            var elToArchive = container.GetBlockBlobReference("file");
            var newPath = container.GetBlockBlobReference(archivePath + "file");
            newPath.StartCopyFromBlob(elToArchive);

            Trace.TraceInformation("Archive task ended. Archive created path : {0}", archivePath);
        }

        #endregion
    }
}
