using HeroHRM.Database;
using HeroHRM.Repository;
using HeroHRM.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM
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
            services.AddDbContext<HeroHRMContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<HeroHRMContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/login";
            });
            services.AddHttpContextAccessor();

            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IJobTitleRepository, JobTitleRepository>();
            services.AddScoped<IPayGradesRepository, PayGradesRepository>();
            services.AddScoped<IEmploymentStatusRepository, EmploymentStatusRepository>();
            services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
            services.AddScoped<ICompanyInfoRepository, CompanyInfoRepository>();
            services.AddScoped<ICompanyBranchRepository, CompanyBranchRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEducationRepsoitory,EducationRepsoitory>();
            services.AddScoped<ILanguageRepository,LanguageRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<IMembershipRepository, MembershipRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeContactRepository, EmployeeContactRepository>();
            services.AddScoped<IEmployeeDependantRepository, EmployeeDependantRepository>();
            services.AddScoped<IEmployeeEducationRepository, EmployeeEducationRepository>();
            services.AddScoped<IEmployeeImmigrationRepository, EmployeeImmigrationRepository>();
            services.AddScoped<IEmployeeJobRepository, EmployeeJobRepository>();
            services.AddScoped<IEmployeeLanguageRepository, EmployeeLanguageRepository>();
            services.AddScoped<IEmployeeLicenseRepository, EmployeeLicenseRepository>();
            services.AddScoped<IEmployeeMembershipRepository, EmployeeMembershipRepository>();
            services.AddScoped<IEmployeeSalaryRepository, EmployeeSalaryRepository>();
            services.AddScoped<IEmployeeSkillRepository, EmployeeSkillRepository>();
            services.AddScoped<IEmployeeSubordinateRepository, EmployeeSubordinateRepository>();
            services.AddScoped<IEmployeeSupervisorRepository, EmployeeSupervisorRepository>();
            services.AddScoped<IEmployeeWorkExperienceRepository, EmployeeWorkExperienceRepository>();
            services.AddScoped<IEmployeeEmergencyRepository, EmployeeEmergencyRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IHolidayRepository, HolidayRepository>();
            services.AddScoped<IResignRepository, ResignRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
