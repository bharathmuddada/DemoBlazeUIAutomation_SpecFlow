Feature: DemoBlazeOrders

A short summary of the feature

Background: 

   Given I navigate to the demoblaze website
   And I login with "valid" credentials


Scenario: Validate Ordering Phone
	When I navigate to "Phones" menu and select "Samsung galaxy s6"
	And Product is added to cart
	And I place an order for the items in cart
	Then Confirmation should show the message "Thank you for your purchase!"


Scenario: Validate Ordering Laptop
	When I navigate to "Laptops" menu and select "Sony vaio i5"
	And Product is added to cart
	And I place an order for the items in cart
	Then Confirmation should show the message "Thank you for your purchase!"
