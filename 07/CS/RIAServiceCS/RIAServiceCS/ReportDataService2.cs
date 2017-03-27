namespace Central.Data.Services
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Server;
    using System.Data.EntityClient;
    using System.Web.Configuration;
    using ApplicationData.Implementation;

    public class ReportDataService2 : DomainService
    {

        //the name of this project
        private const string METADATA_NAME = "ApplicationData";

        //used to build the metatdata
        const string METADATA_FORMAT =
            "res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl";

        //LightSwitch uses a special name for its intrinsic database connection
        //instead of ApplicationData as you would normally expect
        const string CONNECTION_NAME = "_IntrinsicData";

        //the data provider name
        const string PROVIDER_NAME = "System.Data.SqlClient";

        private ApplicationDataObjectContext _context;

        public ApplicationDataObjectContext Context
        {
            get
            {
                if (_context == null)
                {
                    var builder = new EntityConnectionStringBuilder();

                    builder.Metadata = string.Format(
                        METADATA_FORMAT, METADATA_NAME);
                    builder.Provider = PROVIDER_NAME;
                    builder.ProviderConnectionString = WebConfigurationManager.ConnectionStrings[CONNECTION_NAME].ConnectionString;

                    _context = new ApplicationDataObjectContext(builder.ConnectionString);
                }

                return _context;
            }



        }

        [Query(IsDefault = true)]
        public IQueryable<ReportDataClass> GenderCount()
        {
            IQueryable<ReportDataClass> result = null;

            result = from Person p in this.Context.People
                     group p by p.Gender into g

                     select new ReportDataClass
                        {
                            Id = g.Key.Id,
                            Name = g.Key.GenderName,
                            Total = g.Count()
                        };


            return result;
        }

        protected override int Count<T>(IQueryable<T> query)
        {
            return query.Count();
        }


    }


    public class ReportDataClass
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Total { get; set; }

        // if you need to cast any values from one type to another, 
        // you'll need to do it here
        // because casts aren't allowed in LINQ to Entity queries
        internal float TotalSingle
        {
            set
            {
                this.Total = new decimal(value);
            }
        }
    }

}


