Feature: DemoBlazeMultipleOrders



Background: 

   Given I navigate to the demoblaze website
   And I login with "valid" credentials



Scenario: Validate Ordering Phones and Laptops
	When I navigate to "Phones" menu and select "Samsung galaxy s6"
	And Product is added to cart
	And I navigate to homepage
	And I navigate to "Laptops" menu and select "Sony vaio i5"
	And Product is added to cart
	Then product names in the cart should match the "Sony vaio i5,Samsung galaxy s6" 

Scenario: Validate the Price in the order confirmation

	When I navigate to "Phones" menu and select "Samsung galaxy s6"
	And Product is added to cart
	And I navigate to homepage
	And I navigate to "Laptops" menu and select "Sony vaio i5"
	And Product is added to cart
	And I place an order for the items in cart

	Then product names in the cart should match the "Sony vaio i5,Samsung galaxy s6" 
	And total price is equal to the order confirmation price