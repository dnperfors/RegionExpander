using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace RegionExpander.Diagnostics
{
    public abstract class RegionAnalyzer<TLanguageKindEnum> : DiagnosticAnalyzer where TLanguageKindEnum : struct
    {
        private static readonly DiagnosticDescriptor s_regionRule = new DiagnosticDescriptor("REGION1", "Region is unnecessary", "Region is unnecessary", "Editor", DiagnosticSeverity.Hidden, true, customTags: WellKnownDiagnosticTags.Unnecessary);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(s_regionRule);

        protected abstract TLanguageKindEnum[] GetSyntaxKinds();

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.RegisterSyntaxNodeAction(AnalyzeSyntaxNode, GetSyntaxKinds());
        }

        protected void AnalyzeSyntaxNode(SyntaxNodeAnalysisContext context)
        {
            context.ReportDiagnostic(Diagnostic.Create(s_regionRule, context.Node.GetLocation()));
        }
    }
}
