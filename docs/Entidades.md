# Entidades

Levantamento das entidades principais do jogo. Esta seção descreve o que cada entidade representa no contexto do sistema.

---

## Jogador

O personagem controlado pelo usuário. É o ponto central de toda a interação com o mundo.

---

## Inventário

Armazena os itens coletados pelo jogador. Cada slot referencia um tipo de recurso e sua quantidade.

---

## SlotItem

Representa uma entrada no inventário do jogador, associando um tipo de recurso à quantidade possuída.

---

## Recurso

Catálogo de matérias-primas coletáveis no mundo (Madeira, Trigo, Água etc.). Usado em crafting e construções. A quantidade possuída pelo jogador é armazenada no SlotItem.

---

## Golem

Criatura mágica criada pelo jogador para automatizar tarefas. Cada golem executa uma função específica de acordo com a runa equipada.

---

## Runa

Item mágico obtido em dungeons. Quando equipada em um golem, define qual tarefa ele executará automaticamente. Possui nível reservado para uso futuro (sem efeito mecânico no MVP).

---

## Construção

Estrutura posicionada pelo jogador no grid do mapa. Serve como âncora para as mecânicas de automação e progressão.

---

## Dungeon

Local especial no mapa onde o jogador enfrenta desafios e obtém runas. É uma especialização de Construção — herda seu `id` como chave primária.

---

## Mapa

O mundo do jogo. No MVP, é composto por 1 bioma (floresta/planície) com tiles de terreno e objetos posicionados. É a fonte da verdade de tudo que existe no mundo.
