using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LesagencesPropertyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IPropertyService
    {
        string connectionString = "Data Source=10.50.56.156;Initial Catalog=LesAgency;User Id=sa;Password=Qwerty1;";
        public List<PropertyModel> GetPropertyList()
        {
            List<PropertyModel> models = new List<PropertyModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlQuery = @"SELECT TOP 20  Properties.Uid, Name, Address, SalePrice, RoomsCount, TotalSquare ,
                           (SELECT TOP 1 Uid FROM PropertyDocuments WHERE PropertyUid=Properties.Uid ORDER BY RowNo ASC) AS ImageId
		                   FROM Properties WHERE IsDeleted=0 ORDER BY CreatedUtc DESC";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    PropertyModel model = new PropertyModel
                    {

                        Uid = ReplaceNullGuid(dataReader["Uid"].ToString()),
                        Address = ReplaceNullString(dataReader["Address"]),
                        SalePrice = ReplaceNullDecimal(dataReader["SalePrice"]),
                        Name = ReplaceNullString(dataReader["Name"]),
                        RoomsCount = ReplaceNullInt(dataReader["RoomsCount"]),
                        TotalSquare = ReplaceNullInt(dataReader["TotalSquare"]),
                        ImageId = ReplaceNullGuid(dataReader["ImageId"].ToString())
                    };

                    models.Add(model);
                }
                dataReader.Close();
                return models;
            }
        }

        public PropertyDocumentModel GetPropertyDocument(Guid Id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PropertyDocumentModel model = new PropertyDocumentModel();
                connection.Open();
                string sqlQuery = @"SELECT Body FROM PropertyDocuments WHERE Uid = @Id";
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                command.Parameters.AddWithValue("@Id", Id);
                SqlDataReader sqlDataReader =  command.ExecuteReader();
                sqlDataReader.Read();
                byte[] image = (byte[])sqlDataReader["Body"];
                model.Image = image;
                return model;
            }
        }

        public string ReplaceNullString(object value)
        {
            if (value == null)
            {
                return "";
            }
            else
            {
                return value.ToString();
            }
        }

        public int ReplaceNullInt(object value)
        {
            if (value == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt16(value);
            }
        }

        public decimal ReplaceNullDecimal(object value)
        {
            if (value == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToDecimal(value);
            }
        }

        public Guid ReplaceNullGuid(object value)
        {
            if (value == null)
            {
                return default(Guid);
            }
            else
            {
                return Guid.Parse(value.ToString());
            }
        }
    }
}
