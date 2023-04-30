using System.Threading.Tasks;
using OrchardCore.ContentManagement.Metadata.Models;
using OrchardCore.ContentTypes.Editors;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Markdown.Models;
using Mermaid.OrchardCore.ViewModels;

namespace Mermaid.OrchardCore.Settings
{
    public class MarkdownMermaidDisplaySettingsDriver : ContentTypePartDefinitionDisplayDriver<MarkdownBodyPart>
    {
        public override IDisplayResult Edit(ContentTypePartDefinition contentTypePartDefinition, IUpdateModel updater)
        {
            return Initialize<MarkdownBodyPartMermaidSettingsViewModel>("MarkdownBodyPartMermaidSettings_Edit", model =>
                {
                    var settings = contentTypePartDefinition.GetSettings<MarkdownBodyPartMermaidSettings>();

                    model.Theme = settings.Theme;
                })
                .Location("DisplayMode");
        }

        public override async Task<IDisplayResult> UpdateAsync(ContentTypePartDefinition contentTypePartDefinition, UpdateTypePartEditorContext context)
        {
            if (contentTypePartDefinition.DisplayMode() == "Mermaid")
            {
                var model = new MarkdownBodyPartMermaidSettingsViewModel();
                var settings = new MarkdownBodyPartMermaidSettings();

                if (await context.Updater.TryUpdateModelAsync(model, Prefix))
                {
                    settings.Theme = model.Theme;

                    context.Builder.WithSettings(settings);
                }
            }

            return Edit(contentTypePartDefinition, context.Updater);
        }
    }
}
