using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using KonkeMunicipality.Models;

namespace KonkeMunicipality.Services
{
    public class IssueService
    {
        private readonly string dataFolder;
        private readonly string attachmentFolder;
        private readonly string filePath;

        public IssueService()
        {
            dataFolder = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data");

            attachmentFolder = Path.Combine(
                dataFolder,
                "Attachments");

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            if (!Directory.Exists(attachmentFolder))
            {
                Directory.CreateDirectory(attachmentFolder);
            }

            filePath = Path.Combine(dataFolder, "issues.json");
        }

        public List<Issue> GetIssues()
        {
            if (!File.Exists(filePath))
            {
                return new List<Issue>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Issue>();
            }

            JavaScriptSerializer serializer =
                new JavaScriptSerializer();

            return serializer.Deserialize<List<Issue>>(json)
                   ?? new List<Issue>();
        }

        public void SaveIssue(Issue issue)
        {
            List<Issue> issues = GetIssues();

            issues.Add(issue);

            JavaScriptSerializer serializer =
                new JavaScriptSerializer();

            string json = serializer.Serialize(issues);

            File.WriteAllText(filePath, json);
        }

        public string GenerateIssueId()
        {
            List<Issue> issues = GetIssues();

            int nextNumber = issues.Count + 1;

            return "KLM-" + nextNumber.ToString("D4");
        }

        public string SaveAttachment(string sourceFilePath, string issueId)
        {
            if (string.IsNullOrWhiteSpace(sourceFilePath))
            {
                return string.Empty;
            }

            if (!File.Exists(sourceFilePath))
            {
                return string.Empty;
            }

            string extension =
                Path.GetExtension(sourceFilePath);

            string destinationFileName =
                issueId + extension;

            string destinationPath =
                Path.Combine(
                    attachmentFolder,
                    destinationFileName);

            File.Copy(
                sourceFilePath,
                destinationPath,
                true);

            return destinationPath;
        }
    }
}