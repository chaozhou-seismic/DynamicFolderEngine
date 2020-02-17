using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DynamicFolderEngine
{
    public class ConditionSet: Collection<Condition>
    {

        public string FolderId
        {
            get => GetFolderIdCondition()?.Value;
            set
            {
                var existCondition = GetFolderIdCondition();
                if (existCondition == null)
                {
                    Add(new Condition
                    {
                        Key = Condition.FolderIdKey,
                        Operator = "eq",
                        Value = value
                    });
                }
                else
                {
                    existCondition.Value = value;
                }
            }
        }

        public void Add(string key, string op, string value)
        {
            Add(new Condition
            {
                Key = key,
                Operator = op,
                Value = value
            });
        }

        private Condition GetFolderIdCondition()
        {
            return this.FirstOrDefault(c => c.Key == Condition.FolderIdKey);
        }

    }
}