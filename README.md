# Fawry E-Commerce Challenge 🛒

Hey there!  
This project is a simple C# console app I built for the **Fawry Full Stack Internship Challenge**.

It simulates a basic e-commerce system where:
- You can define different types of products (some expire, some need shipping).
- A customer can add products to their cart.
- The system handles things like stock checking, expiry, and shipping calculations.
- A checkout receipt and shipping notice are printed in the console.

---

## Project Structure

To keep things organized, I split the project into two main folders:

- `Models`: Contains all the core classes like `Product`, `Cart`, `Customer`, and different product types.  
  I also created an `IShippable` interface to mark products that require shipping.

- `Services`: Holds the logic for checkout and shipping.  
  `CheckoutService` handles payments, totals, and customer balance, while `ShippingService` prints the shipment details.

Everything is cleanly separated to follow good object-oriented design.

---

Thanks for checking it out!  
— Ziad Ghoraba
