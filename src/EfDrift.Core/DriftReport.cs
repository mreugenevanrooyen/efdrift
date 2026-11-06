namespace EfDrift.Core;

public sealed class DriftReport
{
    public DriftReport(IReadOnlyList<DriftIssue> issues) => Issues = issues;

    public IReadOnlyList<DriftIssue> Issues { get; }

    public bool HasErrors => Issues.Any(i => i.Severity == DriftSeverity.Error);

    /// <summary>Process exit code for CI: 1 when any error-level drift is found.</summary>
    public int ExitCode => HasErrors ? 1 : 0;
}
