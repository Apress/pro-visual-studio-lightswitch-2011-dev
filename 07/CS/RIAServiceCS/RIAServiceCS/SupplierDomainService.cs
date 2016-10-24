
namespace Central.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Data.SqlClient;
    using System.Configuration;

    [Description ("Enter the connection string to the Shipper Central DB")]
    public class SupplierDomainService : DomainService
    {
        private readonly List<SupplierRecord> _supplierRecordList;
        public SupplierDomainService()
        {
            _supplierRecordList = new List<SupplierRecord>();                
        }

        string _connectionString;
        public override void Initialize
            (System.ServiceModel.DomainServices.Server.DomainServiceContext context)
        {                  
            _connectionString = ConfigurationManager.ConnectionStrings[this.GetType().FullName].ConnectionString;
            base.Initialize(context);
        }

        [Query(IsDefault = true)]        
        public IQueryable<SupplierRecord> GetSampleCustomerData()
        {
            _supplierRecordList.Clear();
            SqlConnection cnn = new SqlConnection(_connectionString);
                        
            SqlCommand cmd = new SqlCommand(
                "SELECT SupplierID, CompanyName,ContactFirstname, ContactSurname FROM Supplier", cnn);

            try
            {
                cnn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        SupplierRecord supplier = new SupplierRecord();
                        supplier.SupplierID = (int)dr["SupplierID"];
                        supplier.SupplierName = dr["CompanyName"].ToString();
                        supplier.FirstName = dr["ContactFirstname"].ToString();
                        supplier.LastName = dr["ContactSurname"].ToString();
                        _supplierRecordList.Add(supplier);
                    }
                }
            }
            finally
            {
                cnn.Close();
            }

            return _supplierRecordList.AsQueryable();       
        }


        public void UpdateSupplierData(SupplierRecord Supplier)
        {
            SqlConnection cnn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(
                "UPDATE Supplier SET  CompanyName = @CompanyName ,ContactFirstname=@ContactFirstname, ContactSurname=@ContactSurname WHERE SupplierID = @SupplierID", cnn);
            cmd.Parameters.AddWithValue("CompanyName", Supplier.SupplierName );
            cmd.Parameters.AddWithValue("ContactFirstName", Supplier.FirstName );
            cmd.Parameters.AddWithValue("ContactSurname", Supplier.LastName );
            cmd.Parameters.AddWithValue("SupplierID", Supplier.SupplierID );

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery(); 
            }
            finally
            {
                cnn.Close();
            }

        }

        public void InsertSupplierData(SupplierRecord Supplier)
        {
            SqlConnection cnn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO Supplier (CompanyName,ContactFirstname, ContactSurname) VALUES ( @CompanyName ,@ContactFirstname, @ContactSurname); SELECT @@Identity ", cnn);
            cmd.Parameters.AddWithValue("CompanyName", Supplier.SupplierName);
            cmd.Parameters.AddWithValue("ContactFirstName", Supplier.FirstName);
            cmd.Parameters.AddWithValue("ContactSurname", Supplier.LastName);
            
            try
            {
                cnn.Open();
                Supplier.SupplierID = (int)cmd.ExecuteScalar();
            }
            finally
            {
                cnn.Close();
            }
        }

        public void DeleteSupplierData(SupplierRecord Supplier)
        {

//Here's the Stored Proc Definition
//CREATE PROCEDURE DeleteSupplier 
//    @SupplierID int
//AS
//BEGIN
//    SET NOCOUNT ON;
//    DELETE FROM Supplier
//    WHERE SupplierID=@SupplierID

//END
//GO

            SqlConnection cnn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("DeleteSupplier", cnn);
            cmd.Parameters.AddWithValue("@SupplierID", Supplier.SupplierID );
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cnn.Close();
            }


        }

    
    }

    public class SupplierRecord
    {
        [Key, Editable (false)]
        public int SupplierID { get; set; }
        [Required(ErrorMessage ="Supplier Name must be entered"), StringLength(60)]
        public string SupplierName { get; set; }
        [StringLength(25)]
        public string FirstName { get; set; }
        [StringLength(25)]        
        public string LastName { get; set; }
    }


    


}


