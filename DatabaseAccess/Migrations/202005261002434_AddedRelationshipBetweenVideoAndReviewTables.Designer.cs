﻿// <auto-generated />
namespace DatabaseAccess.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed partial class AddedRelationshipBetweenVideoAndReviewTables : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddedRelationshipBetweenVideoAndReviewTables));
        
        string IMigrationMetadata.Id
        {
            get { return "202005261002434_AddedRelationshipBetweenVideoAndReviewTables"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}