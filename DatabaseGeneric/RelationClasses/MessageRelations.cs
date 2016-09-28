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
using System.Collections;
using System.Collections.Generic;
using ORMFile;
using ORMFile.FactoryClasses;
using ORMFile.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace ORMFile.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: Message. </summary>
	public partial class MessageRelations
	{
		/// <summary>CTor</summary>
		public MessageRelations()
		{
		}

		/// <summary>Gets all relations of the MessageEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticMessageRelations
	{

		/// <summary>CTor</summary>
		static StaticMessageRelations()
		{
		}
	}
}
