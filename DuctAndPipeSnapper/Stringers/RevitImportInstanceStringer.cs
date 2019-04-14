namespace DuctAndPipeSnapper.Stringers
{
    using Autodesk.Revit.DB;

    class RevitImportInstanceStringer
    {
        private ImportInstance revitImport;
        private string stringerText;

        public ImportInstance RevitImport => revitImport;
        public string StringerText => stringerText;

        public RevitImportInstanceStringer(ImportInstance revitImportInstance, Document doc)
        {
            revitImport = revitImportInstance;
            stringerText = doc.GetElement(revitImport.GetTypeId()).Name;
        }

        public override string ToString()
        {
            return stringerText;
        }
    }
}
