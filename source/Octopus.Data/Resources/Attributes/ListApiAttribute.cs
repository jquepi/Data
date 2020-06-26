using Octopus.Data.Model;

namespace Octopus.Data.Resources.Attributes
{
    /// <summary>
    ///     Indicates that this property will be selectable from a list of options, supplied by the apiEndpoint
    /// </summary>
    public class ListApiAttribute : SelectableAttribute
    {
        public readonly Href ApiEndpoint;

        public ListApiAttribute(SelectMode selectMode, string apiEndpoint)
            : base(selectMode)
        {
            ApiEndpoint = apiEndpoint;
        }
    }
}