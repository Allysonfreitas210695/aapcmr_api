using System.Globalization;
using System.Text;
using api_aapcmr.AppSettings;
using api_aapcmr.Config;
using api_aapcmr.Interfaces;
using api_aapcmr.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Configurações para autenticação com OAuth 2.0 (Bearer)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT no formato 'Bearer {seu_token_aqui}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<IAutenticanteService, AutenticanteService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IAcoesApoioService, AcoesApoioService>();
builder.Services.AddScoped<ITipoGastoService, TipoGastoService>();
builder.Services.AddScoped<IAcaoApoioSemanalService, AcaoApoioSemanalService>();
builder.Services.AddScoped<ITratamentoPacienteService, TratamentoPacienteService>();
builder.Services.AddScoped<ISituacaoHabitacionalService, SituacaoHabitacionalService>();
builder.Services.AddScoped<IComposicaoFamiliarService, ComposicaoFamiliarService>();
builder.Services.AddScoped<IDoacaoService, DoacaoService>();
builder.Services.AddScoped<IDashBoardService, DashBoardService>();
builder.Services.AddScoped<IPerfilPacienteService, PerfilPacienteService>();
builder.Services.AddScoped<IRelatorioMensalService, RelatorioMensalService>();
builder.Services.AddScoped<IEmailService, EmailService>();

var key = Encoding.ASCII.GetBytes(Settings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"Temp")))
        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"Temp"));

    app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"Temp")),
        RequestPath = new PathString("/anexos")
    });

    app.UseHttpsRedirection();
}else {
     // Configurações para ambiente de produção
    app.UseHttpsRedirection();

    // Desabilitar a validação do certificado em produção
    app.Use(async (context, next) =>
    {
        if (context.Request.IsHttps)
        {
            context.Connection.ClientCertificate = new System.Security.Cryptography.X509Certificates.X509Certificate2();
        }

        await next.Invoke();
    });
}


app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

// Configurar a aceitação de qualquer certificado de cliente
app.Use(async (context, next) =>
{
    if (context.Request.IsHttps)
    {
        // Desabilitar a validação do certificado durante o desenvolvimento
        context.Connection.ClientCertificate = new System.Security.Cryptography.X509Certificates.X509Certificate2();
    }

    await next.Invoke();
});


app.MapControllers();


var supportedCultures = new[]{
    new CultureInfo("pt-BR")
};
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("pt-BR"),
    SupportedCultures = supportedCultures,
    FallBackToParentCultures = false
});
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

app.Run();