using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.OData;

namespace WebDataModel
{
    public interface INopvDataRepository
    {
        IQueryable<NOPVData> GetAll();
        NOPVData GetDetails(string bbl);
        //NOPVData UpdateDetails(string bbl, Delta<NOPVData> data);
        NOPVData UpdateDetails(string bbl, JsonPatch.JsonPatchDocument<NOPVData> data);
        NOPVData SaveDetails(NOPVData data);
    }
}
