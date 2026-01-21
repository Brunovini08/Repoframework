
# RepoFramework

O RepoFramework foi criado para facilitar a utilização de CRUDs e com ele você não precisa fazer a implementação manualmente.


## Funcionalidades

- Integração com MongoDB
- Implementação de Insert
- Implementação de GetAll
- Implementação de GetById
- Implementação de Update
- Implementação de Delete


## Stack utilizada
**Back-end:** .NET 10, MongoDB


## Uso/Exemplos

1. Recomendamos criar uma interface que herda de IRepositorybase<T>, onde T seria seu modelo de collection para utilizar os métodos CRUD no seu repository.
```csharp
public interface IRepositoryUser : Repositorybase<User>
{
}
```

2. Criar um Repository para sua entidade implementando a classe concreta do Repositorybase passando como tipo genérico o User e a interface que você gerou.
DatabaseMongoDB é uma dependencia interna que será configurada no seu program ou onde você controla suas injeções de dependências e a string collectionName seria o meu da sua collection para a lib poder interpretar onde tem que acessar dentro do seu banco
```csharp
public class RepositoryUser : Repositorybase<User>, IRepositoryUser
{

    public RepositoryUser(DatabaseMongoDB database, string collectionName = "Users")
    {
        
    }

   
}
```

3. Fazer a Injeção de Dependência do seu repository dentro da sua camada de utilização

```csharp
 public readonly IRepositoryUser _repositoryUser;

 public ServiceUser(IRepositoryUser repositoryUser)
 {
     _repositoryUser = repositoryUser;
 }

 public async Task Insert(CreateUserRequestDTO userRequest)
 {
     var user = new User(userRequest.Name, userRequest.Age);
     await _repositoryUser.InsertOneAsync(user);
 }
 public async Task<IEnumerable<User>> GetAll()
 {
     return await _repositoryUser.FindAsync();
 }
```

4. Após isso, faça o registro das devidas DIs dentro de sua aplicação e configure as variaveis que a Lib pede, onde você irá passar sua ConnectionString e seu DatabaseName.

```csharp
builder.Services.AddDependencies(opt =>
{
    opt.ConnectionString = builder.Configuration["ConnectionString"];
    opt.DatabaseName = builder.Configuration["Database"];
});
```

5. Faça o build da aplicação e rode normalmente.
## Autores

- [Bruno Vinícius](https://www.github.com/Brunovini08)

