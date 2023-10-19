# InteractiveAutoSample
A short sample trying to use InteractiveAuto and prepare it for both InteractiveServer and InteractiveWebAssembly modes

The project should build and run for .NET 8 RC2.  It runs because the WebScrape sample component is not being used on the Home page.

The WebScrape component wants to call back to the server's exposed endpoint so it can make the call out to the internet.  While not shown in this sample, it is presumed that Client project components must assume they have little protection against snooping into code so this could just as easily be a sensitive call to a back end api with authorization required.  Perhaps we look for a Backend For Frontend approach where the Blazor app calls back into the same server with the crucial authentication information in a strict https cookie, and then the server is capable of making the authenticated requests on its behalf.

Uncomment the following in AutoRenderModeServices\AutoRenderModeServices.Client\Pages\Home.razor

`@* <WebScrape></WebScrape> *@`

And now the app should break complaining that the URL is invalid without a base address.

