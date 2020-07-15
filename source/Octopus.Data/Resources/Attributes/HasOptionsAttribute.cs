using System;

namespace Octopus.Data.Resources.Attributes
{
    /// <summary>
    ///     Indicates that this property is selectable from a list of options, which are implied by the enum type of this
    ///     property
    /// </summary>
    public class HasOptionsAttribute : SelectableAttribute
    {
        public HasOptionsAttribute(SelectMode selectMode)
            : base(selectMode)
        {
        }
    }
}