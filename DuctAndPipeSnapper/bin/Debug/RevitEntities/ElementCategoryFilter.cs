namespace HelloRevit
{
    using Autodesk.Revit.DB;
    using System;
    
    public class ElementCategoryFilter : ElementSelectionFilter
    {
        private BuiltInCategory bic;

        public BuiltInCategory BuiltInCategoryID => bic;

        public ElementCategoryFilter(BuiltInCategory bic) => this.bic = bic;

        public override bool AllowElement(Element elem)
        {
            return elem.Category.Id.IntegerValue.Equals((int)bic);
        }

        public override bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}
