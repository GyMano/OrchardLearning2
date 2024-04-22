using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Media;

namespace OL2.Core.Controllers
{
    public class FileManagementController : Controller
    {
        private readonly IMediaFileStore _mediaFileStore;
        public FileManagementController(IMediaFileStore mediaFileStore)
        {

            _mediaFileStore = mediaFileStore;
        }

        public async Task<string> CreateFile()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("Hello, world!"));
            await _mediaFileStore.CreateFileFromStreamAsync("Demo.txt", stream);

            return "OK";
        }

        public async Task<string> ReadFile()
        {
            var fileInfo = await _mediaFileStore.GetFileInfoAsync("Demo.txt");

            if (fileInfo is not null)
            {
                string fileinfostr = $"File info: size: {fileInfo.Length}, last modified UTC: {fileInfo.LastModifiedUtc}.";

                using var fileStream = await _mediaFileStore.GetFileStreamAsync("Demo.txt");



                if (fileStream is not null)
                {
                    using var streamReader = new StreamReader(fileStream);
                    string filestreamstr = await streamReader.ReadToEndAsync();

                    return fileinfostr + " Content: " + filestreamstr;
                }
                return fileinfostr;

            }
            return "no file found on that path";
        }
    }
}
