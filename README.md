# razor-page-override
Used to illustrate any problems occurring when trying to override razor pages

I'm trying to achieve overriding of existing 'Theme' pages, located in 'Pages/Theme', by placing another page with the same name in the 'Pages/Overrides' folder.
I have done so by creating a PageRouteModelConvention named `ThemeTemplatePageRouteModelConvention`. Any pages in the 'Pages/Overrides' folder will be reachable without the '/Overrides/' route prefix and have priority over the similarly named view in the 'Pages/Theme' folder.

In the current setup, we have three pages in Pages/Theme:
1. Index
2. About
3. Contact

And two pages in Pages/Overrides:
1. Index
2. About

The behaviour that I would like to have with these pages:

- Index page with / route used from Pages/Overrides
- About page with /about route used from Pages/Overrides
- Contact page with /contact route used from Pages/Theme

This works as I want it to work.  
However, the anchor tags created in the Pages/Theme/Components/\_Header partial to a non-overriden page in Pages/Theme using the anchor tag helper does not create the correct route.  
See the root/index page where the \_Header component is included. The About page link is generated correctly as the About page is also in the same folder. However, the Contact page link does not seem to be generated properly. This link to the Contact page only works when you're on the Contact page itself, as that is situated in Pages/Theme.
Generation of the anchor tag doesn't seem to take the locations views can be situatied in into account.

Because the link is in a component that I do not want to override, I can't modify the `asp-page` attribute to fix the problem.

How can I let the Header component generate a link to the Contact Theme page from the overriding Index page?
