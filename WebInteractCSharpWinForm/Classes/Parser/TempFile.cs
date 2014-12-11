using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebInteractCSharpWinForm.Classes.Parser
{
    class TempFile
    {
        /// <summary>
        /// Creates new temp file
        /// </summary>
        /// <returns>String fileName: The path of filename</returns>
        public static string CreateTmpFile()
        {

            string fileName = string.Empty;
            try
            {
                // Get the full name of the newly created Temporary file. 
                // Note that the GetTempFileName() method actually creates
                // a 0-byte file and returns the name of the created file.
                fileName = Path.GetTempFileName();

                // Craete a FileInfo object to set the file's attributes
                FileInfo fileInfo = new FileInfo(fileName);

                // Set the Attribute property of this file to Temporary. 
                // Although this is not completely necessary, the .NET Framework is able 
                // to optimize the use of Temporary files by keeping them cached in memory.
                fileInfo.Attributes = FileAttributes.Temporary;

                //ssageBox.Show("TEMP file created at: " + fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to create TEMP file or set its attributes: " + ex.Message);
            }

            return fileName;
        }
        /// <summary>
        /// Write data into temp filename
        /// </summary>
        /// <param name="tmpFile">file path</param>
        /// <param name="content">file content</param>
        public static void UpdateTmpFile(string tmpFile, string content)
        {
            try
            {
                // Write to the temp file.
                StreamWriter streamWriter = File.AppendText(tmpFile);
                streamWriter.Write(content);
                streamWriter.Flush();
                streamWriter.Close();

                //Console.WriteLine("TEMP file updated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to TEMP file: " + ex.Message);
            }
        }
    }
}
