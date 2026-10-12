"""Confere o catálogo e as coleções antes de gerar os pacotes."""
import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]


def validate():
    items = json.loads((ROOT / 'content/catalogue.json').read_text(encoding='utf-8'))
    bundles = json.loads((ROOT / 'content/bundles.json').read_text(encoding='utf-8'))['manifest']
    ids = [item['id'] for item in items]
    assert len(items) == len(set(ids)) == 30, 'Catálogo precisa ter 30 IDs exclusivos.'
    assert all(re.fullmatch('[0-9a-f]{24}', item) for item in ids), 'ID inválido.'
    assert {entry['key'] for entry in bundles} == {item['bundle'] for item in items}, 'Manifesto não cobre o catálogo.'
    for item in items:
        asset = ROOT / 'content/bundles' / item['bundle']
        assert asset.is_relative_to(ROOT / 'content/bundles') and asset.is_file(), f"Bundle ausente: {item['slug']}"
        assert item['price'] > 0 and item['weight'] > 0, 'Preço/peso inválidos.'
        assert item['width'] > 0 and item['height'] > 0, 'Dimensões inválidas.'
        assert item['assetLicense'] == 'CC0' and item['assetSource'].startswith('https://polyhaven.com/a/'), 'Proveniência ausente.'
    print('Catálogo e 30 bundles conferidos.')


if __name__ == '__main__':
    validate()
