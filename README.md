![voyager](https://github.com/DimSoftwareWorks/Starknet.Voyager/assets/26678419/51dd5d43-a8b7-4e2a-b219-c039a5be982a)

**Starknet Voyager Explorer Http Client**

Based on Voyager API 0.1.0

<hr />

This is a .NET Http Client wrapper for the Starknet Voyager Explorer: https://voyager.online/

Voyager Explorer Docs: https://docs.voyager.online/

To use Voyager Explorer client an API key is needed.

You can request API key by going on their website: https://voyager.online/

Then click **Data**, then **Voyager API** from the menu, then you should fill the form that is required. (this is valid till last update)

<hr />

**Client Usage**

<hr />

Register as HttpClient and set Voyager Explorer base url: https://docs.voyager.online/#servers

```
services.AddHttpClient<IVoyagerExplorerHttpClient, VoyagerExplorerHttpClient>(client =>
{
    client.BaseAddress = new Uri("[VOYAGER_API_URL]");
});
```
