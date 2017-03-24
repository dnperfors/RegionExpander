using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Outlining;
using Microsoft.VisualStudio.Utilities;

namespace RegionExpander
{
    [Export(typeof(IWpfTextViewCreationListener))]
    [ContentType("CSharp")]
    [TextViewRole(PredefinedTextViewRoles.Document)]
    internal sealed class RegionExpanderTextViewCreationListener : IWpfTextViewCreationListener
    {
        [Import(typeof(IOutliningManagerService))]
        private IOutliningManagerService _outliningManagerService;

        public void TextViewCreated(IWpfTextView textView)
        {
            new RegionExpander(textView, _outliningManagerService.GetOutliningManager(textView));
        }
    }
}