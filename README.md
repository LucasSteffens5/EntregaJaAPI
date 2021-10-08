# EntregaJaAPI
API implementada em .NET 5,  com gerenciar as vendas de uma loja delivery.


É possível Criar, Remover, Atualizar e Listar produtos.

# Criar Produtos

Para Criar Produtos basta executar o POST com a URL https://localhost:5001/CriarProduto com o seguinte corpo:
```javascript
{
    "Nome": "Arroz",
    "Descricao": "Branco",
    "Preco": 20.5
}
```
A resposta esperada é:

```javascript
{
    "idProduto": 1,
    "nome": "Arroz",
    "descricao": "Branco",
    "preco": 20.5
}
```

# Remover Produtos

Para remover/excluir produtos basta executar o DELETE com a seguinte URL https://localhost:5001/DeletarProduto/{id}
Onde {id} indica o identificador único do produto.

A resposta esperada é um 204 no content.


# Atualizar Produtos
Para atualizar produtos basta executar o comando PUT com  a URL https://localhost:5001/AtualizarProduto/{id} acompanhado pelo corpo da atualização.
Onde {id} indica o identificador único do produto.

```javascript
{
    "nome": "Cebola",
    "descricao": "In Natura",
    "preco": 5.5
}
```

# Listar Produtos
Para listar todos os produtos basta executar o comando GET com a URL https://localhost:5001/ListarProdutos

Para lista um produto basta executar o comando GET com a URL https://localhost:5001/ConsultarProduto/{id}
Onde {id} indica o identificador único do produto.



# Criar Vendas
Para criar uma venda basta executar o comando POST com a URL https://localhost:5001/RealizarVenda acompanhado do seguinte corpo.

```javascript
{
  "cep": "78570-000",
  "produtosDaVenda": [
    {
      "idProduto": 3,
      "quantidade": 4
    },
    {
      "idProduto": 4,
      "quantidade": 5
    }
  ]
}
```
É retornado um Bad Request caso:

* O CEP não seja informado ou informado de maneira invalida.
* Algum dos itens informados não existir na base de dados.
