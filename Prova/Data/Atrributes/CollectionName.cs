//using System;
//namespace Prova.Data;

///// <summary>
///// Attribute used to annotate Enities with to override mongo collection name. By default, when this attribute
///// is not specified, the classname will be used.
///// </summary>
//[AttributeUsage(AttributeTargets.Class, Inherited = true)]
//public class CollectionNameAtributeTeste : Attribute
//{

//	/// <summary>
//	/// Initializes a new instance of the CollectionName class atribute with the desired name.
//	/// </summary>
//	/// <param name="value"></param>
//	/// <exception cref="ArgumentException"></exception>
//	public CollectionNameAtributeTeste(string value)
//	{
//		if (string.IsNullOrWhiteSpace(value))
//			throw new ArgumentException("Empty collectionname not allowed", nameof(value));

//		Name = value;
//	}

//	/// <summary>
//	/// Get the name of the collection
//	/// </summary>
//	/// <value>The name of the collection</value>
//	public virtual string Name { get; private set; }

//	/// <summary>
//	/// 
//	/// </summary>
//	/// <typeparam name="T"></typeparam>
//	/// <returns>Returns the collectionname for T.</returns>
//	/// <exception cref="ArgumentException"></exception>
//	public static string GetCollectionName<T>() where T : class
//	{
//		string collectionName;

//		if (typeof(T).BaseType.Equals(typeof(object)))
//		{
//			collectionName = GetCollectionNameFromInterface<T>();
//		}
//		else
//		{
//			collectionName = GetCollectionNameFromType(typeof(T));
//		}

//		if (string.IsNullOrEmpty(collectionName))
//		{
//			throw new ArgumentException("Collection name be empty for this entity");
//		}

//		return collectionName;
//	}

//	/// <summary>
//	/// 
//	/// </summary>
//	/// <typeparam name="T"></typeparam>
//	/// <returns>Returns the collectionname from the specified type.</returns>
//	private static string GetCollectionNameFromInterface<T>()
//	{
//		string collectionname;


//        //Check to see if the object (inherited from Entity) has a ColletionName attribute
//        var att = GetCustomAttribute(typeof(T), typeof(CollectionNameAtribute));

//		if (att != null)
//		{
//            //It does! Return the value specified by the CollectionName attribute
//            collectionname = ((CollectionNameAtribute)att).Name;
//		}
//		else
//		{
//			collectionname = typeof(T).Name;
//		}
//		return collectionname;
//	}



//	/// <summary>
//	/// 
//	/// </summary>
//	/// <param name="entitytype"></param>
//	/// <returns>Returns the collectionname from the specified type.</returns>
//	private static string GetCollectionNameFromType(Type entitytype)
//	{
//		string collectionname;

//		//Check to see if the object (inherited from Entity) has a ColletionName attribute

//		var att = GetCustomAttribute(entitytype, typeof(CollectionNameAtribute));
//		if (att != null)
//		{
//			//It does! Return the value specified by the CollectionName attribute
//			collectionname = ((CollectionNameAtribute)att).Name;
//		}
//		else
//		{
//			collectionname = entitytype.Name;
//		}

//		return collectionname;
//	}

//}

