using CSharpStudy.DefensiveCoding.Methods.Core.Common;

namespace CSharpStudy.DefensiveCoding.Methods
{
    //provide operations for ordering process
    //clear purpose, good name, focused code, short length, automated code test, predictable result
    public class OrderController
    {
        public OrderController()
        {
            this.customerRepository = new CustomerRepository();
            this.orderRepository = new OrderRepository();
            this.inventoryRepository = new InventoryRepository();
            this.emailLibrary = new EmailLibrary();
        }

        private CustomerRepository customerRepository { get; set; }
        private OrderRepository orderRepository { get; set; }
        private InventoryRepository inventoryRepository { get; set; }
        private EmailLibrary emailLibrary { get; set; }

        public void PlaceOrder(Customer customer,
                                Order order,
                                Payment payment,
                                bool emailReceipt,
                                bool allowSplitOrders)
        {
            var customerRepository = new CustomerRepository();
            customerRepository.Add(customer);

            var orderRepository = new OrderRepository();
            orderRepository.Add(order);

            var inventoryRepository = new InventoryRepository();
            inventoryRepository.OrderItems(order, allowSplitOrders);

            payment.ProcessPayment();

            if (emailReceipt)
            {
                customer.ValidateEmail();
                customerRepository.Update();

                var emailLibrary = new EmailLibrary();
                emailLibrary.SendEmail(customer.EmailAddress, "here is your receipt");
            }
        }
    }
}
