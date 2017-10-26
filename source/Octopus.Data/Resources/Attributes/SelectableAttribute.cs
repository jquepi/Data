using System;

namespace Octopus.Data.Resources.Attributes
{
    /// <summary>
    /// Base class indicating that this property will be selectable from a list of valid options in the UI
    /// </summary>
    public abstract class SelectableAttribute : Attribute
    {
        public readonly SelectMode SelectMode;

        protected SelectableAttribute(SelectMode selectMode)
        {
            SelectMode = selectMode;
        }
    }
}