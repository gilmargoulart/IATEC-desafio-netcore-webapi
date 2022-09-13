# IATEC


## Executar
```dotnet run```

Acessar [http://localhost:5135/api-docs]

## Desafio técnico

- Quando você começar, faça um commit vazio com a mensagem Inicial e quando terminar, faça o commit com uma mensagem final;

- Você deve prover evidências suficientes de que sua solução está completa indicando, no mínimo, que ela funciona;

- Construir uma API REST utilizando .Net Core e C#.

- A API deve expor uma rota com documentação swagger ([http://.../api-docs]http://.../api-docs).

- A API deve possuir 3 operações:

1) Registrar venda: Recebe os dados do vendedor + itens vendidos.Registra venda com status "Aguardando pagamento";
2) Buscar venda: Busca pelo Id da venda;
3) Atualizar venda: Permite que seja atualizado o status da venda.

- OBS.: Possíveis status: Pagamento aprovado | Enviado | Entregue | Cancelado.

Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;

O vendedor deve possuir id, cpf, nome;

A inclusão de uma venda deve possuir pelo menos 1 item;

A atualização de status deve permitir somente as seguintes transições:

De: Aguardando pagamento Para: Pagamento Aprovado

De: Aguardando pagamento Para: Cancelada

De: Pagamento Aprovado Para: Enviado

De: Pagamento Aprovado Para: Cancelada

De: Enviado. Para: Entregue

Status:
> 0: Aguardando pagamento\
> 1: Pagamento aprovado\
> 2: Enviado\
> 3: Entregue\
> 9: Cancelado
