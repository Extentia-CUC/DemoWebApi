using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace WebDataModel
{
    public class NopvDataRepository : INopvDataRepository
    {
        private SampleWebDataEntities dbContext;
        public NopvDataRepository(SampleWebDataEntities _dbContext)
        {
            dbContext = _dbContext;
        }

        public IQueryable<NOPVData> GetAll()
        {
            
            return dbContext.NOPVDatas.AsQueryable().OrderBy(a=>a.BBL);
        }

        public NOPVData GetDetails(string bbl)
        {
            //var query =  dbContext.Database.SqlQuery<NOPVData>("select * from \"NOPVData\" where \"BBL\"=@bbl", new NpgsqlParameter("bbl", bbl));
            //string querytxt = "select * from \"NOPVData\" where \"BBL\" = '" + bbl + "'";
            //var query = dbContext.NOPVDatas.SqlQuery(querytxt).FirstOrDefault();
            //NOPVData entity = query;
            NOPVData entity = dbContext.NOPVDatas.FirstOrDefault(e => e.BBL == bbl);
            if (entity == null)
                throw new Exception("BBL not found");
            return entity;
        }

        public NOPVData SaveDetails(NOPVData data)
        {
            NOPVData nopvObject = dbContext.NOPVDatas.Add(data);
            dbContext.SaveChanges();
            return nopvObject;
        }
        public NOPVData UpdateDetails(string bbl, JsonPatch.JsonPatchDocument<NOPVData> data)
        {
            NOPVData entity = dbContext.NOPVDatas.FirstOrDefault(b => b.BBL == bbl);
            if (entity == null)
                throw new Exception("BBL not found");

            try
            {

                //dbContext.Entry(entity).CurrentValues.SetValues(data);
                data.ApplyUpdatesTo(entity);
                //dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return entity;
            }
            catch(Exception ex)
            {
                throw new Exception("Error while updating data", ex);
            }
        }

        public void ExecuteFunction()
        {
            //connectionString = "metadata=res://*/WebDataContext.csdl|res://*/WebDataContext.ssdl|res://*/WebDataContext.msl;provider=Npgsql;
            //    provider connection string=&quot;Host=127.0.0.1;Database=SampleWebData;Username=postgres;Password=#ext123
            //var connectionString = "Host=127.0.0.1;Username=postgres;Password=#ext123;Database=SampleWebData";
            //NpgsqlConnection _connPg = new NpgsqlConnection(connectionString);
            //_connPg.Open();
            //using (var cmd = _connPg.CreateCommand())
            //{
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.CommandText = "insert_log";
            //    cmd.ExecuteReader();
            //}
            //using (var cmd = _connPg.CreateCommand())
            //{
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.CommandText = "\"Increment\"";
            //    var par1 = cmd.CreateParameter();
            //    par1.DataTypeName = "integer";
            //    par1.ParameterName = "i";
            //    par1.Value = 2;
            //    var par2 = cmd.CreateParameter();
            //    par2.DataTypeName = "integer";
            //    par2.ParameterName = "val";
            //    par2.Value = 2;
            //    cmd.Parameters.Add(par1);
            //    cmd.Parameters.Add(par2);
            //    var res = cmd.ExecuteScalar();
            //}

            // var res = dbContext.Database.SqlQuery(typeof(void), "insert_log", new object[0]);

            // var res = dbContext.Database.ExecuteSqlCommand("select insert_log()");
            //var param = new Npgsql.NpgsqlParameter("val", NpgsqlTypes.NpgsqlDbType.Integer);
            //param.Value = 1;
            //var param2 = new Npgsql.NpgsqlParameter("i", NpgsqlTypes.NpgsqlDbType.Integer);
            //param2.Value = 1;
            //var result = dbContext.Database.SqlQuery<int>("select \"Increment\"(@i,@val)", param2,param).FirstOrDefault();
            //var param = new NpgsqlParameter("bbl", "1000750043");
            //var rowset = dbContext.Database.SqlQuery<NOPVData>("select * from get_details(@bbl)", param);

            //foreach (var cust in rowset)
            //{
            //    var bbl = cust.BBL;
            //}
            //dbContext.Database.Connection.Open();
            //using (var cmd = dbContext.Database.Connection.CreateCommand())
            //{
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.CommandText = "\"Increment\"";
            //    var par1 = cmd.CreateParameter();
            //    par1.DbType = System.Data.DbType.Int32;
            //    par1.ParameterName = "i";
            //    par1.Value = 2;
            //    var par2 = cmd.CreateParameter();
            //    par2.DbType = System.Data.DbType.Int32;
            //    par2.ParameterName = "val";
            //    par2.Value = 2;
            //    cmd.Parameters.Add(par1);
            //    cmd.Parameters.Add(par2);
            //    var res = cmd.ExecuteScalar();
            //}

            //dbContext.Database.Connection.Close();

            //var result = ModelDefinedFunctions.Increment(2, 3, dbContext);
            //var result = dbContext.Increment(2, 3);
            //var nopv_result = dbContext.get_details("1000970044").ToList<NOPVData>();
            //var result = dbContext.total_lotfrontage("C6-2A");
            var result = dbContext.insert_log();
        }
    }
}
