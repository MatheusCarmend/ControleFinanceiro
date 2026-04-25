Controle Financeiro (Dashboard Financeiro)

Aplicação full stack para gerenciamento financeiro, permitindo o registro de ganhos e despesas, cálculo automático de saldo e visualização das transações.

Tecnologias utilizadas:

🔹 Back-end
* C#
* .NET / ASP.NET Core
* Entity Framework Core
* SQL Server
  
🔹 Front-end
* HTML
* CSS
* JavaScript

Funcionalidades:
Cadastro de transações (ganhos e despesas)
Cálculo automático de saldo
Listagem de transações
Organização por tipo (ganho/despesa)
Interface simples e funcional


Sobre o projeto:
Este projeto foi desenvolvido com o objetivo de praticar o desenvolvimento full stack, integrando uma API REST construída em ASP.NET Core com um front-end em JavaScript puro.
A aplicação simula um sistema real de controle financeiro, aplicando conceitos como:
* CRUD
* Integração front-end/back-end
* Persistência de dados com banco relacional
* Estruturação de APIs REST


Como executar o projeto:
🔹 Back-end
1. Acesse a pasta:
```bash
cd backend
```
2. Execute a aplicação:
```bash
dotnet run
```
3. A API estará disponível em:
```bash
https://localhost:7133
```

### 🔹 Front-end
1. Acesse a pasta:
```bash
cd frontend
```
2. Abra o arquivo `index.html` no navegador
   ou utilize a extensão Live Server no VS Code
   

Integração
O front-end consome a API através do endpoint:
```bash
https://localhost:7133/api/transactions
```

Melhorias futuras:
🔍 Filtros por categoria
📅 Filtro por data
🗑️ Exclusão de transações
✏️ Edição de transações
🔐 Autenticação de usuários

---

Autor:
Matheus Cardoso
🔗 https://github.com/MatheusCarmend

---

