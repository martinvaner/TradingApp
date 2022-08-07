STILL IN PROGRESS

- using clean architecture

Popis aplikace (TO BE):
Aplikace slouží pro uživatele, kteří chtějí sledovat různé statistiky ohledně akcií + další informace. Uživatelé se budou přihlašovat pomocí google účtu. Po přihlášení se zobrazí dashboard, kde uvidí zvolené akcie a jejich statistiky. Jednotlivé sledované akcie mohou přidávat/odebírat.

Aktuální stav:
V tuto chvíli jsou vytvořené 3 projekty. Downloader, BE a FE. 

Downloader slouží pro stahování historických dat z externího api (používám rapidAPI - yahoo finance). Je vystaven endpoint - data/getdata/{symbol}, na kterém získám close ceny za posledních 200 dní. Zároveň se tyto ceny zapisují do redis, abych nedělal zbytečné requesty na externí api. Dále je vystaven endpoint data/subscribe, kde si zaregistruju nové tickery, které chci sledovat.

BE slouží jako backend aplikace, kde se vypočítávají statistiky (zatím pouze průměr). Zároveň vystavuje API, které využívá frontend. Při požadavku na data se nejprve koukne do redisu, jestli tam data nejsou nastahovaná. Pokud jsou, pošle ty. Pokud nejsou, zavolá Downloader API, aby data získal. V této aplikaci také komunikuji s relační databází pomocí EF. Databáze (postgre) slouží pro párování uživatelů a tickerů (jaký uživatel má jaký ticker).

FE zobrazuje data. Je napsán v angularu a na data se dotazuje BE. Umožňuje přidávání a odebírání sledovaných tickerů.

Co hotové není:
- přihlašování uživatele (zatím natvrdo používám jednoho usera)
- automatické stahování nových dat po 24 hodinách
- více statistik


U projektů chybí appsettings.json, protože tam ukládám keys do api.


Ukázka FE pro představu:
![image](https://user-images.githubusercontent.com/32337795/183282238-6e87555d-97c3-4e0a-8671-16bd4ebf5897.png)

