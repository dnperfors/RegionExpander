using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.VisualBasic;

namespace RegionExpander.Diagnostics
{
    [DiagnosticAnalyzer(LanguageNames.VisualBasic)]
    public class VisualBasicRegionAnalyzer : RegionAnalyzer<SyntaxKind>
    {
        protected override SyntaxKind[] GetSyntaxKinds()
        {
            return new[] { SyntaxKind.RegionDirectiveTrivia, SyntaxKind.EndRegionDirectiveTrivia };
        }
    }
}
