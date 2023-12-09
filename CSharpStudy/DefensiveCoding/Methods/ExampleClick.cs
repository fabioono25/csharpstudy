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
            var payment = new Payment();

            var orderController = new OrderController();

            //named arguments
            orderController.PlaceOrder(customer, order, payment, emailReceipt: false, allowSplitOrders: true);
        }
    }
}
