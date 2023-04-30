using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.Modules;
using OrchardCore.ResourceManagement;
using Mermaid.OrchardCore.Settings;

namespace Mermaid.OrchardCore
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();
            services.AddScoped<IContentPartFieldDefinitionDisplayDriver, MarkdownFieldMermaidDisplaySettingsDriver>();
            services.AddScoped<IContentTypePartDefinitionDisplayDriver, MarkdownMermaidDisplaySettingsDriver>();
        }
    }
}