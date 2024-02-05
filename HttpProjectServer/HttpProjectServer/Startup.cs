using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HttpProjectServer;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        
    }

    /*public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapPost("/", async context =>
            {
                if (context.Request.HasFormContentType && context.Request.Form.ContainsKey("messagePackData"))
                {
                    var messagePackData = context.Request.Form["messagePackData"];
                    byte[] requestData = Convert.FromBase64String(messagePackData);

                    // Deserialize the MessagePack data
                    var requestObj = MessagePackSerializer.Deserialize<GetUserInfoQ>(requestData);

                    // Process the request and prepare the response
                    var responseObj = new GetUserInfoA()
                    {
                        UserId = requestObj.UserId,
                        UserName = "John Doe", // Replace with actual data retrieval logic
                        // Add other response properties as needed
                    };

                    // Serialize the response object to MessagePack format
                    byte[] responseData = MessagePackSerializer.Serialize(responseObj);

                    // Send the response to the client
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.ContentLength = responseData.Length;
                    await context.Response.Body.WriteAsync(responseData);
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid request");
                }
            });
        });
    }*/

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMiddleware<Route>();
    }
    
}