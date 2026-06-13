# InventoryService

Microsserviço responsável por gerenciar o estoque de itens do restaurante.

## Tecnologias
- .NET 8
- Entity Framework Core + SQLite
- Swagger/OpenAPI

## Porta padrão
`5002`

## Como rodar

```bash
dotnet run
```

Swagger disponível em: http://localhost:5002/swagger

## Endpoints
- `GET /api/inventory` — Lista todos os itens em estoque
- `GET /api/inventory/{productId}` — Consulta estoque de um produto
- `POST /api/inventory/decrease` — Decrementa quantidade em estoque
