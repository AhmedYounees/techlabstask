using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.AhmedYounes.Domains;

namespace Nop.Plugin.AhmedYounes.Migrations;
[NopMigration("11/16/2024 1:23:56 PM", "Nop.Plugin.AhmedYounes schema", MigrationProcessType.Installation)]
public class SchemaMigration : AutoReversingMigration
{
    /// <summary>
    /// Collect the UP migration expressions
    /// </summary>
    public override void Up()
    {
        Create.TableFor<CustomTable>();
    }
}