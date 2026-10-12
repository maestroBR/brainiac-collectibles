# Compilar e empacotar

Requisitos: .NET SDK 10, Python 3, SPT 4.1.6 local. Para o addon, WeekendDrops 1.0.7 instalado.

Passe o diretório `SPT_Runtime` por `SptRoot`:

```sh
dotnet build src/Collectibles/Collectibles.csproj -c Release -p:SptRoot="CAMINHO/SPT_Runtime"
dotnet build addons/WeekendCollections/WeekendCollections.csproj -c Release -p:SptRoot="CAMINHO/SPT_Runtime"
python tools/validate.py
python tools/package.py
```

Também é possível definir `SPT_ROOT` no ambiente. `WeekendRoot` pode apontar para outra pasta do Weekend. O build não instala nada no jogo.

`package.py` produz dois ZIPs em `dist/`: um com itens e bundles, outro apenas com o addon. A estrutura interna já corresponde à pasta de instalação. Os bundles em `content/bundles` são os assets compilados desta versão; editar C# não os recria. Para alterar modelos, é necessário um projeto Unity/SDK adequado, fontes Poly Haven e nova validação. O SDK e assets proprietários do jogo não estão incluídos.

No VS Code, use as tarefas “Compilar itens” e “Compilar addon”. Depois execute “Validar catálogo” e “Gerar pacotes”. Os pacotes e arquivos temporários ficam fora do Git.

Para verificar a integração sem iniciar o servidor:

```sh
dotnet run --project tests/CollectionMergeCheck.csproj -p:SptRoot="CAMINHO/SPT_Runtime"
```

Essa verificação cobre preservação de coleções existentes e ausência de duplicatas ao recarregar. Não substitui a validação dentro do jogo.
