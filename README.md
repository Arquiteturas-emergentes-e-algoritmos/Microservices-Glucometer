# Microserviços 
Vinda do ágil, há divergências sobre se microserviços são um novo estilo arquitetural ou uma aplicação maior da arquitetura orientada a serviços. O foco de um microserviço é decompor a aplicação em pequenos serviços que se comunicarão através de APIs Rest e streams garantindo pricipalmente a modularidade de cada serviço através de um sistema distribuído. 
Ao utilizar os microserviços, a aplicação ganha alguns benefícios como:
- Escalabilidade;
- Segurança
- Tolerância a falhas
- Manutenabilidade;
- Cada módulo se torna independente, substituível e evoluível;
- Menos complexidade dentro de um módulo;
- Mais testabilidade dentro de um módulo;
- Pode-se utilizar mais de uma linguagem, ou seja, um serviço A pode utilizar uma linguagem X enquanto um serviço B utilizar uma linguagem Y;
Todavia, o microserviços também apresentam uma série de malefícios como:
- Dificuldade em fazer testes entre serviços, por ser um sistema distribuído;
- Requere mais coordenação do time de desenvolvimento;
- Aplicativo como um geral se torna mais complexo;
- Conceitos de qualidade de software ainda são obscuros quanto a microserviços;
- Uso crescente de memória;

Para construir um aplicativo utilizando a arquitetura de microserviços, é essencial planejar cuidadosamente como os serviços serão fragmentados, já que isso é fundamental para a escalabilidade. A fragmentação pode ser realizada com base em verbos, criando um microserviço para cada ação, em substantivos, estruturando serviços em torno de entidades, ou utilizando modelos como o ETSI. Além disso, a comunicação entre os microserviços é um aspecto crítico. Pode-se optar pelo acesso direto aos serviços, uma abordagem flexível, mas que pode gerar atrasos; pelo uso de gateways, comuns na IoT para lidar com limitações de dispositivos legados; ou por serviços de mensageria, amplamente utilizados por sua capacidade de gerenciar comunicações assíncronas e atrasos controlados, por fim, vale ressaltar que a base de dados é independente entre cada microserviço, ou seja, uma base para cada.

Para produzir as provas de conceito associadas à tal arquitetura, foi construído um diagrama que revela a conversação entre os microserviços, para fins de praticidade, 
foi utilizado o método de acesso direto aos serviços, todavia, vale ressaltar que normalmente é utilizado um serviço de mensageria. A imagem abaixo revela essa relação entre os microserviços:



Ao submeter esta arquitetura a prova de conceito, aliada a arquitetura onion, foi observado uma maior independência no processo de desenvolvimento entre os microserviços, cada repositório pode-se adequar de maneira natural conforme a necessidade do tema de cada microserviço. Além disso, como já evidenciado pelo material teórico, a testabilidade melhorou dentro de um módulo, todavia, testes de integração entre os serviços se tornaram extremamente difícies, ademais, foi necessário criar mais duas rotas para o projeto afim de modularizar de maneira correta a aplicação. Uma propriedade que ficou bastante evidente durante o processo de desenvolvimento dos microserviços foi a manutenabilidade de cada modulo, na primeira submissão do código ao sonar, foram acusados pouquíssimos erros, e os que foram acusados, foram fáceis de serem resolvidos.
