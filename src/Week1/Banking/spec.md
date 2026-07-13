# Banking

We are going into the banking business!

## Narrative

Customers will have accounts. They will be able to get their balance, make deposits, and make withdrawals. Each customer will have an Account ID that will be assigned to them when they sign up at the bank (still working on this process).

## Requirements

For now, we'll assume each account is "brand new" (we'll worry about looking up accounts later).

### Opening Balance

Each new account should have the correct opening balance.

(state-based testing, but can be adapted to interaction testing)
Given we have a brand new account
When we retrieve the balance
Then it provides $5000

### Deposits

Customers can deposit money into their account. Deposits increase the balance.

Given I have a new account
When I deposit $112.00
Then the balance should be $5112.00

### Making Withdrawals

Customers can withdraw money from their account and this will reduce their balance. 

> Note: We do not allow overdraft.

## Work In Process

- Storing and retreiving accounts in the database
- Customer Loyalty: "Gold Accounts"
