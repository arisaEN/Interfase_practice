using 練習1.Components;
using 練習1.Components.Interface;
using 練習1.Components.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー

// Dog を使いたい場合
//builder.Services.AddScoped<IAnimal, Dog>();

// Cat を使いたい場合（↑をコメントアウトしてこちらを有効に）
builder.Services.AddScoped<IAnimal, Cat>();



//つまり・・・・使用側(webページ)の変更をせずとも 実装を切り替えれる！
//実装切り替えてうまくいかなければ、実装側が悪い、実装の修正だけで済む。

///悪い例（逆転されていない）：
///コンポーネントA（使う側） ---> 具体クラスB（使われる側）

///良い例（依存性逆転）：
///コンポーネントA（使う側） ---> IInterface <--- コンポーネントB（実装）


//ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
