namespace DuctAndPipeSnapper.Stringers
{
    using Autodesk.Revit.DB;

    class RevitLevelStringer
    {
        private string stringerText;
        public Level RevitLevel { get; set; }
        public string StringerText => stringerText;

        public RevitLevelStringer(Level level)
        {
            RevitLevel = level;
            stringerText = level.Name;
        }
        public override string ToString()
        {
            return stringerText;
        }
    }
}
