Bem vindo ao projeto de teste desenvolvimento para a eWave do desenvolvedor Leonardo Tosin

Para executar: 

1) Abra a solução do projeto no visual studio (foi desenvolvido no 2022) e mude as configurações de conexão de banco de dados do SQL Server no arquivo appsettings.json.
2) Crie na sua instancia do SQL Server um banco de dados chamado TruckDB.
3) Ainda no visual studio, executar no Console de Gerenciador de Pacotes os seguintes comandos:
  AddMigration TruckMigration1
  Update-Database  
3) Compilar o projeto eWaveVolvoAPI, você pode executar no IIS Express ou rodar na sua instancia do IIS da sua maquina em uma porta personalizada.
4) No arquivo: eWaveVoltoView\js\requestApi.js editar a primeira linha de código, substituindo o IP do arquivo pelo IP da sua maquina:porta que está rodando o IIS, cuidado para não remover o conteudo /api/.
5) Executar o arquivo eWaveVoltoView\index.html no navegador.
