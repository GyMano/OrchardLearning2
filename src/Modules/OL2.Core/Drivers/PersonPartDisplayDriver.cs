using OL2.Core.Models;
using OL2.Core.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL2.Core.Drivers
{
    public class PersonPartDisplayDriver : ContentPartDisplayDriver<PersonPart>
    {
        public override IDisplayResult Display(PersonPart part, BuildPartDisplayContext context) =>
            Initialize<PersonPartViewModel>(
                GetDisplayShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content:5")
            .Location("Summary", "Content:5");

        public override IDisplayResult Edit(PersonPart part, BuildPartEditorContext context) =>
            Initialize<PersonPartViewModel>(
                GetEditorShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Content:5");

        public override async Task<IDisplayResult> UpdateAsync(PersonPart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var viewModel = new PersonPartViewModel();

            await updater.TryUpdateModelAsync(viewModel, Prefix);

            // Populate part from view model here.

            part.Name = viewModel.Name;
            part.Handedness = viewModel.Handedness;
            part.BirthDateUtc = viewModel.BirthDateUtc;

            return Edit(part, context);
        }

        private static void PopulateViewModel(PersonPart part, PersonPartViewModel viewModel)
        {
            // Populate view model from part here.

            viewModel.Name = part.Name;
            viewModel.Handedness = part.Handedness;
            viewModel.BirthDateUtc = part.BirthDateUtc;
        }
    }
}
