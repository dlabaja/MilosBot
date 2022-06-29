# MilošBot
Projekt, na kterém jsme pracovali přes půl roku - discord bot s více jak 70 funkcemi včetně verifikací, anti raidů, obrázků politiků, hledače na wikipedii a youtube...

Bot je psaný v C# s knihovnou Discord.NET

První kód jsem napsal v listopadu 2020, a i díky tomu, že se nás na tvorbě podílelo vícero, kód vypadá, tak jak vypadá. I tak to ale stálo za to, a doufám, že to alespoň někomu trošku pomůže.

![credits](https://cdn.discordapp.com/attachments/782281045236121610/883749988147028008/unknown.png)

## Jak spustit
# !!POZOR!!
### Tento bot byl dělán pro JEDEN server a s MongoDB databází. Nikdy nebyl určen k použití na jiných serverech. Pokud tak chcete učinit, musíte vytvořit stejné kolekce v databázi a překopat všechny id rolí a kanálů!!!
Pokud chcete i přes všechen ten neudržitelný kód bota spustit, tady je návod:
1. Stáhněte si repo
2. Stáhněte si Visual Studio (https://visualstudio.microsoft.com/cs/)
3. Založte si MongoDB účet a databázi (https://www.mongodb.com/cloud/atlas)
4. Sežeňte si token bota (https://discord.com/developers/applications) 

1. Otevřete si Miloše ve Visual Studiu
2. Nahraďte "TOKEN" vaším tokenem - "TOKEN" se spustí na UNIX systémech, "TOKEN2" na Windows (super pro debug)
3. Nahraďte "MongoDB connection string" vaším connection stringem
4. Vytvořte kolekce podle obrázku (spousta je zbytečná, ale jejich absence může dělat bordel)

![mongo](https://media.discordapp.net/attachments/719249155817603103/883799184485023764/unknown.png)

9. Opravte id rolí a kanálů, aby seděly pro váš server
