# Relacionamentos

Define como as entidades se conectam entre si no contexto do jogo.

---

| Entidade A | Entidade B | Relação     | Cardinalidade | Descrição                                                                           |
| :--------- | :--------- | :---------- | :------------ | :---------------------------------------------------------------------------------- |
| Jogador    | Inventário | possui      | 1 para 1      | O jogador tem um único inventário.                                                  |
| Jogador    | Golem      | cria        | 1 para N      | O jogador pode criar múltiplos golems.                                              |
| Golem      | Runa       | equipa      | N para 1      | Cada golem usa uma runa por vez; a mesma runa pode ser usada por golems diferentes. |
| Runa       | Dungeon    | é obtida em | N para 1      | Runas são recompensas de dungeons.                                                  |
| Jogador    | Construção | constrói    | 1 para N      | O jogador pode construir múltiplas estruturas.                                      |
| Construção | Mapa       | existe em   | N para 1      | Construções são posicionadas no mapa.                                               |
| Golem      | Mapa       | se move em  | N para 1      | Golems operam dentro do mapa.                                                       |
| Dungeon    | Construção | especializa | 1 para 1      | Dungeon é um tipo específico de Construção, herdando seu id.                        |
| Inventário | SlotItem   | contém      | 1 para N      | Um inventário pode ter múltiplos slots, inclusive com o mesmo recurso.              |
| SlotItem   | Recurso    | referencia  | N para 1      | Cada slot aponta para um tipo de recurso.                                           |
