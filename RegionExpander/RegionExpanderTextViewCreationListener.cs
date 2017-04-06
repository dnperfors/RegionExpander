using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Outlining;
using Microsoft.VisualStudio.Utilities;

namespace RegionExpander
{
    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("CSharp")]
    [ContentType("Basic")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal sealed class RegionExpanderTextViewCreationListener : IWpfTextViewCreationListener
    {
        [Import(typeof(IOutliningManagerService))]
        private IOutliningManagerService _outliningManagerService;

        public void TextViewCreated(IWpfTextView textView)
        {
            RegionExpander.Register(textView, _outliningManagerService.GetOutliningManager(textView));
        }
    }
}