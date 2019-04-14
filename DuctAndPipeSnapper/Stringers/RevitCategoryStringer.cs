namespace DuctAndPipeSnapper.Stringers
{
    using Autodesk.Revit.DB;

    class RevitCategoryStringer
    {
        private Category revitCategory;
        private string stringerText;

        public Category RevitCategory => revitCategory;
        public string StringerText => stringerText;

        public RevitCategoryStringer(Category revitCategory)
        {
            this.revitCategory = revitCategory;
            stringerText = revitCategory.Name;
        }
        public override string ToString()
        {
            return stringerText;
        }
    }
}
