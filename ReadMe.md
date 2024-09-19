# Task Service with Testing, Code Analysis, and Reviews

## Objective
Refine the **Task Service** with a focus on testing, static code analysis, and peer reviews. Apply code and software review principles to ensure quality, covering both automated and manual review processes.

---

## Instructions

### 1. Task Service Refinement
- Implement Task CRUD operations:
    - **Create, Read, Update, Delete** tasks.
    - Enforce business rules (e.g., task title must not be empty, task description must have a minimum length).
- Prioritize clean, readable, and efficient code.

### 2. Unit Testing with Mocking
- Use mocking frameworks (Moq for C#) to isolate external dependencies.
- Write unit tests for core business logic.
- Aim for **75% code coverage**.

### 3. Test Design
- Use **Equivalence Partitioning** and **Boundary Value Analysis**:
    - Test min/max task title lengths.
    - Test valid/invalid task states (e.g., active, completed).
- Implement these test cases and include them in your reports.

### 1., 2. and 3: Refine Task Service, Unit testing and test design
- We made sure to refine our code, and made unit tests for our validator part. We also made sure to use Equivalence Partitioning and Boundary Value Analysis for our tests.
Our unit tests are made based on this data:
- Description length:
  - Valid, too short, too long ( minimum 5, maximum 255)
  - Boundary value: 4-5, 255-256
- Category length:
  - Valid, too short, too long ( minimum 2, maximum 50)
  - Boundary value: 1-2, 50-51
- Deadline:
  - Valid, invalid ( minimum datetime now -1 min, maximum datetime is as long as the calendar can show)
  - Boundary value: now to 1 min ago, now to 1 min in the future

In our Validator.cs file and ValidatorTest.cs, the validator is tested with the above data.

### 4. Static Code Analysis (PMD or FxCop)
- Integrate **PMD** (Java) or **FxCop** (C#) into your build process.
- Fix at least **three critical issues** identified by the static code analyzer.
- Submit the report and the corrected code.

### 5. Code Coverage (JaCoCo or Coverlet)
- Use **JaCoCo** (Java) or **Coverlet** (C#) for code coverage.
- Ensure at least **75% code coverage**.
- Submit the coverage report.

### 6. Optional: Code Quality with SonarQube
- If possible, integrate **SonarQube** for deeper code analysis.
- Address and fix at least **three major issues** detected.
- Submit the SonarQube report (optional).

### 7. Peer Code Review
- Conduct a **code review** with a peer based on principles from the [Code Review](https://en.wikipedia.org/wiki/Code_review) article.
- Focus on:
    - Code readability and maintainability.
    - Adherence to coding standards.
    - Correct use of mocks in tests.
    - Identification of potential bugs.
- Submit written feedback and any suggested code changes.

### 8. Software Review
- Perform a **Software Review** based on the [Software Review](https://en.wikipedia.org/wiki/Software_review) article:
    - Functional correctness: Does the code do what it is supposed to do?
    - Non-functional aspects (performance, maintainability, etc.).
    - Best practices (code structure, documentation).
- Submit a **300-word report** reflecting on your findings and improvements.

We made sure that our software was correct, and that it was easy to maintain. We also made sure that the code was structured in a way that was easy to understand, and that the documentation was clear and concise.
The code was made to do what it was supposed to do, and if there were anything that were 'too much' or 'too little', we made sure to fix it.

### 9. Reflection on Testing and Code Quality
- Write a **300-400 word reflection** on:
    - Impact of static code analysis tools (PMD, JaCoCo).
    - Importance of mocking in unit testing.
    - Value of code and software reviews.
    - Influence of Equivalence Partitioning and Boundary Value Analysis on test design.
- Discuss how these practices helped in identifying and fixing issues early.

Impact of static code analysis tools:
- We implemented Qodana, which is a static code analysis tool. This tool helped us identify issues, redundant code or unused code, and helped us fix them before they became a problem.

Value of code and software reviews:
- Specifically software reviews, helped us understand the importance of teamwork. Sometimes we are too focused on the small things we need to do, without looking at the rest of the code. This is where software reviews come in, and help us see the bigger picture.
  - For example: We made the validator tests 3 different ways in the beginning. With the help of code reviews, we could see what the others had made, and made sure that it was similar.

Influence of Equivalence Partitioning and Boundary Value Analysis on test design:

---

## Deliverables
- Refined Task Service source code.
- Unit tests with mocks.
- PMD (or FxCop) report.
- JaCoCo (or Coverlet) code coverage report.
- Peer review feedback and any code changes.
- Software review reflection.
- Optional: SonarQube report.

---

## Project Summary
- **Task Service API**: A CRUD API for managing tasks with emphasis on testability and code quality.
- **Key Focus**:
    - Mocking for isolating business logic.
    - Static code analysis for early identification of issues.
    - Code and software reviews for ensuring overall quality.
    - Comprehensive testing with Equivalence Partitioning and Boundary Value Analysis.

---

## Tools and Technologies
- **Languages**: Java/C# (or equivalent).
- **Mocking**: Mockito, EasyMock (Java), or Moq (C#).
- **Static Code Analysis**: PMD (Java) or FxCop (C#).
- **Code Coverage**: JaCoCo (Java) or Coverlet (C#).
- **Optional**: SonarQube for deeper code quality analysis.
