using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LesagencesPropertyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPropertyService
    {

        [OperationContract]
        List<PropertyModel> GetPropertyList();

        [OperationContract]
        PropertyDocumentModel GetPropertyDocument(Guid Id);
    }
}
