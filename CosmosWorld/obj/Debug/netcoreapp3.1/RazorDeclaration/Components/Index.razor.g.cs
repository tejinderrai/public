#pragma checksum "D:\AspireCSProjects2020\CosmosWorld\Components\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c2521ce502501415aef7f4511eeb347509773b38"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CosmosWorld.Components
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\AspireCSProjects2020\CosmosWorld\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AspireCSProjects2020\CosmosWorld\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AspireCSProjects2020\CosmosWorld\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\AspireCSProjects2020\CosmosWorld\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\AspireCSProjects2020\CosmosWorld\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\AspireCSProjects2020\CosmosWorld\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\AspireCSProjects2020\CosmosWorld\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\AspireCSProjects2020\CosmosWorld\_Imports.razor"
using CosmosWorld;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\AspireCSProjects2020\CosmosWorld\_Imports.razor"
using CosmosWorld.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AspireCSProjects2020\CosmosWorld\Components\Index.razor"
using Microsoft.Azure.Cosmos;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\AspireCSProjects2020\CosmosWorld\Components\Index.razor"
using CosmosWorld.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 39 "D:\AspireCSProjects2020\CosmosWorld\Components\Index.razor"
       

        List<string> c = CountriesService.Countries;

    protected override async Task OnInitializedAsync()
    {
        if (CountriesService.Countries.Count <= 0)
        {
            await CountriesService.PopulateCountries();
        }
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
