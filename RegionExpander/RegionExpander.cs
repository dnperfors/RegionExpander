using System;
using System.Linq;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Outlining;

namespace RegionExpander
{
    internal sealed class RegionExpander
    {
        private readonly IWpfTextView _view;
        private readonly IOutliningManager _outliningManager;

        public RegionExpander(IWpfTextView view, IOutliningManager outliningManager)
        {
            _view = view ?? throw new ArgumentNullException("view");
            _outliningManager = outliningManager ?? throw new ArgumentNullException("outliningManager");
            _outliningManager.RegionsCollapsed += OnRegionCollapsed;
        }

        private void OnRegionCollapsed(object sender, RegionsCollapsedEventArgs e)
        {
            foreach (var region in e.CollapsedRegions.Where(x => x.IsCollapsed))
            {
                var regionSnapshot = region.Extent.TextBuffer.CurrentSnapshot;
                var regionText = region.Extent.GetText(regionSnapshot);
                if (regionText.StartsWith("#region"))
                {
                    _outliningManager.Expand(region);
                }
            }
        }
    }
}