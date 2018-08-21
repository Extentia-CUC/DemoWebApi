using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDataModel;

namespace WebDataService.Models
{
    public class ServiceResponse<T>
    {
        public List<T> Data { get; }
        public PaginationMetadata Pagination { get; }

        public ServiceResponse(IQueryable<T> source, PaginationMetadata paging)
        {
            int totalItems = source.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)paging.Limit);

            Data = source
                            .Skip(paging.Limit * (paging.Offset - 1))
                            .Take(paging.Limit)
                            .ToList();
            
            Pagination = new PaginationMetadata()
            {
                Total = totalPages,
                Limit = paging.Limit,
                Offset = paging.Offset,
                Returned = this.Data.Count
            };
        }

    }
    /// <summary>
    /// Pagination metadata
    /// </summary>
    public class PaginationMetadata
    {
        private int _limit = 300;
        private int _offset = 1;
        /// <summary>
        /// Total number of pages
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Number of items to be returned
        /// </summary>
        public int Limit
        {
            get { return _limit; }
            set
            {
                _limit = value;
            }
        }

        /// <summary>
        /// Page offset
        /// </summary>
        public int Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        /// <summary>
        /// Total items returned
        /// </summary>
        public int Returned { get; set; }
    }




}