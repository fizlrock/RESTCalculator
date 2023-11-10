
public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
			// CORS - механизм ограничения доступа к сервису
        services.AddCors(
                        options =>
                        {
												options.AddPolicy("CorsPolicy", buider =>
														buider.AllowAnyOrigin()
														.AllowAnyMethod()
														.AllowAnyHeader());
                        }

                        );
    }
}
