
# RepoFramework

O RepoFramework foi criado para facilitar a utilização de CRUDs e com ele você não precisa fazer a implementação manualmente.


## Funcionalidades

- Integração com SqlServer com Dapper
- Implementação de Insert
- Implementação de GetAll
- Implementação de GetByIdentifier
- Implementação de Update
- Implementação de Delete


## Stack utilizada
**Back-end:** .NET 10, Dapper, SqlClient


## Uso/Exemplos

1. Recomendamos criar uma interface para utilizar os métodos CRUD no seu repository.
```csharp
public interface IRepositoryUser
{
    Task Create(object formatObject, string sql);
    Task<IEnumerable<TReturn>> GetAll<TReturn>(string sql);
}
```

2. Criar um Repository para sua entidade implementando a interface que você gerou.
```csharp
public class RepositoryUser : IRepositoryUser
{
    private readonly IRepositoryBase _repositoryBase;

    public RepositoryUser(IRepositoryBase repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public async Task Create(object formatObject, string sql)
    {
        await _repositoryBase.Create(formatObject, sql);
    }

    public async Task<IEnumerable<TReturn>> GetAll<TReturn>(string sql)
    {
        return await _repositoryBase.GetAll<TReturn>(sql);
    }
}
```

3. Fazer a Injeção de Dependência do seu repository dentro da sua camada de utilização - **(Para fins de demonstração, foi utilizado na Controller, porém não é recomendado essa prática em cenários reais)**.

```csharp
private readonly RepositoryUser _repositoryBase;
public UserController(RepositoryUser repositoryBase)
{
    _repositoryBase = repositoryBase;
}

[HttpGet]
public async Task<ActionResult> Get()
{
    var sql = @"SELECT Id, Name, Age FROM Users";
    var users = await _repositoryBase.GetAll<Users>(sql);
    if (users is not null)
        return Ok(users);
    return NoContent();
}

[HttpPost]
public async Task<ActionResult> Post([FromBody] Users req)
{
    var user = new Users(req.Name, req.Age);
    var sql = @"INSERT INTO Users(Id, Name, Age) VALUES (@id, @name, @age)";
    await _repositoryBase.Create(new { id = user.Id, name = user.Name, age = user.Age }, sql);
    return Created();
}
```

4. Após isso, faça o registro das devidas DIs dentro de sua aplicação.

```csharp
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddSingleton<IConfigurationDB, DatabaseSqlServer>();
builder.Services.AddSingleton(typeof(IRepositoryBase), typeof(RepositoryBase));
builder.Services.AddSingleton<RepositoryUser>();
```

```
Observação: No registro da dependência, é utilizado uma classe de modelo para buscar a sua conexão do banco, onde dentro dela contém a propriedade - ConnectionString, dentro da sua sessão, deve estar com o mesmo nome para identificação da connection string.
```

5. Faça o build da aplicação e rode normalmente.
## Autores

- [Bruno Vinícius](https://www.github.com/Brunovini08)

