"""Confere o catálogo e as coleções antes de gerar os pacotes."""
import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]


def validate():
    items = json.loads((ROOT / 'content/catalogue.json').read_text(encoding='utf-8'))
    bundles = json.loads((ROOT / 'content/bundles.json').read_text(encoding='utf-8'))['manifest']
    sets = json.loads((ROOT / 'addons/WeekendCollections/collections.json').read_text(encoding='utf-8'))
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
    assert len(sets) == len({s['id'] for s in sets}) == 3, 'Coleções duplicadas.'
    collection_ids = [item for s in sets for item in s['itemIds']]
    assert len(collection_ids) == len(set(collection_ids)) == 30 and set(collection_ids) == set(ids), 'Coleções não correspondem aos itens.'
    for collection in sets:
        assert len(collection['itemIds']) == 10
        assert all(0 < m['required'] <= 10 and m['gpReward'] >= 0 for m in collection['milestones'])
        assert any(m['required'] == 10 for m in collection['milestones']), 'Marco final ausente.'
    print('Catálogo, 30 bundles e três coleções conferidos.')


if __name__ == '__main__':
    validate()
