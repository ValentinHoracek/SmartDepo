# SmartDepo

## Zadání
Vytvořte jednoduchou aplikaci pro simulaci plánování jízdy tramvají stojících za sebou na jedné koleji. Tramvaje strojí seřazené za sebou na pozicích 0-N. Tramvaje na pozicích 0-C mají naplánovanou misi, tramvaje na pozicích (C+1)-N misi nemají.

## Spuštění
Pro spuštění aplikace je připraven soubor docker-compose.yml. Stačí spustit následující příkazy:
```
- docker compose build
- docker compose run -d
```

## Applikace
### Backend
Rest API s InMmeoryDb pro ukládání dat, připraveno na rozšíření pro více klientů. Aplikace se spustí s defaultním nastavením 10 tramvají na koleji. Po spuštění k dispozici [API dokumentace](http://localhost:7002/swagger/index.html).

### Frontend
Využití Blazor Web App. Na stist tlačítka **Fetch Data** se z API získá defaultní nastavení tramvají na koleji. Nasledně se zobrazí tramvaje na koleji (zelené - mají misi, červené - nemají misi). Stiskem talčítka **Schedule Next** se zavolá API a vybere tramvaj s nejbližší v pořadí pro naplánovaní nové mise, nebo vytvoří novou v případě, že všechny tramvaje už mají misi naplánovanou. Kliknutím na již naplánovanou tramvaj ji lze uvolnit z aktuálního plánu.


