using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlToDB
{
    public class CodeDBContext: DbContext
    {

        public DbSet<ProcessItem> Process { get; set; }

        public DbSet<TruckXML> TruckXML { get; set; }

        public DbSet<JobXML> JobXML { get; set; }

        public DbSet<ServiceXML> ServiceXML { get; set; }


        //public CodeDBContext() : base("")
        //{

        //}

        public CodeDBContext(string connection):base(connection)
        {
            Configuar();
        }

        

        public CodeDBContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configuar();
        }

        private void Configuar()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<PortConfig>();
        //    //modelBuilder.Entity<DetectorModel>();
        //    //modelBuilder.Entity<StationModel>();
        //    //modelBuilder.Entity<AssistModel>();

        //    var initializer = new  DBInitializer(modelBuilder);
        //    Database.SetInitializer(initializer);
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<ProcessItem>();
        //    modelBuilder.Enstity<TruckXML>();

        //    Database.SetInitializer<CodeDBContext>(null);
        //    //Database.SetInitializer<CodeDBContext>(new CreateDatabaseIfNotExists<CodeDBContext>());
        //}
    }
}
