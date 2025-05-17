# 📘 Scrum_Examen_.NET

Projet ASP.NET Core MVC développé dans le cadre d’un examen à ESPRIT.

## 📦 Structure

- **AM.ApplicationCore** : Contient les entités métiers, interfaces, et services de base.
- **AM.Infrastructure** : Contient le DbContext, les configurations EF, le UnitOfWork.
- **AM.UI.WEB** : Frontend MVC (Views, Controllers, Razor Pages).
- **AM.UI.Console** : Projet console de test (optionnel).

## ⚙️ Fonctionnalités principales

- CRUD complet sur l'entité `Tache`
- Liaison avec les entités `Membre`, `Sprint`, `Projet`
- Injection de dépendances via `IUnitOfWork` et `IService<>`
- Formulaire dynamique avec `Enum`, `SelectList`, `DateTime`

## ✅ Technologies

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server LocalDB
- Visual Studio 2022

## 🧪 Exécution

1. Ouvrir le projet avec Visual Studio.
2. Configurer la base de données dans `AMContext.cs`.
3. Exécuter `Update-Database` pour créer les tables.
4. Lancer le projet via `AM.UI.WEB`.

---

> *Réalisé par Sarra Bouazzi, 2025.*
