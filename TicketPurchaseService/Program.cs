using TicketsPurchaseService.Data;
using TicketsPurchaseService.Data.Entites;

using (TicketsPurchaseServiceDbContext _context = new TicketsPurchaseServiceDbContext())
{
    //Add Flights
    var flight1 = new Flight(Cities.Moscow, Cities.Warsaw, DateTime.Now);
    var flight2 = new Flight(Cities.Prague, Cities.Berlin, DateTime.Now);
    var flight3 = new Flight(Cities.Paris, Cities.London, DateTime.Now);
    var flight4 = new Flight(Cities.Rome, Cities.Athens, DateTime.Now);
    var flight5 = new Flight(Cities.Athens, Cities.Moscow, DateTime.Now);

    _context.Flights.AddRange(flight1, flight2, flight3, flight4, flight5);

    //Add Users
    var user1 = new User("Ivan");
    var user2 = new User("Alexander");
    var user3 = new User("Daniel");
    var user4 = new User("Peter");
    var user5 = new User("Leonid");

    _context.Users.AddRange(user1, user2, user3, user4, user5);

    //Add Purchases
    var purchase1 = new Purchase { User = user1 };
    var purchase2 = new Purchase { User = user2 };
    var purchase3 = new Purchase { User = user3 };
    var purchase4 = new Purchase { User = user4 };
    var purchase5 = new Purchase { User = user5 };

    _context.Purchases.AddRange(purchase1, purchase2, purchase3, purchase4, purchase5);

    //Add Tickets
    var ticket1 = new Ticket { PassengerName = "Ivan", Flight = flight1, Purchase = purchase1 };
    var ticket2 = new Ticket { PassengerName = "Alexander", Flight = flight1, Purchase = purchase1 };
    var ticket3 = new Ticket { PassengerName = "Daniel", Flight = flight2, Purchase = purchase2 };
    var ticket4 = new Ticket { PassengerName = "Peter", Flight = flight2, Purchase = purchase2 };
    var ticket5 = new Ticket { PassengerName = "Leonid", Flight = flight3, Purchase = purchase3 };
    var ticket6 = new Ticket { PassengerName = "Paul", Flight = flight3, Purchase = purchase3 };
    var ticket7 = new Ticket { PassengerName = "Max", Flight = flight4, Purchase = purchase4 };
    var ticket8 = new Ticket { PassengerName = "Mark", Flight = flight4, Purchase = purchase4 };
    var ticket9 = new Ticket { PassengerName = "Korney", Flight = flight5, Purchase = purchase5 };
    var ticket10 = new Ticket { PassengerName = "John", Flight = flight5, Purchase = purchase5 };

    ticket1.Sell();
    ticket3.Sell();
    ticket5.Sell();
    ticket7.Sell();

    _context.Tickets.AddRange(ticket1, ticket2, ticket3, ticket4, ticket5, ticket6, ticket7, ticket8, ticket9, ticket10);


    _context.SaveChanges();

}
