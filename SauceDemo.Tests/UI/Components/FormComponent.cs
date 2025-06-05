namespace SauceDemo.Tests.UI.Components
{
    using System.Collections.ObjectModel;

    public class FormComponent
    {
        public FormComponent(Dictionary<string, FormFieldComponent> fields)
        {
            Fields = new ReadOnlyDictionary<string, FormFieldComponent>(fields);
        }

        public IReadOnlyDictionary<string, FormFieldComponent> Fields { get; }

        public FormFieldComponent GetField(string fieldDisplayName)
        {
            if (!Fields.TryGetValue(fieldDisplayName, out var field))
            {
                var validFields = string.Join(", ", Fields.Keys.OrderBy(k => k));
                throw new ArgumentException(
                    $"Invalid field name: '{fieldDisplayName}'. Allowed values: {validFields}",
                    nameof(fieldDisplayName));
            }

            return field;
        }
    }
}