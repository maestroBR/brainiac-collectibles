# Compilar e empacotar

Requisitos: .NET SDK 10, Python 3, SPT 4.1.6 local. 

Passe o diretório `SPT_Runtime` por `SptRoot`:

```sh
dotnet build src/Collectibles/Collectibles.csproj -c Release -p:SptRoot="CAMINHO/SPT_Runtime"
python tools/validate.py
python tools/package.py
```

Também é possível definir `SPT_ROOT` no ambiente. `WeekendRoot` pode apontar para outra pasta do Weekend. O build não instala nada no jogo.

`package.py` produz um ZIP em `dist/`: com itens e bundles. A estrutura interna já corresponde à pasta de instalação. Os bundles em `content/bundles` são os assets compilados desta versão; editar C# não os recria. Para alterar modelos, é necessário um projeto Unity/SDK adequado, fontes Poly Haven e nova validação. O SDK e assets proprietários do jogo não estão incluídos.

No VS Code, use as tarefas “Compilar itens”. Depois execute “Validar catálogo” e “Gerar pacotes”. Os pacotes e arquivos temporários ficam fora do Git.



Para o VS Code resolver as referências sem argumentos de terminal, crie `Directory.Build.local.props` na raiz:

```xml
<Project>
  <PropertyGroup>
    <SptRoot>CAMINHO/SPT_Runtime</SptRoot>
  </PropertyGroup>
</Project>
```

Esse arquivo é ignorado pelo Git e guarda apenas sua configuração local. Depois recarregue a janela do VS Code.
