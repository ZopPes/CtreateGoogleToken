using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;

Console.WriteLine("путь к клиенту Google");
var clientPath=Console.ReadLine();

UserCredential Client = await GoogleWebAuthorizationBroker.AuthorizeAsync
       (
           clientSecrets: (await GoogleClientSecrets.FromFileAsync(clientPath)).Secrets
           ,
           scopes: new[] { SheetsService.Scope.Spreadsheets }
           ,
           user: "user"
           ,
           taskCancellationToken: CancellationToken.None
           ,
           new FileDataStore("./", true)
           );
Console.WriteLine($"Token: {Client.Token.RefreshToken}");
