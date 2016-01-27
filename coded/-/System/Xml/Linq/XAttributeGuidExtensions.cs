namespace System.Xml.Linq
{
	internal static class XAttributeGuidExtensions
	{
		/// <summary>
		/// Gets the value of the attribute as a Guid.
		/// </summary>
		/// <param name="attribute">The attribute.</param>
		/// <returns></returns>
		public static Guid AsGuid(this XAttribute attribute)
		{
			return attribute.Value.ToGuid();
		}
	}
}