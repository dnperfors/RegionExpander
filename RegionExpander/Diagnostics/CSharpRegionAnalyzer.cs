using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace RegionExpander.Diagnostics
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class CSharpRegionAnalyzer : RegionAnalyzer<SyntaxKind>
    {
        protected override SyntaxKind[] GetSyntaxKinds()
        {
            return new[] { SyntaxKind.RegionDirectiveTrivia, SyntaxKind.EndRegionDirectiveTrivia };
        }
    }
}
