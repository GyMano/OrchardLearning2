using OL2.Core.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.GraphQL.Queries;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL2.Core.Migrations
{
    public class PersonMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public PersonMigrations(IContentDefinitionManager contentDefinitionManager) =>
            _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterPartDefinitionAsync(nameof(PersonPart), part => part
            .Attachable()
            .WithField(nameof(PersonPart.Biography), field => field
                .OfType(nameof(TextField))
                .WithDisplayName("Biography")
                .WithSettings(new TextFieldSettings()
                {
                    Hint = "The biography of the person. test if it updates at all",
                    Required = false
                })
                .WithEditor("TextArea")
            ));

            _contentDefinitionManager.AlterTypeDefinitionAsync("PersonPage", type => type
                .Creatable()
                .Listable()
                .WithPart(nameof(PersonPart))
            );

            _contentDefinitionManager.AlterTypeDefinitionAsync("PersonWidget", type => type
                .WithPart(nameof(PersonPart))
                .Stereotype("Widget")
            );

            return 2;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterTypeDefinitionAsync("PersonWidget", type => type
                .WithPart(nameof(PersonPart))
                .Stereotype("Widget")
            );

            return 2;
        }
    }
}
