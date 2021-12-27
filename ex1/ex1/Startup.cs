using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Swashbuckle.AspNetCore;

using Microsoft.EntityFrameworkCore;
using ex1.Models;
using ex1.Components;

namespace ex1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mvcBuilder = services.AddControllers();

            // XML 포멧터 추가
            mvcBuilder.AddXmlDataContractSerializerFormatters();

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IFiveRepositry, FiveRepository>();

            // TodoContext 등록 한다.
            // InMemory로 생성한다.
            services.AddDbContext<TodoContext>(options => options.UseInMemoryDatabase("TodoList"));


            // openApi 생성하기
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo(){
                    Title = "TodoApi",
                    Version = "v1",
                });
            });

            // 포인트 관리
            //services.AddTransient<IPointRepository, PointRepository>(); // DB Use
            services.AddTransient<IPointRepository, PointRepositoryInMemory>(); // InMemory Use (Test)
            services.AddTransient<IPointLogRepository, PointLogRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


                // Swagger (Open API 사용하기)
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            // CORS 설정 방법들..
            //app.UseCors(option => option.WithOrigins("apiUrl"));
            //app.UseCors(option => option.AllowAnyOrigin().WithMethods("GET"));


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
