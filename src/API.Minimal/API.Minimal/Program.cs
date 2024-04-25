using API.Minimal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var produtoGroup = app.MapGroup("Produtos");


produtoGroup.MapGet("", () =>
{
    return Results.Ok( new ProdutoService().Get());
})
.WithName("GetProdutos")
.WithTags("Produtos")
.WithOpenApi();


produtoGroup.MapPost("", (Produto produto) => { return SaveProduto(produto); })
.WithName("SaveProduto")
.WithTags("Produtos")
.WithOpenApi();

produtoGroup.MapPut("", (Produto produto) => { return UpdateProduto(produto); })
.WithName("UpdateProduto")
.WithTags("Produtos")
.WithOpenApi();


produtoGroup.MapDelete("{id}", (int id) => { return DeleteProduto(id); })
.WithName("DeleteProduto")
.WithTags("Produtos")
.WithOpenApi();

app.Run();

static IResult SaveProduto(Produto produto)
{
    new ProdutoService().AddNew();
    return Results.Ok( produto);
}
static IResult UpdateProduto(Produto produto)
{
    new ProdutoService().Update();
    return Results.Ok(produto);
}

static IResult DeleteProduto(int id)
{
    return Results.Ok();
}