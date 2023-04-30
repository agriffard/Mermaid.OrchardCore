using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace Mermaid.OrchardCore
{
    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();

            _manifest
                .DefineScript("mermaid")
                .SetCdn("https://unpkg.com/mermaid@8.13.10/dist/mermaid.min.js", "https://unpkg.com/mermaid@8.13.10/dist/mermaid.js")
                .SetCdnIntegrity("sha384-fE0AldeAy4e2XA33V/CAgjSn6tr8dbSJtTd6WzA8fNjxGVYvik4nKiwV8oAHJkEa", "sha384-w4ypzlQgHzqxbwJ7VIoqlzLWqii+mTZ4iLHfAWwu8OeLDL4O2MA6cPGlwKz99NgR")
                .SetVersion("8.13.10");
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}
