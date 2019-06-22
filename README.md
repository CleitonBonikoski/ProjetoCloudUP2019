# ProjetoCloudUP2019

1º Passo: Caso a base de dados ProjetoCloud exista, delete ela para começar do zero. Este passo é muito importante.

2º Passo: No Visual Studio, no Nuget Packet Manager Console (Aonde executamos as migrations), selecione a opção DAL no dropdown "Projeto padrão".

3º Passo: Digite:

    update-database -context CloudContexto

4º Passo: No Visual Studio, no Nuget Packet Manager Console (Aonde executamos as migrations), selecione a opção ProjetoCloud no dropdown "Projeto padrão".

5º Passo: Digite:

    update-database -context ProjetoCloudContext

6º Limpe e compile a solução e pronto!
