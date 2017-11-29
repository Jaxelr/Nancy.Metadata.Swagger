# Introduction

Nancy.Metadata.Swagger is a library that makes it easier to create API documentation for swagger (http://swagger.io/) with Nancy metadata modules.

## Dependencies

Nancy.Metadata.Swagger uses Json.NET (http://www.newtonsoft.com/json) to generate documentation and Json.NET Schema (http://www.newtonsoft.com/jsonschema) to generate objects schema (you may need license key for it if you want to generate objects schema)
Also it uses some of Nancy stuff, so it should be installed to.

# Gettings started

First you need to install Nancy.Metadata.Swagger and Nancy.Metadata.Modules nuget packages by:

	PM> Install-Package Nancy.Metadata.Swagger
	PM> Install-Package Nancy.Metadata.Modules

Now you can add metadata module and describe your methods:

Example module:

```c#
public class RootModule : NancyModule
{
	public RootModule() : base("/api")
	{
	    Get["SimpleRequestWithParameter", "/hello/{name}"] = r => Hello(r.name);
	}
}
```
Example metadata module (for ``%modulename%Module`` it should be named ``%modulename%MetadataModule``):
**IMPORTANT: Metadata module file should be placed in the same folder (namespace) with module**

```c#
     public class RootMetadataModule : MetadataModule<SwaggerRouteMetadata>
    {
        public RootMetadataModule()
        {
            Describe["SimpleRequestWithParameter"] = desc => new SwaggerRouteMetadata(desc)
                .With(i => i.WithResponseModel("200", typeof(SimpleResponseModel), "Sample response")
                            .WithRequestParameter("name"));
        }
    }
```

## Adding docs module

You also need to create one additional module that will return you json documentation. Here is the sample:

```c#
    public class DocsModule : SwaggerDocsModuleBase
    {
        public DocsModule(IRouteCacheProvider routeCacheProvider) 
        	: base(routeCacheProvider, 
        	  "/api/docs", 					// where module should be located
        	  "Sample API documentation",   // title
        	  "v1.0", 						// api version
        	  "localhost:5000",             // host
        	  "/api", 						// api base url (ie /dev, /api)
        	  "http")						// schemes
        {
        }
    }
```

## Adding swagger UI:

Now you are able to add swagger UI (you can download it from http://swagger.io/swagger-ui/) and point it to your docs module.
In index.html file you can set default url where ui should get json documentation file.
