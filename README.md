# Brainiac Collectibles

Trinta objetos raros para encontrar, guardar e completar coleções no SPT. Eletrônicos esquecidos, relíquias de campo e equipamentos de pesquisa, com modelos próprios para cada item e textos em português.

![Catálogo dos 30 colecionáveis](docs/catalogo.jpg)

## Dois pacotes, uma escolha

| Pacote | Conteúdo | Requisitos |
| --- | --- | --- |
| **Brainiac Collectibles 1.2.0** | 30 itens, modelos, texturas e loot em cofres | SPT 4.1.6 |
| **Weekend Collections 1.0.0** | 3 coleções de 10 itens, entregas e recompensas de GP | Mod principal 1.2.0 + WeekendDrops 1.0.7 |

O mod principal funciona sem Weekend. O addon é opcional e não altera o arquivo de coleções do Weekend: acrescenta os conjuntos durante o carregamento e preserva configurações já existentes.

## Instalação

Feche o servidor antes de instalar. Extraia o pacote principal na pasta do SPT, onde fica `EscapeFromTarkov.exe`. O resultado deve ser:

```text
SPT_Runtime/user/mods/Maestro-BrainiacCollectibles/
```

Para usar as coleções, instale também o WeekendDrops e extraia o pacote do addon na mesma pasta do jogo:

```text
SPT_Runtime/user/mods/Brainiac-WeekendCollections/
```

Reinicie servidor e cliente. Quem joga pelo Fika precisa receber os bundles do mod principal pelo sistema de sincronização usado pelo grupo. Não copie apenas a DLL: `catalogue.json`, `bundles.json` e os 30 bundles fazem parte do pacote.

## O que encontrar

- **Tecnologia Esquecida:** câmeras, rádio, notebook e outros eletrônicos.
- **Relíquias de Campo:** binóculos, bússola, relógio e peças históricas.
- **Arquivo Brainiac:** instrumentos e objetos de pesquisa.

São itens de coleção. A faca, a granada histórica, o rádio e a lanterna não ganham funções de combate ou de equipamento. Loot usa pesos relativos nos cofres; não são chances independentes por raid. Veja [loot e regiões](docs/LOOT.md).

## Recompensas do addon

Cada entrega rende **750 GP**. Cinco itens rendem **3.750 GP** e dez itens rendem **9.750 GP**, além de **+2% de GP permanente** por coleção completa. As três coleções podem somar +6%. O cálculo e o progresso são controlados pelo Weekend.

Se esses conjuntos já estiverem configurados no seu Weekend, o addon mantém a configuração existente em vez de substituir seus valores. Não acrescenta moeda nem modifica recompensas de outras coleções.

## Compatibilidade e testes

Destinado ao SPT **4.1.6**. O addon usa a API do WeekendDrops **1.0.7**. Builds e integridade do catálogo foram verificados; os 30 bundles já passaram por carregamento/renderização no Unity Editor. Esta separação em dois pacotes ainda precisa de validação em gameplay, incluindo host e cliente Fika. Veja [compatibilidade](docs/COMPATIBILITY.md).

## Desenvolvimento

O código do servidor está em `src/Collectibles`; o addon, em `addons/WeekendCollections`. As referências às DLLs do SPT e do Weekend são locais e não entram no repositório. [Compilação e pacotes](docs/DEVELOPMENT.md).

## Remoção

O addon pode ser retirado sem remover o mod principal; as coleções adicionadas por ele deixam de aparecer após reiniciar. O progresso já salvo pelo Weekend permanece.

Para remover os itens, faça backup e trate os objetos existentes nos perfis antes de retirar o mod principal. Não desinstale com itens personalizados ainda no inventário esperando que o jogo os reconheça sem o mod.

## Créditos

Modelos e texturas do [Poly Haven](https://polyhaven.com), licenciados em **CC0**, com autores e fontes em [CREDITS.md](CREDITS.md). Adaptação, otimização, cadastro de itens e integração: **Project Brainiac**. Código sob MIT; a licença dos modelos é mantida separadamente.

## Identificação

Mod GUID: `project.brainiac.collectibles`.

GUID do addon Weekend: `project.brainiac.weekendcollections`. Use esses mesmos identificadores ao cadastrar os mods no Forge.
