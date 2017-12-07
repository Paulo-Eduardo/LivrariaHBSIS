WebService simples para gerenciamento de inventario de livraria

Base MySQL

Criação tabela
    CREATE TABLE Livro(
        Id char(36) not null,
        Nome varchar(50),
        Autor varchar(50),
        primary key (Id)
    );

Para rodar o sistema:
    - Subir webapi(utilizado Owin para selfhosting)
    - Abir index.html na pasta Front