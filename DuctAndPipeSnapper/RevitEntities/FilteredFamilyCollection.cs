using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace HelperClasses
{
    /// <summary>
    /// Filters Families based on criteria either: FamilyName, a given FamilySymbol, BuiltInFamilyCategory or FamilyCategoryName.
    /// </summary>
    class FilteredFamilyCollection : IEnumerable<Family>
    {
        private String familyName;
        private String familyCategoryName;
        private FamilySymbol filteredFamilySymbol;
        private BuiltInCategory familyCategory;
        private Document currentDocument;
        private IEnumerable<Family> familyList;


        public string FamilyName { get => familyName; set => familyName = value; }
        public FamilySymbol FilteredFamilySymbol { get => filteredFamilySymbol; set => filteredFamilySymbol = value; }
        public string FamilyCategoryName { get => familyCategoryName; set => familyCategoryName = value; }
        public BuiltInCategory FamilyCategory { get => familyCategory; set => familyCategory = value; }
        public Document CurrentDocument { get => currentDocument; set => currentDocument = value; }


        private FilteredFamilyCollection
            (IEnumerable<Family> familyListing, string familyName, FamilySymbol filteredFamilySymbol, BuiltInCategory builtInCategory, string familyCategoryName, Document document)
        {
            this.familyName = familyName;
            this.familyCategoryName = familyCategoryName;
            this.filteredFamilySymbol = filteredFamilySymbol;
            familyCategory = builtInCategory;
            currentDocument = document;
            familyList = familyListing;

        }
        private FilteredFamilyCollection
            (string familyName, FamilySymbol filteredFamilySymbol, BuiltInCategory builtInCategory, string familyCategoryName, Document document) : this(null, familyName, filteredFamilySymbol, builtInCategory, familyCategoryName, document)
        { }
        private FilteredFamilyCollection FilterBasedOnCriteria()
        {
            IEnumerable<Element> rit = new FilteredElementCollector(currentDocument).OfClass(typeof(Family));
            familyList = rit.Cast<Family>();

            if (familyName != null)
            {
                familyList = familyList.Where(q => q.Name == familyName);
            }
            else if (familyCategoryName != null)
            {
                familyList = familyList.Where(f => f.FamilyCategory.Name == familyCategoryName);
            }
            else if (filteredFamilySymbol != null)
            {
                familyList = familyList.Where(q =>
                {
                    foreach (ElementId elementID in q.GetFamilySymbolIds())
                    {
                        if (filteredFamilySymbol.Id == elementID)
                        {
                            return true;
                        }

                    }
                    return false;
                });
            }
            else
            {
                familyList = familyList.Where(q => q.FamilyCategory.Id.IntegerValue.Equals((int)familyCategory));
            }

            return new FilteredFamilyCollection(familyList, familyName, filteredFamilySymbol, familyCategory, familyCategoryName, currentDocument);
        }
        /// <summary>
        /// Instantiate a new collection filtered by Family Name from an Autodesk Revit document.
        /// </summary>
        /// <param name="document"></param>
        /// Current Active Document.
        /// <param name="familyName"></param>
        /// String Value of the FamilyName.
        /// <returns></returns>
        public static FilteredFamilyCollection NewFilteredFamilyCollectionByName(Document document, string familyName) => new FilteredFamilyCollection(familyName, null, 0, null, document).FilterBasedOnCriteria();
        /// <summary>
        /// Instantiate a Family collection given by a specific Category Name.
        /// </summary>
        /// <param name="document"></param>.
        /// Current Active Document.
        /// <param name="familyCategoryName"></param>
        /// String Value of the Name of the Category that would include an enumeration of Families.
        /// <returns></returns>
        public static FilteredFamilyCollection NewFilteredFamilyCollectionByCategoryName(Document document, string familyCategoryName) => new FilteredFamilyCollection(null, null, 0, familyCategoryName, document).FilterBasedOnCriteria();
        /// <summary>
        /// Instantiate a new collection filtered by FamilySymbol Name from an Autodesk Revit document.
        /// </summary>
        /// <param name="document"></param>
        /// Current Active Document.
        /// <param name="familySymbol"></param>
        /// Criteria to filter the Families of an Autodesk Revit document upon the Type of the Family.
        /// <returns></returns>
        public static FilteredFamilyCollection NewFilteredFamilyCollection(Document document, FamilySymbol familySymbol) => new FilteredFamilyCollection(null, familySymbol, 0, null, document).FilterBasedOnCriteria();
        /// <summary>
        /// Instantiate a new collection filtered by Category from an Autodesk Revit document.
        /// </summary>
        /// <param name="document"></param>
        /// Current Active Document.
        /// <param name="builtInCategory"></param>
        /// Criteria as name of the Category that would include an enumeration of Families.
        public static FilteredFamilyCollection NewFilteredFamilyCollection(Document document, BuiltInCategory builtInCategory) => new FilteredFamilyCollection(null, null, builtInCategory, null, document).FilterBasedOnCriteria();

        /// <summary>
        /// Converts the FilteredFamilyCollection into a List of Families.
        /// </summary>
        /// <returns></returns>
        public List<Family> ToFamilies()
        {
            return new List<Family>(familyList);
        }
        /// <summary>
        /// Converts a specific filter that would return only one Family instance from the Autodesk Revit document into a single Family Instance (Such as Filtering by FamilyName).
        /// </summary>
        /// <returns></returns>
        public Family ToFamily()
        {
            List<Family> family = new List<Family>();
            foreach (Family f in familyList)
            {
                family.Add(f);
            }
            return family[0];
        }
        public IEnumerator<Family> GetEnumerator()
        {
            return familyList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return familyList.GetEnumerator();
        }

        


    }
}
