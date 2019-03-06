namespace CSharpStudy.DefensiveCoding.Methods
{
    public class ExampleClick
    {
        private object emailLibrary;

        public void RunExample()
        {
            PlaceOrder();
        }

        private static void PlaceOrder()
        {
            var customer = new Customer();
            //populate the customer instance

            var order = new Order();
            //populate order

            var emailReceipt = true;
            var payment = new Payment();
            //populate payment info

            var allowSplitOrders = true;

            var orderController = new OrderController();

            //named arguments
            orderController.PlaceOrder(customer, order, payment, emailReceipt: false, allowSplitOrders: true);
        }
    }
}
