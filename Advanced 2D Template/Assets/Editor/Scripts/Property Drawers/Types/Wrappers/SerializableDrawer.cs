using UnityEditor;

namespace Types.Wrappers
{
    [CustomPropertyDrawer(typeof(Serializable<>))]
    internal class SerializableDrawer : Miscellaneous.PropertyDrawerBase
    {
        public override string[][] GetPropertyNames() => new string[][]
        {
            new string[] { "_value" },
            new string[] { "_directory" },
            new string[] { "_name" },
            new string[] { "_description" },
            new string[] { "_creationDate" },
            new string[] { "_lastEditedDate" },
            new string[] { "_id" },
            new string[] { "_madeByPlayer" },
            new string[] { "_iconOverride" },
            new string[] { "_previewOverride" },
            new string[] { "_filterTags" },
            new string[] { "_groupTags" }
        };
    }
}
