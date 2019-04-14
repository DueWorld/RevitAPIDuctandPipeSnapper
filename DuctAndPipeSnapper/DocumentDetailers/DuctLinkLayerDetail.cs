namespace DuctAndPipeSnapper
{
    using Autodesk.Revit.DB;
    using Autodesk.Revit.DB.Mechanical;

    public class DuctLinkLayerDetail
    {
        private string cadLayerName;
        private double ductWidth;
        private double ductHeight;
        private double levelOffset;
        private MechanicalSystemType airType;
        private Level detailLevel;
        private Category layerCategory;

        public string CadLayerName => cadLayerName;
        public double DuctWidth => ductWidth;
        public double DuctHeight => ductHeight;
        public double LevelOffset => levelOffset;
        public MechanicalSystemType AirType => airType;
        public Level DetailLevel => detailLevel;
        public Category LayerCategory => layerCategory;

        public DuctLinkLayerDetail(string name, double ductWidth, double ductHeight, double lvlOffet, MechanicalSystemType ductType, Level refLevel, Category layerCategory)
        {
            cadLayerName = name;
            this.ductWidth = ductWidth;
            this.ductHeight = ductHeight;
            this.layerCategory = layerCategory;
            airType = ductType;
            detailLevel = refLevel;
            levelOffset = lvlOffet;
        }
    }
}
