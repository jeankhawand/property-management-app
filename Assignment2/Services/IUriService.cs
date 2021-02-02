using System;
using Assignment2.Filters;

namespace Assignment2.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}