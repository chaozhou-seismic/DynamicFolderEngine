using System;

namespace DynamicFolderEngine
{
    public abstract class Engine
    {
        public Context Context { get; set; }

        protected Engine(Context context)
        {
            Context = context;
        }

        public static Engine Create(Context context, string source)
        {
            if (source == "database")
            {
                return new DatabaseEngine(context);
            }

            if (source == "search")
            {
                return new SearchEngine(context);
            }

            throw new ArgumentOutOfRangeException();
        }


        public Content GetContents(ConditionSet conditionSet, Structure strucure)
        {
            throw new System.NotImplementedException();
        }
    }
}