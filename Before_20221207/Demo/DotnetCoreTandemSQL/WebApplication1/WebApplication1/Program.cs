using Microsoft.EntityFrameworkCore;
using WebApplication1.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

var optionsBuilder = new DbContextOptionsBuilder<Website_BackgroundContext>();
using (var db = new Website_BackgroundContext(optionsBuilder.Options))
{
    // 分層命名參考 https://hackmd.io/@MonsterLee/HJyAdgRBB
    var NewsPO = db.News.ToList();
    //for (var i = 0; i < 10000; i++)
    //{
    //    try
    //    {
    //        var TestsDTO = new Test();
    //        TestsDTO.Test1 = "test";
    //        db.Tests.Add(TestsDTO);
    //        db.SaveChanges();
    //    }
    //    catch (Exception ex)
    //    {
    //        var innerError = ex.InnerException;
    //        // 或者 log
    //        // throw ex;
    //    }
    //}
}

app.Run();



//dotnet ef dbcontext scaffold "Server=150.117.83.67;database=Website_Background;Trusted_Connection=False;user id=carl;password=1165;" Microsoft.EntityFrameworkCore.SqlServer --output-dir EF -f -v