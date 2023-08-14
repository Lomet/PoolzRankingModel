# Poolz Ranking Model

Welcome to the Poolz Ranking Model repository! This model is designed to calculate allocations for Poolz Finance based on a unique blend of linear and rank-based calculations. Developed after two years of observations and trials, this model ensures a fair distribution of allocations while promoting a healthy and growing ecosystem.

## Core Principle

The foundational rule of this model is: **The more points you accumulate, the larger share of the total pool you receive.** This principle ensures that active and contributing users are rewarded appropriately. However, to ensure that smaller amounts of points remain significant and to encourage new users, the model combines linear and rank-based calculations. The flexibility in settings allows for fine-tuning how allocations are split, ensuring adaptability to different scenarios.

## Solution Structure

- **PoolzRanking**: The main project containing the ranking model logic, developed using C#.
- **TestPoolzRanking**: A test project to validate and ensure the correctness of the ranking model.

## Key Features

1. **Linear and Rank-based Allocation**: While the base rule emphasizes the importance of points, only 50% of the allocation is determined linearly based on these points. The other 50% is influenced by the user's rank.
2. **Multipliers**: The model incorporates two multipliers available in the settings. These multipliers allow for setting a delta for each section of the list, offering adaptability in allocation distribution.
3. **Handling Ties**: In scenarios where two or more users have the same number of points, they are awarded the average allocation, ensuring fairness.
4. **Random Winners**: To further promote inclusivity, a subset of users is selected randomly and assigned a specified allocation.
5. **CSV Export**: For ease of analysis and sharing, especially with tools like Excel, results can be exported in CSV format.

## Testing

The solution includes a comprehensive set of tests to validate the core functionality and edge cases of the ranking model. These tests ensure the reliability and accuracy of the allocation calculations.

## Feedback and Contributions

Your feedback is invaluable! Feel free to raise issues if you find any bugs or have suggestions for improvements. Contributions to enhance the model are always welcome!
