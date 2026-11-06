using EfDrift.Core;

namespace EfDrift.Tests;

public class DriftReportTests
{
    [Fact]
    public void ExitCode_IsZero_WhenOnlyWarnings()
    {
        var report = new DriftReport(
        [
            new DriftIssue(DriftKind.UnusedIndex, DriftSeverity.Warning, "Audit", "IX_Audit_Date", "Unused index")
        ]);

        Assert.Equal(0, report.ExitCode);
    }

    [Fact]
    public void ExitCode_IsOne_WhenAnyError()
    {
        var report = new DriftReport(
        [
            new DriftIssue(DriftKind.IndexMissingInDatabase, DriftSeverity.Error, "Sessions",
                "IX_Sessions_TenantId_CreatedAt", "Declared in model, missing in database")
        ]);

        Assert.Equal(1, report.ExitCode);
    }
}
