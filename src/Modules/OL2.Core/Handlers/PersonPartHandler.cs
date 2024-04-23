using OL2.Core.Models;
using OrchardCore.ContentManagement.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OL2.Core.Handlers
{
    public class PersonPartHandler : ContentPartHandler<PersonPart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, PersonPart part)
        {
            context.ContentItem.DisplayText = part.Name;

            return Task.CompletedTask;
        }
    }
}
