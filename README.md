﻿# clean_architecture_example
**O projeto não está adequado para rodar, pois está faltando a implementação dos repositorioes, configuração da main. Seu objetivo é mostrar as comunicações e regras de cada camada**

Este repositório é um exemplo da implementação da arquitetura limpa mostrada no livro “Clean Architecture” do autor Robert C. Martin.

O livro nos apresenta as quatro camadas essenciais, digo isso pois podem haver mais, para a implementação da arquitetura limpa.

## Camadas

### Entidades: 
Ondem ficam as regras de negócios da empresa. Esta camada não conhece ninguém além delas mesma.

### Casos de Uso: 
Ondem ficam as regras de negócio da aplicação. Essa orquestra o fluxo de dados para e a partir das entidades. Essa camada ainda faz parte do Core da aplicação, mas não pode afetar a camada de entidades.

### Adaptadores de Interface: 
Essa camada é mostra ao “mundo” o nosso core (camada de casos de uso e entidades) do sistema. Ela é responsável por realizar a tradução das respostas obtidas dos casos de uso para quem precisa dela. Exemplo: No caso de uso não precisamos especificar qual o HttpCode resultante da operação de criar uma entidade, mas essa camada de adaptadores é quem vai dizer isso para o nosso Driver/Framework Web. Importante saber que é esta camada quem implementará os nossos repositórios.

### Frameworks e Drivers: 
Essa camada se comunica diretamente com a de Adaptadores. Essa é a camada mais volátil do sistema, é o nosso “plug and play” do restante. Aqui ficarão os frameworks web, configurações dos servidores de banco de dados, entre outros.

## Comunicação entre Camadas:

Ao ler o código perceberá que as camadas se conversam através de interfaces, a classe que “quebrará“ essa regra de utilizar uma classe concreta de outra camada será a classe Main, onde utilizará um injetor de dependência para fazer esse bind da interface e sua implementação.

Sobre esse transporte de dados, os Enums, Constantes, que estão presentes na camada Entitidade, podem ser transportados entre as camadas sem a utilização de interfaces. Quanto as classes de negócios não devem sair da classe de Casos de Uso, ou seja, quer utilizar alguma informação da entidade em outra camada, crie um DTO dela.

## Trabalhando à favor da Orientação a Objetos:

O próprio autor do livro cita que se todas as nossa classes forem públicas, poderemos “by-passar” qualquer camada da nossa arquitetura. Se somente os casos de uso podem enxergar suas entidades, coloque-as no mesmo pacote e deixa as entidades como “internal” (um exemplo para .net) e assim para as outras camadas. Deixa a interface ser pública e sua implementação privada. Em alguns casos isso não será possível, mas já ajudará  muitos desenvolvedores, sem perceberem, “pular” camadas da sua arquitetura.

## Padrões:
Como pode se notar no código, a utilização da arquitetura limpa deixa as portas abertas para a utilização de vários padrões recomendados, como por exemplo, podemos aplicar os conceitos/estratégias de DDD na camada de Entities, podemos aplicar CQRS na camada application, podemos aplicar Repositories e Unit Of Work na camada de Adaptadores, entre outros padrões.

## Observação:

A camada de adaptadores, se for levada ao pé da letra, deveria ter além dos presenters (classes responsáveis por traduzir as respostas da camada UseCase para a camada Frameworks) os controllers, para ficar totalmente independente de qualquer framework. Mas como o framework utilizado nessa aplicação já possuía os controllers, foi decidido não criar uma camada a mais para este processo.

## Use com Moderação:

O exemplo mostrado possui dezenas de linhas de código apenas para simular a criação de uma tarefa, ou seja, foi feito um enorme esforço para uma tarefa simples. O próprio criador do clean code cita: 
”Limites arquiteturais completamente desenvolvidos são caros. Eles exigem interfaces, estruturas de dados, IO, gestão de dependência,… Isso requer muito trabalho. Em muitas situações o arquiteto deve julgar se o custo desse limite é alto demais.”

Portanto, em certos cenários, a implantação à risca do Clean Architecture pode não ser a mais adequada, assim como a implantação do DDD não é para todos os casos.

![alt text](image.png)
