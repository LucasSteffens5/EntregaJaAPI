# EntregaJaAPI
API implementada em .NET 5,  com gerenciar as vendas de uma loja delivery.

* É possível Criar, Remover, Atualizar e Listar produtos.
* É possível Criar, Cancelar, e Listar Vendas.
* O frete é calculado automaticamente através do cep informado pelo destinatário.
```
* A sede se localiza em Rio de Janeiro.
* Entregas na mesma cidade custam R$10,00.
* Entregas para outras cidades custam R$20,00.
* Entregas para outros estados custam R$40,00.
```
# Observações sobre a construção:

    * Os testes foram realizados utilizando o POSTMAN.    
    * Foi utilizado Entityframeworkcore.postgresql na máquina local durante o desenvolvimento, porém para o envio o projeto esta configurado para utilizar o            Entityframeworkcore.inmemory.
Para executar a aplicação basta abrir a solução no visual studio 2019, instalar os pacotes se requisitados e executar.
Após basta utilizar o POSTMAN (foi disponibilizado a exportação da coleção do POSTMAN) para realizar as requisições exemplificadas abaixo.

# Criar Produtos

Para Criar Produtos basta executar o POST com a URL https://localhost:5001/CriarProduto com o seguinte corpo:
```javascript
{
    "Nome": "Arroz",
    "Descricao": "Branco",
    "Preco": 20.5
}
```
A resposta esperada é 201 Created: 

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
A resposta esperada é um 204 no content.

# Listar Todos os Produtos
Para listar todos os produtos basta executar o comando GET com a URL https://localhost:5001/ListarProdutos

A resposta esperada é 200 Ok: 

```javascript
[
    {
        "idProduto": 3,
        "nome": "Tomate",
        "descricao": "Italiano",
        "preco": 4.5
    },
    {
        "idProduto": 2,
        "nome": "Cebola",
        "descricao": "In Natur",
        "preco": 5.5
    },
    {
        "idProduto": 4,
        "nome": "Vinho",
        "descricao": "Português",
        "preco": 40.5
    }
]
```


# Listar Produtos por Id
Para listar um produto basta executar o comando GET com a URL https://localhost:5001/ConsultarProduto/{id}
Onde {id} indica o identificador único do produto.

A resposta esperada é 200 Ok: 

```javascript
{
    "idProduto": 3,
    "nome": "Tomate",
    "descricao": "Italiano",
    "preco": 4.5,
    "horaDaConsulta": "2021-10-08T12:30:45.4707268-04:00"
}
```


# Criar Vendas
Para criar uma venda basta executar o comando POST com a URL https://localhost:5001/RealizarVenda acompanhado do seguinte corpo.

```javascript
{
  "cep": "27700-000",
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
A resposta esperada é 201 Created:

```javascript
{
    "idVenda": 3,
    "cep": "27700-000",
    "dataHoraVenda": "2021-10-08T12:32:00.7604346-04:00",
    "dataHoraCancelamentoVenda": "0001-01-01T00:00:00",
    "valorFrete": 20,
    "valorTotalVenda": 220.5,
    "produtosDaVenda": [
        {
            "idProdutoNaVenda": 3,
            "idProduto": 3,
            "nome": "Tomate",
            "descricao": null,
            "preco": 4.5,
            "quantidade": 4
        },
        {
            "idProdutoNaVenda": 4,
            "idProduto": 4,
            "nome": "Vinho",
            "descricao": null,
            "preco": 40.5,
            "quantidade": 5
        }
    ]
}
```

É retornado um Bad Request caso:

* O CEP não seja informado ou informado de maneira invalida.
* Algum dos itens informados não existir na base de dados.

# Cancelar Venda
Para cancelar uma venda basta executar o comando PUT com a URL https://localhost:5001/CancelarVenda/{id}
Onde {id} indica o identificador único da venda.
A resposta esperada é 204 no content:

# Consultar Historico de Venda
Para consultar o histórico de venda basta executar o comando GET com a URL https://localhost:5001/HistoricoDeVenda
A resposta esperada é um 200 Ok:
  
  ```javascript
[
    {
        "idVenda": 1,
        "cep": "78570-000",
        "dataHoraVenda": "2021-10-08T12:24:14.3904638-04:00",
        "dataHoraCancelamentoVenda": "2021-10-08T12:34:02.7071849-04:00",
        "valorFrete": 40,
        "valorTotalVenda": 184.5       
    }
]
```

# Consultar Venda por id
Para consultar uma venda por id basta executar o comando GET com a URL https://localhost:5001/ConsultarVenda/{id}
Onde {id} indica o identificador único da venda.

O resultado esperado é um 200 Ok: 

```javascript
{
    "idVenda": 1,
    "cep": "78570-000",
    "dataHoraVenda": "2021-10-08T12:24:14.3904638-04:00",
    "dataHoraCancelamentoVenda": "2021-10-08T12:34:02.7071849-04:00",
    "valorFrete": 40,
    "valorTotalVenda": 184.5,
    "produtosDaVenda": []
}
```
