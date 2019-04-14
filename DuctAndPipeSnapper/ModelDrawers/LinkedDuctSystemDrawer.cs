using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using System.Collections.Generic;
using System.Linq;

namespace DuctAndPipeSnapper
{
    public class LinkedDuctSystemDrawer
    {
        private ImportInstance cadLink;
        private List<DuctLinkLayerDetail> cadLayerDetails;
        private List<Duct> ductList;
        private Document revitDocument;
        public List<Duct> DuctList => ductList;
        public ImportInstance CadLink { get => cadLink; set => cadLink = value; }
        public List<DuctLinkLayerDetail> CadLayerDetails { get => CadLayerDetails; set => cadLayerDetails = value; }
        public Document RevitDocument { get => revitDocument; set => revitDocument = value; }


        public LinkedDuctSystemDrawer(ImportInstance cadLink, List<DuctLinkLayerDetail> cadLayerDetails, Document doc)
        {
            this.cadLink = cadLink;
            this.cadLayerDetails = cadLayerDetails;
            revitDocument = doc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="drawnDuct"></param>
        /// <param name="layerDetail"></param>
        private void ModifyDrawnDuct(Duct drawnDuct, DuctLinkLayerDetail layerDetail)
        {
            drawnDuct.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).Set(layerDetail.DuctHeight);
            drawnDuct.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).Set(layerDetail.LevelOffset);
            drawnDuct.get_Parameter(BuiltInParameter.RBS_CURVE_WIDTH_PARAM).Set(layerDetail.DuctWidth);
            drawnDuct.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).Set(layerDetail.DetailLevel.Id);
            drawnDuct.get_Parameter(BuiltInParameter.RBS_DUCT_SYSTEM_TYPE_PARAM).Set(layerDetail.AirType.Id);
        }
           
        
        /// <summary>
        /// 
        /// </summary>
        public void DrawDuctFromCadLink()
        {
            Transform transf;
            GraphicsStyle style;
            Line l;
            List<Duct> ductList = new List<Duct>();
            Duct drawnDuct;
            FilteredElementCollector collector = new FilteredElementCollector(revitDocument);
            collector.OfClass(typeof(DuctType)).WhereElementIsElementType();
            DuctType ductType = collector.FirstOrDefault() as DuctType; 
     

            foreach (DuctLinkLayerDetail detail in cadLayerDetails)
            {
                foreach (GeometryObject geoObj in cadLink.get_Geometry(new Options()))
                {
                    if (geoObj is GeometryInstance)
                    {
                        GeometryInstance inst = geoObj as GeometryInstance;
                        transf = inst.Transform;
                        foreach (GeometryObject geoObj2 in inst.SymbolGeometry)
                        {
                            if (geoObj2 is Line)
                            {
                                //get the revit model coordinates.
                                l = geoObj2 as Line;
                                style = revitDocument.GetElement(l.GraphicsStyleId) as GraphicsStyle;
                                if (style.GraphicsStyleCategory.Name== detail.LayerCategory.Name)
                                {
                                    XYZ ptStartInRevit = transf.OfPoint(l.GetEndPoint(0));
                                    XYZ ptEndInRevit = transf.OfPoint(l.GetEndPoint(1));
                                    Curve curve = Line.CreateBound(ptStartInRevit, ptEndInRevit);
                                    drawnDuct = Duct.Create(revitDocument, detail.AirType.Id,ductType.Id, detail.DetailLevel.Id, ptStartInRevit, ptEndInRevit);
                                    ModifyDrawnDuct(drawnDuct, detail);
                                    ductList.Add(drawnDuct);
                                }

                            }
                        }
                    }
                }
            }
            this.ductList = ductList;
        }

    }
}
