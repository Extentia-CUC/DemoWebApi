using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDataModel
{
    public partial class SampleWebDataEntities : DbContext
    {
        //public SampleWebDataEntities()
        //    : base("name=SampleWebDataEntities")
        //{
        //}

        [DbFunction("SampleWebDataModel.Store", "Increment")]
        //public static int Increment(int i, int val, SampleWebDataEntities _dbContext)
        public int Increment(int i, int val)
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;

            var parameters = new List<ObjectParameter>();
            parameters.Add(new ObjectParameter("i", i));
            parameters.Add(new ObjectParameter("val", val));
            
            return objectContext.CreateQuery<int>("SampleWebDataModel.Store.Increment(@i, @val)", 
                parameters.ToArray()).Execute(MergeOption.NoTracking).FirstOrDefault();

        }

        [DbFunction("SampleWebDataModel.Store", "total_lotfrontage")]
        public float total_lotfrontage(string primaryzoning)
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;

            var parameters = new List<ObjectParameter>();
            parameters.Add(new ObjectParameter("primaryzoning", primaryzoning));
            
            return objectContext.CreateQuery<float>("SampleWebDataModel.Store.total_lotfrontage(@primaryzoning)",
                parameters.ToArray()).Execute(MergeOption.NoTracking).FirstOrDefault();

        }

        [DbFunction("SampleWebDataModel.Store", "insert_log")]
        public System.DBNull insert_log()
        {
            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_log");
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            return objectContext.CreateQuery<System.DBNull>("SampleWebDataModel.Store.insert_log()").Execute(MergeOption.NoTracking).FirstOrDefault();

        }
    }

}
