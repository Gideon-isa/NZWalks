
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Constants;
using NZWalks.API.Data;
using NZWalks.API.Mappings;
using NZWalks.API.Repositories;

namespace NZWalks.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			// builder.Services.AddDbContext<NZWalksDbContext>(options => options.UseSqlServer(builder.Configuration.GetSection("NZWalksConnectionString").GetSection("NZWalksConnectionString").Value));

			builder.Services.AddDbContext<NZWalksDbContext>(options => 
			options.UseSqlServer(builder.Configuration.GetConnectionString(DbConstant.DbConnectionString)));
			
			

			builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
			builder.Services.AddScoped<IWalksRepository, SQLWalkRepository>();
			builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
			
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
