using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Shared.Api.Schedule;
using Shared.Api.Swagger;
using Sxh.Server.Settings;
using Swashbuckle.AspNetCore.Swagger;
using Sxh.Db.Models;
using Microsoft.EntityFrameworkCore;
using Sxh.Business.Repository.Interface;
using Sxh.Business.Repository;
using Sxh.Business;
using Sxh.Business.Models;
using Sxh.Server.Middleware;
using Sxh.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shared.Api.Auth.Jwt;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Sxh.Shared.Settings;

namespace Sxh.Server
{
    public class Startup
    {
        const string DB_KEY_SXH = "SxhDbString";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            BuildConfigSettings(services);
            BuildServices(services);
            BuildSwaggerSettings(services);
            BuildSechdules(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            applicationLifetime.ApplicationStarted.Register(() => OnStartup(env));

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new List<string> { "index.html" },
                RequestPath = new PathString(string.Empty)
            });

            var rootPath = env.ContentRootPath;
            AppSetting.Instance.VersionUpdater.ServerConfig.SaveToXml(rootPath); //auto-upgrading configuration
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(rootPath, VersionUpdater.ServerSettings.Namespaces.Config.PhysicalFolder)),
                RequestPath = $"/{VersionUpdater.ServerSettings.Namespaces.Config.VirtrualFolder}"
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            BuildSwaggerUI(app);

            app.UseAuthentication();
            app.UseMvc();
        }

        #region Private Method

        private void OnStartup(IHostingEnvironment env)
        {
            var path = env.ContentRootPath;

            try
            {
                var contentRootDirectoryInfo = new DirectoryInfo(path);
                var pathRoot = $@"{contentRootDirectoryInfo.Parent.Parent.FullName}";
                if (env.IsDevelopment())
                {
                    var pathCodegen = Path.Combine(pathRoot, @"codegen\setup.bat");

                    if (File.Exists(pathCodegen))
                    {
                        //ONLY when Swagger Codegen is enabled, the process could be executable
                        ExcuteProcess(pathCodegen);
                    }
                }
                else if (env.IsProduction())
                {
                    var pathSchedule = Path.Combine(pathRoot, @"schedule\process.bat");
                    if (File.Exists(pathSchedule))
                    {
                        ExcuteProcess(pathSchedule);
                    }
                    var pathCleanup = Path.Combine(pathRoot, @"mypublish\cleanup.bat");

                    if (File.Exists(pathCleanup))
                    {
                        ExcuteProcess(pathCleanup);
                    }
                }
            }
            catch (Exception)
            {
                //ignore
            }
        }

        private void ExcuteProcess(string path)
        {
            try
            {
                var proc = new Process();
                proc.StartInfo.FileName = path;
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception)
            {
                //skip
            }
        }

        private void BuildConfigSettings(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);
            var setting = new AppSettings();
            Configuration.Bind(setting);
            AppSetting.Instance = setting.AppSetting;
            AppSetting.Instance.DbConnection.SetDbConnectStringSxh(Configuration.GetConnectionString(DB_KEY_SXH));
        }

        private void BuildServices(IServiceCollection services)
        {
            //public SxhContext(DbContextOptions options) : base(options) { }
            services.AddDbContext<SxhContext>(options => options.UseSqlServer(Configuration.GetConnectionString(DB_KEY_SXH)));
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<ICalculateRepository, CalculateRepository>();
            services.AddScoped<IProxyRepository, ProxyRepository>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.UseJwtOptionsDefault(AppSetting.Instance.SecretKey).UseMiddleware();
                });
        }

        private void BuildSwaggerSettings(IServiceCollection services)
        {
            //swagger settings
            var rootPath = PlatformServices.Default.Application.ApplicationBasePath;
            //SwaggerManager.Instance.Register(Path.Combine(rootPath, "Sxh.Db.dll")); //register customized models to swagger codegen
            services.UseSwaggerDefault(Path.Combine(rootPath, "Sxh.Server.xml"));
            services.AddSwaggerGen(c => { c.SwaggerDoc(ApiVersion.V1, new Info { Title = $"{ApiVersion.V1} API version", Version = ApiVersion.V1 }); });
        }

        private void BuildSwaggerUI(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.UseSwaggerUIDefault();
                c.SwaggerEndpoint($"/swagger/{ApiVersion.V1}/swagger.json", $"{ApiVersion.V1} APIs");
            });
        }

        private void BuildSechdules(IServiceCollection services)
        {
            services.AddSingleton<IScheduledTask>(new TaskHeartbeats(AppSetting.Instance.Schedules.TargetServer, AppSetting.Instance.Schedules.Heartbeat.Frequency));
            services.AddSingleton<IScheduledTask>(new TaskNextPayment(AppSetting.Instance.Schedules.TargetServer, AppSetting.Instance.Schedules.NextPayment.Frequency));
            services.AddScheduler(async (sender, args) =>
            {
                try
                {
                    //handle exceptions for all schedules
                    await LogProvider.LogAsync($"schedule exception: [{args.Exception.Message}]", LogType.Schedule);
                }
                catch (Exception ex)
                {
                    await LogProvider.LogAsync($"schedule wrapper exception: [{ex.Message}]", LogType.Error);
                }
                finally
                {
                    args.SetObserved();
                }
            });
        }

        #endregion
    }
}
