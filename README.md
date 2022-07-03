Stock analytics
- using clean architecture

Autorizační server
	- zodpovídá za uživatele a autentikaci
	- skládá se z relační DB a backendu
	- v DB budou uložení uživatelé
	- BE slouží jako autorizační server - generuje access-token a předává ho FE aplikaci 

Downloader 
	- z netu nastahuje historická data
	- ukládá jen na redis
	- má seznam tickerů, které periodicky aktualizuje
	- vystavuje api, kde se "registruje" nový ticker

App BE
	- data vyhodnocuje podle SMA (Simple moving average)
	- vystavuje API pro FE
	- 1 funkce
		- na vstup dostane jeden ticker - získá data (redis nebo se dotáže na downloader), zpracuje je a vrátí FE
	- kouká do DB - jaký uživatel má které tickery - v JWT bude i email - podle toho najde v DB

App FE
	- angular
	- zobrazuje data