﻿using Microsoft.EntityFrameworkCore;
using Petshop.Contract.Orders;
using Petshop.Core.Orders;
using Petshop.Infra.Common;

namespace Petshop.Infra.Orders;

public class EFOrderRepository : OrderRepository
{
	private readonly BentiShopContext dbContext;

	public EFOrderRepository(BentiShopContext dbContext)
	{
		this.dbContext = dbContext;
	}



	public Order GetOrder(int id)
	{
		var order = dbContext.Orders.Include(o => o.OrdersInfo)
			.ThenInclude(p => p.Product)
			.FirstOrDefault(order => order.Id == id);
		return order;
	}



	public Order GetPaymentOrder(int orderId)
	{
		var order = dbContext.Orders.Include(p => p.PaymentOrder)
			.Include(o => o.OrdersInfo)
			.ThenInclude(p => p.Product)
		.FirstOrDefault(order => order.Id == orderId);
		return order;
	}

	public List<Order> GetUnsendOrders()
	{
		List<Order> orders = dbContext.Orders
			.Include(payment => payment.PaymentOrder)
			.Where(shiped => shiped.PaymentOrder.Shipped == false).Include(orderinfo=>orderinfo.OrdersInfo).ThenInclude(product=>product.Product).Where(o=>o.OrdersInfo != null).ToList();
		
		return orders;

	}
	public  void AddOrder(Order order)
	{
		 dbContext.Orders.Add(order);
		 dbContext.SaveChanges();
	}


	public  void UpdateOrder(Order order)
	{
		var currentOrder = dbContext.Orders.FirstOrDefault(c => c.Id == order.Id);
		 dbContext.AttachRange(currentOrder.OrdersInfo.Select(products => products.Product));
		dbContext.Orders.Update(currentOrder);
		dbContext.SaveChanges();
	}

	public void SetPaymentDone(string FactorNumber, string TransId)
	{
		var order = dbContext.Orders.Include(z => z.PaymentOrder).FirstOrDefault(o => o.Id == int.Parse(FactorNumber));
		var payment = dbContext.Orders.SingleOrDefault
			(c => c.PaymentOrder.Id == order.PaymentOrder.Id);
		;
		if (order != null)
		{

			payment.PaymentOrder.PaymentCode = TransId;
			payment.PaymentOrder.PaymentDate = DateTime.Now;


			dbContext.SaveChanges();
		}
	}



	void OrderRepository.SetTransactionId(int id, string token, int paymentId)
	{
		var order = dbContext.Orders.FirstOrDefault(order => order.Id == id && order.PaymentOrder.Id == paymentId);
		if (order != null)
		{
			order.PaymentOrder.PaymentCode = token;
			order.PaymentOrder.PaymentDate = DateTime.Now;


			dbContext.SaveChanges();
		}
	}



	
}
