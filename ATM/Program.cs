using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;


    public cardHolder(string cardNum, int pin, String firstName, String lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;

    }

    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getbalance()
    {
        return balance;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please chose one from following options ...");
            Console.WriteLine("1.Deposit");
            Console.WriteLine("2.WithDrawal");
            Console.WriteLine("3.Balance");
            Console.WriteLine("4.Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money do you like to deposit");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getbalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money do you like to withdraw");
            double withdrawal = Double.Parse(Console.ReadLine());
            // check if user have enouf money
            if (currentUser.getbalance() > withdrawal)
            {
                Console.WriteLine("Insufficient balance :");
            }
            else
            {
                currentUser.setBalance(currentUser.getbalance() - withdrawal);
                Console.WriteLine("Thank you");
            }

        }
        void balace(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getbalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123456789", 1234, "Ajete", "Krasniqi", 150.7));
        cardHolders.Add(new cardHolder("9876543219", 4321, "Miranda ", "Osmanaj", 153.7));
        cardHolders.Add(new cardHolder("1357924680", 2468, "Edi", "Krasniqi", 155.7));
        cardHolders.Add(new cardHolder("2468013579", 1357, "Muhamed", "Elezaj", 159.7));

        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please insert your card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check on our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                { break; }
                else
                { Console.WriteLine(" Card not recognised , please try again"); }
            }
            catch
            {
                { Console.WriteLine(" Card not recognised , please try again"); }

            }
        }
        Console.WriteLine("Please insert your pin: ");

        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check on our db

                if (currentUser.getPin() == userPin)
                { break; }
                else
                { Console.WriteLine(" Incorect Pin. Pleas try again."); }
            }
            catch
            {
                { Console.WriteLine(" Incorect Pin , please try again"); }

            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName());
        int option = 0;

        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }

            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balace(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while(option != 4);
        Console.WriteLine("Thank you,have a nice day!");


    }
}

