# PAM-EscolaApi
Repositório destinado a atividade submetida na disciplina de PAM

### Está aplicação utiliza `.env` para configuração de suas variáveis de ambiente!

### 💡 Por que usar o arquivo `.env`?

O arquivo `.env` é utilizado para armazenar variáveis de ambiente — informações que podem variar de uma máquina para outra ou entre ambientes (como desenvolvimento, testes e produção). Ele é especialmente útil para manter dados sensíveis e configurações fora do código-fonte.

#### ✅ Importância do `.env`:

- **Segurança:** evita expor senhas, URLs de banco e outras credenciais no código.
- **Organização:** centraliza a configuração do ambiente em um só lugar.
- **Portabilidade:** permite que diferentes desenvolvedores usem suas próprias configurações locais sem precisar alterar o código da aplicação.
- **Escalabilidade:** facilita a configuração de ambientes distintos com diferentes dados, sem alterar a lógica da aplicação.

> ⚠️ **Importante:**  - **nunca adicione o .env ao Git ou ao GitHub. Ele deve ficar apenas na sua máquina local. O .gitignore já está configurado para isso.**

---

## 🔧 Configuração do `.env`

Para que a aplicação funcione corretamente, é necessário fornecer variáveis de ambiente com as informações de conexão ao banco de dados.

### 1. Copie o arquivo `.env.example`

Este projeto já inclui um arquivo de exemplo chamado `.env.example`. Duplique esse arquivo e renomeie para `.env`

---

### 2. Substitua com suas informações reais

Abra o arquivo .env e edite os valores conforme seu ambiente local ou de produção:
```
DB_USER=seu_user_do_banco
DB_PASSWORD=sua_do_banco
```


---

### 3. Rode a aplicação
Após configurar o .env, você pode iniciar a aplicação ✨
