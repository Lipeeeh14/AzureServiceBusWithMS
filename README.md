# AzureServiceBusWithMS

- O repositório contém as seguintes aplicações
  -- Um producer central que envia as mensagens para o recurso e a fila indicada (utiliza o MassTransit para realizar a comunicação com o Azure Service Bus);
  -- Um consumer com o MassTransit onde ele lida com todo o gerenciamento das filas;
  -- Duas functions, uma para consumir a fila e a outra para consumir as mensagens que foram para a "dead-letter" (outra alternativa de consumer onde já utiliza o serviço fornecido pela Azure facilitando o deploy e infraestrutura da aplicação, além disso o Service Bus fica responsável pelo reenvio das mensagens que retornaram algum tipo de exceção).
