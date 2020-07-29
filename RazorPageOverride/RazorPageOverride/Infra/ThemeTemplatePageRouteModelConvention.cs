using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace RazorPageOverride.Infra
{
    /// <summary>
    /// Convention that configures pages in the /Pages/Overrides folder to be prioritised over pages in the /Pages/Theme folder with the same name.
    /// </summary>
    public class ThemeTemplatePageRouteModelConvention : IPageRouteModelConvention
    {
        public void Apply(PageRouteModel model)
        {
            foreach (var selector in model.Selectors)
            {
                if (selector.AttributeRouteModel.Template.Contains("Overrides"))
                {
                    selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template
                        .Replace("Overrides", "");
                    selector.AttributeRouteModel.Order = 0;
                }
                else
                {
                    selector.AttributeRouteModel.Template = selector.AttributeRouteModel.Template
                        .Replace("Theme", "");
                    selector.AttributeRouteModel.Order = 1;
                }
            }
        }
    }
}