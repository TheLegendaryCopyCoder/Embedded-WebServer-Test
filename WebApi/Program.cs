using WebApi;

// Main method and entrypoint when selfrunnning webserver
WebServer webServer = new WebServer();
await webServer.Start(args);