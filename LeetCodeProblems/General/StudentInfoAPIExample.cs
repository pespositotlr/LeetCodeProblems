using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

namespace LeetCodeProblems.General
{
    class StudentInfoAPIExample
    {
    //}
    

    //    //I'm basing this on using .NET Core 3.1
    //    //Normally you can't/wouldn't want to do this in one file

    //    //This would go in Program.cs
    //    public class Program
    //    {
    //        public static void Main(string[] args)
    //        {
    //            CreateWebHostBuilder(args).Build().Run();
    //        }

    //        public static IHostBuilder CreateHoseBuilder(string[] args) =>
    //            Host.CreateDefaultBuilder(args)
    //                .ConfigureWebHostDefaults(webBuilder =>
    //                {
    //                    webBuilder.UseStartup<Startup>();
    //                });
    //    )
    //}

    //    //This would go in the Statup.cs file
    //    public class Statup
    //    {

    //        private readonly string CorsPolicy = "AllowAll";

    //        public void ConfigureServices(IServiceCollection services)
    //        {
    //            services.AddControllerWithViews();
    //            services.AddDbContext<StudentInfoContext>(options => options.UserInMemoryDatabase(databaseName: "StudentInfoDB"));

    //        }

    //        public void Configure(IApplicationbuilder app, IWebHostEnvironment env)
    //        {
    //            if (env.IsDevelopment())
    //            {
    //                app.UseDeveloperExceptionPage();
    //            }

    //            app.UseHttpsRedirection();

    //            app.useRouting();

    //            app.UseAuthorization();

    //            app.UseCors(options => options.AddPolicy(CorsPolicy, p => p.AllowAnyOrigin()
    //            .AllowAnyMethod()
    //            .AllowAnyHeader()));

    //            app.UseEndpoints(endpoints =>
    //            {
    //                endpoints.MapControllerRoute(
    //                    name: "default",
    //                    pattern: "{controller=StudentInfo}/{action=Index}");
    //            });

    //            app.UseStaticFiles();

    //        }

    //    }


    //    //Db Context you would use for entity framework
    //    public class StudentInfoContext : DbContext
    //    {
    //        public StudentInfoContext(DbContextOptions<StudentInfoContext> options) : base(options)
    //        { }

    //        public DbSet<StudentInfoContext> StudentInfos { get; set; }

    //    }

    //    //General classes
    //    public class StudentInfo
    //    {
    //        public int StudentId { get; set; }
    //        public string FirstName { get; set; }
    //        public string LastName { get; set; }
    //        public string Subject { get; set; }
    //        public double Grade { get; set; }
    //    }

    //    public class StudentInfoUpdateRequest
    //    {
    //        public string FirstName { get; set; }
    //        public string LastName { get; set; }
    //        public string Subject { get; set; }
    //        public double Grade { get; set; }
    //    }

    //    //Controller code, would go in a StudentInfoController.cs
    //    [ApiController]
    //    [Route("/")]
    //    public class StudentInfoController : ControllerBase
    //    {

    //        StudentInfoContext _dbContext;

    //        public StudentInfoController(StudentInfoContext dbContext)
    //        {
    //            _dbContext = dbContext;
    //        }

    //        [HttpGet]
    //        [Route("api/get-student-info/")]
    //        [ProducesResponseType(StatusCode.Status200OK)]
    //        [ProducesResponseType(StatusCode.Status404NotFound)]
    //        public StudentInfo Get([FromBody] int studentId)
    //        {
    //            var studentInfo = _dbContext.StudentInfos.FirstOrDefault(x => x.StudentId = studentId);

    //            if (studentInfo != null)
    //            {
    //                return OK(studentInfo);
    //            }

    //            return NotFound();

    //        }

    //        [HttpPost]
    //        [Route("api/add-student-info/")]
    //        [ProducesResponseType(StatusCode.Status201Created)]
    //        [ProducesResponseType(StatusCode.Status400BadRequest)]
    //        public StudentInfo Post([FromBody] StudentInfoUpdateRequest request)
    //        {
    //            if (String.IsNUllOrEmpty(request.FistName))
    //                return BadRequest();

    //            StudentInfo newStudentInfo = new StudentInfo();
    //            newStudentInfo.FirstName = request.FirstName;
    //            newStudentInfo.LastName = request.LastName;
    //            newStudentInfo.Subject = request.Subject;
    //            newStudentInfo.Grade = request.Grade;

    //            var newId = _dbContext.StudentInfos.Add(newStudentInfo);
    //            _dbContext.SaveChanges();

    //            return CreatedAtAction(nameof(Post), new { StudentId = newId }, newStudentInfo);
    //        }

    //        [HttpPut]
    //        [Route("api/update-student-info/")]
    //        public StudentInfo Update([FromBody] StudentInfoUpdateRequest request)
    //        {
    //            var originalStudentInfo = _dbContext.GetStudentInfoById(request.StudentId);

    //            if (originalStudentInfo != null)
    //            {
    //                StudentInfo newStudentInfo = _dbContext.GetStudentInfo();
    //                newStudentInfo.StudentId = request.StudentId;
    //                newStudentInfo.FirstName = request.FirstName;
    //                newStudentInfo.LastName = request.LastName;
    //                newStudentInfo.Subject = request.Subject;
    //                newStudentInfo.Grade = request.Grade;

    //                _dbContext.StudentInfos.Update(newStudentInfo);
    //                _dbContext.SaveChanges();
    //                return Ok();
    //            }

    //            return BadRequest();
    //        }

    //        [HttpDelete]
    //        [Route("api/delete-student-info/")]
    //        [ProducesResponseType(StatusCode.Status200OK)]
    //        [ProducesResponseType(StatusCode.Status404NotFound)]
    //        public StudentInfo Delete([FromBody] int studentId)
    //        {
    //            var originalStudentInfo = _dbContext.GetStudentInfoById(studentId);

    //            if (originalStudentInfo != null)
    //            {
    //                _dbContext.StudentInfos.Remove(originalStudentInfo);
    //                _dbContext.SaveChanges();
    //                return Ok();
    //            }

    //            return BadRequest();
    //        }
    //    }
    }

}
