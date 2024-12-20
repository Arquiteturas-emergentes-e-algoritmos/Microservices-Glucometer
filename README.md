# 📦 Microserviços 
## 🔎 Oque é ?

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

## 📎 Provas de conceito

Para produzir as provas de conceito associadas à tal arquitetura, foi construído um diagrama que revela a conversação entre os microserviços, para fins de praticidade, 
foi utilizado o método de acesso direto aos serviços, todavia, vale ressaltar que normalmente é utilizado um serviço de mensageria. A relação entre os microserviços da POCs é independente, ou seja, nenhum deles se conversam diretamente, isto é ocorre devido a capacidade modularizante do domínio visando garantir tolerância a quedas nos serviços. 

Ao submeter esta arquitetura a prova de conceito, aliada a arquitetura onion, foi observado uma maior independência no processo de desenvolvimento entre os microserviços, cada repositório pode-se adequar de maneira natural conforme a necessidade do tema de cada microserviço. Além disso, como já evidenciado pelo material teórico, a testabilidade melhorou dentro de um módulo, todavia, testes de integração entre os serviços se tornaram extremamente difícies, ademais, foi necessário criar mais duas rotas para o projeto afim de modularizar de maneira correta a aplicação.

Uma propriedade que ficou bastante evidente durante o processo de desenvolvimento dos microserviços foi a manutenabilidade de cada modulo, na primeira submissão do código ao sonar, foram acusados pouquíssimos erros, e os que foram acusados, foram fáceis de serem resolvidos.

## 🧅 Arquitetura Onion
A **Onion Architecture** é uma abordagem para sistemas corporativos complexos, focada na **separação de responsabilidades** e na redução do **acoplamento** entre componentes.
### Principais conceitos
1. **Domínio no centro**:  
   O núcleo da aplicação é o **Domain Model**, responsável pela lógica de negócios e regras. Camadas externas, como UI e infraestrutura, não afetam o núcleo.
2. **Infraestrutura externa**:  
   Banco de dados e outros sistemas externos são acessados apenas por meio de interfaces definidas no núcleo, facilitando mudanças.
3. **Redução de acoplamento**:  
   Todas as dependências apontam para o núcleo, evitando que mudanças em detalhes externos impactem a lógica central.
4. **Princípio da inversão de dependência**:  
   O núcleo define interfaces e depende de implementações fornecidas pelas camadas externas, promovendo flexibilidade e manutenção.

## 🪐 SonarQube
A figura 2 apresenta os dados coletados pelo SonarQube referentes a esta arquitetura, vale ressaltar que devido a configurações do sonar, não foi possível coletar a cobertura dos testes automaticamente.

![Arquitetura Microserviços](img/SonarGlucometer.PNG)  
*Figura 2: SonarQube. Fonte:Autor*  

## 📖 Referências

1. Fowler, M. Microservices Guide. *martinfowler.com*. Disponível em: [https://martinfowler.com/microservices/](https://martinfowler.com/microservices/).

2. Li, S., Zhang, H., Jia, Z., Zhong, C., Zhang, C., Shan, Z., Shen, J., & Babar, M. A. (2021). Understanding and addressing quality attributes of microservices architecture: A Systematic literature review. *Information and Software Technology, 131*, 106449. DOI: [10.1016/j.infsof.2020.106449](https://doi.org/10.1016/j.infsof.2020.106449).

3. Dmitry, N., & Sneps-Sneppe, M. (2014). On Micro-Services Architecture. *International Journal of Open Information Technologies, 2*(9), 24–27.

4. Palamarchuk, Y. A. (2022). Methods of building microservice architecture of e-learning systems. *Інформаційні технології та комп'ютерна інженерія*, (1), 43–54.

5. Palermo, J. (2008, julho). The Onion Architecture (Part 1). *Programming with Palermo*. Disponível em: [https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/?source=post_page-----551f460c3b2c--------------------------------](https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/?source=post_page-----551f460c3b2c--------------------------------).

## 📅 Versionamento

| Versão |    Data    |         Descrição          |  Autor(es)  |
| :----: | :--------: | :------------------------: | :---------: |
| `1.0`  | 04/12/2024 | Criação de documento | Kauã |
| `1.1` | 19/12/2024| Adição do sonar e das referências | Kauã| 

