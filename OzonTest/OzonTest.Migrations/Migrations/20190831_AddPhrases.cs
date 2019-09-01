using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace OzonTest.Migrations.Migrations
{
    [Migration(20190831092300)]
    public class AddPhrases : Migration
    {  
        public override void Up()
        {
            Create.Table("phrases")
                .WithColumn("id").AsInt64().PrimaryKey().Identity()
                .WithColumn("words").AsString();

            Execute.Script("Migrations/AddIndex.sql");
        }

        public override void Down()
        {
            Delete.Table("phrases");
        }
    }
}
