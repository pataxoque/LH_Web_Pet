-- 1. Criação do Banco
CREATE DATABASE IF NOT EXISTS db_vetplus;
USE db_vetplus;

-- 2. Tabela de Usuários 
CREATE TABLE IF NOT EXISTS tb_usuario (
    pk_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nm_usuario VARCHAR(255) NOT NULL DEFAULT 'Usuário do Sistema',
    nm_email VARCHAR(150) NOT NULL UNIQUE,
    ds_senha_hash VARCHAR(255) NOT NULL,
    fl_senha_temporaria BOOLEAN NOT NULL DEFAULT FALSE,
    ds_perfil VARCHAR(50) NOT NULL,
    fl_ativo BOOLEAN NOT NULL DEFAULT TRUE
);

-- 3. Tabela de Clientes 
CREATE TABLE IF NOT EXISTS tb_cliente (
    pk_cliente INT AUTO_INCREMENT PRIMARY KEY,
    fk_usuario INT NOT NULL,
    nm_cliente VARCHAR(255) NOT NULL,
    cd_cpf VARCHAR(14) NOT NULL UNIQUE,
    cd_telefone VARCHAR(20) NOT NULL,
    FOREIGN KEY (fk_usuario) REFERENCES tb_usuario(pk_usuario) ON DELETE CASCADE
);