Segue o script para criar a tabela no MySQL

NÃO é necessário rodar migrations, apenas crie a tabela e insira os Inserts e o sistema estará rodando normalmente.

Crie o banco com o nome Losjista.

use Lojista
CREATE TABLE Clientes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NomeRazaoSocial VARCHAR(150) NOT NULL,
    Email VARCHAR(150) NOT NULL UNIQUE,
    Telefone VARCHAR(11) NOT NULL,
    DataCadastro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    TipoPessoa ENUM('Física', 'Jurídica') NOT NULL,
    CPFCNPJ VARCHAR(14) NOT NULL UNIQUE,
    InscricaoEstadual VARCHAR(12),
    Isento BOOLEAN NOT NULL DEFAULT FALSE,
    Genero ENUM('Feminino', 'Masculino', 'Outro'),
    DataNascimento DATE,
    Bloqueado BOOLEAN NOT NULL DEFAULT FALSE,
    Senha VARCHAR(15) NOT NULL,
    CONSTRAINT CHK_Senha CHECK (CHAR_LENGTH(Senha) >= 8 AND CHAR_LENGTH(Senha) <= 15)
);


INSERT INTO Clientes (NomeRazaoSocial, Email, Telefone, TipoPessoa, CPFCNPJ, Genero, DataNascimento, Senha, DataCadastro, InscricaoEstadual, Isento, Bloqueado)
VALUES ('João Silva', 'joao.silva@example.com', '11987654321', 'Física', '12345678901', 'Masculino', '1980-01-01', 'senha12345', NOW(), NULL, FALSE, FALSE);

INSERT INTO Clientes (NomeRazaoSocial, Email, Telefone, TipoPessoa, CPFCNPJ, Genero, DataNascimento, Senha, DataCadastro, InscricaoEstadual, Isento, Bloqueado)
VALUES ('Maria Souza', 'maria.souza@example.com', '21987654321', 'Física', '12345678902', 'Feminino', '1990-05-15', 'senha12345', NOW(), NULL, FALSE, FALSE);

INSERT INTO Clientes (NomeRazaoSocial, Email, Telefone, TipoPessoa, CPFCNPJ, DataNascimento, Senha, DataCadastro, InscricaoEstadual, Isento, Bloqueado)
VALUES ('Empresa ABC Ltda', 'contato@empresaabc.com', '31987654321', 'Jurídica', '12345678000101', NULL, 'senha12345', NOW(), '123456789012', FALSE, FALSE);

INSERT INTO Clientes (NomeRazaoSocial, Email, Telefone, TipoPessoa, CPFCNPJ, Genero, DataNascimento, Senha, DataCadastro, InscricaoEstadual, Isento, Bloqueado)
VALUES ('Carlos Pereira', 'carlos.pereira@example.com', '41987654321', 'Física', '12345678903', 'Masculino', '1975-03-22', 'senha12345', NOW(), NULL, FALSE, TRUE);

INSERT INTO Clientes (NomeRazaoSocial, Email, Telefone, TipoPessoa, CPFCNPJ, Genero, DataNascimento, Senha, DataCadastro, InscricaoEstadual, Isento, Bloqueado)
VALUES ('Ana Oliveira', 'ana.oliveira@example.com', '11987654322', 'Física', '12345678904', 'Feminino', '1988-07-10', 'senha12345', NOW(), NULL, FALSE, FALSE);

INSERT INTO Clientes (NomeRazaoSocial, Email, Telefone, TipoPessoa, CPFCNPJ, Genero, DataNascimento, Senha, DataCadastro, InscricaoEstadual, Isento, Bloqueado)
VALUES ('Pedro Santos', 'pedro.santos@example.com', '21987654323', 'Física', '12345678905', 'Masculino', '1995-02-28', 'senha12345', NOW(), NULL, FALSE, FALSE);

INSERT INTO Clientes (NomeRazaoSocial, Email, Telefone, TipoPessoa, CPFCNPJ, DataNascimento, Senha, DataCadastro, InscricaoEstadual, Isento, Bloqueado)
VALUES ('Empresa XYZ Ltda', 'contato@empresaxyz.com', '31987654324', 'Jurídica', '12345678000102', NULL, 'senha12345', NOW(), '123456789013', FALSE, FALSE);

INSERT INTO Clientes (NomeRazaoSocial, Email, Telefone, TipoPessoa, CPFCNPJ, Genero, DataNascimento, Senha, DataCadastro, InscricaoEstadual, Isento, Bloqueado)
VALUES ('Fernanda Costa', 'fernanda.costa@example.com', '41987654325', 'Física', '12345678906', 'Feminino', '1982-11-15', 'senha12345', NOW(), NULL, FALSE, FALSE);
