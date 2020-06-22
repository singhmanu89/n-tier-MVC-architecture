using System;
using System.Collections.Generic;
using System.Linq;
using PagedList;

namespace TrueForm.BusinessObjects.Generic
{
    public static class TrueFormPagedListExtentions
    {
        public static TrueFormPagedList<T> ToTrueFormPagedList<T>(this IList<T> list, IPagedList metdaData)
        {
            return new TrueFormPagedList<T>(list, metdaData);
        }
    }

    ///<summary>
    /// Non-enumerable version of the PagedList class.
    ///</summary>
    [Serializable]
    public class TrueFormPagedList<T> : IPagedList
    {
        /// <summary>
        ///  Non-enumerable version of the PagedList class.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pagedList">A PagedList (likely enumerable) to copy metadata from.</param>
        public TrueFormPagedList(IPagedList<T> pagedList)
        {
            Data = pagedList.ToList();
            PageCount = pagedList.PageCount;
            TotalItemCount = pagedList.TotalItemCount;
            PageNumber = pagedList.PageNumber;
            PageSize = pagedList.PageSize;
            HasPreviousPage = pagedList.HasPreviousPage;
            HasNextPage = pagedList.HasNextPage;
            IsFirstPage = pagedList.IsFirstPage;
            IsLastPage = pagedList.IsLastPage;
            FirstItemOnPage = pagedList.FirstItemOnPage;
            LastItemOnPage = pagedList.LastItemOnPage;
        }


        public TrueFormPagedList(IList<T> list, IPagedList pagedList)
        {
            Data = list;
            PageCount = pagedList.PageCount;
            TotalItemCount = pagedList.TotalItemCount;
            PageNumber = pagedList.PageNumber;
            PageSize = pagedList.PageSize;
            HasPreviousPage = pagedList.HasPreviousPage;
            HasNextPage = pagedList.HasNextPage;
            IsFirstPage = pagedList.IsFirstPage;
            IsLastPage = pagedList.IsLastPage;
            FirstItemOnPage = pagedList.FirstItemOnPage;
            LastItemOnPage = pagedList.LastItemOnPage;
        }

        #region IPagedList Members

        /// <summary>
        ///  Total number of subsets within the superset.
        /// </summary>
        /// <value>
        ///  Total number of subsets within the superset.
        /// </value>
        public int PageCount { get; set; }

        /// <summary>
        ///  Total number of objects contained within the superset.
        /// </summary>
        /// <value>
        ///  Total number of objects contained within the superset.
        /// </value>
        public int TotalItemCount { get; set; }

        /// <summary>
        ///  One-based index of this subset within the superset.
        /// </summary>
        /// <value>
        ///  One-based index of this subset within the superset.
        /// </value>
        public int PageNumber { get; set; }

        /// <summary>
        ///  Maximum size any individual subset.
        /// </summary>
        /// <value>
        ///  Maximum size any individual subset.
        /// </value>
        public int PageSize { get; set; }

        /// <summary>
        ///  Returns true if this is NOT the first subset within the superset.
        /// </summary>
        /// <value>
        ///  Returns true if this is NOT the first subset within the superset.
        /// </value>
        public bool HasPreviousPage { get; set; }

        /// <summary>
        ///  Returns true if this is NOT the last subset within the superset.
        /// </summary>
        /// <value>
        ///  Returns true if this is NOT the last subset within the superset.
        /// </value>
        public bool HasNextPage { get; set; }

        /// <summary>
        ///  Returns true if this is the first subset within the superset.
        /// </summary>
        /// <value>
        ///  Returns true if this is the first subset within the superset.
        /// </value>
        public bool IsFirstPage { get; set; }

        /// <summary>
        ///  Returns true if this is the last subset within the superset.
        /// </summary>
        /// <value>
        ///  Returns true if this is the last subset within the superset.
        /// </value>
        public bool IsLastPage { get; set; }

        /// <summary>
        ///  One-based index of the first item in the paged subset.
        /// </summary>
        /// <value>
        ///  One-based index of the first item in the paged subset.
        /// </value>
        public int FirstItemOnPage { get; set; }

        /// <summary>
        ///  One-based index of the last item in the paged subset.
        /// </summary>
        /// <value>
        ///  One-based index of the last item in the paged subset.
        /// </value>
        public int LastItemOnPage { get; set; }

        #endregion

        /// <summary>
        ///  The subset of items contained only within this one page of the superset.
        /// </summary>
        public IList<T> Data { get; set; }

        /// <summary>
        /// This is always true because if paginign result exist then success is true
        /// if any error will occured then it will be captured by global exception handler <see cref="SellutionExceptionApiAttribute"/>
        /// </summary>
        public bool IsSuccess { get; set; } = true;
    }
}

