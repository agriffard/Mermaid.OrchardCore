using System.Threading.Tasks;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.Views;
using Mermaid.OrchardCore.ViewModels;

namespace Mermaid.OrchardCore.Settings
{
    public class MarkdownFieldMermaidDisplaySettingsDriver : ContentPartFieldDefinitionDisplayDriver<HtmlField>
    {
        public override IDisplayResult Edit(ContentPartFieldDefinition partFieldDefinition)
        {
            return Initialize<MermaidSettingsViewModel>("MarkdownFieldMermaidDisplaySettings_Edit", model =>
            {
                var settings = partFieldDefinition.GetSettings<MarkdownFieldMermaidDisplaySettings>();

                model.Theme = settings.Theme;
            })
            .Location("DisplayMode");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentPartFieldDefinition partFieldDefinition, UpdatePartFieldEditorContext context)
        {
            if (partFieldDefinition.DisplayMode() == "Mermaid")
            {
                var model = new MermaidSettingsViewModel();
                var settings = new MarkdownFieldMermaidDisplaySettings();

                await context.Updater.TryUpdateModelAsync(model, Prefix);

                settings.Theme = model.Theme;

                context.Builder.WithSettings(settings);
            }

            return Edit(partFieldDefinition);
        }
    }
}
