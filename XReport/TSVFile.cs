using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Benri.APIs.Test.Report
{
    public class TSVFile
    {
        public static bool IsFileReady(string fileLink)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(fileLink, FileMode.Open, FileAccess.Read, FileShare.None))
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static async void MakeEmptyReport(string fileLink)
        {
            string title =
                "Description" + "\t" + "URI" + "\t" + "Method" + "\t" +
                "Body" + "\t" + "Expected Status" + "\t" +
                "Actual Status" + "\t" + "Expected Message" + "\t" +
                "Actual Message" + "\t" + "Test Result" + "\n";
            while (!IsFileReady(fileLink))
            {
                Console.WriteLine("Waiting for file ready...");
                Console.ReadLine();
            }
            await File.WriteAllTextAsync(fileLink, title);

        }
        public static async void WriteToEndOfFileAsync(string fileLink, string content)
        {
            while (!IsFileReady(fileLink))
            {
                Console.WriteLine("Waiting for file ready...");
                Console.ReadLine();
            }
            await File.AppendAllTextAsync(fileLink, content);
        }
        public static async void WriteToExistingLine
            (string fileLink, string content)
        {
            //replace \n by null becase WriteAllLinesAsync will add new line
            content = content.Replace("\n", "");
            int lineIndex = GetIndexOfLineByDescription(fileLink, content);
            string[] fileContent = File.ReadAllLines(fileLink);
            fileContent[lineIndex] = content;
            while (!IsFileReady(fileLink))
            {
                Console.WriteLine("Waiting for file ready...");
                Console.ReadLine();
            }
            await File.WriteAllLinesAsync(fileLink, fileContent);
        }
        //update report content
        public static void updateReport(string fileLink, string content)
        {
            if (GetIndexOfLineByDescription(fileLink, content) == -1)
            {
                WriteToEndOfFileAsync(fileLink, content);
            }else
            {
                WriteToExistingLine(fileLink, content);
            }
        }
        //first line of report: Description	URI	Method	Body	Expected Status	Actual Status	Expected Message	Actual Message	Test Result
        public static int GetIndexOfLineByDescription(string fileLink, string lineContent)
        {
            lineContent = lineContent.Replace("\n", "");
            var fileContent = File.ReadAllLines(fileLink);
            string[] contentSplited = lineContent.Split("\t");
            for (int i = 0; i < fileContent.Length; i++)
            {
                string[] lineSplited = fileContent[i].Split("\t");
                if (lineSplited[0] == contentSplited[0])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
