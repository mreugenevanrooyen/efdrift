namespace EfDrift.Core;

public enum DriftSeverity
{
    Warning,
    Error
}

public enum DriftKind
{
    IndexMissingInDatabase,
    IndexMissingInModel,
    ColumnMissingInDatabase,
    ColumnMissingInModel,
    TableMissingInDatabase,
    UnusedIndex
}

/// <summary>A single difference between the EF Core model and the database.</summary>
public sealed record DriftIssue(
    DriftKind Kind,
    DriftSeverity Severity,
    string Table,
    string ObjectName,
    string Message);
