using System;

namespace DynamicFolderEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context
            {
                Tenant = "dev",
                UserId = "1",
            };


            var engine = Engine.Create(context, "database");

            var conditionSet = new ConditionSet();
            conditionSet.FolderId = "root";
            conditionSet.Add("Type", "eq", "Image");

            var structure = new Structure {Type = StructureType.None};

            // Case 1
            // Dynamic Definition:
            //      Folder: root
            //      Rule: Type equals Image
            //      Structure: Flatten
            // Path: *
            conditionSet.FolderId = "root";
            conditionSet.Add("Type", "eq", "Image");

            // Case 2
            // Dynamic Definition: 
            //      Folder: root
            //      Rule: Type equals Image
            //      Structure: KeepFolderStructure
            // Path: *
            conditionSet.FolderId = "root";
            conditionSet.Add("Type", "eq", "Image");

            structure.Type = StructureType.SameAsSource;

            // Case 3
            // Dynamic Definition:
            //      Folder: root
            //      Rule: Type equals Image
            //      Structure: KeepFolderStructure
            // Path: ./
            conditionSet.FolderId = "root";
            conditionSet.Add("Type", "eq", "Image");

            structure.Type = StructureType.SameAsSource;
            structure.Depth = 1;

            // Case 4
            // Dynamic Definition: 
            //      Folder: root
            //      Rule: Type equals Image
            //      Structure: KeepFolder Structure
            // Path: ./PDF (Id = PDF)

            conditionSet.FolderId = "PDF";
            conditionSet.Add("Type", "eq", "Image");

            structure.Type = StructureType.SameAsSource;
            structure.Depth = 1;

            // Case 5
            // Dynamic Definition:
            //      Folder: root
            //      Rule: Type equals Image
            //      Structure: AutoGen
            //          Lvl1: PropA
            //          Lvl2: PropB
            // Result: all

            conditionSet.FolderId = "root";
            conditionSet.Add("Type", "eq", "Image");

            structure.Type = StructureType.ByProperties;
            structure.Payload = "PropA,PropB";

            // Case 5
            // Dynamic Definition: 
            //      Folder: root
            //      Rule: Type equals Image
            //      Structure: AutoGen
            //          Lvl1: PropA
            //          Lvl2: PropB, hide empty 
            // Result: all

            conditionSet.FolderId = "root";
            conditionSet.Add("Type", "eq", "Image");
            conditionSet.Add("PropB", "neq", Condition.EmptyValue);

            structure.Type = StructureType.ByProperties;
            structure.Payload = "PropA,PropB";

            // Case 6
            // Dynamic Definition: 
            //      Folder: root
            //      Rule: Type equals Image
            //      Structure: AutoGen
            //          Lvl1: PropA
            //          Lvl2: PropB, hide empty 
            // Result: ./

            conditionSet.FolderId = "root";
            conditionSet.Add("Type", "eq", "Image");
            conditionSet.Add("PropB", "neq", Condition.EmptyValue);

            structure.Type = StructureType.ByProperties;
            structure.Payload = "PropA,PropB";

            // Case 7
            // Dynamic Definition: 
            //      Folder: root
            //      Rule: Type equals Image
            //      Structure: AutoGen
            //          Lvl1: PropA
            //          Lvl2: PropB, hide empty 
            // Result: ./PropA=A

            conditionSet.FolderId = "root";
            conditionSet.Add("Type", "eq", "Image");
            conditionSet.Add("PropB", "neq", Condition.EmptyValue);
            conditionSet.Add("PropA", "eq", "A");

            structure.Type = StructureType.ByProperties;
            structure.Payload = "PropB";
            structure.Depth = 1;

            // Case 7
            // Dynamic Definition: 
            //      Folder: root
            //      Rule: Type equals Image
            //      Structure: AutoGen
            //          Lvl1: PropA
            //          Lvl2: PropB, hide empty 
            // Result: ./PropA=A/PropB=B

            conditionSet.FolderId = "root";
            conditionSet.Add("Type", "eq", "Image");
            conditionSet.Add("PropB", "neq", Condition.EmptyValue);
            conditionSet.Add("PropA", "eq", "A");
            conditionSet.Add("PropB", "eq", "B");

            structure.Type = StructureType.None;


            var contents = engine.GetContents(conditionSet, structure);

        }

    }
}
