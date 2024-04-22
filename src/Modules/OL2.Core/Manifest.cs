using OrchardCore.Modules.Manifest;

[assembly: Module(
    Name = "OL2.Core",
    Author = "The Orchard Core Team",
    Website = "https://orchardcore.net",
    Version = "0.0.1",
    Description = "OL2.Core",
    Category = "Content Management",
    Dependencies = ["OrchardCore.ContentFields", "OrchardCore.Media"] // new[] { "OrchardCore.Media" }
)]
