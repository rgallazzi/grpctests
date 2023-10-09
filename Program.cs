using GrpcGreeter.Services;
using Grpc.AspNetCore.Web;

namespace GrpcGreeter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.AddConsole();

            // Additional configuration is required to successfully run gRPC on macOS.
            // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
           // logging.AddEventSourceLogger();
            // Add services to the container.
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //app.UseRouting();
            //app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
            //app.UseEndpoints(endpoints =>
            //{
            //endpoints.MapGrpcService<GreeterService>();
            //});
            app.MapGrpcService<GreeterService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}