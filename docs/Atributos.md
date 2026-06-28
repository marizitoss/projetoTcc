# Atributos

Atributos de cada entidade do sistema.

---

## Jogador

| Atributo  | Tipo   | Descrição                      |
| :-------- | :----- | :----------------------------- |
| id        | String | Identificador único do jogador |
| nome      | String | Nome do personagem             |
| posicao_x | Float  | Posição horizontal no mapa     |
| posicao_y | Float  | Posição vertical no mapa       |
| afinidade | String | Afinidade mágica escolhida     |

---

## Inventário

| Atributo          | Tipo             | Descrição                                             |
| :---------------- | :--------------- | :---------------------------------------------------- |
| jogador_id        | String           | chave estrangeira atrelando o inventario ao jogador   |
| slots             | List\<SlotItem\> | Lista de slots com referência ao recurso e quantidade |
| capacidade_maxima | Int              | Limite de slots disponíveis (a definir no MVP)        |

---

## SlotItem

| Atributo   | Tipo    | Descrição                        |
| :--------- | :------ | :------------------------------- |
| recurso    | Recurso | Referência ao tipo de recurso    |
| quantidade | Int     | Quantidade do recurso neste slot |

---

## Recurso

| Atributo | Tipo   | Descrição                      |
| :------- | :----- | :----------------------------- |
| id       | String | Identificador único do recurso |
| nome     | String | Ex: Madeira, Trigo, Água       |
| tipo     | Enum   | MADEIRA \| TRIGO \| AGUA       |

---

## Golem

| Atributo      | Tipo    | Descrição                                                |
| :------------ | :------ | :------------------------------------------------------- |
| id            | String  | Identificador único do golem                             |
| jogador_id    | String  | foreign key do jogador dono do golem                     |
| tipo          | Enum    | COLETOR \| MINERADOR \| TRANSPORTADOR                    |
| runa_equipada | Runa    | Runa que define o comportamento do golem                 |
| posicao_x     | Float   | Posição atual no mapa                                    |
| posicao_y     | Float   | Posição atual no mapa                                    |
| ativo         | Boolean | Se o golem está executando seu comportamento determinado |

---

## Runa

| Atributo       | Tipo   | Descrição                                              |
| :------------- | :----- | :----------------------------------------------------- |
| id             | String | Identificador único                                    |
| nome           | String | Nome da runa                                           |
| tipo_automacao | String | Tipo de tarefa que a runa habilita                     |
| nivel          | Int    | Nível de poder da runa (reservado — sem efeito no MVP) |

---

## Construção

| Atributo  | Tipo    | Descrição                        |
| :-------- | :------ | :------------------------------- |
| id        | String  | Identificador único              |
| tipo      | Enum    | BASE \| ARMAZEM \| DUNGEON       |
| posicao_x | Int     | Posição no grid do mapa (tile X) |
| posicao_y | Int     | Posição no grid do mapa (tile Y) |
| ativa     | Boolean | Se a construção está funcional   |

---

## Dungeon

| Atributo          | Tipo         | Descrição                                                                    |
| :---------------- | :----------- | :--------------------------------------------------------------------------- |
| construcao_id     | String       | Chave primária da Dungeon, que também referencia a Construção correspondente |
| nivel             | Int          | Nível de dificuldade da dungeon                                              |
| runas_disponiveis | List\<Runa\> | Runas que podem ser obtidas ao completar                                     |
| concluida         | Boolean      | Se o jogador já completou essa dungeon                                       |

---

## Mapa

| Atributo    | Tipo               | Descrição                        |
| :---------- | :----------------- | :------------------------------- |
| largura     | Int                | Largura em número de tiles       |
| altura      | Int                | Altura em número de tiles        |
| bioma       | String             | FLORESTA_PLANICIE (único no MVP) |
| tiles       | List\<Tile\>       | Grade de tiles que compõe o mapa |
| construcoes | List\<Construcao\> | Construções posicionadas no mapa |
| golems      | List\<Golem\>      | Golems ativos no mapa            |

## SlotItem

| Atributo      | Tipo | Descrição                            |
| :------------ | :--- | :----------------------------------- | --- |
| id            | Int  | Identificador único do slot          |
| inventario_id | Int  | Referencia o inventário dono do slot |
| recurso_id    | Int  | Referencia o tipo de recurso         |
| quantidade    | Int  | Quantidade do recurso neste slot     |     |
