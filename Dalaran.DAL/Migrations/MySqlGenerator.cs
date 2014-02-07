using System;
using MySql.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;

namespace Dalaran.DAL.Migrations
{
    public class MySqlGenerator : MySqlMigrationSqlGenerator
    {
        public MySqlGenerator()
        {
            
        }
        /*
         * Write this line on Migrations.Configuration.
         *    this.SetSqlGenerator("MySql.Data.MySqlClient", new MySqlGenerator() ); 
         * */

        protected override MigrationStatement Generate(AddForeignKeyOperation op)
        {
            if (op.Name.Equals("FK_dbo.ProductDescriptions_dbo.ProductDescriptionTypes_ProductDescriptionTypeId"))
            {
                op.Name = "FK_dbo.ProdDesc_dbo.ProductDescrTypes";
            }

            return base.Generate(op);
        }
    }
}
