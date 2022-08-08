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
