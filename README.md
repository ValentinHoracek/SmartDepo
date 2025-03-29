# SmartDepo

## Zadání
Vytvořte jednoduchou aplikaci pro simulaci plánování jízdy tramvají stojících za sebou na jedné koleji. Tramvaje strojí seřazené za sebou na pozicích 0-N. Tramvaje na pozicích 0-C mají naplánovanou misi, tramvaje na poyicích (C+1)-N misi nemají.

## Spuštění
Pro spuštění aplikace je připraven soubor docker-compose.yml. Stačí spustit následující příkazy
- docker compose build
- docker compose run -d

## Applikace
- Backend: REST API (InMemoryDb)
- Frontend: Blazor Web App

