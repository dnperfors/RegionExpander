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
            if (outliningManager == null)
            {
                return;
            }
            _outliningManager = outliningManager;

            _view.Closed += OnViewClosed;
            _outliningManager.RegionsCollapsed += OnRegionCollapsed;
        }

        private void OnViewClosed(object sender, EventArgs e)
        {
            if (_view != null)
            {
                _view.Closed -= OnViewClosed;
            }

            if (_outliningManager != null)
            {
                _outliningManager.RegionsCollapsed -= OnRegionCollapsed;
            }
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