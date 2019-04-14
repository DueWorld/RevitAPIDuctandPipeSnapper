namespace DuctAndPipeSnapper.Stringers
{
    using Autodesk.Revit.DB;

    class RevitCadLevelStringer : RevitLevelStringer
    {
        public RevitCadLevelStringer(Document doc, ImportInstance importedCad)
           : base(doc.GetElement(importedCad.LevelId) as Level)
        { }

        public override string ToString()
        {
            return "Selected Cad Link Level";
        }
    }
}
