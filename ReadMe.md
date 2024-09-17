# OLA2: API Testing, Coverage, and Benchmarking
 - Group: **TofuBytes**
 - Members: **Isak, Jamie & Helena**
## Objective
The goal of this assignment is to build a simple REST API, implement tests for its endpoints, ensure sufficient code coverage, and conduct basic performance benchmarking using tools like HTTP files, REST clients, and JMeter (or similar tools).

---

## Table of Contents
1. [Overview](#overview)
2. [Testing and Coverage](#testing-and-coverage)
    - [Integration Tests](#integration-tests)
    - [Code Coverage](#code-coverage)
3. [JMeter Load Testing](#load-testing)
4. [Reflection](#reflection)

---

## Overview
This project involves building a simple CRUD (Create, Read, Update, Delete) REST API, writing integration tests for the API and try to ensure at least 80% code coverage.

We didnt get to finish this project, because we used a lot of time on the basic setup of the project, and we had some issues with the testing of the API.
Therefore we only managed to implement swagger, we managed to make integration tests for the API, we managed to look a little bit into the code coverage and we managed to look into JMeter.

---

## Testing and Coverage

### Integration Tests

We created various integration tests for the API, covering different endpoints:

- GetTasks_ReturnsListOfTasks: 
This test verifies that the GetTasks method retrieves and returns a list of tasks. It sets up two tasks and checks that the response contains exactly two tasks.

- GetTask_ReturnsTaskById: 
This test ensures the GetTask method retrieves a specific task by its ID. It creates a task with ID 1 and checks that the correct task is returned when queried with the same ID.

- AddTask_ReturnsCreatedTask: 
This test verifies that the AddTask method adds a new task and returns the created task. It sets up a new task and checks that the returned task has the expected ID.

- UpdateTask_ReturnsUpdatedTask:  
This test checks if the UpdateTask method successfully updates an existing task. It updates the task's description, category, and completion status, and verifies that the correct updated task is returned.

- DeleteTask_ReturnsNoContent:  
This test ensures that the DeleteTask method successfully deletes a task. It checks that calling DeleteTask with an ID results in a NoContent response, indicating successful deletion.

- GetTask_ReturnsNotFound:  
This test checks the behavior of the GetTask method when a task that doesn't exist is requested. It creates a task with ID 1 but queries for ID 2, ensuring the response is NotFound.

Each test uses a simulated version of the ITaskService to test the controller logic in isolation, without needing a live database.


### Code Coverage
![TestCoverage.png](Images%2FTestCoverage.png)

- Program (81%): The code in the Program section has good test coverage (81%), meaning most of it has been exercised by integration tests.
- Models and Controllers (100%): These sections are fully covered by tests, indicating that the behavior and structure of these components have been thoroughly tested.
- Repositories and Data (0%): These sections have no test coverage. This is because the data layer only has our ToDoListContext, which is our data acccess layer for the database. We did not have time to implement tests for this layer.

Overall, we could have implemented more test to make sure we had enough code coverage, but since we had a hard time with this project, it was not something we had time to do. 

### JMeter Load Testing
![JMeterImg1.png](Images%2FJMeterImg1.png)
![JMeterImg2.png](Images%2FJMeterImg2.png)

This is what we got from the statistics:

#### Requests (Executions) 
- #Samples (500): This means that 500 requests were made during the test.
- FAIL (0): There were no failed requests. All requests were successful.
- Error % (0.00%): The percentage of errors is 0%, indicating that all requests were handled correctly.

#### Response Times (ms) 
- Average (4.09 ms): This is the average time it took for the server to respond to the HTTP requests. A response time of 4.09 milliseconds is extremely fast.
- 99th pct (6 ms): 99% of the requests were completed within 6 milliseconds, showing that there are no major outliers in the response times.

#### Throughput 
Transactions/s (17.99): The server handled approximately 18 requests per second. This is the rate at which the server processed the HTTP requests.

#### Network (KB/sec)
- Received (9.54 KB/sec): The server received data at a rate of 9.54 KB per second.
- Sent (4.52 KB/sec): The server sent data at a rate of 1.16 KB per second.

#### Summary: 
Error-free performance: The 0% error rate is perfect, indicating no issues with the requests.
Fast response times: With an average of 4.09 ms and a max of 31 ms, the system is responding extremely quickly.
Consistent performance: The response times are very consistent, with the 99th percentile still at just 6 ms.
Throughput: Handling nearly 18 transactions per second shows that the system can process a moderate load efficiently.
Overall, the test shows excellent system performance with low response times, high throughput, and no errors.


## Reflection
We didn't satisfy all the assignments criteria (or requirements) within the assigned timeslot and in order to still reach the deadline we focused on working with the tools and gathering an understanding for future projects.
If we were to make this project again, we would make sure we had enough code coverage, since we only made it to 52% of the overall coverage, and make sure to meet all the requirements.

