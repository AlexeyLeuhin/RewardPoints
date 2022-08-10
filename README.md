# RewardPoints

### App has 2 endpoints:
  1. api/RewardPoints, it will generate csv report with reward points for each customer and month
  2. /healthz, it is health endpoint and gives you a possibility to monitor wellness of the api.
                                                  
### In RewardPoints/wwwroot you can find all used static files: 
  1. Predefined csv tables with customers and transactions
  2. Logs file
 
### Result.csv is an example of generated report for current data set 

### Used libraries:
  1. CsvHelper - for reading and writing csv files
  2. Serilog - for looging to txt file
  3. MediatR - for implementing CQRS pattern
  
### Example dataset with results:
  ![image](https://user-images.githubusercontent.com/66141476/183966181-dd4836b7-a2bf-49bc-9a7a-8a4f7e832b04.png)

## Modules description:
 
  ### Exceptions handling:
    Implemented custom middleware ErrorWrappingMiddleware, that catches all the exceptions globally, sets special http response codes,
    logs information about errors to txt file. Added custom exception class StorageFileNotFoundException, that is thrown
    when csv storage tables could not be found.
  
  ### Logging:
    Used Serilog library. Added custom logger service, that incapsulates logging levels logic.
    Information is logged to txt file in wwwroot folder.
    
  ### Data loading:
    Implemented csv context service, that incapsulates data loading logic. Data is grabbed from csv predefined
    files by CsvHelper library.
    
  ### Points calculator:
    Moved calculation rules and logic to separate calculator service in order to have a possibility easily
    and independntly change the way of calculating reward points.
    
  ### Constants:
    All string constants moved to separate static Constants class in Shared module.
    
   
