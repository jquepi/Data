using System;

namespace Octopus.Data.Model
{
    public static class LinkCollectionExtensions
    {
        public static LinkCollection Pagination(this LinkCollection collection,
            Func<int, int, string> formatWithSkipAndTake,
            int currentOffset,
            int perPage,
            int total)
        {
            collection.Add("Page.All", formatWithSkipAndTake(0, int.MaxValue));
            if (currentOffset > 0)
                collection.Add("Page.Previous", formatWithSkipAndTake(Math.Max(currentOffset - perPage, 0), perPage));

            if (total > currentOffset + perPage)
                collection.Add("Page.Next", formatWithSkipAndTake(currentOffset + perPage, perPage));

            collection.Add("Page.Current", formatWithSkipAndTake(currentOffset, perPage));

            var lastPage = Math.Max(0, (int)Math.Ceiling((double)total / perPage) - 1);
            collection.Add("Page.Last", formatWithSkipAndTake(lastPage * perPage, perPage));

            return collection;
        }
    }
}