using MyProfileSite.Shared.Models;
using System.Collections.Generic;

namespace MyProfileSite.Shared
{
    public class PagedResult<T> where T : class
    {
        public int Count { get; }
        public int ItemsPerPage { get; }
        public int CurrentPage { get; }

        private List<T> _pageItems;

        public PagedResult()
        {

        }

        public PagedResult(List<T> pageItems, int count, int itemsPerPage, int currentPage)
        {
            _pageItems = pageItems;
            Count = count;
            ItemsPerPage = itemsPerPage;
            CurrentPage = currentPage;
            PageItems = pageItems;
            Pagination = new Pagination(count, itemsPerPage, currentPage);
        }

        public List<T> PageItems { get; set; }

        public Pagination Pagination { get; set; }
    }
}
