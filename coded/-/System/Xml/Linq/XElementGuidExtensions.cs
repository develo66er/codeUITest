namespace System.Xml.Linq
{
	internal static class XElementGuidExtensions
	{
		/// <summary>
		/// Gets the value of the attribute as a GUID.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <returns></returns>
		public static Guid AttributeValueAsGuid(this XElement element, XName attributeName)
		{
			XAttribute attribute = element.Attribute(attributeName);
			if (attribute == null)
			{
				string message = String.Format("The required attribute '{0}' was not found on '{1}'.", attributeName, element.Name);
				throw new XmlException(message);
			}
			return attribute.Value.ToGuid();
		}

		/// <summary>
		/// Gets the value of the attribute as a GUID, or the default value if the attribute is missing.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns></returns>
		public static Guid AttributeValueAsGuid(this XElement element, XName attributeName, Guid defaultValue)
		{
			XAttribute attribute = element.Attribute(attributeName);
			return attribute == null ? defaultValue : attribute.Value.ToGuid();
		}

		/// <summary>
		/// Gets the value of an XElement as a GUID.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <returns></returns>
		public static Guid ValueAsGuid(this XElement element)
		{
			return element.Value.ToGuid();
		}
	}
}