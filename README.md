# 🔐 PDF Password Protector com CPF

Este projeto em **C#** tem como objetivo **adicionar senha a arquivos PDF**, utilizando os **últimos dígitos do CPF informado como senha**. É uma ferramenta útil para proteger documentos sensíveis, como boletos, relatórios e faturas antes de enviá-los por e-mail.

## 📌 Funcionalidades

- Adiciona proteção por senha a arquivos PDF.
- A senha é gerada automaticamente a partir dos **últimos 4 dígitos do CPF** fornecido.
- Suporte a múltiplos arquivos PDF (caso necessário).
- Interface simples via linha de comando ou biblioteca reutilizável.

## 🛠️ Tecnologias Utilizadas

- C# (.NET Framework ou .NET Core)
- [iTextSharp](https://github.com/itext/itextsharp) (ou outra biblioteca para manipulação de PDFs)
- Visual Studio (recomendado)

## ▶️ Como Usar

1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/pdf-cpf-protector.git
   ```
2. Abra o projeto no Visual Studio.
3. Certifique-se de que você tem a DevExpress instalada e referenciada corretamente.
4. Edite o caminho do arquivo e a senha (baseada no CPF) em Program.cs:
   ```bash
   string inputFilePath = @"C:\\caminho\\arquivo.rtf";
   string senha = "8909"; // últimos 4 dígitos do CPF
   ```
5. Compile e execute o projeto.

⚠️ Requisitos
.NET Framework ou .NET Core compatível com DevExpress.

Licença DevExpress instalada e ativa.

Permissões de gravação nas pastas de entrada/saída.   
