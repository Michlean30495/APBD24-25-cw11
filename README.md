# Ćwiczenie 11 — API recept i pacjentów

Ćwiczenie z ASP.NET Core, Entity Framework Core i SQL Server w podejściu Code First. Projekt zawiera modele lekarzy, pacjentów, leków i recept oraz migracje bazy danych.

**Kategoria:** ćwiczenia APBD · **Przedmiot:** APBD · **Rok akademicki:** 2024/2025

## Technologie

C#, .NET 9, ASP.NET Core, Entity Framework Core, SQL Server, migracje Code First.

## Gdzie jest kod

- [`CodeFirstCw11Api/CodeFirstCw11Api.sln`](./CodeFirstCw11Api/CodeFirstCw11Api.sln)
- [`CodeFirstCw11Api/CodeFirstCw11Api/CodeFirstCw11Api.csproj`](./CodeFirstCw11Api/CodeFirstCw11Api/CodeFirstCw11Api.csproj)

## Uruchomienie

Wymagany jest odpowiedni .NET SDK dla projektu (.NET 9); jeśli repozytorium zawiera `global.json`, uwzględnij również wskazaną w nim wersję SDK.

Projekt wymaga dostępu do SQL Server i bazy zgodnej z modelami lub zapytaniami ćwiczenia. Skonfiguruj lokalne połączenie w ustawieniach aplikacji przed uruchomieniem.
W projekcie używany jest klucz `ConnectionStrings:Default`; migracje znajdują się w katalogu `Migrations`.

Z katalogu głównego repozytorium:

```sh
dotnet restore "CodeFirstCw11Api/CodeFirstCw11Api/CodeFirstCw11Api.csproj"
dotnet run --project "CodeFirstCw11Api/CodeFirstCw11Api/CodeFirstCw11Api.csproj"
```

## Nawigacja

[Wszystkie projekty i materiały ze studiów](https://github.com/Michlean30495)
