using WebApi;
// Entry point for running this app from the same project.
Console.WriteLine("Testapp running embedded webserver.");

try
{
    // Launch browser and browser to url.
    Task.Run(async () =>
    {
        await Task.Delay(2000);
        System.Diagnostics.Process.Start("explorer", "http://localhost:7000/swagger/index.html");
    });
}
catch (Exception ex)
{
    Console.WriteLine("Couldnt launch web browser.");
}

// Launch server
WebServer webServer = new WebServer();
await webServer.Start(args);

