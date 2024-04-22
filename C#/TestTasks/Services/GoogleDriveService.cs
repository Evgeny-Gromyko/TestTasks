using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System.IO;
using System.Text;

namespace TestTasks.Services;

public static class GoogleDriveService
{
    public static async Task<string> UploadJsonTextAsFile(string jsonData)
    {
        UserCredential credential;
        var encodedCredentialsPath = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName +
            @"\e.json";
        var decodedCredentialsPath = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName +
            @"\d.json";


        string credentialString = string.Empty;

        using (var streamReader = new StreamReader(encodedCredentialsPath))
        {
            var fileContents = streamReader.ReadToEnd();
            credentialString = EncryptionHelper.Decrypt(fileContents);
        }

        if (!File.Exists(decodedCredentialsPath))
        {
            using (StreamWriter writer = new StreamWriter(decodedCredentialsPath))
            {
                writer.WriteLine(credentialString);
            }
        }

        using (var stream = new FileStream(decodedCredentialsPath, FileMode.Open, FileAccess.Read))
        {
            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                [DriveService.ScopeConstants.DriveFile],
                "test",
                CancellationToken.None
                );
        }

        var service = new DriveService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "my test app",
        });


        var fileName = "Objects_" +
            DateTime.Now.ToShortDateString() + "_" +
            DateTime.Now.ToShortTimeString() + ".json";

        var fileMetadata = new Google.Apis.Drive.v3.Data.File()
        {
            Name = fileName,
        };

        FilesResource.CreateMediaUpload request;
        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData)))
        {
            request = service.Files.Create(fileMetadata, stream, "application/json");
            request.Fields = "id";
            request.Upload();
        }

        if (!string.IsNullOrEmpty(request.ResponseBody.Id))
        {
            return "Saved successfully." + "\n" +
                "File name: " + fileName + "\n" +
                "Google Drive file id: " + request.ResponseBody.Id + "\n";
        }

        return "Upload faiiled." + "\n";
    }
}
