///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 4.1
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace ORMFile.DatabaseSpecific
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal static class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass(1);
			InitMessageEntityMappings();
		}

		/// <summary>Inits MessageEntity's mappings</summary>
		private void InitMessageEntityMappings()
		{
			this.AddElementMapping("MessageEntity", @"Agile", @"dbo", "Message", 4);
			this.AddElementFieldMapping("MessageEntity", "Active", "Active", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 0);
			this.AddElementFieldMapping("MessageEntity", "Id", "Id", false, "Int", 0, 10, 0, false, "", null, typeof(System.Int32), 1);
			this.AddElementFieldMapping("MessageEntity", "Message", "Message", false, "VarChar", 1024, 0, 0, false, "", null, typeof(System.String), 2);
			this.AddElementFieldMapping("MessageEntity", "Tag", "Tag", false, "VarChar", 16, 0, 0, false, "", null, typeof(System.String), 3);
		}

	}
}
