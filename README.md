# SerializableEx

This product was originally published [here](http://www.codeproject.com/KB/dotnet/SerializableExtraTypes.aspx) in 2008 and the technology has been in use in production environments for 4+ years.  Current publication is located [here](http://www.codeproject.com/KB/dotnet/SerializableExtraTypeNet4.aspx).

It comes in 2 flavors right now, NET2 which also supports NET3.5.  It is fairly solid but has a known issue of not picking up dlls in web/bin folders if they are not directly used in the code base or "on demand" load of the dll is used in IIS.  The NET4 version of this fixes this issue in the same manner that MVC does this.

This code base is very useful for creating modular frameworks based on inheritance.  It can be used for construction of object based configuration and extensibility.  It was originally developed to support a robust extensible reporting solution and is still used in it to this day.
