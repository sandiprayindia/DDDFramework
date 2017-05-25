# Domain Driven Design Based Enterprise Application Framework

An opinionated Enterprise Application Framework based on different Patterns, Principles and Practices of Domain Driven Design.Although not all tactical and strategic Patterns, Principles and Practices of DDD are in place but the most important ones(the ones that are used almost in any Enterprise app) are in place.This being a Framework, any application specific stuff is not there and will never be there in the Core code.

This framework is also helpful in scenarios wherein one needs to interact with different Integration technologies using different .NET based access technologies(can be DBs, SOAP or RESTFUL Web Services or MQs or File Sysstem or an LDAP or any other imaginable data source).Another possible scenario can be in a CQRS(Command Query Responsibility Seggregation) environment wherein the commands are processed in an RDBMS like SQL Server whereas the queries are executed to fetch data from NOSQL DBs.Also, once this framework is completed and if someone uses this framework, atleast for the development of a SPA based Web Application or Website or a Mobile Web application, ideally he/or she should need to work only on Domain Modelling(i.e. mainly Domain,Domain Services and Application Services) and UI stuffs(there might be some requirement for extending some extensibility points which are already provided out of the box or creating new extensibility points all-together or some other configuration stuff changes required like DI container specific stuffs or ORM configurations if RDBMS is used etc).That doesn't mean that all these can be applied only for Web apps or Websites or Mobile Web Application only but in-fact, parts of this framework can be applied to Business Process Management and Integration projects as well.

DDD is more about domain modelling for complex domains using concepts of Entities,Value Objects, Aggregates etc and separating out your Business functionalities from your technical functionalities. Although this framework provides(or will provide) most of the technical functionalities(out of the box, including the source code) used in an Enterprise app and some base level classes for dealing with Entities,Value Objects, Aggregates etc but it's not necessary that one is going to need every bit of it. So use this framework(or may be just parts of the framework) deligently after analyzing the requirements for your app meticulously.

Implementation Overview->
Here the CommandRepository(for persisting data) and QueryableRepository(for querying data) are in-memory representation of some external source - mainly DBs(but can be extended to Web Services or MQ interactions as well or any other imaginable data source for that matter).
The CommandRepository class needs instances of concrete implementation of BaseUnitOfWork and ICommand which can be injected using some DI Framework like Unity.

UnitOfWork (implements IUnitOfWork members) - De-couples the logic to do atomic transactions across Dbs(can be extended to use Web Services/MQs or some other data source as well to be part of the Transaction) using different DB access technologies(again can be extended to use Web Service/MQs or any other data source). UnitOfWork based transactions can be applied at the API or Domain Services or Repository layer.

ICommand & IQuery- Provides contracts to deal with different DB technologies viz. ADO.NET,Enterprise Library or ORMs like Entity FrameWork Code First etc and different DBs(current implementation supports mainly SQL Server - but as mentioned eralier also, can be extended to support other DB types as well).

N.B.-> If one wants to think of any imaginable data source as Repository then atleast for the query side it's better to have a IQueryable provider for the same(atleast to use this framework seamlessly). For an exhaustive list of open source IQueryable providers, one can visit [Linq to Everything](https://blogs.msdn.microsoft.com/charlie/2008/02/28/link-to-everything-a-list-of-linq-providers/) (well, it's almost EVERYTHING).If some imaginable data source is not mentioned in the afore-mentioned list then one can build his/her own IQueryable provider and hopefully the articles viz. [LINQ: Building an IQueryable provider series](https://blogs.msdn.microsoft.com/mattwar/2008/11/18/linq-building-an-iqueryable-provider-series/), [Building Custom LINQ Enabled Data Providers](https://blogs.msdn.microsoft.com/tommer/2007/04/20/building-custom-linq-enabled-data-providers-using-iqueryablet/), [Creating LINQToTwitter library using LinqExtender](http://weblogs.asp.net/mehfuzh/creating-linqtotwitter-library-using-linqextender) and [Writing A Custom LINQ Provider With Re-linq](http://fairwaytech.com/2013/03/writing-a-custom-linq-provider-with-re-linq/) can be helpful in doing the same.And if anyone builds any LINQ to Something(or "Anything") provider, then please don't forget to share it with the world.

Pending Tasks ->

• Incorporation of some tactical DDD stuffs(mainly the common framework elements).

• Trying exploring and incorporating Dapper(a Micro-ORM - Micro ORMs may not provide you some functionalities like UnitOfWork out of the box like that of an ORM but performance wise they are way better compared to ORMs), Event Stores and Grid Based Storage.

• Incorporation of some Restful stuffs which are commonly used in most Enterprise Apps.

• Whatever done till now is all Orchestrations rather than Event Driven Choreographies.Even the async await based request reply
  mechanisms are also actually Orchestrations. True Fire and Forget Event Driven Choreographies(may be with some nominal acknowledgement   sent to the requester) following Eventually Consistent approach  WILL ALSO BE TRIED, at the Web API Layer using "Event Driven Rest"     and at the Business Layer using [Zero  MQ](http://zeromq.org/).[Zero  MQ](http://zeromq.org/) was designed from the ground up, keeping   in mind stock trading apps wherein very high throughput and very low latency are required, as discussed
  [here](http://aosabook.org/en/zeromq.html).         
  N.B. -> One can refer the paper - [Your Coffe Shop Doesn't use 2 phase commit](http://www.enterpriseintegrationpatterns.com/docs/IEEE_Software_Design_2PC.pdf) (written by the Integration genius - Gregor  Hohpe, co-   author of the Integration Bible viz. [Enterprise Integration Patterns](http://www.enterpriseintegrationpatterns.com/)) to see how apps   can be implemented without using Transactional Consistency.

• Testing BulkOperations using SQL Express Edition.

• Fixing WCF related Unit Test Case(s).

• Redesign Caching stuffs to support in-memory caching or some scalable option like Windows AppFabric or Redis(a scalable NOSQL
  option). Ideally, should be designed in a pluggable way to support any cool Caching mechanism coming in future as well.Also should use   some AOP or attribute(annotation) based approach to apply Caching or invalidating the Cache else it becomes very hectic to apply these   cross cutting concerns everywhere within a large application.

• Exploring Single Page Applications and building a Fluent UI Framework using which the UI layout(HTML + CSS) and UI  
  Behaviours(using Javascript) can be coded in a fluent way using Javascript.IF POSSIBLE, will try to have plugin features wherein SPA     Frameworks like Angular or React can be plugged in as and when required.Will also try to incorporate Offline-First capabilities.All     these probably will have a Github Project of its own and that will be used in this project.This is going to take quite some time since   lots of exploration needs to be done in this area.

• Ultimately building a SAAS Framework based on all the above stuffs.

• Fixing or suppressing the Warnings generated by MS Code Analysis Tool (currently, Code Analysis Settings is set to "Microsoft
  Basic Design Guidelines").

• Also need to Run the Code Metrics to check everything is as per standards.
