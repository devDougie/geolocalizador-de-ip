<!--- ![Image](https://github.com/user-attachments/assets/9240ce5d-d7d4-4108-b42b-8b6d8d1b33aa) --->
<!--- ![Image](https://github.com/user-attachments/assets/988f010f-42bf-4bb0-aba2-39d369b8276d) --->

# 🌍 Geolocalizador de IP

<div align="center">
  <img src="https://github.com/user-attachments/assets/9240ce5d-d7d4-4108-b42b-8b6d8d1b33aa">
  <img src="https://github.com/user-attachments/assets/988f010f-42bf-4bb0-aba2-39d369b8276d">
</div>

## 📋 Descrição:

Aplicação de geolocalização aproximada baseada em endereço IP público, desenvolvida em **C# com Windows Forms**. O programa realiza requisições para APIs externas a fim de obter informações como cidade, estado, país, fuso horário, moeda, latitude/longitude, e muito mais, com base em um IP informado pelo usuário ou detectado automaticamente.

⚠️ ATENÇÃO: A geolocalização baseada em IP fornece estimativas aproximadas e está sujeita a imprecisões. Os dados retornados podem representar a localização do provedor de acesso ou de um nó intermediário da rede, resultando em divergências nos campos de cidade, código postal, latitude e longitude em relação à posição geográfica real do usuário.

---

## ⚙️ Funcionalidades:

- Detecta automaticamente o IP público do usuário;
- Consulta os serviços da **ip-api.com** e **ipinfo.io**;
- Exibe dados detalhados como cidade, estado, país, fuso horário, provedor, moeda e coordenadas geográficas;
- Interface gráfica simples e intuitiva (WinForms);
- Compatível com idioma **português (pt-BR)**;
- Recurso de autocompletar e validação do formato do IP.

---

## 🚀 Tecnologias Utilizadas:

- 💬 **Linguagem**: C# (.NET)
- 🛠️ **Framework**: Windows Forms (.NET 6.0 ou superior)
- 🖥️ **IDE recomendada**: Visual Studio Community 2022
- 🔌 **APIs externas**:
  - [`https://ipinfo.io/ip`](https://ipinfo.io/ip) – para obtenção do IP público
  - [`http://ip-api.com`](http://ip-api.com) – para geolocalização e informações do IP
- 📦 **Pacotes NuGet**:
  - `Microsoft.AspNet.WebApi.Client`
  - `Microsoft.Graph`
  - `System.Collections`

---

## ✅ Requisitos:

- Windows 10 ou superior
- .NET 6.0 Runtime
- Visual Studio Community 2022 (com suporte ao desenvolvimento em Windows Forms)

---

## ▶️💻 Como Executar:

1. Clone este repositório:
   ```bash
   git clone https://github.com/devDougie/geolocalizador-de-ip.git
   ```

2. Abra a solução `geolocalizador-de-ip.sln` no Visual Studio Community 2022.

3. Restaure os pacotes NuGet (o Visual Studio pode fazer isso automaticamente ao abrir).

4. Compile e execute o projeto (*F5* ou botão "Iniciar" no Visual Studio).

5. A aplicação será iniciada com a tela principal (*FrmMenu*) onde é possível:
	- Informar manualmente um IP para consulta;
	- Ou clicar em "Recarregar" para preencher automaticamente com o IP público da sua rede.
