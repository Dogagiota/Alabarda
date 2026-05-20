CREATE DATABASE alabarda;
USE alabarda;

CREATE TABLE jogador (
    jogador_id INT AUTO_INCREMENT PRIMARY KEY,
    jogador_nome VARCHAR(45) NOT NULL,
    jogador_email VARCHAR(45) NOT NULL,
    jogador_senha VARCHAR(45) NOT NULL
);

CREATE TABLE personagem (
    personagem_id INT AUTO_INCREMENT PRIMARY KEY,
    personagem_nome VARCHAR(45),
    personagem_descricao TEXT,
    personagem_historia TEXT,
    personagem_vida INT
);

CREATE TABLE arma (
    arma_id INT AUTO_INCREMENT PRIMARY KEY,
    arma_dano INT,
    arma_nome VARCHAR(45),
    arma_descricao TEXT,
    arma_historia TEXT
);

CREATE TABLE armadura (
    armadura_id INT AUTO_INCREMENT PRIMARY KEY,
    armadura_defesa INT,
    armadura_nome VARCHAR(45),
    armadura_descricao TEXT,
    armadura_historia TEXT
);

CREATE TABLE habilidade (
    habilidade_id INT AUTO_INCREMENT PRIMARY KEY,
    habilidade_nome VARCHAR(45),
    habilidade_descricao TEXT,
    habilidade_valor INT
);

CREATE TABLE conquistas (
    conquistas_id INT AUTO_INCREMENT PRIMARY KEY,
    conquistas_nome VARCHAR(45),
    conquistas_descricao TEXT
);

CREATE TABLE salvamento (
    salvamento_id INT AUTO_INCREMENT PRIMARY KEY,
    salvamento_nome VARCHAR(45),
    salvamento_vida_max INT,
    salvamento_conclusao DECIMAL(5,2),
    jogador_jogador_id INT,
    FOREIGN KEY (jogador_jogador_id) REFERENCES jogador(jogador_id)
);

CREATE TABLE arma_has_salvamento (
    arma_arma_id INT,
    salvamento_salvamento_id INT,
    PRIMARY KEY (arma_arma_id, salvamento_salvamento_id),
    FOREIGN KEY (arma_arma_id) REFERENCES arma(arma_id),
    FOREIGN KEY (salvamento_salvamento_id) REFERENCES salvamento(salvamento_id)
);

CREATE TABLE armadura_has_salvamento (
    armadura_armadura_id INT,
    salvamento_salvamento_id INT,
    PRIMARY KEY (armadura_armadura_id, salvamento_salvamento_id),
    FOREIGN KEY (armadura_armadura_id) REFERENCES armadura(armadura_id),
    FOREIGN KEY (salvamento_salvamento_id) REFERENCES salvamento(salvamento_id)
);

CREATE TABLE habilidade_has_salvamento (
    habilidade_habilidade_id INT,
    salvamento_salvamento_id INT,
    PRIMARY KEY (habilidade_habilidade_id, salvamento_salvamento_id),
    FOREIGN KEY (habilidade_habilidade_id) REFERENCES habilidade(habilidade_id),
    FOREIGN KEY (salvamento_salvamento_id) REFERENCES salvamento(salvamento_id)
);

CREATE TABLE salvamento_has_personagem (
    salvamento_salvamento_id INT,
    personagem_personagem_id INT,
    PRIMARY KEY (salvamento_salvamento_id, personagem_personagem_id),
    FOREIGN KEY (salvamento_salvamento_id) REFERENCES salvamento(salvamento_id),
    FOREIGN KEY (personagem_personagem_id) REFERENCES personagem(personagem_id)
);

CREATE TABLE jogador_has_conquistas (
    jogador_jogador_id INT,
    conquistas_conquistas_id INT,
    PRIMARY KEY (jogador_jogador_id, conquistas_conquistas_id),
    FOREIGN KEY (jogador_jogador_id) REFERENCES jogador(jogador_id),
    FOREIGN KEY (conquistas_conquistas_id) REFERENCES conquistas(conquistas_id)
);
