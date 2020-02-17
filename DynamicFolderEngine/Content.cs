using System.Collections;
using System.Collections.Generic;

namespace DynamicFolderEngine
{
    public class Content
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Content> Children { get; set; }
    }
}