# Assesment-RamMishra
 ### Step to run
- Set as startup project to Assessment-RaceTrack
- Run the application.
- Defualt page will open(Track/Index) page.
- Display S#, Name, Type,Photo in grid along with remove action.
- "Add New Vehicle On Track" link will disable, it will enable after deleting and vehicle from track.
- Remove action will remove the vehicle from grid and after referesh page(First time) gid will reflect with updated records.

------------



1. **Assessment-RaceTrack (Front-End)**
 - MVC Architecture
 - Created service class to communicate with repostiry.
  - Controller communicating with service class.
  - Created DTO in model folder.
  - Controller communicating with service class.
  - Created Unity container(App_Start/UnityConfig) to resolve dependecies.
2. **Assessment-RaceTrack.Core**
 - Created repostory classes.
 - Created generic repository classes inside Repository/Common folder.
  - Used UnitOfWork(Partialy).
  
3. **Assessment-RaceTrack.Data**
 - Created dbcontext classes.
 - Created DBInitializer class for codefirst db generation.
 
4. **Assessment-RaceTrack.Models**
 - Created shared model classes.
 
5. **Assessment-RaceTrack.Tests**
 - Created test cases of bussiness logics.
 - Implemented Mock for mocking the repostories.
 

------------


**Used Inheritence over Composition**
I have used inheritence because inheritence is more flexible to create instance of classes and also it is loosely coupled that's why easy to resolve the dependencies in project and easyly mock the object for unit tests
