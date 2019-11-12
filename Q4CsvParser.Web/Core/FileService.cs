using System;
using System.IO;
using System.Web;
using Q4CsvParser.Contracts;

namespace Q4CsvParser.Web.Core
{
    /// <summary>
    /// This file does not need to be unit testable.
    /// Bonus Task:
    /// - Make this file unit testable using the adapter pattern for your file system interactions
    /// - Unit test this file
    /// </summary>
    public class FileService : IFileService
    {
        private const string UploadFilePath = "~/App_Data/uploads/";

        /// <summary>
        /// This file takes the file from the HttpPostedFileBase and saves the file to the appData folder
        /// </summary>
        /// <param name="file"></param>
        /// <returns>The file path in the appData folder the file was saved to</returns>
        public string StoreFile(HttpPostedFileBase file)
        {
            //TODO fill in your logic here
            string directoryPath = HttpContext.Current.Server.MapPath("~/App_Data/uploads/");
            string fullPath = Path.Combine(directoryPath, file.FileName);
            DirectoryInfo dir = Directory.CreateDirectory(directoryPath);
            file.SaveAs(fullPath);
            return fullPath;
        }

        /// <summary>
        /// This function takes in the filePath of a csv file stored in the app data folder and return the string content
        /// of that file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The contents of the file in a string</returns>
        public string ReadFile(string filePath)
        {
            //TODO fill in your logic here
            //throw new NotImplementedException();
            return System.IO.File.ReadAllText(filePath);
        }
    }
}
