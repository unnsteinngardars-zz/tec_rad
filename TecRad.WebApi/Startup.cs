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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using TecRad.Models.NewsItem;
using TecRad.Models.Author;
using TecRad.Models.Category;
using TecRad.Services.Interfaces;
using TecRad.Services;
using TecRad.Repositories.Interfaces;
using TecRad.Repositories;
using TecRad.Services.Implementations;
using TecRad.Repositories.Data;
using TecRad.WebApi.Extensions;

namespace TecRad.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<INewsItemService, NewsItemService>();
            services.AddTransient<INewsItemRepository, NewsItemRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ILogService, LogService>();
            services.AddSingleton<IDataContext, DataContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseMvc();

            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<NewsItem, NewsItemDTO>();
                cfg.CreateMap<NewsItemDTO, NewsItem>();
                cfg.CreateMap<NewsItemInputModel, NewsItem>()
                .ForMember(n => n.CreatedDate, opt => opt.UseValue(DateTime.Now))
                .ForMember(n => n.ModifiedDate, opt => opt.UseValue(DateTime.Now))
                .ForMember(n => n.PublishDate, opt => opt.UseValue(DateTime.Now));
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<AuthorDTO, Author>();
                cfg.CreateMap<AuthorInputModel, Author>()
                .ForMember(a => a.CreatedDate, opt => opt.UseValue(DateTime.Now))
                .ForMember(a => a.ModifiedDate, opt => opt.UseValue(DateTime.Now));
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<CategoryInputModel, Category>()
                .ForMember(c => c.CreatedDate, opt => opt.UseValue(DateTime.Now))
                .ForMember(c => c.ModifiedDate, opt => opt.UseValue(DateTime.Now));

            });
        }
    }
}
