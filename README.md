
# Pet Shop 🐕

### Introdução

Iniciando primeira API, criado uma API simples para um PetShop, API permitirá que você gerencie informações sobre animais de estimação, clientes e serviços oferecidos. 

## Stack utilizada

***\*Back-end:\**** *Asp.Net, .Net, C#, Visual Studio 2022*


* ## Documentação da API

  * [Documentação](https://github.com/nahnaoliv/PetshopAPI)

  #### Estrutura do Projeto

  `PetshopAPI/`
  `│`
  `├── Context/`
  `│   └── PetshopContext.cs/`

  `├── Controllers/`

  `│   ├── ClienteController.cs/`

  `│   ├── ClientePetController.cs/`
  `│   └── ServicoController.cs/`

  `├── Migrations/`

  `├── Models/`
  `│   ├── ClientePet/`
  `│   │   └── ClientePet.cs`

  `│   │   └── EnunmRaca.cs`
  `│   ├── Clientes`
  `│   │   └── Clientes.cs`
  `│   │   └── EnumStatusClientes.cs`

  `│   ├── Servico`
  `│   │   └── EnumDisponibilidade.cs`

  `│   └──   └── Servico.cs`
  `├── PetshopAPI.sln`
  `└── README.md`

  #### Retorna itens por ID

  ```http
    GET /PetShopAPI/{id}
  ```

  | Parâmetro   | Tipo       | Descrição                           |
  | :---------- | :--------- | :---------------------------------- |
  | `id` | `int` | **Obrigatório**. O ID do item que você quer |

  #### Retorna todos os itens

  ```http
    GET /PetShop/Todos
  ```

  | Parâmetro   | Tipo       | Descrição                                   |
  | :---------- | :--------- | :------------------------------------------ |
  | `id`      | `int` | **Obrigatório**. |
