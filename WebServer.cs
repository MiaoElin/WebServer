using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
public static class WebServer {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        // app.MapGet("/", () => "Hello World!");
        app.MapGet("/", () => {
            // return html
            // contetn-type:text/html
            // Results.
            byte[] data = System.Text.Encoding.UTF8.GetBytes("<h1>Hello World</h1>");
            return Results.Text(data, "text/html");
            // 理论是用bytes，这里Text 重载 包括了字节组的
        }
        );
        app.MapGet("/elin", () => "Hello Elin!");
        app.MapGet("/map", () => {
            byte[] data = System.IO.File.ReadAllBytes("map1.png");
            return Results.Bytes(data,"image/png");
        });
        app.Run();
    }
}
