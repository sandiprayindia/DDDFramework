﻿Will mainly have components that might be re-usable across the Web API Pipeline or OWIN Katana & 
IIS Servers etc.One such example is that if you want to inject some functionality within the 
ASP.NET Web API pipeline then you have have 3 options viz. ->
1) OWINMiddleware ->to be used when the functionality needs to be applied for not only Web APIs 
                    but also ASP.NET MVCs or ASP.NET Web Forms.
2) DelegatingHandler -> to be used when the functionality needs to be applied across anywhere 
                        within ASP.NET Web API e.g. across all the controllers.
3) ActionFilter-> to be used when the functionality needs to be applied to certain controller or
                  some specific Action Methods of some controller.

In all the above cases, the underlying logic for the functionality is the same and so as per the
DRY principle, should be seperated out into a seperate container all-together and re-used 
wherever required.And that container in this case is this Project Library which ideally should 
not limit to ASP.NET Web APIs only but rather can extend to any ASP.NET module (be it Web API 
or MVC or Web Forms).

Also its better to opt for Delegating Handlers compared to Global Filters since Delegating 
Handlers comes into action before Global Filters within the ASP.NET Web API pipeline and if 
some data needs to be filtered and then the request needs to be rejected based on some 
criteria then the sooner you do that the better it is, from performance(response time) 
perspective.
