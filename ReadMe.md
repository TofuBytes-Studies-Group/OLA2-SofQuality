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
This project involves building a simple CRUD (Create, Read, Update, Delete) REST API, writing integration tests for the API and trying to ensuring at least 80% code coverage.

We didnt get to finish this project, because we used a lot of time on the basic setup of the project, and we had some issues with the testing of the API.
Therefore we only managed to implement swagger, we managed to make integration tests for the API, we managed to look a little bit into the code coverage and we managed to look into JMeter.

---

## Testing and Coverage
The things we managed to get done was:
- Creating CRUD REST api, with possibility of testing via Swagger.
- Creating integration tests for the API.
- Ensuring (close to) 80% code coverage using Rider built-in test coverage.
- Reflection

### Integration Tests
We created some different integration tests for the API, testing the different endpoints.
- **GetTasks_ReturnsListOfTasks:**
This test checks whether the GetTasks method correctly retrieves and returns a list of tasks. It mocks a list of two tasks and verifies that the result contains exactly two tasks.

- **GetTask_ReturnsTaskById:**
This test ensures that the GetTask method retrieves a task by its ID. It mocks a task with ID 1 and verifies that the controller returns the correct task when queried with the same ID.

- **AddTask_ReturnsCreatedTask:**
This test verifies that the AddTask method adds a new task and returns the created task. It mocks a new task, calls the AddTask method, and checks that the returned task has the expected ID.

- **UpdateTask_ReturnsUpdatedTask:**
This test checks whether the UpdateTask method successfully updates an existing task. It mocks an updated task and verifies that the controller returns the updated task with the correct description, category, and completion status.

- **DeleteTask_ReturnsNoContent:**
This test ensures that the DeleteTask method deletes a task successfully. It verifies that calling DeleteTask with an ID results in a NoContent response, indicating successful deletion.

- **GetTask_ReturnNotFound:**
This test checks the behavior of the GetTask method when a non-existent task is requested. It mocks a task with ID 1, but queries the controller with ID 2, verifying that the result is a NotFound response.

Each test uses mock objects (Mock<ITaskService>) to simulate the service behavior without needing a live database, ensuring the controller logic is isolated and tested independently.

### Code Coverage
![TestCoverage.png](Images%2FTestCoverage.png)

- Program (81%): The code in the Program section has good test coverage (81%), meaning most of it has been exercised by integration tests.
- Models and Controllers (100%): These sections are fully covered by tests, indicating that the behavior and structure of these components have been thoroughly tested.
- Repositories and Data (0%): These sections have no test coverage. This is because the data layer only has our ToDoListContext, which is our data acccess layer for the database. We did not have time to implement tests for this layer.

Overall, we could have implemented more test coverage, but since we had a hard time with this project, it was not something we had time to do. 

### JMeter Load Testing
![JMeterImg1.png](Images%2FJMeterImg1.png)
![JMeterImg2.png](Images%2FJMeterImg2.png)

This is what we got from the statistics:

#### Requests (Executions) 
- #Samples (500): This means that 500 requests were made during the test.
- FAIL (0): There were no failed requests. All requests were successful.
- Error % (0.00%): The percentage of errors is 0%, indicating that all requests were handled correctly.
- 
#### Response Times (ms) 
- Average (4.09 ms): This is the average time it took for the server to respond to the HTTP requests. A response time of 4.09 milliseconds is extremely fast.
- 99th pct (6 ms): 99% of the requests were completed within 6 milliseconds, showing that there are no major outliers in the response times.
- 
#### Throughput 
Transactions/s (17.99): The server handled approximately 18 requests per second. This is the rate at which the server processed the HTTP requests.

#### Network (KB/sec)
Received (9.54 KB/sec): The server received data at a rate of 9.54 KB per second.
Sent (4.52 KB/sec): The server sent data at a rate of 1.16 KB per second.

#### Summary: 
Error-free performance: The 0% error rate is perfect, indicating no issues with the requests.
Fast response times: With an average of 4.09 ms and a max of 31 ms, the system is responding extremely quickly.
Consistent performance: The response times are very consistent, with the 99th percentile still at just 6 ms.
Throughput: Handling nearly 18 transactions per second shows that the system can process a moderate load efficiently.
Overall, the test shows excellent system performance with low response times, high throughput, and no errors.


## Reflection
- Reflect on how you ensured code coverage.

We ensured code coverage, by making sure not to write too many functions that we could not test.

- Discuss the importance of balancing unit and integration testing.
- Summarize your API’s performance based on the load testing results.
- Identify areas where performance optimization may be needed.

This project was a struggle to us. We had a hard time setting it up, and every time we pushed something that worked, it wouldnt work on other computers.
We tried doing it as good as we could with the time we got, and we are happy with the result we got.
If we were to make this project again, we would make sure we had enough code coverage, since we only made it to 52% of the overall coverage.


## Deliverables
Ensure the following are included in your final submission:
1. Source code for the REST API.
2. Unit and integration tests.
3. Code coverage report (minimum 80%).
4. HTTP test scripts (or Postman collection).
5. Load test results and analysis.
6. Reflection document on testing coverage and performance benchmarking.
