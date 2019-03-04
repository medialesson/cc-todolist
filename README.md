# Clean Code Todo List (DE)

[![Build Status](https://travis-ci.org/medialesson/cc-todolist.svg?branch=master)](https://travis-ci.org/medialesson/cc-todolist)

Dieses Repository dient zur Referenz für bekannte Clean Code Techniken. **Eine Übersicht aller angewandten Techniken gibt es [hier](https://github.com/medialesson/cc-todolist/projects/1).**

## Pre-Requisites

Das Projekt wurde mit .NET Core 2.2 in Visual Studio erstellt. Besondere Anforderungen gibt es nicht:

-   Visual Studio 2017, mit .NET Core Workload
-   .NET Core 2.2 SDK oder höher
    

## Build

Dazu einfach wie bei .NET gewohnt die NuGet Packages wiederherstellen und das Projekt von Visual Studio aus starten oder im Projektverzeichnis die PowerShell ausführen und `dotnet build` eingeben.

### Code Style

Dieses Projekt baut auf den [empfohlenen Code Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) von Microsoft auf um eine einheitliche Code-Basis zu gewährleisten.

Dazu gibt es noch ein paar Regeln für das Visual Studio Projekt:

-   Repositories werden im Unterordner `Repositories/` angelegt.
    
-   Service-Klassen werden im Unterordner `Services/` angelegt.
    
-   Helferklassen, wie Helpers, Extensions, Konverter, etc. werden im Unterordner `Common/Helpers/`, `Common/Extensions/`, etc. angelegt.
    
-   Datenmodelle werden im Unterordner `Data/` angelegt.
    

## Contributing

Probleme und Fehler können gerne unter den Issues eingereicht werden. Bei Bedarf kann auch gerne ein Pull Request auf dieses Projekt erstellt werden, sodass Deine Änderungen direkt hier übernommen werden können.

## Lizenz

Die aktuelle [Lizenz](https://github.com/medialesson/cc-todolist/blob/master/LICENSE.md) ist hier einsehbar.
