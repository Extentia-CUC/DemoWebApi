﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebDataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SampleWebDataEntities : DbContext
    {
        public SampleWebDataEntities()
            : base("name=SampleWebDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<NOPVData> NOPVDatas { get; set; }
    
        [DbFunction("SampleWebDataEntities", "get_details")]
        public virtual IQueryable<NOPVData> get_details(string bbl)
        {
            var bblParameter = bbl != null ?
                new ObjectParameter("bbl", bbl) :
                new ObjectParameter("bbl", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<NOPVData>("[SampleWebDataEntities].[get_details](@bbl)", bblParameter);
        }
    
        //public virtual int insert_log()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_log");

        //}
    }
}
