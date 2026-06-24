# 🚀 Fluxo de trabalho com Git

## 1. Atualize sua branch

Antes de começar a programar, sempre sincronize seu repositório local com o remoto:

```bash
git pull
```

Isso garante que você tenha as alterações mais recentes da equipe.

## 2. Faça suas alterações

Desenvolva normalmente e salve seus arquivos.

## 3. Adicione os arquivos modificados

```bash
git add .
```

## 4. Crie o commit

```bash
git commit
```

Escreva uma mensagem clara descrevendo o que foi feito.

**Exemplos:**

```text
feat: adiciona tela de login
fix: corrige erro de validação
refactor: reorganiza estrutura do projeto
```

## 5. Envie para sua branch

```bash
git push
```

⚠️ **Nunca faça push diretamente para a `main`.**

## 6. Abra um Pull Request (PR)

Após enviar sua branch:

* Abra um Pull Request para a `main`;
* Solicite revisão de outro integrante da equipe;
* Aguarde aprovação antes de realizar o merge.

## ✅ Fluxo resumido

```bash
git pull
git add .
git commit
git push
```

Depois, abra o Pull Request para revisão.
