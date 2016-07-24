///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace ORMFile.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal static class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass( (1 + 0));
			InitMessageEntityInfos();

			this.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits MessageEntity's FieldInfo objects</summary>
		private void InitMessageEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(MessageFieldIndex), "MessageEntity");
			this.AddElementFieldInfo("MessageEntity", "Active", typeof(System.Boolean), false, false, false, false,  (int)MessageFieldIndex.Active, 0, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "Id", typeof(System.Int32), true, false, false, false,  (int)MessageFieldIndex.Id, 0, 0, 10);
			this.AddElementFieldInfo("MessageEntity", "Message", typeof(System.String), false, false, false, false,  (int)MessageFieldIndex.Message, 1024, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "Tag", typeof(System.String), false, false, false, false,  (int)MessageFieldIndex.Tag, 16, 0, 0);
		}
		
	}
}




