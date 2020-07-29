using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace RazorPageOverride.Infra
{
    public class ThemeViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            var locations = new List<string>
            {
                "/Pages/Theme/{0}.cshtml",
                "/Pages/Theme/Shared/{0}.cshtml",
                "/Pages/Theme/Components/{0}.cshtml",
                "/Pages/Overrides/{0}.cshtml",
                "/Pages/Overrides/Shared/{0}.cshtml",
                "/Pages/Overrides/Components/{0}.cshtml"
            };
            return locations.Union(viewLocations);
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // Empty by design
        }
    }
}