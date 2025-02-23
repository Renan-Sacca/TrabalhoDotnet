using Microsoft.EntityFrameworkCore;
using ProjetoAcademico.Domain.Interfaces.Repositories;
using ProjetoAcademico.Domain.Interfaces.Services;
using ProjetoAcademico.Domain.Services;
using ProjetoAcademico.Infra.Data.Context;
using ProjetoAcademico.Infra.Data.Repositories;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using ProjetoAcademico.Domain.DTOs.CursoDto.Adicionar;
using ProjetoAcademico.Domain.DTOs.CursoDto.Atualizar;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Adicionar;
using ProjetoAcademico.Domain.DTOs.ProfessorDto.Atualizar;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServiceCurso, ServiceCurso>();
builder.Services.AddScoped<IRepositoryCurso, RepositoryCurso>();

// Adicionando serviços e repositórios para Professor
builder.Services.AddScoped<IServiceProfessor, ServiceProfessor>();
builder.Services.AddScoped<IRepositoryProfessor, RepositoryProfessor>();

builder.Services.AddDbContext<ProjetoAcademicoContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ProjetoAcademicoConnection"));
});

builder.Services.AddCors();

builder.Services
    .AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.Converters
        .Add(new JsonStringEnumConverter()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(cors => cors
    .AllowAnyOrigin()
    .AllowAnyMethod() // Get, Post, Put, Delete, etc...
    .AllowAnyHeader());

#region Rotas do Curso
app.MapPost("/curso/adicionar", ([FromServices] IServiceCurso serviceCurso, CursoAdicionarDto cursoAdicionarDto) =>
{
    var response = serviceCurso.Adicionar(cursoAdicionarDto);
    return response.Sucesso ? Results.Created("created", response) : Results.BadRequest(response);
})
.WithTags("Curso");

app.MapGet("/curso/listar", ([FromServices] IServiceCurso serviceCurso) =>
{
    var response = serviceCurso.Listar();
    return Results.Ok(response);
})
.WithTags("Curso");

app.MapGet("/curso/obter/{id:guid}", ([FromServices] IServiceCurso serviceCurso, Guid id) =>
{
    var response = serviceCurso.Obter(id);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Curso");

app.MapPut("/curso/atualizar", ([FromServices] IServiceCurso serviceCurso, CursoAtualizarDto cursoAtualizarDto) =>
{
    var response = serviceCurso.Atualizar(cursoAtualizarDto);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Curso");

app.MapDelete("/curso/remover/{id:guid}", ([FromServices] IServiceCurso serviceCurso, Guid id) =>
{
    var response = serviceCurso.Remover(id);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Curso");
#endregion

#region Rotas do Professor
app.MapPost("/professor/adicionar", ([FromServices] IServiceProfessor serviceProfessor, ProfessorAdicionarDto professorAdicionarDto) =>
{
    var response = serviceProfessor.Adicionar(professorAdicionarDto);
    return response.Sucesso ? Results.Created("created", response) : Results.BadRequest(response);
})
.WithTags("Professor");

app.MapGet("/professor/listar", ([FromServices] IServiceProfessor serviceProfessor) =>
{
    var response = serviceProfessor.Listar();
    return Results.Ok(response);
})
.WithTags("Professor");

app.MapGet("/professor/obter/{id:guid}", ([FromServices] IServiceProfessor serviceProfessor, Guid id) =>
{
    var response = serviceProfessor.Obter(id);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Professor");

app.MapPut("/professor/atualizar", ([FromServices] IServiceProfessor serviceProfessor, ProfessorAtualizarDto professorAtualizarDto) =>
{
    var response = serviceProfessor.Atualizar(professorAtualizarDto);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Professor");

app.MapDelete("/professor/remover/{id:guid}", ([FromServices] IServiceProfessor serviceProfessor, Guid id) =>
{
    var response = serviceProfessor.Remover(id);
    return response.Sucesso ? Results.Ok(response) : Results.BadRequest(response);
})
.WithTags("Professor");
#endregion

app.UseHttpsRedirection();

app.Run();
