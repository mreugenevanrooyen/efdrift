# efdrift

**Catch the drift between your EF Core model and your real database before production does.**

> Status: early development. The check command is not implemented yet. See the roadmap below.

## Why

EF Core migrations are supposed to keep your model and your database in step. In practice they drift:

- An index is declared on an entity, but no migration ever creates it. The app works, tests pass,
  and every query that relied on that index becomes a table scan in production.
- A column is added by hand or by a hotfix script and never makes it back into the model.
- A migration is edited after it was applied somewhere, so environments quietly disagree.

`dotnet ef migrations has-pending-model-changes` compares the model to the *migration snapshot*.
It cannot tell you what is actually in the *database*. `efdrift` compares the model to the live schema.

## Planned usage

```text
dotnet tool install -g EfDrift

efdrift check --project ./src/App.Data --connection "Server=...;Database=..."

✗ IX_Sessions_TenantId_CreatedAt
  declared on Session entity, missing in database
✗ Orders.LegacyRef  in database, not in model
⚠ IX_Audit_Date  unused (0 seeks since last restart)

3 issues · exit code 1
```

It will exit with code 1 on any error-level drift, so it can gate a CI/CD pipeline.

## Roadmap

1. **Model reader:** load the EF Core `IRelationalModel` from a `DbContext` (in-process first, then from a project path).
2. **Database reader:** read the live SQL Server schema (tables, columns, indexes).
3. **Comparer:** tables, columns, index existence and index column order.
4. **CLI:** `efdrift check` with console output and CI exit codes.
5. **Test-helper mode:** `EfDriftAssert.NoDrift(dbContext)` for integration tests.
6. **Usage checks:** unused and missing-index hints from SQL Server DMVs.
7. **Output formats:** JSON and Markdown (for PR comments).
8. **More providers:** PostgreSQL.

## Build

```text
dotnet build
dotnet test
```

## License

MIT
